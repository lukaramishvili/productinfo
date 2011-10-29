using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProductInfo;

namespace ShopInfo_GUI
{
    public partial class frmShopInfoLoginForm : Form
    {
        public frmShopInfoLoginForm()
        {
            InitializeComponent();
        }

        DataTable tblAllActiveCashiers;

        private void frmShopInfoLoginForm_Load(object sender, EventArgs e)
        {
            tblAllActiveCashiers = ShopInfo_Main_Form.DataConn.AllActiveCashiers();
            cmb_cashier_id.DataSource = tblAllActiveCashiers;
            cmb_cashier_id.ValueMember = "id";
            cmb_cashier_id.DisplayMember = "sName";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            foreach (DataRow dr in tblAllActiveCashiers.Rows)
            {
                if (dr["id"].ToString() == cmb_cashier_id.SelectedValue.ToString())
                {
                    if (true == (bool)dr["eActive"])
                    {
                        if (dr["sPasswd"].ToString() == txtPasswd.Text)
                        {
                            ShopInfo_Main_Form.fAuthenticated = true;
                            ShopInfo_Main_Form.ActiveCashierID = (int)dr["id"];
                            ShopInfo_Main_Form.sActiveCashierName = dr["sName"].ToString();
                            this.Close();
                        }
                    }
                }
            }
            //
            if (false == ShopInfo_Main_Form.fAuthenticated)
            {
                MessageBox.Show("პაროლი არასწორია, სცადეთ თავიდან");
            }
            //
        }
    }
}
