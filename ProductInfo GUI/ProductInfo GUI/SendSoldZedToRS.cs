using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Collections;
using ProductInfo;

namespace ProductInfo_UI
{
    public partial class SendSoldZedToRS : Form
    {
        public SendSoldZedToRS()
        {
            InitializeComponent();
        }

        Zednadebi zedToSend = null;

        private void SendSoldZedToRS_Load(object sender, EventArgs e)
        {
            cb_rs_trans_type_id.Items.Add(new DictionaryEntry(1, "საავტომობილო"));
            cb_rs_trans_type_id.Items.Add(new DictionaryEntry(2, "სარკინიგზო"));
            cb_rs_trans_type_id.Items.Add(new DictionaryEntry(3, "საავიაციო"));
            cb_rs_trans_type_id.Items.Add(new DictionaryEntry(4, "სხვა"));
            cb_rs_trans_type_id.Items.Add(new DictionaryEntry(5, "მისაბმელი"));
            cb_rs_trans_type_id.ValueMember = "Key";
            cb_rs_trans_type_id.DisplayMember = "Value";
            cb_rs_trans_type_id.DataSource = cb_rs_trans_type_id.Items;
            //
            cb_rs_wb_type.Items.Add(new DictionaryEntry(DataProvider.OperationType.ShidaGadazidva, "შიდა გადაზიდვა"));
            cb_rs_wb_type.Items.Add(new DictionaryEntry(DataProvider.OperationType.SellTransporting, "მიწოდება ტრანსპორტირებით"));
            cb_rs_wb_type.Items.Add(new DictionaryEntry(DataProvider.OperationType.Sell, "მიწოდება ტრანსპორტირების გარეშე"));
            cb_rs_wb_type.Items.Add(new DictionaryEntry(DataProvider.OperationType.Distribucia, "დისტრიბუცია"));
            cb_rs_wb_type.Items.Add(new DictionaryEntry(DataProvider.OperationType.UkanDabruneba, "საქონლის უკან დაბრუნება"));
            cb_rs_wb_type.ValueMember = "Key";
            cb_rs_wb_type.DisplayMember = "Value";
            cb_rs_wb_type.DataSource = cb_rs_wb_type.Items;
            //
            cb_rs_wb_type.SelectedValue = DataProvider.OperationType.Sell;
            //
            if (null == zedToSend)
            {
                MessageBox.Show("ზედნადები არასწორადაა გადაცემული!");
                this.Close();
            }
            else if (0 == zedToSend.OrderedItemList.Count)
            {
                MessageBox.Show("ცარიელი ზედნადების გაგზავნა არაა დაშვებული!");
                this.Close();
            }
            else
            {
                //ზედნადები სწორად გადაეცა.
                //აქ უკვე დამატებითი ველები უნდა შეავსოს მომხმარებელმა რაც PrepareZednadebiEasy-ს სჭირდება
                //
            }
        }

        internal void InitSendZed(Zednadebi arg_zed_to_send)
        {
            zedToSend = arg_zed_to_send;
        }

        private void btnSendZedToRS_Click(object sender, EventArgs e)
        {
            Buyer zed_buyer 
                = ProductInfo_Main_Form.conn.BuyerByIdentCode(zedToSend.buyer_saident);
            
            //delivery_date is not needed when first saving zednadebi
            XmlElement xmlSellingZed
                = ProductInfo_Main_Form.rsge.PrepareZednadebi(
                    zedToSend, 0, (DataProvider.OperationType)cb_rs_wb_type.SelectedValue,
                    zed_buyer, (ck_buyer_is_georgian.Checked ? 1 : 0),
                    txt_start_address.Text, txt_end_address.Text,
                    txt_driver_ident.Text, (ck_driver_is_georgian.Checked ? 1 : 0),
                    txt_driver_name.Text, Utilities.Utilities.ParseDecimal(txt_transp_cost.Text),
                    "", "", DateTime.Now, 1, ProductInfo_Main_Form.rsge.GetSellerUnId(), 0,
                    txt_car_number.Text, ProductInfo_Main_Form.rsge.GetSUserId(), dt_begin_date.Value,
                    (ck_trans_cost_payer.Checked ? 1 : 2), (int)cb_rs_trans_type_id.SelectedValue, 
                    txt_transp_type_name.Text, "");
            XmlElement resultSendWaybill 
                = ProductInfo_Main_Form.rsge.SaveWaybill(xmlSellingZed);
            int errCode = Utilities.Utilities.ParseInt(resultSendWaybill.SelectSingleNode("/STATUS").InnerText);
            switch (errCode)
            {
                case 0:
                    string sWaybillNumber 
                        = resultSendWaybill.SelectSingleNode("/WAYBILL_NUMBER").InnerText;
                    MessageBox.Show("ზედნადების rs.ge-ზე დამახსოვრება ნომრით \""
                        + sWaybillNumber + "\" წარმატებით დასრულდა!");
                    break;
                default:
                    MessageBox.Show("შეცდომა " + errCode.ToString() + ", "
                        + RSGeWebService.RSGeConnection.GetWBError(errCode) + "!");
                    break;
            }
            //
            //MessageBox.Show(resultSendWaybill.OuterXml);
        }

        private void txt_end_address_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
