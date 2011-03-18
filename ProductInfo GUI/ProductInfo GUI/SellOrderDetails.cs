using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProductInfo;
using Data_Visualization;
using Utilities;
using System.IO;

namespace ProductInfo_UI
{
    public partial class SellOrderDetails_Form : Form
    {
        public SellOrderDetails_Form()
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



        private void close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public enum DetailedListViewMode { BoughtZed, SoldZed, SellOrder }
        DetailedListViewMode ViewMode = DetailedListViewMode.SellOrder;

        DataTable so_details;

        string EditingZedIdent = "";
        string EditingZedOperation = "";
        string EditingZedClientIdent = "";
        DateTime EditingZedTarigi = DateTime.Now;
        string EditingZedAfSeria = "";
        string EditingZedAfNomeri = "";

        int SellOrderID = -1;

        int SOd_mogeba_col_index = -1;

        private void CleanUpSensitiveSellOrderInfo()
        {
            if (true != ProductInfo_Main_Form.conn.AllowSensitiveInformation)
            {
                if (sold_rem_list.Columns.Contains(SOd_mogeba_col))
                {
                    SOd_mogeba_col_index = SOd_mogeba_col.Index;
                    sold_rem_list.Columns.Remove(SOd_mogeba_col);
                }

                /**/
                DataTable empty_so_details_dt = new DataTable();
                foreach (DataColumn ch in so_details.Columns)
                {
                    if (ch.Ordinal != SOd_mogeba_col_index)
                    {
                        empty_so_details_dt.Columns.Add(ch.ColumnName);
                    }
                }
                foreach (DataRow dr in so_details.Rows)
                {
                    for (int i = 0; i < dr.ItemArray.Length; i++)
                    {
                        DataRow dr_clone = empty_so_details_dt.NewRow();

                        object[] CloneItems = new object[dr_clone.ItemArray.Length];
                        int k = 0;
                        for (int j = 0; j < dr.ItemArray.Length; j++)
                        {
                            if (j == SOd_mogeba_col_index)
                            {
                                continue;
                            }
                            CloneItems[k] = dr.ItemArray[j];
                            k++;
                        }
                        dr_clone.ItemArray = CloneItems;

                        empty_so_details_dt.Rows.Add(dr_clone);
                        break;
                    }
                }
                so_details = empty_so_details_dt;
                /**/
            }
        }


        public void ShowSellOrderDetails(int SellOrderID_arg, string zed_ident_arg, string using_check_arg)
        {
            this.ViewMode = DetailedListViewMode.SellOrder;
            this.Text = "გაყიდვის დეტალები";
            this.SellOrderID = SellOrderID_arg;

            datetime_zed_tarigi.Visible = false;
            txt_af_seria.Visible = false;
            txt_af_nomeri.Visible = false;
            btn_zed_update.Visible = false;
            lbl_edit_af_seria.Visible = false;
            lbl_edit_af_nomeri.Visible = false;
            lbl_editzed_af_date.Visible = false;
            datepicker_af_date.Visible = false;
            btn_add_soldrems.Location = new Point(btn_add_soldrems.Location.X, sold_rem_list.Location.Y - 16 - btn_add_soldrems.Height);

            so_details = ProductInfo_Main_Form.conn.SellOrderDetails(SellOrderID_arg);
            ProductInfo_Main_Form.DataTableToListView(sold_rem_list, so_details, true);
            attributes_lbl.Text = /*"გაყიდვის დრო: " + SellOrderDate.ToString() +*/ "\nზედნადების ნომერი: " + (("" != zed_ident_arg) ? zed_ident_arg : "გაყიდულია უზედნადებოდ") + "\n" + (("1" == using_check_arg | "ჩეკით" == using_check_arg) ? "გაყიდულია ჩეკით" : "გაყიდულია უჩეკოდ") + "\n\n\n";
            SOd_print_btn.Enabled = true;
            SOd_print_gasavali_btn.Enabled = true;

            CleanUpSensitiveSellOrderInfo();
        }

        public void ShowSoldZedDetails(string buyer_ident_arg, string zed_ident_arg, DateTime dro_arg)
        {
            this.ViewMode = DetailedListViewMode.SoldZed;
            this.EditingZedIdent = zed_ident_arg;
            this.EditingZedOperation = "Sell";
            this.EditingZedClientIdent = buyer_ident_arg;
            LoadEditingZedValues();
            this.SellOrderID = ProductInfo_Main_Form.conn.SellOrderIDByZedCode(buyer_ident_arg, zed_ident_arg);

            string soldzed_buyer_name = (from Buyer b in ProductInfo_Main_Form.conn.AllBuyers() where b.saidentifikacio_kodi == buyer_ident_arg select b.saxeli).ToArray()[0];

            this.Text = soldzed_buyer_name + "-ზე გასული ზედნადები N. " + zed_ident_arg;

            so_details = ProductInfo_Main_Form.conn.SoldZedDetails(buyer_ident_arg, zed_ident_arg);
            ProductInfo_Main_Form.DataTableToListView(sold_rem_list, so_details, true);
            attributes_lbl.Text = "გაყიდვის დრო: " + dro_arg.ToString() + "\n" +
                "მყიდველი: " + soldzed_buyer_name + "\nზედნადების ნომერი: " + zed_ident_arg + "\n\n\n\n";
            SOd_print_btn.Enabled = true;
            SOd_print_gasavali_btn.Enabled = true;

            CleanUpSensitiveSellOrderInfo();
        }

