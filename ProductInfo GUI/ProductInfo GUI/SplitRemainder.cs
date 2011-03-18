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

        DataTable splittables;
        List<int> rem_ids = new List<int>();

        int CurrentRemStoreID = 0;

        private void SplitRemainder_Form_Load(object sender, EventArgs e)
        {

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
            switch (Int32.Parse(splittables.Rows[0][11].ToString()))
            {
                case 1:
                    txt_store1_count.Enabled = false;
                    txt_store2_count.Enabled = true;
                    txt_store1_count.Text = splittables.Rows[0][5].ToString();
                    break;
                case 2:
                    txt_store2_count.Enabled = false;
                    txt_store1_count.Enabled = true;
                    txt_store2_count.Text = splittables.Rows[0][5].ToString();
                    break;
            }
            lbl_rem_info.Text = "პროდუქტი: \n" + ProductInfo_Main_Form.conn.GetProductByBarCode(prod_barcode).name;
        }

        private void cmb_select_remainder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_select_remainder.SelectedIndex > -1)//es araa sachiro
            {
                switch (Int32.Parse(splittables.Rows[cmb_select_remainder.SelectedIndex][11].ToString()))
                {
                    case 1:
                        txt_store1_count.Enabled = false;
                        txt_store2_count.Enabled = true;
                        CurrentRemStoreID = 1;
                        txt_store1_count.Text = splittables.Rows[cmb_select_remainder.SelectedIndex][5].ToString();
                        txt_store2_count.Text = "0";
                        break;
                    case 2:
                        txt_store2_count.Enabled = false;
                        txt_store1_count.Enabled = true;
                        CurrentRemStoreID = 2;
                        txt_store2_count.Text = splittables.Rows[cmb_select_remainder.SelectedIndex][5].ToString();
                        txt_store1_count.Text = "0";
                        break;
                }
            }
        }

        private void txt_store1_count_TextChanged(object sender, EventArgs e)
        {
            if (2 == CurrentRemStoreID)
            {
                try
                {
                    decimal minus = ParseDecimal(splittables.Rows[cmb_select_remainder.SelectedIndex][5].ToString()) - ParseDecimal(txt_store1_count.Text);
                    txt_store2_count.Text = (minus).ToString();
                    if (minus < 0)
                    {
                        txt_store2_count.Text = "0";
                        txt_store1_count.Text = splittables.Rows[cmb_select_remainder.SelectedIndex][5].ToString();
                    }
                    if (ParseDecimal(txt_store1_count.Text) < 0)
                    {
                        txt_store2_count.Text = splittables.Rows[cmb_select_remainder.SelectedIndex][5].ToString();
                        txt_store1_count.Text = "0";
                    }
                }
                catch (ArgumentException)
                {
                }
                catch (FormatException)
                {
                }
            }
        }

        private void txt_store2_count_TextChanged(object sender, EventArgs e)
        {
            if (1 == CurrentRemStoreID)
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
        }

        private void submit_btn_Click(object sender, EventArgs e)
        {
            int target_store_id = 0;
            if (1 == CurrentRemStoreID)
            {
                target_store_id = 2;
            }
            if (2 == CurrentRemStoreID)
            {
                target_store_id = 1;
            }
            decimal PieceCount = 0;
            if (1 == CurrentRemStoreID)
            {
                PieceCount = ParseDecimal(txt_store2_count.Text);
            }
            else if (2 == CurrentRemStoreID)
            {
                PieceCount = ParseDecimal(txt_store1_count.Text);
            }
            info split_info = ProductInfo_Main_Form.conn.SplitRemainder(Int32.Parse(splittables.Rows[cmb_select_remainder.SelectedIndex][0].ToString()), target_store_id, PieceCount);
            MessageBox.Show(split_info.details, split_info.errcode.ToString());
            if (0 == split_info.errcode)
            {
                this.Close();
            }
        }
    }
}
