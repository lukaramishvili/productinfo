using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProductInfo;

namespace ProductInfo_UI
{

    public partial class ChooseRSIncomingZed : Form
    {
        public ChooseRSIncomingZed()
        {
            InitializeComponent();
        }

        public event WaybillChosenHandler evtWaybillChosen;
        public WBChosenEventArgs eWbChosen = null;
        public delegate void WaybillChosenHandler
            (ChooseRSIncomingZed frmChooseRSIncomingZed, WBChosenEventArgs eWbSuccess);

        public void btn_save_rs_incoming_zed_Click(object sender, EventArgs e)
        {
            MessageBox.Show("TODO: zednadebis dagenerireba da gadacema AddRemainder.cs-stvis");
            //TODO: generate zednadebi from textboxes/table_incoming_zeds,
            //then assign that zednadebi to WBChosenZed,
            //and then raise event
            eWbChosen.WBChosenZed = null;
            //raise waybill selected event
            evtWaybillChosen(this, eWbChosen);
        }

        private void ChooseRSIncomingZed_Load(object sender, EventArgs e)
        {
            FindIncomingWaybill frmFindIncomingWB = new FindIncomingWaybill();
            frmFindIncomingWB.evtWaybillIDSelected += 
                new FindIncomingWaybill.WaybillIDSelectedHandler
                (delegate(FindIncomingWaybill frmFindIncomingWaybill,
                WBIDSelectedEventArgs eWBIDSelected)
            {
                Zednadebi SelectedZed 
                    = ProductInfo_Main_Form.rsge.LoadWaybill(eWBIDSelected.Waybill_ID);

                if (null == SelectedZed)
                {
                    MessageBox.Show("ზედნადები არასწორადაა გადაცემული!");
                    this.Close();
                }
                else
                {
                    txt_rs_zed_ident.Text = SelectedZed.zednadebis_nomeri;
                    txt_rs_buyer_ident.Text = SelectedZed.supplier_saident;
                    txt_rs_buyer_name.Text = "Not Implemented";
                    foreach (Remainder r in SelectedZed.OrderedItemList)
                    {
                        table_incoming_zeds.Rows.Add(new object[]{
                            r.product_barcode,
                            r.product_barcode,
                            r.initial_pieces,
                            r.sell_price
                        });
                    }
                    //
                }
            });//end FindIncomingWaybill.evtWaybillIDSelected

            //placeholder for zednadebi downloaded from rs.ge
            //Zednadebi IncomingZed = ProductInfo_Main_Form.conn.GetZednadebi
            //    ("001", DataProvider.OperationType.Buy.ToString(), "123123123");
        }
    }

    public class WBChosenEventArgs : EventArgs
    {
        private Zednadebi _WBChosenZed;
        public Zednadebi WBChosenZed
        {
            set
            {
                this._WBChosenZed = value;
            }
            get
            {
                return this._WBChosenZed;
            }
        }
    }
}
