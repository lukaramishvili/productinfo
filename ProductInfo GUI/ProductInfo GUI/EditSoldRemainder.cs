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
    public partial class EditSoldRemainder_Form : Form
    {
        public EditSoldRemainder_Form()
        {
            InitializeComponent();
        }

        public static float ParseFloat(string arg)
        {
            return Utilities.Utilities.ParseFloat(arg);
        }

        public static decimal ParseDecimal(string arg)
        {
            return Utilities.Utilities.ParseDecimal(arg);
        }

        // ---

        enum SoldRemainderEditType { Remainder, SoldRemainder };

        SoldRemainderEditType EditType = SoldRemainderEditType.SoldRemainder;
        bool DetailsLoaded = false;
        int EditingSoldRemID = 0;
        decimal PieceCount = 0.0m;
        decimal PiecePrice = 0.0m;
        decimal PackCapacity = 0.0m;
        string BuyerName = "none";
        DateTime OrderTime = DateTime.Now;
        bool UsingCheck = false;
        string ZedIdentCode = "none";

        public void LoadRemDetails(decimal piece_cnt_arg, decimal piece_price_arg, decimal pack_cap_arg, string supplier_name_arg, DateTime zed_date_arg, string zed_ident_arg)
        {
            PieceCount = piece_cnt_arg;
            PiecePrice = piece_price_arg;
            PackCapacity = pack_cap_arg;
            BuyerName = supplier_name_arg;
            OrderTime = zed_date_arg;
            UsingCheck = true;
            ZedIdentCode = zed_ident_arg;

            attributes_lbl.Text = "შემომტანი: " + BuyerName + "\nშემოტანის დრო: " + OrderTime.ToString() + "\nზედნადების ნომერი: " + ZedIdentCode + "\nტევადობა: " + pack_cap_arg;
            piece_count_txt.Text = PieceCount.ToString();
            piece_price_txt.Text = PiecePrice.ToString();
            capacity_txt.Text = PackCapacity.ToString();

            DetailsLoaded = true;
        }

        public void LoadSoldRemDetails(decimal piece_cnt_arg, decimal piece_price_arg, decimal pack_cap_arg, string buyer_name_arg, DateTime order_time_arg, bool using_check_arg, string zed_ident_arg)
        {
            PieceCount = piece_cnt_arg;
            PiecePrice = piece_price_arg;
            PackCapacity = pack_cap_arg;
            BuyerName = buyer_name_arg;
            OrderTime = order_time_arg;
            UsingCheck = using_check_arg;
            ZedIdentCode = zed_ident_arg;

            attributes_lbl.Text = "გაყიდვის დრო: " + OrderTime.ToString() + "\nზედნადების ნომერი: " + (("" != ZedIdentCode) ? ZedIdentCode : "გაყიდულია უზედნადებოდ") + "\n" + ((UsingCheck) ? "გაყიდულია ჩეკით" : "გაყიდულია უჩეკოდ") + "\nმყიდველი: " + BuyerName;
            piece_count_txt.Text = PieceCount.ToString();
            piece_price_txt.Text = PiecePrice.ToString();


            DetailsLoaded = true;
        }

        public void PopulateRemainderFields(int soldrem_id)
        {
            EditType = SoldRemainderEditType.Remainder;
            EditingSoldRemID = soldrem_id;

            this.Text = "ნაშთის შეცვლა";
            gpbox_sold_count.Text = "საწყისი რაოდენობა";

            DataTable RemDetails = ProductInfo_Main_Form.conn.RemainderByID(soldrem_id);
            if (RemDetails.Rows.Count > 0)
            {
                LoadRemDetails(ParseDecimal(RemDetails.Rows[0][0].ToString()), ParseDecimal(RemDetails.Rows[0][1].ToString()), ParseDecimal(RemDetails.Rows[0][2].ToString()), RemDetails.Rows[0][3].ToString(), DateTime.Parse(RemDetails.Rows[0][4].ToString()), RemDetails.Rows[0][5].ToString());
            }
            else
            {
                MessageBox.Show("ინფორმაცია არ არსებობს!", "404");
                this.Close();
            }
        }

        public void PopulateSoldRemainderFields(int soldrem_id)
        {
            EditType = SoldRemainderEditType.SoldRemainder;
            EditingSoldRemID = soldrem_id;

            this.Text = "გაყიდული პროდუქტის შეცვლა";
            gpbox_sold_count.Text = "გაყიდული რაოდენობა";

            capacity_txt.Enabled = false;

            DataTable SoldRemDetails = ProductInfo_Main_Form.conn.SoldRemainderByID(soldrem_id);
            if (SoldRemDetails.Rows.Count > 0)
            {
                LoadSoldRemDetails(ParseDecimal(SoldRemDetails.Rows[0][0].ToString()), ParseDecimal(SoldRemDetails.Rows[0][1].ToString()), ParseDecimal(SoldRemDetails.Rows[0][2].ToString()), SoldRemDetails.Rows[0][3].ToString(), DateTime.Parse(SoldRemDetails.Rows[0][4].ToString()), Convert.ToBoolean(Int32.Parse(SoldRemDetails.Rows[0][5].ToString())), SoldRemDetails.Rows[0][6].ToString());
            }
            else
            {
                MessageBox.Show("ინფორმაცია არ არსებობს!", "404");
                this.Close();
            }
        }

        private void btn_update_soldrem_Click(object sender, EventArgs e)
        {
            switch (EditType)
            {
                case SoldRemainderEditType.Remainder:
                    info updrem_ret = ProductInfo_Main_Form.conn.UpdateRemainder(EditingSoldRemID, ParseDecimal(piece_count_txt.Text), ParseDecimal(piece_price_txt.Text), ParseDecimal(capacity_txt.Text));
                    MessageBox.Show(updrem_ret.details, updrem_ret.errcode.ToString());
                    if (0 == updrem_ret.errcode)
                    {
                        this.Close();
                    }
                    break;
                case SoldRemainderEditType.SoldRemainder:
                    info updsoldrem_ret = ProductInfo_Main_Form.conn.UpdateSoldRemainder(EditingSoldRemID, ParseDecimal(piece_count_txt.Text), ParseDecimal(piece_price_txt.Text));
                    MessageBox.Show(updsoldrem_ret.details, updsoldrem_ret.errcode.ToString());
                    if (0 == updsoldrem_ret.errcode)
                    {
                        this.Close();
                    }
                    break;
            }
        }

        private void EditSoldRemainder_Form_Load(object sender, EventArgs e)
        {

        }


    }
}
