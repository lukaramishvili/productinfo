using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ProductInfo;
using Data_Visualization;
using Utilities;
using System.IO;

namespace ProductInfo_UI
{
    public partial class ProductInfo_Main_Form : Form
    {
        public ProductInfo_Main_Form()
        {
            InitializeComponent();
        }

        public static string UTF8String(string arg)
        {
            return Utilities.Utilities.UTF8String(arg);
        }

        public static string EngFromUTF8String(string arg)
        {
            return Utilities.Utilities.EngFromUTF8String(arg);
        }

        public static float ParseFloat(string arg)
        {
            return Utilities.Utilities.ParseFloat(arg);
        }

        public static decimal ParseDecimal(string arg)
        {
            return Utilities.Utilities.ParseDecimal(arg);
        }

        //
        //
        //

        private void names_data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void navigation_list_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void search_text_Click(object sender, EventArgs e)
        {
            search_text.Text = "";
            search_text.Click -= search_text_Click;
        }
        /// <summary>
        /// 
        /// </summary>
        public static DataProvider conn = new DataProvider();
        public bool pi_authenticated = false;


        public static BackgroundWorker WorkerThread = new BackgroundWorker();


        public Product[] all_products;
        public Supplier[] all_suppliers;
        public Buyer[] all_buyers;

        Remainder[] all_valid_rems = null;

        DataTable prodrem_list_dt = new DataTable();
        DataTable bought_af_list_dt = new DataTable();
        DataTable sold_af_list_dt = new DataTable();
        DataTable zed_list_dt = new DataTable();
        DataTable sold_zed_list_dt = new DataTable();
        DataTable rem_list_dt = new DataTable();
        DataTable agcera_dt = new DataTable();
        DataTable soldrems_dt = new DataTable();
        DataTable suppliers_dt = new DataTable();
        DataTable buyers_dt = new DataTable();
        DataTable sold_prodrem_list_dt = new DataTable();
        DataTable moneytransfers_dt = new DataTable();
        DataTable store_summary_dt = new DataTable();
        DataTable bought_af_standard_list_dt = new DataTable();
        //
        int sold_roi_col_index = -1;
        int sold_z_roi_col_index = -1;
        int sold_z_roi_withoutVAT_col_index = -1;
        //

        //
        private Dictionary<string, int[]> selected_table_indices = new Dictionary<string, int[]>();
        //

        public static int ActiveStoreID = 0;

        DateTime DateFilterSince = new DateTime(1990, 01, 01);
        DateTime DateFilterUntil = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 1);

        bool UsingCheck = true;

        //
        bool sell_clicked = false;

        decimal[] Sell_Row_Pricing = new decimal[2000];

        public string pressed_name_keystrokes = "";

        //
        Form ldform = new Form();//LoginDialogForm
        TextBox uname_txt = new TextBox();
        TextBox pwd_txt = new TextBox();
        Button accept_btn = new Button();

        private void Form1_Load(object sender, EventArgs e)
        {
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);

            ActiveStoreID = Convert.ToInt32(Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\zero\ProductInfo\1.0", "StoreID", 0));
            tb_store_chooser.SelectedIndex = ActiveStoreID;
            //
            tb_since_datepicker.Value = new DateTime(1990, 01, 01);
            tb_until_datepicker.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 1);
            tb_since_datepicker.ValueChanged += new EventHandler(tb_since_datepicker_ValueChanged);
            tb_until_datepicker.ValueChanged += new EventHandler(tb_until_datepicker_ValueChanged);
            DateFilterSince = tb_since_datepicker.Value;
            DateFilterUntil = tb_until_datepicker.Value;
            //
            ToolStripControlHost tb_since_host = new ToolStripControlHost(tb_since_datepicker);
            toolbar.Items.Add(tb_since_host);
            toolbar.Items.Add(this.tb_since_lbl);
            ToolStripControlHost tb_until_host = new ToolStripControlHost(tb_until_datepicker);
            toolbar.Items.Add(tb_until_host);
            toolbar.Items.Add(this.tb_until_lbl);
            //
            sb_sum_lbl.Visible = false;
            sb_sum_withoutVAT_lbl.Visible = false;

            status_bar_text.Text = ProductInfo_Main_Form.conn.status.details;




            all_valid_rems = conn.GetValidRemainders(ActiveStoreID, UsingCheck);

            all_suppliers = conn.AllSuppliers();

            all_buyers = conn.AllBuyers();

            if (all_buyers.Length > 0)
            {
                cmb_xelze_myidveli.Items.Clear();
                foreach (Buyer nbuyer in all_buyers)
                {
                    cmb_xelze_myidveli.Items.Add(nbuyer.saxeli);
                }
            }

            all_products = conn.GetProductSuggestions("");

            //
            if (all_valid_rems.Length > 0)
            {
                sell_name_col.Items.Clear();

                foreach (Remainder nrem in all_valid_rems)
                {
                    foreach (Product nprod in all_products)
                    {
                        if (nprod.barcode == nrem.product_barcode && !sell_name_col.Items.Contains(nprod.name))
                        {
                            sell_name_col.Items.Add(nprod.name);
                            break;
                        }
                    }
                }
            }
            ckb_pay_method.SelectedIndex = 0;
            /*
            if (all_products.Length > 0)
            {
                sell_name_col.Items.Clear();
                foreach (Product nprod in all_products)
                {
                    sell_name_col.Items.Add(nprod.name);
                }
            }
             * */

            try
            {
                uname_txt.Text = Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\zero\ProductInfo\1.0", "Username", "manager").ToString();
                pwd_txt.Text = Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\zero\ProductInfo\1.0", "Password", "123").ToString();
            }
            catch (NullReferenceException)
            {
            }



            ldform.MaximizeBox = false;
            ldform.MinimizeBox = false;
            ldform.StartPosition = FormStartPosition.CenterScreen;
            ldform.Text = "პროგრამაში შესვლა: ";
            ldform.AcceptButton = accept_btn;
            uname_txt.Location = new Point(20, 40);
            pwd_txt.Location = new Point(20, 70);
            accept_btn.Location = new Point(20, 100);
            accept_btn.Text = "შესვლა";

            ldform.Controls.Add(uname_txt);
            ldform.Controls.Add(pwd_txt);
            ldform.Controls.Add(accept_btn);

            this.Enabled = false;
            this.AddOwnedForm(ldform);
            ldform.Show(this);
            ldform.Focus();
            ldform.Activate();
            ldform.ActiveControl = uname_txt;
            uname_txt.Focus();
            uname_txt.Select();
            ldform.Focus();

            ldform.Load += new EventHandler(ldform_Load);
            ldform.FormClosing += new FormClosingEventHandler(ldform_FormClosing);
            accept_btn.Click += new EventHandler(accept_btn_Click);

