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
    public partial class AddProduct_Form : Form
    {
        public AddProduct_Form()
        {
            InitializeComponent();
        }

        private void prod_add_btn_Click(object sender, EventArgs e)
        {
            ProductInfo_Main_Form main_frm = new ProductInfo_Main_Form();
            main_frm.Enabled = true;

            if ("" == barcode_txt.Text | "" == name_txt.Text)
            {
                return;
            }

            Product prod2add = new Product(barcode_txt.Text, name_txt.Text, vat_ckb.Checked);
            info prod_add_info = ProductInfo_Main_Form.conn.AddProductName(prod2add);

            MessageBox.Show(prod_add_info.details, prod_add_info.errcode.ToString());
            if (0 == prod_add_info.errcode)
            {
                //success
                this.Close();
            }
        }

        private void ProductAdd_Load(object sender, EventArgs e)
        {

        }
    }
}