        private void LoadEditingZedValues()
        {
            DataTable dt_EditingZedInfo = ProductInfo_Main_Form.conn.SingleZedDetails(this.EditingZedIdent, EditingZedOperation, EditingZedClientIdent);
            txt_af_seria.Text = dt_EditingZedInfo.Rows[0][5].ToString();
            txt_af_nomeri.Text = dt_EditingZedInfo.Rows[0][6].ToString();
            datetime_zed_tarigi.Value = DateTime.Parse(dt_EditingZedInfo.Rows[0][2].ToString());

            if ("" != dt_EditingZedInfo.Rows[0][11].ToString())
            {
                datepicker_af_date.Value = DateTime.Parse(dt_EditingZedInfo.Rows[0][11].ToString());
            }
        }

        public void ShowBoughtZedDetails(string supplier_ident_arg, string zed_ident_arg, DateTime dro_arg)
        {
            this.ViewMode = DetailedListViewMode.BoughtZed;
            this.EditingZedIdent = zed_ident_arg;
            this.EditingZedOperation = "Buy";
            this.EditingZedClientIdent = supplier_ident_arg;
            LoadEditingZedValues();

            string boughtzed_supplier_name = (from Supplier s in ProductInfo_Main_Form.conn.AllSuppliers() where s.saidentifikacio_kodi == supplier_ident_arg select s.saxeli).ToArray()[0];

            this.Text = boughtzed_supplier_name + "-სგან მიღებული ზედნადები N. " + zed_ident_arg;

            so_details = ProductInfo_Main_Form.conn.BoughtZedDetails(supplier_ident_arg, zed_ident_arg);
            ProductInfo_Main_Form.DataTableToListView(sold_rem_list, so_details, true);
            attributes_lbl.Text = "მიღების დრო: " + dro_arg.ToString() + "\n" +
                "მომწოდებელი: " + boughtzed_supplier_name + "\nზედნადების ნომერი: " + zed_ident_arg + "\n\n\n\n";
            SOd_print_btn.Enabled = true;
            SOd_print_gasavali_btn.Enabled = false;
            SOd_print_gasavali_btn.Visible = false;

            CleanUpSensitiveSellOrderInfo();
        }

        private void SellOrderDetails_Form_Load(object sender, EventArgs e)
        {

        }

        private void SOd_print_btn_Click(object sender, EventArgs e)
        {
            DataTable so_details_print = so_details.Copy();//ProductInfo_Main_Form.ListViewToDataTable(sold_rem_list);
            /*if (true != ProductInfo_Main_Form.conn.AllowSensitiveInformation)
            {
                so_details_print.Columns.Remove("მოგება");
            }*/

            PrintPreview_Form prevw_frm = new PrintPreview_Form();
            prevw_frm.Show();
            prevw_frm.DrawData(so_details_print, false);
        }

        private void cmi_SellOrder_item_edit_Click(object sender, EventArgs e)
        {
            if (0 < sold_rem_list.SelectedItems.Count && "ჯამი" != sold_rem_list.SelectedItems[0].Text)
            {
                EditSoldRemainder_Form editsoldrem_frm = new EditSoldRemainder_Form();
                switch (this.ViewMode)
                {
                    case DetailedListViewMode.SellOrder:
                        editsoldrem_frm.Show();
                        editsoldrem_frm.PopulateSoldRemainderFields(Int32.Parse(sold_rem_list.SelectedItems[0].SubItems[SOd_id_col.Index].Text));
                        break;
                    case DetailedListViewMode.BoughtZed:
                        editsoldrem_frm.Show();
                        editsoldrem_frm.PopulateRemainderFields(Int32.Parse(sold_rem_list.SelectedItems[0].SubItems[SOd_id_col.Index].Text));
                        break;
                    case DetailedListViewMode.SoldZed:
                        editsoldrem_frm.Show();
                        editsoldrem_frm.PopulateSoldRemainderFields(Int32.Parse(sold_rem_list.SelectedItems[0].SubItems[SOd_id_col.Index].Text));
                        break;
                }
            }
        }

