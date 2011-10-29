using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utilities;

namespace ProductInfo_UI
{
    public partial class EditCashierList_Form : Form
    {
        public EditCashierList_Form()
        {
            InitializeComponent();
        }

        public static int ParseInt(string arg)
        {
            return Utilities.Utilities.ParseInt(arg);
        }

        public static bool ParseBool(string arg)
        {
            return Utilities.Utilities.ParseBool(arg);
        }

        DataTable AllCashiers;

        private void EditCashierList_Form_Load(object sender, EventArgs e)
        {
            AllCashiers = ProductInfo_Main_Form.conn.AllCashiers();
            edit_cashiers_grid.DataSource = AllCashiers;
            edit_cashiers_grid.Columns["id"].ReadOnly = true;
            edit_cashiers_grid.Columns["sName"].HeaderText = "სახელი";
            edit_cashiers_grid.Columns["sPasswd"].HeaderText = "პაროლი";
            edit_cashiers_grid.Columns["eActive"].HeaderText = "სტატუსი";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgr in edit_cashiers_grid.Rows)
            {
                if (dgr.IsNewRow)
                {
                    continue;
                }
                info updcashier_info = ProductInfo_Main_Form.conn.UpdateCashier(ParseInt(dgr.Cells["id"].Value.ToString()), dgr.Cells["sName"].Value.ToString(), dgr.Cells["sPasswd"].Value.ToString(), (bool)ParseBool(dgr.Cells["eActive"].Value.ToString()));
                MessageBox.Show(updcashier_info.details, updcashier_info.errcode.ToString());
            }
            AllCashiers = ProductInfo_Main_Form.conn.AllCashiers();
            edit_cashiers_grid.DataSource = AllCashiers;
        }
    }
}
