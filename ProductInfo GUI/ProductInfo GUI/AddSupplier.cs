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
    public partial class AddSupplier_Form : Form
    {
        public AddSupplier_Form()
        {
            InitializeComponent();
        }

        public enum ActionType { Add, Edit };

        private ActionType _job = ActionType.Add;

        public ActionType job
        {
            get
            {
                return _job;
            }
            set
            {
                _job = value;
                if (ActionType.Add == value)
                {
                    supplier_ident_code_txt.Enabled = true;
                }
                else if (ActionType.Edit == value)
                {
                    supplier_ident_code_txt.Enabled = false;
                }

            }
        }

        private void submit_btn_Click(object sender, EventArgs e)
        {
            if ("" != supplier_name_txt.Text && "" != supplier_ident_code_txt.Text && "" != supplier_address_txt.Text)
            {
                if (ActionType.Add == this.job)
                {
                    Supplier newSupplier = new Supplier(supplier_ident_code_txt.Text, supplier_name_txt.Text, supplier_address_txt.Text);
                    info retAddSupplier = ProductInfo_Main_Form.conn.AddSupplier(newSupplier);
                    MessageBox.Show(retAddSupplier.details, retAddSupplier.errcode.ToString());
                    if (0 == retAddSupplier.errcode)
                    {
                        this.Close();
                    }
                }
                else if (ActionType.Edit == this.job)
                {
                    Supplier newSupplier = new Supplier(supplier_ident_code_txt.Text, supplier_name_txt.Text, supplier_address_txt.Text);
                    info retEditSupplier = ProductInfo_Main_Form.conn.EditSupplier(newSupplier);
                    MessageBox.Show(retEditSupplier.details, retEditSupplier.errcode.ToString());
                    if (0 == retEditSupplier.errcode)
                    {
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("გთხოვთ შეავსოთ ყველა ველი!");
            }
        }

        private void AddSupplier_Form_Load(object sender, EventArgs e)
        {

        }


    }
}