            search_text.Enabled = false;
            btn_export_csv.Enabled = false;

        }

        void sell_list_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //better do nothing or cancel editing than continuously show MessageBoxes. 
            sell_list.CancelEdit();
        }

        void SetStatusText(string text)
        {
            status_bar_text.Text = text;
        }
        void SetStatusProgress(int progress)
        {
            status_progress_bar.Visible = true;
            status_progress_bar.Value = progress;
            if (100 == progress)
            {
                status_progress_bar.Visible = false;
            }
        }

        void tb_since_datepicker_ValueChanged(object sender, EventArgs e)
        {
            DateFilterSince = tb_since_datepicker.Value;
            if (zednadebebi_tabpage == tab_container.SelectedTab)
            {
                //if (!WorkerThread.Spawn(delegate()
                //{
                zed_list_dt = conn.Bought_Zed_Statistics(DateFilterSince, DateFilterUntil);
                //}))
                //{
                //  MessageBox.Show("სერვერთან დაკავშირების პრობლემაა. სცადეთ თავიდან. ");
                //}
                DataTableToListView(zed_list, zed_list_dt, true);
            }
            if (sold_zednadebebi_tabpage == tab_container.SelectedTab)
            {
                //if (!WorkerThread.Spawn(delegate()
                //{
                sold_zed_list_dt = conn.Sold_Zed_Statistics(DateFilterSince, DateFilterUntil);
                //}))
                //{
                //    MessageBox.Show("სერვერთან დაკავშირების პრობლემაა. სცადეთ თავიდან. ");
                //}
                DataTable empty_sold_zed_list_dt = new DataTable();
                #region populate_empty_sold_zed_list_dt
                foreach (ColumnHeader ch in sold_zed_list.Columns)
                {
                    empty_sold_zed_list_dt.Columns.Add(ch.Text);
                }

                foreach (DataRow dr in sold_zed_list_dt.Rows)
                {
                    for (int i = 0; i < dr.ItemArray.Length; i++)
                    {
                        DataRow dr_clone = empty_sold_zed_list_dt.NewRow();
                        if (conn.AllowSensitiveInformation)
                        {
                            dr_clone.ItemArray = dr.ItemArray;
                        }
                        else
                        {
                            object[] CloneItems = new object[dr_clone.ItemArray.Length];
                            int k = 0;
                            for (int j = 0; j < dr.ItemArray.Length; j++)
                            {
                                if (j == sold_z_roi_col_index | j == sold_z_roi_withoutVAT_col_index)
                                {
                                    continue;
                                }
                                CloneItems[k] = dr.ItemArray[j];
                                k++;
                            }
                            dr_clone.ItemArray = CloneItems;
                        }
                        empty_sold_zed_list_dt.Rows.Add(dr_clone);
                        break;
                    }
                }
                #endregion

                DataTableToListView(sold_zed_list, empty_sold_zed_list_dt, true);
            }
            if (sold_tabpage == tab_container.SelectedTab)
            {
                SetStatusText("მიმდინარეობს ინფორმაციის სერვერიდან ინფორმაციის მოწოდება..");
                SetStatusProgress(50);

                DateTime since = DateFilterSince;
                DateTime until = DateFilterUntil;
                //if (WorkerThread.Spawn(delegate()
                //{
                soldrems_dt = conn.Sold_Rem_Statistics(ActiveStoreID, since, until);
                //}))
                //{
                SetStatusText("ინფორმაცია სერვერიდან მიღებულია.");
                SetStatusProgress(100);
                //
                DataTableToListView(sold_list, soldrems_dt, true);
                //}
                //else
                //{
                //SetStatusText("პროცესი დაკავებულია. ");
                //}
            }
            if (sold_prods_tabpage == tab_container.SelectedTab)
            {
                sold_prodrem_list_dt = conn.GetSoldRemaindersByProductName(ActiveStoreID, DateFilterSince, DateFilterUntil);
                //}))
                //{
                //    MessageBox.Show("სერვერთან დაკავშირების პრობლემაა. სცადეთ თავიდან. ");
                //}
                DataTableToListView(sold_prodrem_list, sold_prodrem_list_dt, true);
            }
            if (moneytransfers_tabpage == tab_container.SelectedTab)
            {
                moneytransfers_dt = conn.MoneyTransferStatistics(ActiveStoreID, DateFilterSince, DateFilterUntil);

                DataTableToListView(moneytransfer_list, moneytransfers_dt, true);
            }

            UpdateStatusSums();
        }

        void tb_until_datepicker_ValueChanged(object sender, EventArgs e)
        {
            DateFilterUntil = tb_until_datepicker.Value;
            if (zednadebebi_tabpage == tab_container.SelectedTab)
            {
                //if (!WorkerThread.Spawn(delegate()
                //{
                zed_list_dt = conn.Bought_Zed_Statistics(DateFilterSince, DateFilterUntil);
                //}))
                //{
                //  MessageBox.Show("სერვერთან დაკავშირების პრობლემაა. სცადეთ თავიდან. ");
                //}
                DataTableToListView(zed_list, zed_list_dt, true);
            }
            if (sold_zednadebebi_tabpage == tab_container.SelectedTab)
            {
                //if (!WorkerThread.Spawn(delegate()
                //{
                sold_zed_list_dt = conn.Sold_Zed_Statistics(DateFilterSince, DateFilterUntil);
                //}))
                //{
                //    MessageBox.Show("სერვერთან დაკავშირების პრობლემაა. სცადეთ თავიდან. ");
                //}
                DataTable empty_sold_zed_list_dt = new DataTable();
                #region populate_empty_sold_zed_list_dt
                foreach (ColumnHeader ch in sold_zed_list.Columns)
                {
                    empty_sold_zed_list_dt.Columns.Add(ch.Text);
                }

                foreach (DataRow dr in sold_zed_list_dt.Rows)
                {
                    for (int i = 0; i < dr.ItemArray.Length; i++)
                    {
                        DataRow dr_clone = empty_sold_zed_list_dt.NewRow();
                        if (conn.AllowSensitiveInformation)
                        {
                            dr_clone.ItemArray = dr.ItemArray;
                        }
                        else
                        {
                            object[] CloneItems = new object[dr_clone.ItemArray.Length];
                            int k = 0;
                            for (int j = 0; j < dr.ItemArray.Length; j++)
                            {
                                if (j == sold_z_roi_col_index | j == sold_z_roi_withoutVAT_col_index)
                                {
                                    continue;
                                }
                                CloneItems[k] = dr.ItemArray[j];
                                k++;
                            }
                            dr_clone.ItemArray = CloneItems;
                        }
                        empty_sold_zed_list_dt.Rows.Add(dr_clone);
                        break;
                    }
                }
                #endregion

                DataTableToListView(sold_zed_list, empty_sold_zed_list_dt, true);
            }
            if (sold_tabpage == tab_container.SelectedTab)
            {
                SetStatusText("მიმდინარეობს ინფორმაციის სერვერიდან ინფორმაციის მოწოდება..");
                SetStatusProgress(50);

                DateTime since = DateFilterSince;
                DateTime until = DateFilterUntil;
                //if (WorkerThread.Spawn(delegate()
                //{
                soldrems_dt = conn.Sold_Rem_Statistics(ActiveStoreID, since, until);
                //}))
                //{
                SetStatusText("ინფორმაცია სერვერიდან მიღებულია.");
                SetStatusProgress(100);

                DataTableToListView(sold_list, soldrems_dt, true);
                //}
                //else
                //{
                //    SetStatusText("პროცესი დაკავებულია. ");
                //}
            }
            if (sold_prods_tabpage == tab_container.SelectedTab)
            {
                sold_prodrem_list_dt = conn.GetSoldRemaindersByProductName(ActiveStoreID, DateFilterSince, DateFilterUntil);
                //}))
                //{
                //    MessageBox.Show("სერვერთან დაკავშირების პრობლემაა. სცადეთ თავიდან. ");
                //}
                DataTableToListView(sold_prodrem_list, sold_prodrem_list_dt, true);
            }
            if (moneytransfers_tabpage == tab_container.SelectedTab)
            {
                moneytransfers_dt = conn.MoneyTransferStatistics(ActiveStoreID, DateFilterSince, DateFilterUntil);
                //}))
                //{
                //    MessageBox.Show("სერვერთან დაკავშირების პრობლემაა. სცადეთ თავიდან. ");
                //}
                DataTableToListView(moneytransfer_list, moneytransfers_dt, true);
            }
            UpdateStatusSums();
        }

        void Application_ApplicationExit(object sender, EventArgs e)
        {
            if (true == pi_authenticated)
            {
                Microsoft.Win32.Registry.SetValue(@"HKEY_CURRENT_USER\Software\zero\ProductInfo\1.0", "StoreID", ActiveStoreID);
                conn.Close();
            }
        }

        void accept_btn_Click(object sender, EventArgs e)
        {

            info conn_info = conn.Connect(uname_txt.Text, pwd_txt.Text);
            status_bar_text.Text = conn.status.details;


            if (0 == conn_info.errcode)
            {
                this.Enabled = true;
                uname_txt.Text = "asd";
                ldform.FormClosing -= ldform_FormClosing;
                ldform.Close();
                pi_authenticated = true;

                if (true != conn.AllowSensitiveInformation)
                {
                    sold_roi_col_index = sold_roi_col.Index;
                    sold_z_roi_col_index = sold_z_roi_col.Index;
                    sold_z_roi_withoutVAT_col_index = sold_z_roi_withoutVAT_col.Index;
                    sold_list.Columns.Remove(sold_roi_col);
                    sold_zed_list.Columns.Remove(sold_z_roi_col);
                    sold_zed_list.Columns.Remove(sold_z_roi_withoutVAT_col);
                }
            }
            else
            {

            }
        }

        void ldform_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CloseReason.UserClosing == e.CloseReason)
            {
                if (MessageBox.Show("სახელის და პაროლის შეყვანის გარეშე \nპროგრამაში შესვლას ვერ შეძლებთ!", "გამოვრთოთ პროგრამა?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ldform.FormClosing -= ldform_FormClosing;
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                info conn_info = conn.Connect(uname_txt.Text, pwd_txt.Text);
                MessageBox.Show(conn.status.errcode.ToString());


                if (0 == conn_info.errcode)
                {
                    this.Enabled = true;

                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        void ldform_Load(object sender, EventArgs e)
        {

        }



        private void mm_product_add_Click(object sender, EventArgs e)
        {

            AddProduct_Form prod_add_frm = new AddProduct_Form();
            prod_add_frm.Show();
            prod_add_frm.FormClosed += new FormClosedEventHandler(prod_add_frm_FormClosed);
            //this.Enabled = false;

        }

        void prod_add_frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            RefreshTabs();

            //update remainders
            all_valid_rems = conn.GetValidRemainders(ActiveStoreID, UsingCheck);
            //update product names
            all_products = conn.GetProductSuggestions("");
            //refresh list with updated names
            if (all_valid_rems.Length > 0)
            {
                sell_name_col.Items.Clear();

                foreach (Remainder nrem in all_valid_rems)
                {
                    foreach (Product nprod in all_products)
                    {
                        if (nprod.barcode == nrem.product_barcode && !sell_name_col.Items.Contains(nprod.name))
                        {
                            sell_name_col.Items.Add(nprod.name);
                            break;
                        }
                    }
                }
            }
            //
        }

        private void mm_productlist_add_Click(object sender, EventArgs e)
        {
            AddProductList_Form prodlist_add_frm = new AddProductList_Form();
            prodlist_add_frm.Show();
            prodlist_add_frm.FormClosed += new FormClosedEventHandler(prodlist_add_frm_FormClosed);
            //this.Enabled = false; 
        }

        void prodlist_add_frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            RefreshTabs();

            //update remainders
            all_valid_rems = conn.GetValidRemainders(ActiveStoreID, UsingCheck);
            //update product names
            all_products = conn.GetProductSuggestions("");
            //refresh list with updated names
            if (all_valid_rems.Length > 0)
            {
                sell_name_col.Items.Clear();

                foreach (Remainder nrem in all_valid_rems)
                {
                    foreach (Product nprod in all_products)
                    {
                        if (nprod.barcode == nrem.product_barcode && !sell_name_col.Items.Contains(nprod.name))
                        {
                            sell_name_col.Items.Add(nprod.name);
                            break;
                        }
                    }
                }
            }
            //
        }

        private void mm_add_supplier_Click(object sender, EventArgs e)
        {
            AddSupplier_Form supplier_add_frm = new AddSupplier_Form();
            supplier_add_frm.Show();

            supplier_add_frm.FormClosed += delegate(object senderAddSuppForm, FormClosedEventArgs eAddSuppForm)
            {
                all_suppliers = conn.AllSuppliers();

                RefreshTabs();
            };
        }

        private void mm_sell_zednadebi_Click(object sender, EventArgs e)
        {
            Sell_Form sell_zed_frm = new Sell_Form();
            sell_zed_frm.Show();
            sell_zed_frm.FormClosed += new FormClosedEventHandler(sell_zed_frm_FormClosed);
        }

        void sell_zed_frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            RefreshTabs();
        }

        private void mm_add_remainders_Click(object sender, EventArgs e)
        {
            AddRemainders_Form add_remainders_frm = new AddRemainders_Form();
            add_remainders_frm.Show();
            add_remainders_frm.FormClosed += new FormClosedEventHandler(add_remainders_frm_FormClosed);
        }

        void add_remainders_frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            RefreshTabs();
            all_suppliers = conn.AllSuppliers();

            //update remainders
            all_valid_rems = conn.GetValidRemainders(ActiveStoreID, UsingCheck);
            if (all_valid_rems.Length > 0)
            {
                sell_name_col.Items.Clear();

                foreach (Remainder nrem in all_valid_rems)
                {
                    foreach (Product nprod in all_products)
                    {
                        if (nprod.barcode == nrem.product_barcode && !sell_name_col.Items.Contains(nprod.name))
                        {
                            sell_name_col.Items.Add(nprod.name);
                            break;
                        }
                    }
                }
            }
        }

        private void mm_sell_remainders_Click(object sender, EventArgs e)
        {
            Sell_Form sell_frm = new Sell_Form();
            sell_frm.Show();
            sell_frm.ActiveStoreID = ActiveStoreID;
            sell_frm.FormClosed += new FormClosedEventHandler(sell_frm_FormClosed);
        }

        void sell_frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            RefreshTabs();
            all_buyers = conn.AllBuyers();

            all_valid_rems = conn.GetValidRemainders(ActiveStoreID, UsingCheck);
            if (all_valid_rems.Length > 0)
            {
                sell_name_col.Items.Clear();

                foreach (Remainder nrem in all_valid_rems)
                {
                    foreach (Product nprod in all_products)
                    {
                        if (nprod.barcode == nrem.product_barcode && !sell_name_col.Items.Contains(nprod.name))
                        {
                            sell_name_col.Items.Add(nprod.name);
                            break;
                        }
                    }
                }
            }
        }

        private void search_text_TextChanged(object sender, EventArgs e)
        {
            RememberTableSelections();
            if ("ძებნა" != search_text.Text)
            {
                FilterTables(search_text.Text);
            }
            RestoreTableSelections();
        }

        private void FilterTables(string filter_string)
        {
            if (nashtebi_tabpage == tab_container.SelectedTab)
            {
                DataTable empty_dt = new DataTable();
                foreach (ColumnHeader ch in rem_list.Columns)
                {
                    empty_dt.Columns.Add(ch.Text);
                }

                foreach (DataRow dr in rem_list_dt.Rows)
                {
                    for (int i = 0; i < dr.ItemArray.Length; i++)
                    {
                        if (dr.ItemArray[i].ToString().Contains(filter_string))
                        {
                            DataRow dr_clone = empty_dt.NewRow();
                            dr_clone.ItemArray = dr.ItemArray;
                            empty_dt.Rows.Add(dr_clone);
                            break;
                        }
                    }
                }

                DataTableToListView(rem_list, empty_dt, true);
            }
            else if (zednadebebi_tabpage == tab_container.SelectedTab)
            {
                DataTable empty_dt = new DataTable();
                foreach (ColumnHeader ch in zed_list.Columns)
                {
                    empty_dt.Columns.Add(ch.Text);
                }

                foreach (DataRow dr in zed_list_dt.Rows)
                {
                    for (int i = 0; i < dr.ItemArray.Length; i++)
                    {
                        if (dr.ItemArray[i].ToString().Contains(filter_string))
                        {
                            DataRow dr_clone = empty_dt.NewRow();
                            dr_clone.ItemArray = dr.ItemArray;
                            empty_dt.Rows.Add(dr_clone);
                            break;
                        }
                    }
                }

                DataTableToListView(zed_list, empty_dt, true);
            }
            else if (sold_zednadebebi_tabpage == tab_container.SelectedTab)
            {
                DataTable empty_dt = new DataTable();
                foreach (ColumnHeader ch in sold_zed_list.Columns)
                {
                    empty_dt.Columns.Add(ch.Text);
                }

                foreach (DataRow dr in sold_zed_list_dt.Rows)
                {
                    for (int i = 0; i < dr.ItemArray.Length; i++)
                    {
                        if (dr.ItemArray[i].ToString().Contains(filter_string))
                        {
                            DataRow dr_clone = empty_dt.NewRow();
                            if (conn.AllowSensitiveInformation)
                            {
                                dr_clone.ItemArray = dr.ItemArray;
                            }
                            else
                            {
                                object[] CloneItems = new object[dr_clone.ItemArray.Length];
                                int k = 0;
                                for (int j = 0; j < dr.ItemArray.Length; j++)
                                {
                                    if (j == sold_z_roi_col_index | j == sold_z_roi_withoutVAT_col_index)
                                    {
                                        continue;
                                    }
                                    CloneItems[k] = dr.ItemArray[j];
                                    k++;
                                }
                                dr_clone.ItemArray = CloneItems;
                            }
                            empty_dt.Rows.Add(dr_clone);
                            break;
                        }
                    }
                }

                DataTableToListView(sold_zed_list, empty_dt, true);
            }
            else if (bought_afs_tabpage == tab_container.SelectedTab)
            {
            }
            else if (suppliers_tabpage == tab_container.SelectedTab)
            {
                DataTable empty_dt = new DataTable();
                foreach (ColumnHeader ch in suppliers_list.Columns)
                {
                    empty_dt.Columns.Add(ch.Text);
                }

                foreach (DataRow dr in suppliers_dt.Rows)
                {
                    for (int i = 0; i < dr.ItemArray.Length; i++)
                    {
                        if (dr.ItemArray[i].ToString().Contains(filter_string))
                        {
                            DataRow dr_clone = empty_dt.NewRow();
                            dr_clone.ItemArray = dr.ItemArray;
                            empty_dt.Rows.Add(dr_clone);
                            break;
                        }
                    }
                }

                DataTableToListView(suppliers_list, empty_dt, true);
            }
            else if (buyers_tabpage == tab_container.SelectedTab)
            {
                DataTable empty_dt = new DataTable();
                foreach (ColumnHeader ch in buyers_list.Columns)
                {
                    empty_dt.Columns.Add(ch.Text);
                }

                foreach (DataRow dr in buyers_dt.Rows)
                {
                    for (int i = 0; i < dr.ItemArray.Length; i++)
                    {
                        if (dr.ItemArray[i].ToString().Contains(filter_string))
                        {
                            DataRow dr_clone = empty_dt.NewRow();
                            dr_clone.ItemArray = dr.ItemArray;
                            empty_dt.Rows.Add(dr_clone);
                            break;
                        }
                    }
                }

                DataTableToListView(buyers_list, empty_dt, true);
            }
            else if (productnames_tabpage == tab_container.SelectedTab)
            {
                DataTable empty_dt = new DataTable();
                foreach (ColumnHeader ch in prod_names_list.Columns)
                {
                    empty_dt.Columns.Add(ch.Text);
                }

                foreach (DataRow dr in prodrem_list_dt.Rows)
                {
                    for (int i = 0; i < dr.ItemArray.Length; i++)
                    {
                        if (dr.ItemArray[i].ToString().Contains(filter_string))
                        {
                            DataRow dr_clone = empty_dt.NewRow();
                            dr_clone.ItemArray = dr.ItemArray;
                            empty_dt.Rows.Add(dr_clone);
                            break;
                        }
                    }
                }

                DataTableToListView(prod_names_list, empty_dt, true);
            }
            else if (sold_tabpage == tab_container.SelectedTab)
            {
                DataTable empty_dt = new DataTable();
                foreach (ColumnHeader ch in sold_list.Columns)
                {
                    empty_dt.Columns.Add(ch.Text);
                }

                foreach (DataRow dr in soldrems_dt.Rows)
                {
                    for (int i = 0; i < dr.ItemArray.Length; i++)
                    {
                        if (dr.ItemArray[i].ToString().Contains(filter_string))
                        {
                            DataRow dr_clone = empty_dt.NewRow();
                            if (conn.AllowSensitiveInformation)
                            {
                                dr_clone.ItemArray = dr.ItemArray;
                            }
                            else
                            {
                                object[] CloneItems = new object[dr_clone.ItemArray.Length];
                                int k = 0;
                                for (int j = 0; j < dr.ItemArray.Length; j++)
                                {
                                    if (j == sold_roi_col_index)
                                    {
                                        continue;
                                    }
                                    CloneItems[k] = dr.ItemArray[j];
                                    k++;
                                }
                                dr_clone.ItemArray = CloneItems;
                            }
                            empty_dt.Rows.Add(dr_clone);
                            break;
                        }
                    }
                }

                DataTableToListView(sold_list, empty_dt, true);
            }
            else if (agcera_tabpage == tab_container.SelectedTab)
            {
                DataTable empty_dt = new DataTable();
                foreach (ColumnHeader ch in agcera_rem_list.Columns)
                {
                    empty_dt.Columns.Add(ch.Text);
                }

                foreach (DataRow dr in agcera_dt.Rows)
                {
                    for (int i = 0; i < dr.ItemArray.Length; i++)
                    {
                        if (dr.ItemArray[i].ToString().Contains(filter_string))
                        {
                            DataRow dr_clone = empty_dt.NewRow();
                            dr_clone.ItemArray = dr.ItemArray;
                            empty_dt.Rows.Add(dr_clone);
                            break;
                        }
                    }
                }

                DataTableToListView(agcera_rem_list, empty_dt, true);
            }
            else if (sold_prods_tabpage == tab_container.SelectedTab)
            {
                DataTable empty_dt = new DataTable();
                foreach (ColumnHeader ch in sold_prodrem_list.Columns)
                {
                    empty_dt.Columns.Add(ch.Text);
                }

                foreach (DataRow dr in sold_prodrem_list_dt.Rows)
                {
                    for (int i = 0; i < dr.ItemArray.Length; i++)
                    {
                        if (dr.ItemArray[i].ToString().Contains(filter_string))
                        {
                            DataRow dr_clone = empty_dt.NewRow();
                            dr_clone.ItemArray = dr.ItemArray;
                            empty_dt.Rows.Add(dr_clone);
                            break;
                        }
                    }
                }

                DataTableToListView(sold_prodrem_list, empty_dt, true);
            }
            else if (moneytransfers_tabpage == tab_container.SelectedTab)
            {
                DataTable empty_dt = new DataTable();
                foreach (ColumnHeader ch in moneytransfer_list.Columns)
                {
                    empty_dt.Columns.Add(ch.Text);
                }

                foreach (DataRow dr in moneytransfers_dt.Rows)
                {
                    for (int i = 0; i < dr.ItemArray.Length; i++)
                    {
                        if (dr.ItemArray[i].ToString().Contains(filter_string))
                        {
                            DataRow dr_clone = empty_dt.NewRow();
                            dr_clone.ItemArray = dr.ItemArray;
                            empty_dt.Rows.Add(dr_clone);
                            break;
                        }
                    }
                }

                DataTableToListView(moneytransfer_list, empty_dt, true);
            }
            UpdateStatusSums();
        }

        private void mm_add_buyer_Click(object sender, EventArgs e)
        {
            AddBuyer_Form buyer_add_frm = new AddBuyer_Form();
            buyer_add_frm.Show();
            buyer_add_frm.FormClosed += new FormClosedEventHandler(buyer_add_frm_FormClosed);
        }

        void buyer_add_frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            all_buyers = conn.AllBuyers();

            if (all_buyers.Length > 0)
            {
                cmb_xelze_myidveli.Items.Clear();
                foreach (Buyer nbuyer in all_buyers)
                {
                    cmb_xelze_myidveli.Items.Add(nbuyer.saxeli);
                }
            }

            RefreshTabs();
        }

        private void sell_list_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            pressed_name_keystrokes = "";
            if (sell_clicked && !sell_list.Rows[e.RowIndex].IsNewRow)
            {
                HighlightNonCompleteFields(sell_list.Rows[e.RowIndex]);
            }
            if (sell_list.Columns["sell_barcode_col"].Index == e.ColumnIndex && null != sell_list.Rows[e.RowIndex].Cells[e.ColumnIndex].Value)
            {

                Product ProdJustScanned = ProductInfo_Main_Form.conn.GetProductByBarCode(sell_list.Rows[e.RowIndex].Cells["sell_barcode_col"].EditedFormattedValue.ToString());
                if ("nameless" == ProdJustScanned.name)
                {
                    if (DialogResult.Yes == MessageBox.Show("შტრიხ–კოდი არ არის დარეგისტრირებული. გსურთ პროდუქტის ბაზაში დამატება?", "შეცდომა!", MessageBoxButtons.YesNo))
                    {
                        AddProduct_Form add_scanned_frm = new AddProduct_Form();
                        add_scanned_frm.Show();
                        add_scanned_frm.Controls["barcode_txt"].Text = sell_list.Rows[e.RowIndex].Cells["sell_barcode_col"].Value.ToString();
                        add_scanned_frm.Controls["name_txt"].Focus();
                    }
                    else
                    {
                        sell_list.Rows[e.RowIndex].Cells["sell_barcode_col"].Value = "000000000";
                    }
                }
                else
                {
                    sell_list.Rows[e.RowIndex].Cells["sell_name_col"].Value = ProdJustScanned.name;
                }

                IEnumerable<Remainder> query = new List<Remainder>();
                query = from r in all_valid_rems
                        where r.product_barcode == sell_list.Rows[e.RowIndex].Cells["sell_barcode_col"].Value.ToString()
                        select r;

                var StoreRems = from rem in query
                                group rem by rem.storehouse_id into storrem
                                select new { StoreID = storrem.Key, remaining_items = storrem.Sum(rem => rem.remaining_pieces) };
                var rem_rem = (from sr in StoreRems
                               where ActiveStoreID == sr.StoreID
                               select sr.remaining_items).ToArray();
                if (rem_rem.Length > 0)
                {
                    sell_list.Rows[e.RowIndex].Cells["sell_remaining_col"].Value = rem_rem[0].ToString("G4") + " (#" + ActiveStoreID.ToString() + ")";
                }
                else
                {
                    sell_list.Rows[e.RowIndex].Cells["sell_remaining_col"].Value = 0.ToString("G4") + " (#" + ActiveStoreID.ToString() + ")";
                }

                if (query.ToArray().Length > 0)
                {
                    sell_list.Rows[e.RowIndex].Cells["sell_capacity_col"].Value = query.ToArray()[0].pack_capacity.ToString("G4");
                    sell_list.Rows[e.RowIndex].Cells["sell_initial_price_info_col"].Value = query.ToArray()[0].buy_price.ToString("G4");
                }
                else
                {
                    MessageBox.Show("ეს პროდუქტი საწყობების ბაზაში არაა დარჩენილი. ");
                    sell_list.Rows[e.RowIndex].Cells["sell_barcode_col"].Value = "000000000";
                }
            }

            if (sell_list.Columns["sell_name_col"].Index == e.ColumnIndex && null != sell_list.Rows[e.RowIndex].Cells[e.ColumnIndex].Value)
            {
                foreach (Product nXprod in all_products)
                {
                    if (sell_list.Rows[e.RowIndex].Cells["sell_name_col"].Value.ToString() == nXprod.name)
                    {
                        sell_list.Rows[e.RowIndex].Cells["sell_barcode_col"].Value = nXprod.barcode;

                        IEnumerable<Remainder> query = new List<Remainder>();
                        query = from r in all_valid_rems
                                where r.product_barcode == sell_list.Rows[e.RowIndex].Cells["sell_barcode_col"].Value.ToString()
                                select r;

                        var StoreRems = from rem in query
                                        group rem by rem.storehouse_id into storrem
                                        select new { StoreID = storrem.Key, remaining_items = storrem.Sum(rem => rem.remaining_pieces) };
                        var rem_rem = (from sr in StoreRems
                                       where ActiveStoreID == sr.StoreID
                                       select sr.remaining_items).ToArray();
                        if (rem_rem.Length > 0)
                        {
                            sell_list.Rows[e.RowIndex].Cells["sell_remaining_col"].Value = rem_rem[0].ToString("G4") + " (#" + ActiveStoreID.ToString() + ")";
                        }
                        else
                        {
                            sell_list.Rows[e.RowIndex].Cells["sell_remaining_col"].Value = 0.ToString("G4") + " (#" + ActiveStoreID.ToString() + ")";
                        }

                        if (query.ToArray().Length > 0)
                        {
                            sell_list.Rows[e.RowIndex].Cells["sell_capacity_col"].Value = query.ToArray()[0].pack_capacity.ToString("G4");
                            sell_list.Rows[e.RowIndex].Cells["sell_initial_price_info_col"].Value = query.ToArray()[0].buy_price.ToString("G4");
                        }
                        else
                        {
                            MessageBox.Show("ეს პროდუქტი საწყობების ბაზაში არაა დარჩენილი. ");
                            sell_list.Rows[e.RowIndex].Cells["sell_barcode_col"].Value = "000000000";
                        }

                        break;
                    }
                }
            }

            if (e.ColumnIndex == sell_pack_price_col.Index && null != sell_list.Rows[e.RowIndex].Cells["sell_pack_price_col"].Value && null != sell_list.Rows[e.RowIndex].Cells["sell_capacity_col"].Value)
            {
                sell_list.Rows[e.RowIndex].Cells["sell_piece_price_col"].Value = ParseDecimal(sell_list.Rows[e.RowIndex].Cells["sell_pack_price_col"].Value.ToString()) / ParseDecimal(sell_list.Rows[e.RowIndex].Cells["sell_capacity_col"].Value.ToString());
            }

            if (e.ColumnIndex == sell_piece_price_col.Index && null != sell_list.Rows[e.RowIndex].Cells["sell_piece_price_col"].Value && null != sell_list.Rows[e.RowIndex].Cells["sell_capacity_col"].Value)
            {
                sell_list.Rows[e.RowIndex].Cells["sell_pack_price_col"].Value = ParseDecimal(sell_list.Rows[e.RowIndex].Cells["sell_piece_price_col"].Value.ToString()) * ParseDecimal(sell_list.Rows[e.RowIndex].Cells["sell_capacity_col"].Value.ToString());
            }
            //aqamde shemocmebulia
            try
            {
                if (null != sell_list.Rows[e.RowIndex].Cells["sell_pack_amount_col"].Value
                | null != sell_list.Rows[e.RowIndex].Cells["sell_piece_amount_col"].Value)
                {
                    decimal pack_count = 0.0m;
                    decimal only_piece_count = 0.0m;
                    decimal whole_piece_count = 0.0m;
                    decimal current_capacity = 0.0m;

                    decimal piece_price = 0.0m;
                    decimal row_sum_price = 0.0m;

                    if (null != sell_list.Rows[e.RowIndex].Cells["sell_pack_amount_col"].Value)
                    {
                        pack_count = ParseDecimal(sell_list.Rows[e.RowIndex].Cells["sell_pack_amount_col"].Value.ToString());
                    }
                    if (null != sell_list.Rows[e.RowIndex].Cells["sell_piece_amount_col"].Value)
                    {
                        only_piece_count = ParseDecimal(sell_list.Rows[e.RowIndex].Cells["sell_piece_amount_col"].Value.ToString());
                    }

                    if (null != sell_list.Rows[e.RowIndex].Cells["sell_capacity_col"].Value)
                    {
                        current_capacity = ParseDecimal(sell_list.Rows[e.RowIndex].Cells["sell_capacity_col"].Value.ToString());
                    }
                    whole_piece_count = pack_count * current_capacity + only_piece_count;
                    sell_list.Rows[e.RowIndex].Cells["sell_piece_amount_info"].Value = whole_piece_count;

                    if (null != sell_list.Rows[e.RowIndex].Cells["sell_piece_price_col"].Value)
                    {
                        piece_price = ParseDecimal(sell_list.Rows[e.RowIndex].Cells["sell_piece_price_col"].Value.ToString());

                        row_sum_price = whole_piece_count * piece_price;
                        sell_list.Rows[e.RowIndex].Cells["sell_sum_price_col"].Value = row_sum_price;
                        Sell_Row_Pricing[e.RowIndex] = row_sum_price;
                        UpdateSumSellPrice();
                    }
                }
            }
            catch (FormatException)
            {
                sell_status_lbl.Text = "შეავსეთ ველები შესაბამისი ფორმატით. ";
            }
            catch (NullReferenceException)//not needed
            {
                sell_status_lbl.Text = "ყველა ველი არაა შევსებული. ";
            }
        }

        private void HighlightNonCompleteFields(DataGridViewRow nextRow)
        {
            if (null == nextRow.Cells["sell_barcode_col"].Value)
            {
                nextRow.Cells["sell_barcode_col"].Style.BackColor = Color.Red;
            }
            else
            {
                nextRow.Cells["sell_barcode_col"].Style.BackColor = Color.White;
            }
            if (null == nextRow.Cells["sell_capacity_col"].Value)
            {
                nextRow.Cells["sell_capacity_col"].Style.BackColor = Color.Red;
            }
            else
            {
                nextRow.Cells["sell_capacity_col"].Style.BackColor = Color.White;
            }
            if (
                    (null == nextRow.Cells["sell_pack_amount_col"].Value && null == nextRow.Cells["sell_piece_amount_col"].Value)
                    | (null != nextRow.Cells["sell_pack_amount_col"].Value && 0.0m >= ParseDecimal(nextRow.Cells["sell_pack_amount_col"].Value.ToString()))
                    | (null != nextRow.Cells["sell_piece_amount_col"].Value && 0.0m >= ParseDecimal(nextRow.Cells["sell_piece_amount_col"].Value.ToString()))
                )
            {
                nextRow.Cells["sell_pack_amount_col"].Style.BackColor = Color.Red;
                nextRow.Cells["sell_piece_amount_col"].Style.BackColor = Color.Red;
            }
            else
            {
                nextRow.Cells["sell_pack_amount_col"].Style.BackColor = Color.White;
                nextRow.Cells["sell_piece_amount_col"].Style.BackColor = Color.White;
            }
            /*if (null == nextRow.Cells["sell_rem_store1_col"].Value)
            {
                //nextRow.Cells["sell_rem_store1_col"].Style.BackColor = Color.Red;
            }
            else
            {
                nextRow.Cells["sell_rem_store1_col"].Style.BackColor = Color.White;
            }
            if (null == nextRow.Cells["sell_rem_store2_col"].Value)
            {
                //nextRow.Cells["sell_rem_store2_col"].Style.BackColor = Color.Red;
            }
            else
            {
                nextRow.Cells["sell_rem_store2_col"].Style.BackColor = Color.White;
            }*/
            if (
                    (null == nextRow.Cells["sell_pack_price_col"].Value && null == nextRow.Cells["sell_piece_price_col"].Value)
                    | (null != nextRow.Cells["sell_pack_price_col"].Value && 0.0m >= ParseDecimal(nextRow.Cells["sell_pack_price_col"].Value.ToString()))
                    | (null != nextRow.Cells["sell_piece_price_col"].Value && 0.0m >= ParseDecimal(nextRow.Cells["sell_piece_price_col"].Value.ToString()))
                )
            {
                nextRow.Cells["sell_pack_price_col"].Style.BackColor = Color.Red;
                nextRow.Cells["sell_piece_price_col"].Style.BackColor = Color.Red;
            }
            else
            {
                nextRow.Cells["sell_pack_price_col"].Style.BackColor = Color.White;
                nextRow.Cells["sell_piece_price_col"].Style.BackColor = Color.White;
            }
        }

        public void UpdateSumSellPrice()
        {
            decimal SumPrice = 0.0m;
            foreach (decimal nXprice in Sell_Row_Pricing)
            {
                SumPrice += nXprice;
            }
            sell_status_sum_price_lbl.Text = "საერთო ფასი " + SumPrice.ToString() + " ლარი";
        }



        private void sell_list_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == sell_delete_col.Index)
            {
                if (!sell_list.Rows[e.RowIndex].IsNewRow && null != sell_list.Rows[e.RowIndex])
                {
                    string ProdToDel = (null != sell_list.Rows[e.RowIndex].Cells["sell_name_col"].Value) ? sell_list.Rows[e.RowIndex].Cells["sell_name_col"].Value.ToString() : "პროდუქტი";
                    if (DialogResult.Yes == MessageBox.Show("ნამდვილად გსურთ სიიდან " + ProdToDel + "-ს ამოშლა?", "დადასტურება", MessageBoxButtons.YesNo))
                    {
                        sell_list.Rows.Remove(sell_list.Rows[e.RowIndex]);
                        UpdateSumSellPrice();
                    }
                }
            }
        }

        private void sell_list_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F8)
            {
                try
                {
                    int currentRowIndex = sell_list.CurrentRow.Index;
                    sell_list.ClearSelection();
                    sell_list.EndEdit();
                    sell_list.Rows[currentRowIndex].Cells["sell_barcode_col"].Selected = true;
                }
                catch (NullReferenceException)
                {
                    sell_list.Rows.Add();
                }
            }
        }

        private void sell_list_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyDown -= sell_list_Control_KeyDown;
            e.Control.KeyDown += new KeyEventHandler(sell_list_Control_KeyDown);

            if (sell_name_col.Index == sell_list.CurrentCell.ColumnIndex)
            {
                ComboBox cb = (ComboBox)e.Control;
                cb.DropDownStyle = ComboBoxStyle.DropDown;
            }
        }

        void sell_list_Control_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F8)
            {
                try
                {
                    int currentRowIndex = sell_list.CurrentRow.Index;
                    sell_list.ClearSelection();
                    sell_list.EndEdit();
                    sell_list.Rows[currentRowIndex].Cells["add_rem_barcode_col"].Selected = true;
                }
                catch (NullReferenceException)
                {
                    sell_list.Rows.Add();
                }
            }

            if (sell_name_col.Index == sell_list.CurrentCell.ColumnIndex)
            {
                Control ctl = (Control)sender;
                e.SuppressKeyPress = false;
                e.Handled = true;
                string pressedKey = ((char)e.KeyValue).ToString();
                if (!e.Shift)
                {
                    pressedKey = pressedKey.ToLower();
                }
                if (e.KeyData != Keys.Shift)
                {
                    pressed_name_keystrokes += UTF8String(pressedKey);
                }

                status_bar_text.Text = pressed_name_keystrokes;
                if ("" != pressed_name_keystrokes)
                {
                    try
                    {
                        Product[] prod_suggestions = new List<Product>().ToArray();
                        //if (!WorkerThread.Spawn(delegate()
                        //                      {
                        prod_suggestions = ProductInfo_Main_Form.conn.GetProductSuggestions(pressed_name_keystrokes);
                        //                    }))
                        //{
                        //  MessageBox.Show("სერვერთან დაკავშირების პრობლემაა. სცადეთ თავიდან. ");
                        //}
                        if (prod_suggestions.Length > 0)
                        {
                            sell_list.CurrentRow.Cells["sell_barcode_col"].Value = prod_suggestions[0].barcode;
                            foreach (object nextItem in sell_name_col.Items)
                            {
                                if (nextItem.ToString() == prod_suggestions[0].name)
                                {
                                    sell_list.CurrentRow.Cells["sell_name_col"].Value = nextItem.ToString();//prod_suggestions[0].name;
                                    break;
                                }
                            }
                            /*
                             * add_rem_name_col.Items.Clear();
                            foreach (Product nprod in prod_suggestions)
                            {
                                add_rem_name_col.Items.Add(nprod.name);
                            }
                             * that's if product name is a combobox
                             * */
                        }
                    }
                    catch (NullReferenceException)
                    {
                        MessageBox.Show("null ref");
                    }
                }
            }//AutoComplete Product Name
        }

        private void tab_container_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sell_tabpage == tab_container.SelectedTab | summary_tabpage == tab_container.SelectedTab)
            {
                search_text.Enabled = false;
                btn_export_csv.Enabled = false;
            }
            else
            {
                search_text.Enabled = true;
                btn_export_csv.Enabled = true;
            }

            if (bought_afs_tabpage == tab_container.SelectedTab | sold_afs_tabpage == tab_container.SelectedTab | zednadebebi_tabpage == tab_container.SelectedTab | sold_zednadebebi_tabpage == tab_container.SelectedTab | nashtebi_tabpage == tab_container.SelectedTab | (sold_tabpage == tab_container.SelectedTab && true == conn.AllowSensitiveInformation))
            {
                sb_sum_lbl.Visible = true;
                sb_sum_withoutVAT_lbl.Visible = true;
            }
            else
            {
                sb_sum_lbl.Visible = false;
                sb_sum_withoutVAT_lbl.Visible = false;
            }

            RefreshTabs();

            UpdateStatusSums();

        }


        public void RefreshTabs()
        {
            RememberTableSelections();
            if (sell_tabpage == tab_container.SelectedTab)
            {
                all_valid_rems = conn.GetValidRemainders(ActiveStoreID, UsingCheck);
                if (0 == ActiveStoreID)
                {
                    sell_list.Enabled = false;
                    sell_submit_btn.Enabled = false;
                }
                else
                {
                    sell_list.Enabled = true;
                    sell_submit_btn.Enabled = true;
                }
            }
            if (productnames_tabpage == tab_container.SelectedTab)
            {
                //if (!WorkerThread.Spawn(delegate()
                //{
                prodrem_list_dt = conn.GetRemaindersByProductName(ActiveStoreID);
                //}))
                //{
                //    MessageBox.Show("სერვერთან დაკავშირების პრობლემაა. სცადეთ თავიდან. ");
                //}
                DataTableToListView(prod_names_list, prodrem_list_dt, true);
            }
            if (suppliers_tabpage == tab_container.SelectedTab)
            {
                //if (!WorkerThread.Spawn(delegate()
                //{
                suppliers_dt = conn.Supplier_Fin_Statistics();
                //}))
                //{
                //   MessageBox.Show("სერვერთან დაკავშირების პრობლემაა. სცადეთ თავიდან. ");
                //}
                DataTableToListView(suppliers_list, suppliers_dt, true);
                //PopulateSupplierList(("ძებნა" == search_text.Text) ? "" : search_text.Text);
            }
            if (buyers_tabpage == tab_container.SelectedTab)
            {
                buyers_dt = conn.Buyer_Fin_Statistics();

                DataTableToListView(buyers_list, buyers_dt, true);
            }
            if (bought_afs_tabpage == tab_container.SelectedTab)
            {
                //if (!WorkerThread.Spawn(delegate()
                //{
                bought_af_list_dt = conn.Bought_AF_Statistics();
                //}))
                //{
                //    MessageBox.Show("სერვერთან დაკავშირების პრობლემაა. სცადეთ თავიდან. ");
                //}
                DataTableToListView(bought_af_list, bought_af_list_dt, true);
            }
            if (sold_afs_tabpage == tab_container.SelectedTab)
            {
                //if (!WorkerThread.Spawn(delegate()
                //{
                sold_af_list_dt = conn.Sold_AF_Statistics();
                //}))
                //{
                //    MessageBox.Show("სერვერთან დაკავშირების პრობლემაა. სცადეთ თავიდან. ");
                //}
                DataTableToListView(sold_af_list, sold_af_list_dt, true);
            }
            if (zednadebebi_tabpage == tab_container.SelectedTab)
            {
                //if (!WorkerThread.Spawn(delegate()
                //{
                zed_list_dt = conn.Bought_Zed_Statistics(DateFilterSince, DateFilterUntil);
                //}))
                //{
                //  MessageBox.Show("სერვერთან დაკავშირების პრობლემაა. სცადეთ თავიდან. ");
                //}
                DataTableToListView(zed_list, zed_list_dt, true);
            }
            if (sold_zednadebebi_tabpage == tab_container.SelectedTab)
            {
                //if (!WorkerThread.Spawn(delegate()
                //{
                sold_zed_list_dt = conn.Sold_Zed_Statistics(DateFilterSince, DateFilterUntil);
                //}))
                //{
                //    MessageBox.Show("სერვერთან დაკავშირების პრობლემაა. სცადეთ თავიდან. ");
                //}
                DataTable empty_sold_zed_list_dt = new DataTable();
                #region populate_empty_sold_zed_list_dt
                foreach (ColumnHeader ch in sold_zed_list.Columns)
                {
                    empty_sold_zed_list_dt.Columns.Add(ch.Text);
                }

                foreach (DataRow dr in sold_zed_list_dt.Rows)
                {
                    for (int i = 0; i < dr.ItemArray.Length; i++)
                    {
                        DataRow dr_clone = empty_sold_zed_list_dt.NewRow();
                        if (conn.AllowSensitiveInformation)
                        {
                            dr_clone.ItemArray = dr.ItemArray;
                        }
                        else
                        {
                            object[] CloneItems = new object[dr_clone.ItemArray.Length];
                            int k = 0;
                            for (int j = 0; j < dr.ItemArray.Length; j++)
                            {
                                if (j == sold_z_roi_col_index | j == sold_z_roi_withoutVAT_col_index)
                                {
                                    continue;
                                }
                                CloneItems[k] = dr.ItemArray[j];
                                k++;
                            }
                            dr_clone.ItemArray = CloneItems;
                        }
                        empty_sold_zed_list_dt.Rows.Add(dr_clone);
                        break;
                    }
                }
                #endregion

                DataTableToListView(sold_zed_list, empty_sold_zed_list_dt, true);
            }
            if (nashtebi_tabpage == tab_container.SelectedTab)
            {
                //if (!WorkerThread.Spawn(delegate()
                //{
                rem_list_dt = conn.Rem_Statistics(ActiveStoreID);
                //}))
                //{
                //    MessageBox.Show("სერვერთან დაკავშირების პრობლემაა. სცადეთ თავიდან. ");
                //}
                DataTableToListView(rem_list, rem_list_dt, true);
            }
            if (agcera_tabpage == tab_container.SelectedTab)
            {
                //if (!WorkerThread.Spawn(delegate()
                //{
                agcera_dt = conn.Agcera_Statistics(ActiveStoreID);
                //}))
                //{
                //   MessageBox.Show("სერვერთან დაკავშირების პრობლემაა. სცადეთ თავიდან. ");
                // }
                DataTableToListView(agcera_rem_list, agcera_dt, true);
            }
            if (sold_tabpage == tab_container.SelectedTab)
            {
                soldrems_dt = conn.Sold_Rem_Statistics(ActiveStoreID, DateFilterSince, DateFilterUntil);

                DataTable empty_soldrems_dt = new DataTable();
                #region populate_empty_soldrems_dt
                foreach (ColumnHeader ch in sold_list.Columns)
                {
                    empty_soldrems_dt.Columns.Add(ch.Text);
                }

                foreach (DataRow dr in soldrems_dt.Rows)
                {
                    for (int i = 0; i < dr.ItemArray.Length; i++)
                    {
                        DataRow dr_clone = empty_soldrems_dt.NewRow();
                        if (conn.AllowSensitiveInformation)
                        {
                            dr_clone.ItemArray = dr.ItemArray;
                        }
                        else
                        {
                            object[] CloneItems = new object[dr_clone.ItemArray.Length];
                            int k = 0;
                            for (int j = 0; j < dr.ItemArray.Length; j++)
                            {
                                if (j == sold_roi_col_index)
                                {
                                    continue;
                                }
                                CloneItems[k] = dr.ItemArray[j];
                                k++;
                            }
                            dr_clone.ItemArray = CloneItems;
                        }
                        empty_soldrems_dt.Rows.Add(dr_clone);
                        break;
                    }
                }
                #endregion

                DataTableToListView(sold_list, empty_soldrems_dt, true);
            }
            if (sold_prods_tabpage == tab_container.SelectedTab)
            {
                sold_prodrem_list_dt = conn.GetSoldRemaindersByProductName(ActiveStoreID, DateFilterSince, DateFilterUntil);
                //}))
                //{
                //    MessageBox.Show("სერვერთან დაკავშირების პრობლემაა. სცადეთ თავიდან. ");
                //}
                DataTableToListView(sold_prodrem_list, sold_prodrem_list_dt, true);
            }
            if (moneytransfers_tabpage == tab_container.SelectedTab)
            {
                moneytransfers_dt = conn.MoneyTransferStatistics(ActiveStoreID, DateFilterSince, DateFilterUntil);
                //}))
                //{
                //    MessageBox.Show("სერვერთან დაკავშირების პრობლემაა. სცადეთ თავიდან. ");
                //}
                DataTableToListView(moneytransfer_list, moneytransfers_dt, true);
            }
            if (summary_tabpage == tab_container.SelectedTab)
            {
                store_summary_dt = conn.StoreSummary(ActiveStoreID);

                summary_cash_amount.Text = store_summary_dt.Rows[0][0].ToString();
            }
            if (bought_af_standard_list_tabpage == tab_container.SelectedTab)
            {
                //if (!WorkerThread.Spawn(delegate()
                //{
                bought_af_standard_list_dt = conn.Bought_AF_Standard_List();
                //}))
                //{
                //    MessageBox.Show("სერვერთან დაკავშირების პრობლემაა. სცადეთ თავიდან. ");
                //}
                DataTableToListView(bought_af_standard_list, bought_af_standard_list_dt, false);
            }
            //
            if ("ძებნა" != search_text.Text)
            {
                FilterTables(search_text.Text);
            }
            RestoreTableSelections();
            //
            UpdateStatusSums();
            //
        }

        private void RestoreTableSelections()
        {
            if (productnames_tabpage == tab_container.SelectedTab)
            {
                foreach (int i in selected_table_indices["prod_names_list"])
                {
                    if (prod_names_list.Items.Count > i)
                    {
                        prod_names_list.Items[i].Selected = true;
                    }
                }
            }
            if (suppliers_tabpage == tab_container.SelectedTab)
            {
                foreach (int i in selected_table_indices["suppliers_list"])
                {
                    if (suppliers_list.Items.Count > i)
                    {
                        suppliers_list.Items[i].Selected = true;
                    }
                }
            }
            if (buyers_tabpage == tab_container.SelectedTab)
            {
                foreach (int i in selected_table_indices["buyers_list"])
                {
                    if (buyers_list.Items.Count > i)
                    {
                        buyers_list.Items[i].Selected = true;
                    }
                }
            }
            if (bought_afs_tabpage == tab_container.SelectedTab)
            {
                foreach (int i in selected_table_indices["bought_af_list"])
                {
                    if (bought_af_list.Items.Count > i)
                    {
                        bought_af_list.Items[i].Selected = true;
                    }
                }
            }
            if (sold_afs_tabpage == tab_container.SelectedTab)
            {
                foreach (int i in selected_table_indices["sold_af_list"])
                {
                    if (sold_af_list.Items.Count > i)
                    {
                        sold_af_list.Items[i].Selected = true;
                    }
                }
            }
            if (zednadebebi_tabpage == tab_container.SelectedTab)
            {
                foreach (int i in selected_table_indices["zed_list"])
                {
                    if (zed_list.Items.Count > i)
                    {
                        zed_list.Items[i].Selected = true;
                    }
                }
            }
            if (sold_zednadebebi_tabpage == tab_container.SelectedTab)
            {
                foreach (int i in selected_table_indices["sold_zed_list"])
                {
                    if (sold_zed_list.Items.Count > i)
                    {
                        sold_zed_list.Items[i].Selected = true;
                    }
                }
            }
            if (nashtebi_tabpage == tab_container.SelectedTab)
            {
                foreach (int i in selected_table_indices["rem_list"])
                {
                    if (rem_list.Items.Count > i)
                    {
                        rem_list.Items[i].Selected = true;
                    }
                }
            }
            if (agcera_tabpage == tab_container.SelectedTab)
            {
                foreach (int i in selected_table_indices["agcera_rem_list"])
                {
                    if (agcera_rem_list.Items.Count > i)
                    {
                        agcera_rem_list.Items[i].Selected = true;
                    }
                }
            }
            if (sold_tabpage == tab_container.SelectedTab)
            {
                foreach (int i in selected_table_indices["sold_list"])
                {
                    if (sold_list.Items.Count > i)
                    {
                        sold_list.Items[i].Selected = true;
                    }
                }
            }
            if (sold_prods_tabpage == tab_container.SelectedTab)
            {
                foreach (int i in selected_table_indices["sold_prodrem_list"])
                {
                    if (sold_prodrem_list.Items.Count > i)
                    {
                        sold_prodrem_list.Items[i].Selected = true;
                    }
                }
            }
            if (moneytransfers_tabpage == tab_container.SelectedTab)
            {
                foreach (int i in selected_table_indices["moneytransfer_list"])
                {
                    if (moneytransfer_list.Items.Count > i)
                    {
                        moneytransfer_list.Items[i].Selected = true;
                    }
                }
            }
            if (bought_af_standard_list_tabpage == tab_container.SelectedTab)
            {
                foreach (int i in selected_table_indices["bought_af_standard_list"])
                {
                    if (bought_af_standard_list.Items.Count > i)
                    {
                        bought_af_standard_list.Items[i].Selected = true;
                    }
                }
            }
        }

        private void RememberTableSelections()
        {
            if (productnames_tabpage == tab_container.SelectedTab)
            {
                selected_table_indices["prod_names_list"] = prod_names_list.SelectedIndices.Cast<int>().ToArray();
            }
            if (suppliers_tabpage == tab_container.SelectedTab)
            {
                selected_table_indices["suppliers_list"] = suppliers_list.SelectedIndices.Cast<int>().ToArray();
            }
            if (buyers_tabpage == tab_container.SelectedTab)
            {
                selected_table_indices["buyers_list"] = buyers_list.SelectedIndices.Cast<int>().ToArray();
            }
            if (bought_afs_tabpage == tab_container.SelectedTab)
            {
                selected_table_indices["bought_af_list"] = bought_af_list.SelectedIndices.Cast<int>().ToArray();
            }
            if (sold_afs_tabpage == tab_container.SelectedTab)
            {
                selected_table_indices["sold_af_list"] = sold_af_list.SelectedIndices.Cast<int>().ToArray();
            }
            if (zednadebebi_tabpage == tab_container.SelectedTab)
            {
                selected_table_indices["zed_list"] = zed_list.SelectedIndices.Cast<int>().ToArray();
            }
            if (sold_zednadebebi_tabpage == tab_container.SelectedTab)
            {
                selected_table_indices["sold_zed_list"] = sold_zed_list.SelectedIndices.Cast<int>().ToArray();
            }
            if (nashtebi_tabpage == tab_container.SelectedTab)
            {
                selected_table_indices["rem_list"] = rem_list.SelectedIndices.Cast<int>().ToArray();
            }
            if (agcera_tabpage == tab_container.SelectedTab)
            {
                selected_table_indices["agcera_rem_list"] = agcera_rem_list.SelectedIndices.Cast<int>().ToArray();
            }
            if (sold_tabpage == tab_container.SelectedTab)
            {
                selected_table_indices["sold_list"] = sold_list.SelectedIndices.Cast<int>().ToArray();
            }
            if (sold_prods_tabpage == tab_container.SelectedTab)
            {
                selected_table_indices["sold_prodrem_list"] = sold_prodrem_list.SelectedIndices.Cast<int>().ToArray();
            }
            if (moneytransfers_tabpage == tab_container.SelectedTab)
            {
                selected_table_indices["moneytransfer_list"] = moneytransfer_list.SelectedIndices.Cast<int>().ToArray();
            }
            if (bought_af_standard_list_tabpage == tab_container.SelectedTab)
            {
                selected_table_indices["bought_af_standard_list"] = bought_af_standard_list.SelectedIndices.Cast<int>().ToArray();
            }
        }


        private void UpdateStatusSums()
        {
            decimal cost = 0.0m;
            decimal costWithoutVAT = 0.0m;

            if (zednadebebi_tabpage == tab_container.SelectedTab)
            {
                foreach (ListViewItem lvi in zed_list.Items)
                {
                    if ("ჯამი" == lvi.Text)
                    {
                        continue;
                    }
                    try
                    {
                        cost += ParseDecimal(lvi.SubItems[zed_list_costwithVAT_col.Index].Text);
                        costWithoutVAT += ParseDecimal(lvi.SubItems[zed_list_costwithoutVAT_col.Index].Text);
                    }
                    catch (FormatException)
                    {
                        //this is not going to happen if data integrity is safe
                    }
                }
            }
            if (sold_zednadebebi_tabpage == tab_container.SelectedTab)
            {
                foreach (ListViewItem lvi in sold_zed_list.Items)
                {
                    if ("ჯამი" == lvi.Text)
                    {
                        continue;
                    }
                    try
                    {
                        cost += ParseDecimal(lvi.SubItems[sold_z_price.Index].Text);
                        costWithoutVAT += ParseDecimal(lvi.SubItems[sold_z_VAT_tax_amount.Index].Text);
                    }
                    catch (FormatException)
                    {
                        //this is not going to happen if data integrity is safe
                    }
                }
            }
            if (bought_afs_tabpage == tab_container.SelectedTab)
            {
                foreach (ListViewItem lvi in bought_af_list.Items)
                {
                    if ("ჯამი" == lvi.Text)
                    {
                        continue;
                    }
                    try
                    {
                        cost += ParseDecimal(lvi.SubItems[af_whole_cost_col.Index].Text);
                        costWithoutVAT += ParseDecimal(lvi.SubItems[af_whole_cost_withoutVAT_col.Index].Text);
                    }
                    catch (FormatException)
                    {
                        //this is not going to happen if data integrity is safe
                    }
                }
            }
            if (sold_afs_tabpage == tab_container.SelectedTab)
            {
                foreach (ListViewItem lvi in sold_af_list.Items)
                {
                    if ("ჯამი" == lvi.Text)
                    {
                        continue;
                    }
                    try
                    {
                        cost += ParseDecimal(lvi.SubItems[sold_af_cost_col.Index].Text);
                        costWithoutVAT += ParseDecimal(lvi.SubItems[sold_af_cost_withoutVAT_col.Index].Text);
                    }
                    catch (FormatException)
                    {
                        //this is not going to happen if data integrity is safe
                    }
                }
            }

            if (nashtebi_tabpage == tab_container.SelectedTab)
            {
                foreach (ListViewItem lvi in rem_list.Items)
                {
                    if ("ჯამი" == lvi.Text)
                    {
                        continue;
                    }
                    try
                    {
                        cost += ParseDecimal(lvi.SubItems[rem_list_remaining_whole_price_col.Index].Text);
                        costWithoutVAT += ParseDecimal(lvi.SubItems[rem_list_cost_withoutVAT_col.Index].Text);
                    }
                    catch (FormatException)
                    {
                        //this is not going to happen if data integrity is safe
                    }
                }
            }

            if (sold_tabpage == tab_container.SelectedTab)
            {
                foreach (ListViewItem lvi in sold_list.Items)
                {
                    if ("ჯამი" == lvi.Text)
                    {
                        continue;
                    }
                    if (0 == ActiveStoreID | ActiveStoreID.ToString() == lvi.SubItems[sold_storeid_col.Index].Text)
                    {
                        try
                        {
                            cost += ParseDecimal(lvi.SubItems[sold_income_col.Index].Text);
                            if (sold_list.Columns.Contains(sold_roi_col))
                            {
                                costWithoutVAT += ParseDecimal(lvi.SubItems[sold_roi_col.Index].Text);
                            }
                        }
                        catch (FormatException)
                        {
                            //this is not going to happen if data integrity is safe
                        }
                    }
                }
            }


            sb_sum_lbl.Text = "ჯამი: " + cost.ToString("N") + " ლარი";
            sb_sum_withoutVAT_lbl.Text = "ჯამი დღგ–ს გარეშე: " + costWithoutVAT.ToString("N") + " ლარი";
            if (sold_tabpage == tab_container.SelectedTab)
            {
                sb_sum_lbl.Text = "აღებული თანხა: " + cost.ToString("N") + " ლარი";
                sb_sum_withoutVAT_lbl.Text = "მოგება: " + costWithoutVAT.ToString("N") + " ლარი";
            }
            if (sold_zednadebebi_tabpage == tab_container.SelectedTab)
            {
                sb_sum_lbl.Text = "ჯამური ფასი: " + cost.ToString("N") + " ლარი";
                sb_sum_withoutVAT_lbl.Text = "ჯამური დღგ: " + costWithoutVAT.ToString("N") + " ლარი";
            }
        }

        private void PopulateSupplierList(string suggestion_arg)
        {
            suppliers_list.Items.Clear();
            Supplier[] AllSuppliers = conn.AllSuppliers();
            foreach (Supplier nextSupplier in AllSuppliers)
            {
                if (nextSupplier.saxeli.Contains(suggestion_arg))
                {
                    string[] supplier_attribs = new string[5];
                    supplier_attribs[0] = nextSupplier.saxeli;
                    supplier_attribs[1] = nextSupplier.saidentifikacio_kodi;
                    supplier_attribs[2] = nextSupplier.address;
                    suppliers_list.Items.Add(new ListViewItem(supplier_attribs));
                }
            }
        }

        private void PopulateBuyerList()
        {
            buyers_list.Items.Clear();
            Buyer[] AllBuyers = conn.AllBuyers();
            foreach (Buyer nextBuyer in AllBuyers)
            {
                string[] buyer_attribs = new string[5];
                buyer_attribs[0] = nextBuyer.saxeli;
                buyer_attribs[1] = nextBuyer.saidentifikacio_kodi;
                buyer_attribs[2] = nextBuyer.address;
                buyers_list.Items.Add(new ListViewItem(buyer_attribs));
            }
        }

        public static void DataTableToListView(ListView listview_target, DataTable cxrili, bool sumAtTheEnd)
        {
            listview_target.Items.Clear();

            ListViewItem sum_lvi = new ListViewItem("ჯამი");
            sum_lvi.Font = new Font(listview_target.Font, FontStyle.Bold);
            bool firstColIter = true;
            foreach (DataColumn nextCol in cxrili.Columns)
            {
                if (firstColIter)
                {
                    firstColIter = false;
                    continue;
                }
                sum_lvi.SubItems.Add("0");
            }

            foreach (DataRow nextRow in cxrili.Rows)
            {
                ListViewItem next_lvi = new ListViewItem(nextRow[0].ToString());
                bool firstIter = true;
                foreach (DataColumn nextCol in cxrili.Columns)
                {
                    if (firstIter)
                    {
                        firstIter = false;
                        continue;
                    }
                    next_lvi.SubItems.Add(nextRow[nextCol].ToString());

                    if (sumAtTheEnd)
                    {
                        decimal currAccum = ParseDecimal(sum_lvi.SubItems[nextCol.Ordinal].Text);
                        decimal nextItem = 0.0m;
                        if (Regex.IsMatch(nextRow[nextCol].ToString(), @"^[-+]?[0-9]*[,\.]?[0-9]+$", RegexOptions.CultureInvariant | RegexOptions.Compiled))
                        {
                            nextItem = ParseDecimal(nextRow[nextCol].ToString());
                        }
                        sum_lvi.SubItems[nextCol.Ordinal].Text = (currAccum + nextItem).ToString();
                    }
                }
                listview_target.Items.Add(next_lvi);
            }
            //add sum item
            if (sumAtTheEnd)
            {
                foreach (ListViewItem.ListViewSubItem lvsi in sum_lvi.SubItems)
                {
                    if ("ჯამი" == lvsi.Text)
                    {
                        continue;
                    }
                    lvsi.Text = ParseDecimal(lvsi.Text).ToString("N");
                }
                listview_target.Items.Add(sum_lvi);
            }
        }

        public static DataTable ListViewToDataTable(ListView listview_target)
        {
            DataTable ret_table = new DataTable();
            foreach (ColumnHeader ch in listview_target.Columns)
            {
                ret_table.Columns.Add(ch.Text);
            }
            foreach (ListViewItem lvi in listview_target.Items)
            {
                DataRow dr = ret_table.NewRow();
                //for (int i = 0; i < lvi.SubItems.Count; i++)
                for (int i = 0; i < listview_target.Columns.Count; i++)
                {
                    dr[i] = lvi.SubItems[i].Text;
                }
                ret_table.Rows.Add(dr);
            }
            return ret_table;
        }

        public static string ListViewToCSV(ListView target_lv)
        {
            string lines = "";
            //save headers
            foreach (ColumnHeader ch in target_lv.Columns)
            {
                lines += "\"" + ch.Text + "\"" + "\t";
            }
            lines += "\r\n";

            foreach (ListViewItem lvi in target_lv.Items)
            {
                foreach (ListViewItem.ListViewSubItem lvsi in lvi.SubItems)
                {
                    lines += "\"" + lvsi.Text + "\"" + "\t";
                }
                lines += "\r\n";
            }
            return lines;
        }

        public static string ListViewToDSV(ListView target_lv)
        {
            string lines = "";
            //save headers
            foreach (ColumnHeader ch in target_lv.Columns)
            {
                lines += ch.Text + "\t";
            }
            lines += "\r\n";

            foreach (ListViewItem lvi in target_lv.Items)
            {
                foreach (ListViewItem.ListViewSubItem lvsi in lvi.SubItems)
                {
                    lines += lvsi.Text + "\t";
                }
                lines += "\r\n";
            }
            return lines;
        }

        public static DataTable DataTable_AddSum(DataTable target_dt)
        {
            DataTable ret_dt = target_dt.Copy();
            DataRow sum_row = ret_dt.NewRow();
            sum_row[0] = "ჯამი";
            for (int i = 0; i < ret_dt.Columns.Count; i++)
            {
                if (0 == i)
                {
                    continue;
                }
                sum_row[i] = 0.0m;
            }

            foreach (DataRow nextRow in ret_dt.Rows)
            {
                for (int j = 0; j < ret_dt.Columns.Count; j++)
                {
                    if (0 == j)
                    {
                        continue;
                    }
                    decimal currAccum = ParseDecimal(sum_row[j].ToString());//ParseDecimal(sum_lvi.SubItems[nextCol.Ordinal].Text);
                    decimal nextItem = 0.0m;
                    if (Regex.IsMatch(nextRow[j].ToString(), @"^[-+]?[0-9]*[,\.]?[0-9]+$", RegexOptions.CultureInvariant | RegexOptions.Compiled))
                    {
                        nextItem = ParseDecimal(nextRow[j].ToString());
                    }
                    sum_row[j] = currAccum + nextItem;
                }
            }
            //add sum item
            ret_dt.Rows.Add(sum_row);
            //return
            return ret_dt;
            //end
        }

        private void prod_names_list_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            /*
            IEnumerable<Product> query = new List<Product>();
            if (e.Column == pnames_bcode_col.Index)
            {
                query = from p in all_products
                        orderby p.barcode ascending
                        select p;
            }
            else if (e.Column == pnames_name_col.Index)
            {
                query = from p in all_products
                        orderby p.name ascending
                        select p;
            }
            prod_names_list.Items.Clear();

            foreach (Product nextProdName in query)
            {
                string[] byprod_rem_items = new string[4];
                byprod_rem_items[0] = nextProdName.barcode;
                byprod_rem_items[1] = nextProdName.name;
                prod_names_list.Items.Add(new ListViewItem(byprod_rem_items));
            }
             * */




            /*DataTable orderby_dt = new DataTable();
            IEnumerable<DataRow> initial_rows=prodrem_list_dt.AsEnumerable();
            IEnumerable<DataRow> query = new List<DataRow>();//prodrem_list_dt.AsEnumerable();

            query = from r in initial_rows
                    orderby r[e.Column]
                    select r;


            prod_names_list.Items.Clear();
           // prodrem_list_dt.Rows.Clear();
            foreach (DataRow nextR in query)
            {
                orderby_dt.Rows.Add(nextR);
                //prodrem_list_dt.Rows.Add(nextR);
            }
            DataTableToListView(prod_names_list, prodrem_list_dt);
            DataTableToListView(prod_names_list, orderby_dt);*/

        }

        private void prod_list_edit_cmi_Click(object sender, EventArgs e)
        {
            if (0 < prod_names_list.SelectedItems.Count && "ჯამი" != prod_names_list.SelectedItems[0].Text)
            {
                EditProduct_Form editprod_frm = new EditProduct_Form();
                editprod_frm.Show();
                editprod_frm.Controls["barcode_txt"].Text = prod_names_list.Items[prod_names_list.SelectedIndices[0]].SubItems[pnames_bcode_col.Index].Text;
                editprod_frm.Controls["name_txt"].Text = prod_names_list.Items[prod_names_list.SelectedIndices[0]].SubItems[pnames_name_col.Index].Text;
                ((CheckBox)editprod_frm.Controls["vat_ckb"]).Checked = conn.GetProductByBarCode(prod_names_list.Items[prod_names_list.SelectedIndices[0]].SubItems[pnames_bcode_col.Index].Text).usesVAT;
            }
        }

        private void tb_store_chooser_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActiveStoreID = tb_store_chooser.SelectedIndex;

            RefreshTabs();
            //
        }

        private void sell_submit_btn_Click(object sender, EventArgs e)
        {
            sell_clicked = true;

            bool are_we_using_check = using_check_ckb.Checked;

            Zednadebi gayidva_zed = null;
            AngarishFaqtura gayidva_af = null;
            List<Remainder> zed_prod_list = new List<Remainder>();
            DataProvider.PaymentType paying_method_now = DataProvider.PaymentType.Nagdi;
            if ("ნაღდი" == ckb_pay_method.Text)
            {
                paying_method_now = DataProvider.PaymentType.Nagdi;
            }
            else if ("კონსიგნაცია" == ckb_pay_method.Text)
            {
                paying_method_now = DataProvider.PaymentType.Konsignacia;
            }
            else if ("უნაღდო" == ckb_pay_method.Text)
            {
                paying_method_now = DataProvider.PaymentType.Unagdo;
            }


            foreach (DataGridViewRow nextRow in sell_list.Rows)
            {
                if (!nextRow.IsNewRow)
                {
                    Remainder nextRemS1 = new Remainder();

                    if (
                            null == nextRow.Cells["sell_barcode_col"].Value |
                            null == nextRow.Cells["sell_capacity_col"].Value |
                            (null == nextRow.Cells["sell_piece_amount_col"].Value && null == nextRow.Cells["sell_pack_amount_col"].Value) |
                            (null == nextRow.Cells["sell_piece_price_col"].Value && null == nextRow.Cells["sell_pack_price_col"].Value) |
                            (null != nextRow.Cells["sell_piece_price_col"].Value && 0.0m >= ParseDecimal(nextRow.Cells["sell_piece_price_col"].Value.ToString()))
                        )
                    {
                        HighlightNonCompleteFields(nextRow);

                        sell_status_lbl.Text = "გთხოვთ შეავსოთ აუცილებელი ველები!";
                        return;
                    }
                    else
                    {
                        string nbarcode = nextRow.Cells["sell_barcode_col"].Value.ToString();
                        decimal ncapacity = ParseDecimal(nextRow.Cells["sell_capacity_col"].Value.ToString());
                        decimal npiece_price = ParseDecimal(nextRow.Cells["sell_piece_price_col"].Value.ToString());

                        decimal n_pack_count = 0.0m;
                        decimal n_piece_count = 0.0m;
                        decimal n_whole_count = 0.0m;
                        if (null != nextRow.Cells["sell_pack_amount_col"].Value)
                        {
                            n_pack_count = ParseDecimal(nextRow.Cells["sell_pack_amount_col"].Value.ToString());
                        }
                        if (null != nextRow.Cells["sell_piece_amount_col"].Value)
                        {
                            n_piece_count = ParseDecimal(nextRow.Cells["sell_piece_amount_col"].Value.ToString());
                        }

                        n_whole_count = n_pack_count * ncapacity + n_piece_count;

                        nextRemS1.storehouse_id = ActiveStoreID;
                        nextRemS1.product_barcode = nbarcode;
                        nextRemS1.supplier_ident = Buyer.xelze.saidentifikacio_kodi;
                        nextRemS1.zednadebis_nomeri = "0";
                        nextRemS1.pack_capacity = ncapacity;
                        nextRemS1.buy_price = npiece_price;
                        nextRemS1.formal_buy_price = npiece_price;
                        nextRemS1.sell_price = npiece_price;
                        nextRemS1.formal_sell_price = npiece_price;
                        nextRemS1.initial_pieces = n_whole_count;
                        nextRemS1.remaining_pieces = n_whole_count;

                        /*nextRemS2.storehouse_id = 2;
                        nextRemS2.product_barcode = nbarcode;
                        nextRemS2.supplier_ident = Buyer.xelze.saidentifikacio_kodi;
                        nextRemS2.zednadebis_nomeri = "0";
                        nextRemS2.pack_capacity = ncapacity;
                        nextRemS2.buy_price = npiece_price;
                        nextRemS2.formal_buy_price = npiece_price;
                        nextRemS2.sell_price = 0.0m;
                        nextRemS2.formal_sell_price = 0.0m;
                        nextRemS2.initial_pieces = n_whole_count;
                        nextRemS2.remaining_pieces = n_whole_count;
                        */

                        if (n_whole_count > 0)
                        {
                            zed_prod_list.Add(nextRemS1);
                        }
                        /*
                        if (nstore1_count > 0)
                        {
                            zed_prod_list.Add(nextRemS1);
                        }                        
                        if (nstore2_count > 0)
                        {
                            zed_prod_list.Add(nextRemS2);
                        }*/

                    }


                }
                else
                {
                    //Last, unused row (IsNewRow)
                }
            }//foreach datagridviewrow

            if (0 == zed_prod_list.Count)
            {
                MessageBox.Show("პროდუქტების სიის გარეშე გაყიდვა არ მოხდება!");
                return;
            }
            Buyer xelze_myidveli = (-1 != cmb_xelze_myidveli.SelectedIndex) ? all_buyers[cmb_xelze_myidveli.SelectedIndex] : Buyer.xelze;

            SellOrder shemotana_SO;
            shemotana_SO = new SellOrder(DateTime.Now, are_we_using_check, paying_method_now, xelze_myidveli, null, zed_prod_list.ToArray(), null);//passing null is normal, we there check for null reference to determine it was passed

            info trans_res = ProductInfo_Main_Form.conn.AddSellOrder(shemotana_SO);
            MessageBox.Show("TODO in DataProvider: SPROC RETVAL??? " + trans_res.errcode.ToString() + ":" + trans_res.details);
            if (501 == trans_res.errcode | 0 == trans_res.errcode)
            {
                MessageBox.Show("პროდუქტები გაყიდულია.");

                if (DataProvider.PaymentType.Nagdi == paying_method_now)
                {
                    decimal selling_rem_sum = 0.0m;
                    //(from z_nextrem in zed_prod_list
                    //select (z_nextrem.sell_price * z_nextrem.initial_pieces)).Sum();
                    foreach (Remainder next_selling_rem in zed_prod_list.ToArray())
                    {
                        selling_rem_sum += next_selling_rem.sell_price * next_selling_rem.initial_pieces;
                    }
                    //gayidulis gadaricxva
                    info payforsellingorder_info = ProductInfo_Main_Form.conn.TransferMoney(xelze_myidveli.saidentifikacio_kodi, DataProvider.MoneyTransferType.Take, DateTime.Now, selling_rem_sum, typeof(Buyer), DataProvider.MoneyTransferPurpose.PayFor, ActiveStoreID, null/*typeof(SellOrder)*/, null/*add_SO.id*/);
                    MessageBox.Show(payforsellingorder_info.details, payforsellingorder_info.errcode.ToString());
                }
                sell_list.Rows.Clear();
                sell_clicked = false;

                Sell_Row_Pricing = new decimal[2000];
                UpdateSumSellPrice();
            }
            else if (404 == trans_res.errcode)
            {
                MessageBox.Show("ამ რაოდენობის პროდუქტები საწყობში აღარაა დარჩენილი! ");
            }
            else
            {
                MessageBox.Show("მოხდა შეცდომა. პროდუქტები არ გაყიდულა! ");
            }
        }

        private void tb_print_btn_Click(object sender, EventArgs e)
        {
            if (nashtebi_tabpage == tab_container.SelectedTab)
            {
                PrintPreview_Form pprev_frm = new PrintPreview_Form();
                pprev_frm.Show();
                pprev_frm.DrawData(ListViewToDataTable(rem_list), true);
            }
            if (zednadebebi_tabpage == tab_container.SelectedTab)
            {

                PrintPreview_Form pprev_frm = new PrintPreview_Form();
                pprev_frm.Show();
                pprev_frm.DrawData(ListViewToDataTable(zed_list), true);
            }
            if (sold_zednadebebi_tabpage == tab_container.SelectedTab)
            {

                PrintPreview_Form pprev_frm = new PrintPreview_Form();
                pprev_frm.Show();
                pprev_frm.DrawData(ListViewToDataTable(sold_zed_list), true);
            }
            if (bought_afs_tabpage == tab_container.SelectedTab)
            {

                PrintPreview_Form pprev_frm = new PrintPreview_Form();
                pprev_frm.Show();
                pprev_frm.DrawData(ListViewToDataTable(bought_af_list), true);
            }
            if (sold_afs_tabpage == tab_container.SelectedTab)
            {

                PrintPreview_Form pprev_frm = new PrintPreview_Form();
                pprev_frm.Show();
                pprev_frm.DrawData(ListViewToDataTable(sold_af_list), true);
            }
            if (suppliers_tabpage == tab_container.SelectedTab)
            {

                PrintPreview_Form pprev_frm = new PrintPreview_Form();
                pprev_frm.Show();
                pprev_frm.DrawData(ListViewToDataTable(suppliers_list), true);
            }
            if (buyers_tabpage == tab_container.SelectedTab)
            {

                PrintPreview_Form pprev_frm = new PrintPreview_Form();
                pprev_frm.Show();
                pprev_frm.DrawData(ListViewToDataTable(buyers_list), true);
            }
            if (productnames_tabpage == tab_container.SelectedTab)
            {

                PrintPreview_Form pprev_frm = new PrintPreview_Form();
                pprev_frm.Show();
                pprev_frm.DrawData(ListViewToDataTable(prod_names_list), true);
            }
            if (sell_tabpage == tab_container.SelectedTab)
            {
            }
            if (agcera_tabpage == tab_container.SelectedTab)
            {

                PrintPreview_Form pprev_frm = new PrintPreview_Form();
                pprev_frm.Show();
                pprev_frm.DrawData(ListViewToDataTable(agcera_rem_list), true);
            }
            if (sold_tabpage == tab_container.SelectedTab)
            {

                PrintPreview_Form pprev_frm = new PrintPreview_Form();
                pprev_frm.Show();
                pprev_frm.DrawData(ListViewToDataTable(sold_list), true);
            }
            if (bought_af_standard_list_tabpage == tab_container.SelectedTab)
            {

                PrintPreview_Form pprev_frm = new PrintPreview_Form();
                pprev_frm.Show();
                pprev_frm.DrawData(ListViewToDataTable(bought_af_standard_list), false);
            }
        }

        private void agcera_rem_list_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmi_rem_list_supplier_info_Click(object sender, EventArgs e)
        {
            if (0 < rem_list.SelectedItems.Count && "ჯამი" != rem_list.SelectedItems[0].Text)
            {
                tab_container.SelectedTab = suppliers_tabpage;
                int supp_name_col_ind = rem_list_supplier_header.Index;
                search_text.Text = rem_list.SelectedItems[0].SubItems[supp_name_col_ind].Text;
            }
        }

        private void cmi_this_supplier_remainders_Click(object sender, EventArgs e)
        {
            if (0 < suppliers_list.SelectedItems.Count && "ჯამი" != suppliers_list.SelectedItems[0].Text)
            {
                tab_container.SelectedTab = nashtebi_tabpage;
                int supp_list_name_col_ind = suppliers_list_name_header.Index;
                search_text.Text = suppliers_list.SelectedItems[0].SubItems[supp_list_name_col_ind].Text;
            }
        }

        private void cmi_supplier_money_transfer_Click(object sender, EventArgs e)
        {
            if (suppliers_list.SelectedItems.Count > 0 && "ჯამი" != suppliers_list.SelectedItems[0].Text)
            {
                MoneyTransfer_Form supp_transf_frm = new MoneyTransfer_Form();
                supp_transf_frm.Show();
                supp_transf_frm.LoadInterface(typeof(Supplier), DataProvider.MoneyTransferType.Give, suppliers_list.SelectedItems[0].SubItems[suppliers_list_ident_code_header.Index].Text, ActiveStoreID, DataProvider.MoneyTransferPurpose.SimpleTransfer, null, null);
                supp_transf_frm.FormClosed += new FormClosedEventHandler(supp_transf_frm_FormClosed);
            }
        }

        void supp_transf_frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            RefreshTabs();
        }

        private void using_check_ckb_CheckedChanged(object sender, EventArgs e)
        {
            if (true == using_check_ckb.Checked)
            {
                all_valid_rems = conn.GetValidRemainders(ActiveStoreID, true);
            }
            else
            {
                all_valid_rems = conn.GetValidRemainders(ActiveStoreID, false);
            }
        }

        private void cm_supplier_edit_Click(object sender, EventArgs e)
        {
            if (0 < suppliers_list.SelectedIndices.Count && "ჯამი" != suppliers_list.SelectedItems[0].Text)
            {
                AddSupplier_Form changesupp_frm = new AddSupplier_Form();
                changesupp_frm.Show();
                changesupp_frm.job = AddSupplier_Form.ActionType.Edit;

                changesupp_frm.Text = "მომწოდებლის შეცვლა";
                changesupp_frm.supplier_name_txt.Text = suppliers_dt.Rows[suppliers_list.SelectedIndices[0]][0].ToString();
                changesupp_frm.supplier_ident_code_txt.Text = suppliers_dt.Rows[suppliers_list.SelectedIndices[0]][1].ToString();
                changesupp_frm.supplier_address_txt.Text = suppliers_dt.Rows[suppliers_list.SelectedIndices[0]][2].ToString();
                changesupp_frm.FormClosed += delegate(object senderChangeSuppForm, FormClosedEventArgs eChangeSuppForm)
                {
                    RefreshTabs();
                };
            }
        }

        private void cmi_sold_details_Click(object sender, EventArgs e)
        {
            if (0 < sold_list.SelectedItems.Count && "ჯამი" != sold_list.SelectedItems[0].Text)
            {
                SellOrderDetails_Form cmi_sod_details_frm = new SellOrderDetails_Form();
                cmi_sod_details_frm.Show();
                // bug 38
                cmi_sod_details_frm.ShowSellOrderDetails(Int32.Parse(sold_list.SelectedItems[0].SubItems[sold_id_col.Index].Text)
                    , sold_list.SelectedItems[0].SubItems[sold_zed_ident_col.Index].Text
                    , sold_list.SelectedItems[0].SubItems[sold_using_check_col.Index].Text);
                cmi_sod_details_frm.FormClosed += new FormClosedEventHandler(cmi_sod_details_frm_FormClosed);
            }
        }

        void cmi_sod_details_frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            RefreshTabs();
        }

        private void cmi_zed_print_Click(object sender, EventArgs e)
        {
            if (0 < sold_zed_list.SelectedItems.Count && "ჯამი" != sold_zed_list.SelectedItems[0].Text)
            {
                SellOrder SO_byZed = conn.GetSellOrderByZedCode(sold_zed_list.SelectedItems[0].SubItems[sold_z_ident_code_col.Index].Text);
                Bitmap[] zed_print_bmp = BitmapGenerator.RenderZednadebi(SO_byZed);
                PrintPreview_Form prevw_frm = new PrintPreview_Form();
                prevw_frm.Show();
                string buyer_ident = (from all_b in all_buyers
                                      where all_b.saxeli == sold_zed_list.SelectedItems[0].SubItems[sold_z_buyer_col.Index].Text
                                      select all_b.saidentifikacio_kodi).ToArray()[0];
                //count distinct barcodes
                int soldzed_rem_count = conn.SoldZedRemCount(sold_zed_list.SelectedItems[0].SubItems[sold_z_ident_code_col.Index].Text, true);
                prevw_frm.DrawBitmaps(zed_print_bmp, false, true, buyer_ident, soldzed_rem_count);
            }
        }

        private void cmi_incoming_zeds_details_Click(object sender, EventArgs e)
        {
            if (0 < zed_list.SelectedItems.Count && "ჯამი" != zed_list.SelectedItems[0].Text)
            {
                SellOrderDetails_Form boughtzed_details_frm = new SellOrderDetails_Form();
                boughtzed_details_frm.Show();
                string supplier_ident_str = (from all_s in all_suppliers
                                             where all_s.saxeli == zed_list.SelectedItems[0].SubItems[zed_supplier_col.Index].Text
                                             select all_s.saidentifikacio_kodi).ToArray()[0];
                boughtzed_details_frm.ShowBoughtZedDetails(supplier_ident_str, zed_list.SelectedItems[0].Text, DateTime.Parse(zed_list.SelectedItems[0].SubItems[zed_date_col.Index].Text));
                boughtzed_details_frm.FormClosed += new FormClosedEventHandler(boughtzed_details_frm_FormClosed);
            }
        }

        void boughtzed_details_frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            RefreshTabs();
        }

        private void cmi_sold_zed_details_Click(object sender, EventArgs e)
        {
            if (0 < sold_zed_list.SelectedItems.Count && "ჯამი" != sold_zed_list.SelectedItems[0].Text)
            {
                SellOrderDetails_Form soldzed_details_frm = new SellOrderDetails_Form();
                soldzed_details_frm.Show();
                string buyer_ident_str = (from all_b in all_buyers
                                          where all_b.saxeli == sold_zed_list.SelectedItems[0].SubItems[sold_z_buyer_col.Index].Text
                                          select all_b.saidentifikacio_kodi).ToArray()[0];
                soldzed_details_frm.ShowSoldZedDetails(buyer_ident_str, sold_zed_list.SelectedItems[0].Text, DateTime.Parse(sold_zed_list.SelectedItems[0].SubItems[sold_z_date_col.Index].Text));
                soldzed_details_frm.FormClosed += new FormClosedEventHandler(soldzed_details_frm_FormClosed);
            }
        }

        void soldzed_details_frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            RefreshTabs();
        }

        private void cmi_prod_list_delete_dublicates_Click(object sender, EventArgs e)
        {
            if (0 < prod_names_list.SelectedItems.Count && "ჯამი" != prod_names_list.SelectedItems[0].Text)
            {
                info RemProdRes = conn.RemoveProduct(prod_names_list.SelectedItems[0].Text);
                MessageBox.Show(RemProdRes.details, RemProdRes.errcode.ToString());
                prodrem_list_dt = conn.GetRemaindersByProductName(ActiveStoreID);
                DataTableToListView(prod_names_list, prodrem_list_dt, true);
            }
        }

        private void cmi_this_supplier_zeds_Click(object sender, EventArgs e)
        {
            if (0 < suppliers_list.SelectedItems.Count && "ჯამი" != suppliers_list.SelectedItems[0].Text)
            {
                tab_container.SelectedTab = zednadebebi_tabpage;
                int supp_list_name_col_ind = suppliers_list_name_header.Index;
                search_text.Text = suppliers_list.SelectedItems[0].SubItems[supp_list_name_col_ind].Text;
            }
        }

        private void cmi_buyer_money_transfer_Click(object sender, EventArgs e)
        {
            if (buyers_list.SelectedItems.Count > 0 && "ჯამი" != buyers_list.SelectedItems[0].Text)
            {
                MoneyTransfer_Form buyer_transf_frm = new MoneyTransfer_Form();
                buyer_transf_frm.Show();
                buyer_transf_frm.LoadInterface(typeof(Buyer), DataProvider.MoneyTransferType.Take, buyers_list.SelectedItems[0].SubItems[buyer_ident_col.Index].Text, ActiveStoreID, DataProvider.MoneyTransferPurpose.SimpleTransfer, null, null);
                buyer_transf_frm.FormClosed += new FormClosedEventHandler(buyer_transf_frm_FormClosed);
            }

        }

        void buyer_transf_frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            RefreshTabs();
        }

        private void cmi_incoming_zeds_edit_Click(object sender, EventArgs e)
        {
            if (0 < zed_list.SelectedItems.Count && "ჯამი" != zed_list.SelectedItems[0].Text)
            {
                SellOrderDetails_Form sod_details_frm = new SellOrderDetails_Form();
                sod_details_frm.Show();
                string supplier_ident_str = (from all_s in all_suppliers
                                             where all_s.saxeli == zed_list.SelectedItems[0].SubItems[zed_supplier_col.Index].Text
                                             select all_s.saidentifikacio_kodi).ToArray()[0];
                sod_details_frm.ShowBoughtZedDetails(supplier_ident_str, zed_list.SelectedItems[0].Text, DateTime.Parse(zed_list.SelectedItems[0].SubItems[zed_date_col.Index].Text));
                sod_details_frm.FormClosed += new FormClosedEventHandler(sod_details_frm_FormClosed);
            }
        }

        void sod_details_frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            RefreshTabs();
        }

        private void cmi_sold_edit_Click(object sender, EventArgs e)
        {
            if (null != sold_list.SelectedItems[0] && "ჯამი" != sold_list.SelectedItems[0].Text)
            {
                SellOrderDetails_Form sold_details_frm = new SellOrderDetails_Form();
                sold_details_frm.Show();
                sold_details_frm.ShowSellOrderDetails(Int32.Parse(sold_list.SelectedItems[0].Text)
                    , sold_list.SelectedItems[0].SubItems[sold_zed_ident_col.Index].Text
                    , sold_list.SelectedItems[0].SubItems[sold_using_check_col.Index].Text);
                sold_details_frm.FormClosed += new FormClosedEventHandler(sold_details_frm_FormClosed);
            }
        }

        void sold_details_frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            RefreshTabs();
        }

        private void cmi_split_rems_Click(object sender, EventArgs e)
        {
            if (0 < rem_list.SelectedItems.Count && "ჯამი" != rem_list.SelectedItems[0].Text)
            {
                SplitRemainder_Form splitrems_frm = new SplitRemainder_Form();
                splitrems_frm.Show();
                splitrems_frm.LoadRemainders(rem_list.SelectedItems[0].SubItems[rem_list_barcode_header.Index].Text);
            }
        }

        private void cmi_supp_oper_hist_Click(object sender, EventArgs e)
        {
            if (suppliers_list.SelectedItems.Count > 0 && "ჯამი" != suppliers_list.SelectedItems[0].Text)
            {
                tab_container.SelectedTab = moneytransfers_tabpage;
                search_text.Text = suppliers_list.SelectedItems[0].SubItems[suppliers_list_name_header.Index].Text;
            }
        }

        private void cmi_buyer_oper_hist_Click(object sender, EventArgs e)
        {
            if (buyers_list.SelectedItems.Count > 0 && "ჯამი" != buyers_list.SelectedItems[0].Text)
            {
                tab_container.SelectedTab = moneytransfers_tabpage;
                search_text.Text = buyers_list.SelectedItems[0].SubItems[buyer_name_col.Index].Text;
            }
        }

        private void cmb_xelze_myidveli_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool valid_buyer = false;
            foreach (Buyer b in all_buyers)
            {
                if (cmb_xelze_myidveli.Text == b.saxeli)
                {
                    valid_buyer = true;
                    break;
                }
            }
            ckb_pay_method.Enabled = valid_buyer;
        }

        private void cmb_xelze_myidveli_TextChanged(object sender, EventArgs e)
        {
            bool valid_buyer = false;
            foreach (Buyer b in all_buyers)
            {
                if (cmb_xelze_myidveli.Text == b.saxeli)
                {
                    valid_buyer = true;
                    break;
                }
            }
            ckb_pay_method.Enabled = valid_buyer;
            if (!valid_buyer)
            {
                ckb_pay_method.SelectedIndex = 0;
            }
        }

        private void cmi_incoming_zeds_remove_Click(object sender, EventArgs e)
        {
            if (zed_list.SelectedItems.Count > 0 && "ჯამი" != zed_list.SelectedItems[0].Text)
            {
                string rmzed_ident = zed_list.SelectedItems[0].SubItems[zed_ident_col.Index].Text;
                string rmzed_supp_ident = (from al_s in all_suppliers
                                           where al_s.saxeli == zed_list.SelectedItems[0].SubItems[zed_supplier_col.Index].Text
                                           select al_s.saidentifikacio_kodi).ToArray()[0];
                if (DialogResult.Yes == MessageBox.Show("დარწმუნებული ხართ, რომ გსურთ ზედნადები N. " + zed_list.SelectedItems[0].SubItems[zed_ident_col.Index].Text + "-ს ამოშლა?", "დადასტურება!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    info remremainder_info = info.niy();
                    remremainder_info = ProductInfo_Main_Form.conn.RemoveZednadebi(rmzed_ident, "Buy", rmzed_supp_ident);

                    MessageBox.Show(remremainder_info.details, remremainder_info.errcode.ToString());

                    RefreshTabs();
                }
            }
        }

        private void sb_refresh_btn_Click(object sender, EventArgs e)
        {
            RefreshTabs();
        }

        private void cmi_incoming_zeds_payfor_Click(object sender, EventArgs e)
        {
            if (zed_list.SelectedItems.Count > 0 && "ჯამი" != zed_list.SelectedItems[0].Text)
            {
                if (DialogResult.Yes == MessageBox.Show("ნამდვილად გსურთ ზედნადების ვალის დაფარვა?", "დადასტურება", MessageBoxButtons.YesNo))
                {
                    string payfor_zed_supp_name = zed_list.SelectedItems[0].SubItems[zed_supplier_col.Index].Text;
                    Supplier payfor_zed_supplier = (from pf_s in all_suppliers where pf_s.saxeli == payfor_zed_supp_name select pf_s).ToArray()[0];
                    string payfor_zed_ident = zed_list.SelectedItems[0].SubItems[zed_ident_col.Index].Text;
                    decimal payfor_zed_cost = Utilities.Utilities.ParseDecimal(zed_list.SelectedItems[0].SubItems[zed_list_costwithVAT_col.Index].Text);

                    info payforincomingzed_info = ProductInfo_Main_Form.conn.TransferMoney(payfor_zed_supplier.saidentifikacio_kodi, DataProvider.MoneyTransferType.Give, DateTime.Now, payfor_zed_cost, typeof(Supplier), DataProvider.MoneyTransferPurpose.PayFor, ActiveStoreID, typeof(Zednadebi), payfor_zed_ident);
                    MessageBox.Show(payforincomingzed_info.details, payforincomingzed_info.errcode.ToString());

                    RefreshTabs();
                }
            }
            else
            {
                MessageBox.Show("ზედნადები არ არის მონიშნული!");
            }
        }

        private void cmi_sold_zed_payfor_Click(object sender, EventArgs e)
        {
            if (sold_zed_list.SelectedItems.Count > 0 && "ჯამი" != sold_zed_list.SelectedItems[0].Text)
            {
                if (DialogResult.Yes == MessageBox.Show("ნამდვილად გსურთ ზედნადების ვალის დაფარვა?", "დადასტურება", MessageBoxButtons.YesNo))
                {
                    string payfor_zed_buyer_name = sold_zed_list.SelectedItems[0].SubItems[sold_z_buyer_col.Index].Text;
                    Buyer payfor_zed_buyer = (from pf_b in all_buyers where pf_b.saxeli == payfor_zed_buyer_name select pf_b).ToArray()[0];
                    string payfor_zed_ident = sold_zed_list.SelectedItems[0].SubItems[sold_z_ident_code_col.Index].Text;
                    //girebuleba
                    decimal payfor_zed_cost = Utilities.Utilities.ParseDecimal(sold_zed_list.SelectedItems[0].SubItems[sold_z_cost_col.Index].Text);
                    //mogeba, DataTable-dan imito vitvlit ro sheileba user-it iyos shesuli da ar uchvenebdes mogebis vels
                    decimal payfor_zed_roi = Utilities.Utilities.ParseDecimal((from DataRow nr in sold_zed_list_dt.Rows
                                                                               where nr["საიდენტ. კოდი"].ToString() == payfor_zed_ident
                                                                               && nr["მყიდველი"].ToString() == payfor_zed_buyer_name
                                                                               select nr["მოგება"]).ToArray()[0].ToString());
                    //gadasaxdelia girebulebas + mogeba (anu mosacemi tanxa)
                    decimal payfor_zed_amount = payfor_zed_cost + payfor_zed_roi;
                    info payforsoldzed_info = ProductInfo_Main_Form.conn.TransferMoney(payfor_zed_buyer.saidentifikacio_kodi, DataProvider.MoneyTransferType.Take, DateTime.Now, payfor_zed_amount, typeof(Buyer), DataProvider.MoneyTransferPurpose.PayFor, ActiveStoreID, typeof(Zednadebi), payfor_zed_ident);
                    MessageBox.Show(payforsoldzed_info.details, payforsoldzed_info.errcode.ToString());

                    RefreshTabs();
                }
            }
            else
            {
                MessageBox.Show("ზედნადები არ არის მონიშნული!");
            }
        }

        private void cmi_mt_remove_Click(object sender, EventArgs e)
        {
            if (moneytransfer_list.SelectedItems.Count > 0 && "ჯამი" != moneytransfer_list.SelectedItems[0].Text)
            {
                if (DialogResult.Yes == MessageBox.Show("ნამდვილად გსურთ ფულადი ოპერაციის გაუქმება?", "დადასტურება", MessageBoxButtons.YesNo))
                {
                    int mt_id = -66;
                    try
                    {
                        mt_id = Int32.Parse(moneytransfer_list.SelectedItems[0].SubItems[mt_id_col.Index].Text);
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("პარამეტრის ფორმატირებისას მოხდა შეცდომა!");
                        return;
                    }
                    conn.RemoveMoneyTransfer(mt_id);

                    RefreshTabs();
                }
            }
            else
            {
                MessageBox.Show("ფულადი ოპერაცია არ არის მონიშნული!");
            }
        }

        private void cmi_sold_zed_remove_Click(object sender, EventArgs e)
        {
            if (sold_zed_list.SelectedItems.Count > 0 && "ჯამი" != sold_zed_list.SelectedItems[0].Text)
            {
                string rmzed_ident = sold_zed_list.SelectedItems[0].SubItems[sold_z_ident_code_col.Index].Text;
                string rmzed_buyer_ident = (from al_b in all_buyers
                                            where al_b.saxeli == sold_zed_list.SelectedItems[0].SubItems[sold_z_buyer_col.Index].Text
                                            select al_b.saidentifikacio_kodi).ToArray()[0];
                if (DialogResult.Yes == MessageBox.Show("დარწმუნებული ხართ, რომ გსურთ ზედნადები N. " + sold_zed_list.SelectedItems[0].SubItems[sold_z_ident_code_col.Index].Text + "-ს ამოშლა?", "დადასტურება!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    info remremainder_info = info.niy();
                    remremainder_info = ProductInfo_Main_Form.conn.RemoveZednadebi(rmzed_ident, "Sell", rmzed_buyer_ident);

                    MessageBox.Show(remremainder_info.details, remremainder_info.errcode.ToString());

                    RefreshTabs();
                }
            }
        }

        private void cmi_buyer_edit_Click(object sender, EventArgs e)
        {
            if (0 < buyers_list.SelectedIndices.Count && "ჯამი" != buyers_list.SelectedItems[0].Text)
            {
                AddBuyer_Form changebuyer_frm = new AddBuyer_Form();
                changebuyer_frm.Show();
                changebuyer_frm.job = AddBuyer_Form.ActionType.Edit;

                changebuyer_frm.Text = "მყიდველის შეცვლა";
                changebuyer_frm.buyer_name_txt.Text = buyers_dt.Rows[buyers_list.SelectedIndices[0]][0].ToString();
                changebuyer_frm.buyer_ident_code_txt.Text = buyers_dt.Rows[buyers_list.SelectedIndices[0]][1].ToString();
                changebuyer_frm.buyer_address_txt.Text = buyers_dt.Rows[buyers_list.SelectedIndices[0]][2].ToString();

                changebuyer_frm.FormClosed += delegate(object senderChangeBuyerForm, FormClosedEventArgs eChangeBuyerForm)
                {
                    RefreshTabs();
                };
            }
        }

        private void btn_export_csv_Click(object sender, EventArgs e)
        {
            if (sell_tabpage == tab_container.SelectedTab | summary_tabpage == tab_container.SelectedTab)
            {
                return;
            }

            string csv_output = "";

            if (productnames_tabpage == tab_container.SelectedTab)
            {
                csv_output = ListViewToCSV(prod_names_list);
            }
            if (suppliers_tabpage == tab_container.SelectedTab)
            {
                csv_output = ListViewToCSV(suppliers_list);
            }
            if (buyers_tabpage == tab_container.SelectedTab)
            {
                csv_output = ListViewToCSV(buyers_list);
            }
            if (bought_afs_tabpage == tab_container.SelectedTab)
            {
                csv_output = ListViewToCSV(bought_af_list);
            }
            if (sold_afs_tabpage == tab_container.SelectedTab)
            {
                csv_output = ListViewToCSV(sold_af_list);
            }
            if (zednadebebi_tabpage == tab_container.SelectedTab)
            {
                csv_output = ListViewToCSV(zed_list);
            }
            if (sold_zednadebebi_tabpage == tab_container.SelectedTab)
            {
                csv_output = ListViewToCSV(sold_zed_list);
            }
            if (nashtebi_tabpage == tab_container.SelectedTab)
            {
                csv_output = ListViewToCSV(rem_list);
            }
            if (agcera_tabpage == tab_container.SelectedTab)
            {
                csv_output = ListViewToCSV(agcera_rem_list);
            }
            if (sold_tabpage == tab_container.SelectedTab)
            {
                csv_output = ListViewToCSV(sold_list);
            }
            if (sold_prods_tabpage == tab_container.SelectedTab)
            {
                csv_output = ListViewToCSV(sold_prodrem_list);
            }
            if (moneytransfers_tabpage == tab_container.SelectedTab)
            {
                csv_output = ListViewToCSV(moneytransfer_list);
            }
            if (summary_tabpage == tab_container.SelectedTab)
            {
                //
            }
            if (bought_af_standard_list_tabpage == tab_container.SelectedTab)
            {
                csv_output = ListViewToCSV(bought_af_standard_list);
            }


            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            sfd.FileName = tab_container.SelectedTab.Text + " - " + DateTime.Now.Day + " " + BitmapGenerator.GeorgianMonths[DateTime.Now.Month] + " " + DateTime.Now.Year + " " + DateTime.Now.Hour + "-" + DateTime.Now.Minute;
            sfd.AddExtension = true;

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

        private void sell_list_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow dgrow in sell_list.Rows)
            {
                if (dgrow.IsNewRow)
                {
                    continue;
                }
                dgrow.HeaderCell.Value = String.Format((dgrow.Index + 1).ToString(), "0");
            }
            sell_list.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
        }




    }
}
