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
    public partial class AddBuyer_Form : Form
    {
        public AddBuyer_Form()
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
                    buyer_ident_code_txt.Enabled = true;
                }
                else if (ActionType.Edit == value)
                {
                    buyer_ident_code_txt.Enabled = false;
                }

            }
        }

        private void AddBuyer_Load(object sender, EventArgs e)
        {

        }

        private void submit_btn_Click(object sender, EventArgs e)
        {
            if ("" != buyer_name_txt.Text && "" != buyer_ident_code_txt.Text && "" != buyer_address_txt.Text)
            {
                if (ActionType.Add == this.job)
                {
                    Buyer newBuyer = new Buyer(buyer_ident_code_txt.Text, buyer_name_txt.Text, buyer_address_txt.Text);
                    info retAddBuyer = ProductInfo_Main_Form.conn.AddBuyer(newBuyer);
                    MessageBox.Show(retAddBuyer.details, retAddBuyer.errcode.ToString());
                    if (0 == retAddBuyer.errcode)
                    {
                        this.Close();
                    }
                }
                else if (ActionType.Edit == this.job)
                {
                    Buyer newBuyer = new Buyer(buyer_ident_code_txt.Text, buyer_name_txt.Text, buyer_address_txt.Text);
                    info retEditBuyer = ProductInfo_Main_Form.conn.EditBuyer(newBuyer);
                    MessageBox.Show(retEditBuyer.details, retEditBuyer.errcode.ToString());
                    if (0 == retEditBuyer.errcode)
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
    }
}
