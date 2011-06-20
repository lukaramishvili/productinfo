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
    public partial class SplitRemainder_Form : Form
    {
        public SplitRemainder_Form()
        {
            InitializeComponent();
        }

        public float ParseFloat(string arg)
        {
            return Utilities.Utilities.ParseFloat(arg);
        }

        public decimal ParseDecimal(string arg)
        {
            return Utilities.Utilities.ParseDecimal(arg);
        }

        //-----------------

        DataTable all_stores;

        DataTable splittables;
        List<int> rem_ids = new List<int>();

        int CurrentRemStoreID = 0;
        int TargetRemStoreID = 0;

        private void SplitRemainder_Form_Load(object sender, EventArgs e)
        {
            all_stores = ProductInfo_Main_Form.conn.AllStores();

            cb_target_store_id.DataSource = all_stores;
            cb_target_store_id.ValueMember = "id";
            cb_target_store_id.DisplayMember = "Name";
        }

        public void LoadRemainders(string prod_barcode)
        {
            splittables = ProductInfo_Main_Form.conn.SplittableRemainders(prod_barcode);
            foreach (DataRow dr in splittables.Rows)
            {
                rem_ids.Add(Int32.Parse(dr[0].ToString()));
                cmb_select_remainder.Items.Add(dr[11].ToString() + ") " + dr[5].ToString() + "/" + dr[4].ToString() + " : \t " + dr[12].ToString());
            }
            cmb_select_remainder.SelectedIndex = 0;
            CurrentRemStoreID = Int32.Parse(splittables.Rows[0][11].ToString());

            txt_store1_count.Text = splittables.Rows[0][5].ToString();

            lbl_rem_info.Text = "პროდუქტი: \n" + ProductInfo_Main_Form.conn.GetProductByBarCode(prod_barcode).name;
        }

        private void cmb_select_remainder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_select_remainder.SelectedIndex > -1)//es araa sachiro
            {
                CurrentRemStoreID = Int32.Parse(splittables.Rows[cmb_select_remainder.SelectedIndex][11].ToString());
                lbl_store1.Text = "საწყობ " + CurrentRemStoreID.ToString() + "–ში არსებული რაოდენობა";

                txt_store1_count.Text = splittables.Rows[cmb_select_remainder.SelectedIndex][5].ToString();
                txt_store2_count.Text = "0";
            }
        }

        private void txt_store2_count_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal minus = ParseDecimal(splittables.Rows[cmb_select_remainder.SelectedIndex][5].ToString()) - ParseDecimal(txt_store2_count.Text);
                txt_store1_count.Text = (minus).ToString();
                if (minus < 0)
                {
                    txt_store1_count.Text = "0";
                    txt_store2_count.Text = splittables.Rows[cmb_select_remainder.SelectedIndex][5].ToString();
                }
                if (ParseDecimal(txt_store2_count.Text) < 0)
                {
                    txt_store1_count.Text = splittables.Rows[cmb_select_remainder.SelectedIndex][5].ToString();
                    txt_store2_count.Text = "0";
                }
            }
            catch (ArgumentException)
            {
            }
            catch (FormatException)
            {
            }

        }

        private void submit_btn_Click(object sender, EventArgs e)
        {
            if (TargetRemStoreID == CurrentRemStoreID)
            {
                MessageBox.Show("გთხოვთ აირჩიოთ საწყობი, სადაც მოხდება გადატანა!");
                return;
            }
            decimal PieceCount = ParseDecimal(txt_store2_count.Text);

            info split_info = ProductInfo_Main_Form.conn.SplitRemainder(Int32.Parse(splittables.Rows[cmb_select_remainder.SelectedIndex][0].ToString()), TargetRemStoreID, PieceCount);
            MessageBox.Show(split_info.details, split_info.errcode.ToString());
            if (0 == split_info.errcode)
            {
                this.Close();
            }
        }

        private void cb_target_store_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                TargetRemStoreID = (int)cb_target_store_id.SelectedValue;
            }
            catch (InvalidCastException)
            {
            }
        }


        //
    }
}
