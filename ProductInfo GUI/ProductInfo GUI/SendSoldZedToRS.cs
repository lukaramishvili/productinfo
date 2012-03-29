using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
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
                = ProductInfo_Main_Form.rsge.PrepareSoldZednadebiEasy(
                    zedToSend, 0, zed_buyer, txt_start_address.Text,
                    DateTime.Now, ProductInfo_Main_Form.rsge.GetSellerUnId(),
                    ProductInfo_Main_Form.rsge.GetSUserId());
            XmlElement resultSendWaybill 
                = ProductInfo_Main_Form.rsge.SaveWaybill(xmlSellingZed);
            //TODO: receive results in xml, parse and display results
        }
    }
}
