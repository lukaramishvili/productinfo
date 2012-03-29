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

        private Zednadebi IncomingZed = null;

        public void btn_save_rs_incoming_zed_Click(object sender, EventArgs e)
        {

        }

        internal void InitIncomingZed(ProductInfo.Zednadebi arg_zed)
        {
            IncomingZed = arg_zed;
        }

        private void ChooseRSIncomingZed_Load(object sender, EventArgs e)
        {
            if (null == IncomingZed)
            {
                MessageBox.Show("ზედნადები არასწორადაა გადაცემული!");
                this.Close();
            }
            else
            {
                txt_rs_zed_ident.Text = IncomingZed.zednadebis_nomeri;
                txt_rs_buyer_ident.Text = IncomingZed.supplier_saident;
                txt_rs_buyer_name.Text = "Not Implemented";
                foreach (Remainder r in IncomingZed.OrderedItemList)
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
        }
    }
}