        private void cmi_SellOrder_item_delete_Click(object sender, EventArgs e)
        {
            if (0 < sold_rem_list.SelectedItems.Count && "ჯამი" != sold_rem_list.SelectedItems[0].Text)
            {
                if (DialogResult.Yes == MessageBox.Show("დარწმუნებული ხართ, რომ გსურთ სიიდან \"" + sold_rem_list.SelectedItems[0].SubItems[SOd_prodname_col.Index].Text + "\"-ს ამოშლა?", "დადასტურება!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    info remremainder_info = info.niy();
                    //delete selected remainder/SoldRemainder
                    switch (this.ViewMode)
                    {
                        case DetailedListViewMode.SellOrder:
                            remremainder_info = ProductInfo_Main_Form.conn.RemoveSoldRemainder(Int32.Parse(sold_rem_list.SelectedItems[0].SubItems[SOd_id_col.Index].Text));
                            break;
                        case DetailedListViewMode.BoughtZed:
                            remremainder_info = ProductInfo_Main_Form.conn.RemoveRemainder(Int32.Parse(sold_rem_list.SelectedItems[0].SubItems[SOd_id_col.Index].Text));
                            break;
                        case DetailedListViewMode.SoldZed:
                            remremainder_info = ProductInfo_Main_Form.conn.RemoveSoldRemainder(Int32.Parse(sold_rem_list.SelectedItems[0].SubItems[SOd_id_col.Index].Text));
                            break;
                    }
                    MessageBox.Show(remremainder_info.details, remremainder_info.errcode.ToString());
                }
            }
        }

        private void btn_zed_update_Click(object sender, EventArgs e)
        {
            info updzed_info = ProductInfo_Main_Form.conn.UpdateZednadebi(EditingZedIdent, EditingZedOperation, EditingZedClientIdent, datetime_zed_tarigi.Value, txt_af_seria.Text, txt_af_nomeri.Text, datepicker_af_date.Value);
            MessageBox.Show(updzed_info.details, updzed_info.errcode.ToString());
        }

        private void btn_add_soldrems_Click(object sender, EventArgs e)
        {
            AddRemainderItem_Form addrem_frm = new AddRemainderItem_Form();
            addrem_frm.FormClosed += delegate(object senderAddRemFormClosed, FormClosedEventArgs eAddRemFormClosed)
            {
                //refresh unda iyos amis magivrad
                MessageBox.Show("გთხოვთ თავიდან გახსნათ დეტალური სიის ფანჯარა, რათა იხილოთ შეტანილი ცვლილებები!");
            };

            switch (this.ViewMode)
            {
                case DetailedListViewMode.SellOrder:
                    addrem_frm.LoadSellOrderInterface(EditingZedClientIdent, EditingZedIdent, SellOrderID);
                    addrem_frm.ShowDialog();
                    break;
                case DetailedListViewMode.BoughtZed:
                    addrem_frm.LoadBoughtZedInterface(EditingZedClientIdent, EditingZedIdent);
                    addrem_frm.ShowDialog();
                    break;
                case DetailedListViewMode.SoldZed:
                    addrem_frm.LoadSoldZedInterface(EditingZedClientIdent, EditingZedIdent, SellOrderID);
                    addrem_frm.ShowDialog();
                    break;
            }
            //

        }

        private void btn_exportCSV_SOd_Click(object sender, EventArgs e)
        {
            string csv_output = ProductInfo_Main_Form.ListViewToCSV(sold_rem_list);

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";

            try
            {
                switch (this.ViewMode)
                {
                    case DetailedListViewMode.SellOrder:
                        sfd.FileName = "გაყიდვა #" + SellOrderID + " - " + DateTime.Now.Day + " " + BitmapGenerator.GeorgianMonths[DateTime.Now.Month] + " " + DateTime.Now.Year + " " + DateTime.Now.Hour + "-" + DateTime.Now.Minute;
                        break;
                    case DetailedListViewMode.BoughtZed:
                        sfd.FileName = "" + EditingZedClientIdent + "–სგან შემოსული ზედნადები #" + EditingZedIdent + " - " + DateTime.Now.Day + " " + BitmapGenerator.GeorgianMonths[DateTime.Now.Month] + " " + DateTime.Now.Year + " " + DateTime.Now.Hour + "-" + DateTime.Now.Minute;
                        break;
                    case DetailedListViewMode.SoldZed:
                        sfd.FileName = "" + EditingZedClientIdent + "–ზე გასული ზედნადები #" + EditingZedIdent + " - " + DateTime.Now.Day + " " + BitmapGenerator.GeorgianMonths[DateTime.Now.Month] + " " + DateTime.Now.Year + " " + DateTime.Now.Hour + "-" + DateTime.Now.Minute;
                        break;
                }
            }
            catch (Exception)
            {
            }


            if (DialogResult.OK == sfd.ShowDialog())
            {
                info savefile_info = Utilities.Externals.SaveCSV(sfd.FileName, csv_output);
                if (0 != savefile_info.errcode)
                {
                    MessageBox.Show(savefile_info.details, savefile_info.errcode.ToString());
                }
                //
            }
        }

        private void SOd_print_gasavali_btn_Click(object sender, EventArgs e)
        {
            DataTable so_gasavali_print = ProductInfo_Main_Form.conn.Gasavali(SellOrderID);
            so_gasavali_print = ProductInfo_Main_Form.DataTable_AddSum(so_gasavali_print);

            PrintPreview_Form prevw_frm = new PrintPreview_Form();
            prevw_frm.Show();
            prevw_frm.DrawData(so_gasavali_print, false);
        }
        //
    }
}
