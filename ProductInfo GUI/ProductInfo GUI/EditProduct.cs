using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProductInfo;
using Utilities;

namespace ProductInfo_UI
{
    public partial class EditProduct_Form : Form
    {
        public EditProduct_Form()
        {
            InitializeComponent();
        }

        private void prod_edit_btn_Click(object sender, EventArgs e)
        {
            info prod_upd_info = ProductInfo_Main_Form.conn.UpdateProduct(barcode_txt.Text, name_txt.Text, vat_ckb.Checked?1:0);
            if (0 == prod_upd_info.errcode | 501 == prod_upd_info.errcode)
            {
                MessageBox.Show("პროდუქტი ჩასწორებულია");
                this.Close();
            }
            else
            {
                MessageBox.Show("მოხდა შეცდომა "+prod_upd_info.errcode.ToString());
            }
        }


    }
}
