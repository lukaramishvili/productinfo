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
using Data_Visualization;
using Microsoft.PointOfService;

namespace ShopInfo_GUI
{
    public partial class ShopInfo_Main_Form : Form
    {
        public ShopInfo_Main_Form()
        {
            InitializeComponent();
        }

        public static decimal ParseDecimal(string arg)
        {
            return Utilities.Utilities.ParseDecimal(arg);
        }

        public static DataProvider DataConn = new DataProvider();

        DataTable all_stores;

        int ActiveStoreID = 0;
        int ActiveCashBoxID = 1;
        public static int ActiveCashierID = 0;
        public static string sActiveCashierName = "";

        Remainder[] SellableRemainders = null;

        Product[] AllProducts = null;

        //ONLY AFTER the user clicks the sell button, any fields with invalid values will be filled with red
        bool sell_clicked = false;

        //per-row sum cache (to avoid calculating it by hand when needed)
        List<decimal> Sell_Row_Pricing = new List<decimal>();

        //CashDrawer object
        CashDrawer m_Drawer = null;

        public static bool fAuthenticated = false;

        private void ShopInfo_Main_Form_Load(object sender, EventArgs e)
        {
            frmShopInfoLoginForm checkLoginForm = new frmShopInfoLoginForm();
            checkLoginForm.ShowDialog();
            //continue when the dialog is closed
            while (false == fAuthenticated)
            {
                if (DialogResult.No == MessageBox.Show("ნამდვილად გსურთ გამოსვლა?", "გამოსვლა", MessageBoxButtons.YesNo))
                {
                    checkLoginForm.ShowDialog();
                }
                else
                {
                    break;
                    //using applicaition exit here causes bug
                }
            }
            //exit here and not inside while loop because it causes bugs
            if (false == fAuthenticated || 1 > ActiveCashierID)
            {
                Application.Exit();
            }
            else
            {
                lblActiveCashierName.Text = "მოლარე: " + sActiveCashierName;
            }
            //
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
            //
            all_stores = DataConn.AllStores();

            //
            int StoreIDFromRegistry = Convert.ToInt32(Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\zero\ProductInfo\1.0", "StoreID", 0));
            if (all_stores.Select("id = " + StoreIDFromRegistry).Length > 0)//check that the StoreID we are using actually exists in database
            {
                ActiveStoreID = StoreIDFromRegistry;
            }
            else
            {
                ActiveStoreID = 0;
            }
            //
            int CashBoxIDFromRegistry = Convert.ToInt32(Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\zero\ProductInfo\1.0", "CashBoxID", 0));
            ActiveCashBoxID = CashBoxIDFromRegistry;
            //TODO: user authorization && get CashierID(current user id) from database && Registry.SetValue([CashierID that was read from database])
            //int CashierIDFromRegistry = Convert.ToInt32(Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\zero\ProductInfo\1.0", "CashierID", 0));
            //ActiveCashierID = CashierIDFromRegistry;

            //if this is not done by hand, then first row will not have DefaultCellStyle
            sell_grid.Rows[0].Height = sell_grid.RowTemplate.Height;
            sell_grid.Rows[0].DefaultCellStyle = sell_grid.RowTemplate.DefaultCellStyle;
            //
            RefreshDBStateTables();
            //Init CashDrawer
            InitCashDrawer();
            //
        }

        void Application_ApplicationExit(object sender, EventArgs e)
        {
            CloseResourceDeviceCashDrawer();
        }

        private void CloseResourceDeviceCashDrawer()
        {
            if (null != m_Drawer)
            {
                m_Drawer.Close();
            }
        }

        private void RefreshDBStateTables()
        {
            SellableRemainders = DataConn.GetValidRemainders(ActiveStoreID, true);

            AllProducts = DataConn.GetProductSuggestions("");

            //
            if (SellableRemainders.Length > 0)
            {
                sell_prodname_col.Items.Clear();

                //TODO: performance problem - currently this loop executes ~10k times
                foreach (Remainder nextRem in SellableRemainders)
                {
                    var matchingProds = (from Product p in AllProducts
                                           where p.barcode == nextRem.product_barcode
                                           select p.name).ToArray();
                    if (matchingProds.Length > 0)
                    {
                        var nextRemProdName = matchingProds[0];
                        if (!sell_prodname_col.Items.Contains(nextRemProdName))
                        {
                            sell_prodname_col.Items.Add(nextRemProdName);
                        }
                    }
                }
            }
        }

        private void InitCashDrawer()
        {
            //<<<step1>>>--Start
            //Use a Logical Device Name which has been set on the SetupPOS.
            string strLogicalName = "CashDrawer";

            try
            {
                //Create PosExplorer
                PosExplorer posExplorer = new PosExplorer();

                DeviceInfo deviceInfo = null;

                try
                {
                    deviceInfo = posExplorer.GetDevice(DeviceType.CashDrawer, strLogicalName);
                    m_Drawer = (CashDrawer)posExplorer.CreateInstance(deviceInfo);
                }
                catch (Exception)
                {
                    //Nothing can be used.
                    //ChangeButtonStatus();
                    return;
                }
                //Open the device
                //Use a Logical Device Name which has been set on the SetupPOS.
                m_Drawer.Open();

                //Get the exclusive control right for the opened device.
                //Then the device is disable from other application.
                //m_Drawer.Claim(1000);

                //Enable the device.
                m_Drawer.DeviceEnabled = true;

            }
            catch (PosControlException)
            {
                //Nothing can be used.
                //Nothing can be used.
                //ChangeButtonStatus();
            }
            //<<<step1>>>--End
        }

        private void UpdateSumSellPrice()
        {
            Sell_Row_Pricing.Clear();
            foreach (DataGridViewRow nextRow in sell_grid.Rows)
            {
                if (!nextRow.IsNewRow)
                {
                    Sell_Row_Pricing.Add
                        (
                        ParseDecimal((sell_grid.Rows[nextRow.Index].Cells[sell_piece_count_col.Index].Value ?? 0.0m).ToString())
                        *
                        ParseDecimal((sell_grid.Rows[nextRow.Index].Cells[sell_piece_price_col.Index].Value ?? 0.0m).ToString())
                        );
                }
            }
            lbl_status_sum.Text = "ჯამი: " + Math.Round(Sell_Row_Pricing.Sum(), 2).ToString() + " ლარი";
        }

        private enum NotificationSeverity { Success, Error, Information };
        //it cannot be a utility function, it just uses actual Controls to show notifications
        private void NotifyOnScreen(string message, NotificationSeverity how_important)
        {
            //TODO: notify by raising a bar like "remember password" in FF 3.6, not MessageBox
            MessageBox.Show(message, how_important.ToString());
        }

        private void sell_btn_Click(object sender, EventArgs e)
        {
            SellFormSubmit();
        }

        private void SellFormSubmit()
        {
            if ("" == (cash_handled_txt.Text ?? "")
                | 0 >= ParseDecimal(cash_handled_txt.Text ?? "")
                | false == IsHandledCashEnough()
                )
            {
                MessageBox.Show("თანხა არ არის საკმარისი!");
                return;
            }
            //sell button is clicked, so any invalid fields will get a red background unless corrected
            sell_clicked = true;
            //
            List<Remainder> RemsToSell = new List<Remainder>();
            foreach (DataGridViewRow nextRow in sell_grid.Rows)
            {
                if (nextRow.IsNewRow)
                {
                    continue;
                }
                Remainder nextRem = new Remainder();

                nextRem.product_barcode = (nextRow.Cells[sell_barcode_col.Index].Value ?? "").ToString();
                nextRem.storehouse_id = ActiveStoreID;
                nextRem.initial_pieces = ParseDecimal((nextRow.Cells[sell_piece_count_col.Index].Value ?? 0.0m).ToString());
                nextRem.sell_price = ParseDecimal((nextRow.Cells[sell_piece_price_col.Index].Value ?? 0.0m).ToString());

                RemsToSell.Add(nextRem);
            }

            //determine how much there is to pay for the SellOrder
            decimal SellOrderTotal = 0.0m;
            foreach (Remainder next_selling_rem in RemsToSell.ToArray())
            {
                SellOrderTotal += next_selling_rem.sell_price * next_selling_rem.initial_pieces;
            }

            //prepare selling information and sell
            SellOrder CurrentSellOrder = new SellOrder(DateTime.Now
                                                        , true
                                                        , DataProvider.PaymentType.Nagdi
                                                        , Buyer.xelze
                                                        , null
                                                        , RemsToSell.ToArray()
                                                        , null);
            //this variable will be initialized by the AddSellOrder call
            //add SellOrder to database
            //use new fast optimized method instead of AddSellOrderWithPayment
            info SellResult = DataConn.FastAddShopInfoSellOrderWithPayment(CurrentSellOrder, Buyer.xelze.saidentifikacio_kodi
                                                            , SellOrderTotal
                                                            , ActiveStoreID
                                                            , ActiveCashBoxID
                                                            , ActiveCashierID);
            //success (code 0 means success, code 501 - NotImplementedYet, in early versions 501 was initial value and if it wasn't modified, it meant error did not occur (only erros modified success message). silly, right. )
            if (501 == SellResult.errcode | 0 == SellResult.errcode)
            {
                //print POS check and open cash drawer
                BitmapGenerator.PrintPOSCheck(CurrentSellOrder, ParseDecimal(cash_handled_txt.Text), ParseDecimal(cash_change_txt.Text), AllProducts, sActiveCashierName);
                //TODO:Open Cash Drawer (probably from utilities.external)
                //pay automatically for the SellOrder
                //////////pay code moved to transactional AddSellOrderWithPayment
                //notify (selling result + ) how the payment transfer resulted 
                //NotifyOnScreen("პროდუქტები გაყიდულია. ", NotificationSeverity.Success);
                //TODO: insert wait time? to give the user time to look at the first notification
                //
                OpenCashDrawer();
                //
                NotifyOnScreen("პროდუქტები გაყიდულია. " + SellResult.details
                    , (0 == SellResult.errcode) ? NotificationSeverity.Success : NotificationSeverity.Error);

                //clear the list so next SellOrder can be entered
                sell_grid.Rows.Clear();
                //
                sell_grid.Focus();
                //
                cash_handled_txt.Text = "0.0";
                cash_change_txt.Text = "0.0";
                //the sell button is not clicked yet for the next entered SellOrder, so we set it to false
                sell_clicked = false;

                //TODO: reset the per-row sum cache
                //nothing to do here. the real TODO is, when needed, to use the List<decimal> template instead of decimal[]
                Sell_Row_Pricing.Clear();
                //update total entered SellOrder sum (0.0 in this case, as no items have been entered yet)
                UpdateSumSellPrice();
                //
                //end success case
            }
            else if (404 == SellResult.errcode)
            {
                NotifyOnScreen("ამ რაოდენობის პროდუქტები საწყობში აღარაა დარჩენილი! ", NotificationSeverity.Error);
            }
            else
            {
                NotifyOnScreen("მოხდა შეცდომა. პროდუქტები არ გაყიდულა! ", NotificationSeverity.Error);
            }
            //
        }

        private void OpenCashDrawer()
        {
            //<<<step1>>>--Start
            //When outputting to a printer,a mouse cursor becomes like a hourglass.
            Cursor.Current = Cursors.WaitCursor;
            //btnOpen.Enabled = false;

            try
            {
                //Open the drawer by using the "OpenDrawer" method.
                m_Drawer.OpenDrawer();

                // Wait during open drawer.
                while (m_Drawer.DrawerOpened == false)
                {
                    System.Threading.Thread.Sleep(100);
                }

                //When the drawer is not closed in ten seconds after opening, beep until it is closed.
                //If  that method is executed, the value is not returned until the drawer is closed.
                m_Drawer.WaitForDrawerClose(10000, 2000, 100, 1000);

                //btnOpen.Enabled = true;

                Cursor.Current = Cursors.Default;
            }
            catch (PosControlException)
            {
            }
            catch (NullReferenceException)
            {
            }
            //<<<step1>>>---End
        }

        private void sell_grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == sell_barcode_col.Index)
            {
                string EnteredBarcode = (sell_grid.Rows[e.RowIndex].Cells[sell_barcode_col.Index].Value ?? "").ToString();
                bool WasEnteredWeightEmbeddedBarcode = false;
                decimal EmbeddedWeight = 1.0m;
                //check if the barcode is weight embedded barcode
                if (true == IsBarcodeEANWeightEmbedded(EnteredBarcode))
                {
                    EmbeddedWeight = ParseDecimal(EnteredBarcode.Substring(7, 5));
                    if (EmbeddedWeight > 100)
                    {
                        //if Weight is equal or less than 100 grams, then it's count, not weight
                        EmbeddedWeight = EmbeddedWeight / 1000.0m;
                    }
                    EnteredBarcode = EnteredBarcode.Substring(2, 5);
                    WasEnteredWeightEmbeddedBarcode = true;
                    sell_grid.Rows[e.RowIndex].Cells[sell_barcode_col.Index].Value = EnteredBarcode;
                }
                UpdateCurrentRowAccordingToBarcode(EnteredBarcode);
                //
                int RowsMatched = 0;
                int FirstRowIndexMatchedForCurrentBarCode = -1;
                decimal SumSimilarBarcodes = 0.0m;//this is not a sum, this is an amount taken from one field (existing row with matching barcode)
                foreach (DataGridViewRow nextRow in sell_grid.Rows)
                {
                    if (!nextRow.IsNewRow)
                    {
                        if ((nextRow.Cells[sell_barcode_col.Index].Value ?? "").ToString() == EnteredBarcode)
                        {
                            if (-1 == FirstRowIndexMatchedForCurrentBarCode)
                            {
                                FirstRowIndexMatchedForCurrentBarCode = nextRow.Index;
                            }
                            SumSimilarBarcodes = Math.Max(SumSimilarBarcodes, ParseDecimal((nextRow.Cells[sell_piece_count_col.Index].Value ?? 0.0m).ToString()));
                            RowsMatched++;
                            if (RowsMatched > 1)
                            {
                                int RowIndexToRemove = nextRow.Index;
                                System.Threading.Thread DelayedRowDelete = new System.Threading.Thread(delegate()
                                {
                                    if (!sell_grid.Rows[RowIndexToRemove].IsNewRow)
                                    {
                                        MethodInvoker SellGridRowRemover = new MethodInvoker(delegate() { sell_grid.Rows.RemoveAt(RowIndexToRemove); });
                                        sell_grid.Invoke(SellGridRowRemover);
                                    }
                                });
                                DelayedRowDelete.Start();
                                //
                                sell_grid.Rows[FirstRowIndexMatchedForCurrentBarCode].Cells[sell_piece_count_col.Index].Value = EmbeddedWeight + SumSimilarBarcodes;// +ParseDecimal((nextRow.Cells[sell_piece_count_col.Index].Value ?? 0.0m).ToString());

                                sell_grid.Rows[FirstRowIndexMatchedForCurrentBarCode].Cells[sell_sum_price_col.Index].Value = ParseDecimal((sell_grid.Rows[FirstRowIndexMatchedForCurrentBarCode].Cells[sell_piece_count_col.Index].Value ?? 0.0m).ToString())
                                    *
                                    ParseDecimal((nextRow.Cells[sell_piece_price_col.Index].Value ?? 0.0m).ToString());
                                //
                                break;
                            }
                            else
                            {
                                sell_grid.Rows[FirstRowIndexMatchedForCurrentBarCode].Cells[sell_piece_count_col.Index].Value = EmbeddedWeight + SumSimilarBarcodes;// +ParseDecimal((nextRow.Cells[sell_piece_count_col.Index].Value ?? 0.0m).ToString());

                                sell_grid.Rows[FirstRowIndexMatchedForCurrentBarCode].Cells[sell_sum_price_col.Index].Value = ParseDecimal((sell_grid.Rows[FirstRowIndexMatchedForCurrentBarCode].Cells[sell_piece_count_col.Index].Value ?? 0.0m).ToString())
                                    *
                                    ParseDecimal((nextRow.Cells[sell_piece_price_col.Index].Value ?? 0.0m).ToString());
                            }
                            //end if barcodes match
                        }
                    }
                }
            }
            UpdateSumSellPrice();
            //CellEndEdit-is magivrad EditingControlShowing-is shida Control-ebis  event-ebs gamoviyeneb
            return;
            if (e.ColumnIndex == sell_barcode_col.Index)
            {
                string BarcodeForThisRow = (sell_grid.Rows[e.RowIndex].Cells[sell_barcode_col.Index].Value ?? "").ToString();
                if ("" != BarcodeForThisRow)
                {
                    var MatchedRemainders = (from Remainder r in SellableRemainders
                                             where r.product_barcode == BarcodeForThisRow
                                             //In ShopInfo, we assign MAXIMUM sell price instead of OLDEST
                                             //(ShopInfo-shi maximums vigebt fass da ara yvelaze dzveli nashtisas): order by shemotanis tarigi. TODO: GetValidRemainders unda sheicvalos da barcodestan ertad prod saxeli da shemotanis tarigic daematos
                                             //orderby r.product_barcode ascending
                                             select r
                                                 ).ToArray();
                    if (0 < MatchedRemainders.Length)
                    {
                        sell_grid.Rows[e.RowIndex].Cells[sell_piece_price_col.Index].Value = Math.Round(MatchedRemainders.Max(w => w.sell_price), 2);//price for the oldest remainder
                        var nextRemProdName = (from Product p in AllProducts
                                               where p.barcode == BarcodeForThisRow
                                               select p.name).ToArray()[0];
                        sell_grid.Rows[e.RowIndex].Cells[sell_prodname_col.Index].Value = nextRemProdName;
                    }
                }
                //by changing the product name, we thereby changed the sell_price (sell_piece_count_col), so update sum price for that row automatically
                sell_grid.Rows[e.RowIndex].Cells[sell_sum_price_col.Index].Value
                    =
                    ParseDecimal((sell_grid.Rows[e.RowIndex].Cells[sell_piece_count_col.Index].Value ?? 0.0m).ToString())
                    *
                    ParseDecimal((sell_grid.Rows[e.RowIndex].Cells[sell_piece_price_col.Index].Value ?? 0.0m).ToString());
                //
            }
            else if (e.ColumnIndex == sell_prodname_col.Index)
            {
                string ProdNameForThisRow = (sell_grid.Rows[e.RowIndex].Cells[sell_prodname_col.Index].Value ?? "").ToString();
                string[] MatchedProductBarcodes = (from Product p in AllProducts
                                                   where p.name == ProdNameForThisRow
                                                   select p.barcode
                                             ).ToArray();
                if (MatchedProductBarcodes.Length > 0)
                {
                    string MatchedProductBarcode = MatchedProductBarcodes[0];
                    var MatchedRemainders = (from r in SellableRemainders
                                             where r.product_barcode == MatchedProductBarcode
                                             select r
                        ).ToArray();
                    if (0 < MatchedRemainders.Length)
                    {
                        sell_grid.Rows[e.RowIndex].Cells[sell_piece_price_col.Index].Value = Math.Round(MatchedRemainders.Max(w => w.sell_price), 2);//price for the oldest remainder
                        sell_grid.Rows[e.RowIndex].Cells[sell_barcode_col.Index].Value = MatchedProductBarcode;
                    }
                    //by changing the product name, we thereby changed the sell_price (sell_piece_count_col), so update sum price for that row automatically
                    sell_grid.Rows[e.RowIndex].Cells[sell_sum_price_col.Index].Value
                        =
                        ParseDecimal((sell_grid.Rows[e.RowIndex].Cells[sell_piece_count_col.Index].Value ?? 0.0m).ToString())
                        *
                        ParseDecimal((sell_grid.Rows[e.RowIndex].Cells[sell_piece_price_col.Index].Value ?? 0.0m).ToString());
                }
                //
            }
            else if (e.ColumnIndex == sell_piece_count_col.Index)
            {
                sell_grid.Rows[e.RowIndex].Cells[sell_sum_price_col.Index].Value
                    =
                    ParseDecimal((sell_grid.Rows[e.RowIndex].Cells[sell_piece_count_col.Index].Value ?? 0.0m).ToString())
                    *
                    ParseDecimal((sell_grid.Rows[e.RowIndex].Cells[sell_piece_price_col.Index].Value ?? 0.0m).ToString());
            }
            else if (e.ColumnIndex == sell_sum_price_col.Index)
            {
                if ((null != sell_grid.Rows[e.RowIndex].Cells[sell_sum_price_col.Index].Value)
                    &&
                    (0.0m != ParseDecimal(sell_grid.Rows[e.RowIndex].Cells[sell_sum_price_col.Index].Value.ToString())))
                {
                    sell_grid.Rows[e.RowIndex].Cells[sell_piece_count_col.Index].Value
                        =
                        ParseDecimal((sell_grid.Rows[e.RowIndex].Cells[sell_sum_price_col.Index].Value ?? 0.0m).ToString())
                        /
                        ParseDecimal((sell_grid.Rows[e.RowIndex].Cells[sell_piece_price_col.Index].Value ?? 1.0m).ToString());
                }
                else
                {
                    sell_grid.Rows[e.RowIndex].Cells[sell_sum_price_col.Index].Value
                        =
                        ParseDecimal((sell_grid.Rows[e.RowIndex].Cells[sell_piece_count_col.Index].Value ?? 0.0m).ToString())
                        *
                        ParseDecimal((sell_grid.Rows[e.RowIndex].Cells[sell_piece_price_col.Index].Value ?? 0.0m).ToString());
                }
            }
            //
        }

        private bool IsBarcodeEANWeightEmbedded(string EnteredBarcode_arg)
        {
            bool RetVal = false;
            if (13 == EnteredBarcode_arg.Length)
            {
                if (210 == Int32.Parse(EnteredBarcode_arg.Substring(0, 3))
                    |
                    220 == Int32.Parse(EnteredBarcode_arg.Substring(0, 3)))
                {
                    int step2 = 3 * (
                        Int32.Parse(EnteredBarcode_arg.Substring(11, 1))
                        + Int32.Parse(EnteredBarcode_arg.Substring(9, 1))
                        + Int32.Parse(EnteredBarcode_arg.Substring(7, 1))
                        + Int32.Parse(EnteredBarcode_arg.Substring(5, 1))
                        + Int32.Parse(EnteredBarcode_arg.Substring(3, 1))
                        + Int32.Parse(EnteredBarcode_arg.Substring(1, 1))
                        );
                    int step3 = Int32.Parse(EnteredBarcode_arg.Substring(10, 1))
                        + Int32.Parse(EnteredBarcode_arg.Substring(8, 1))
                        + Int32.Parse(EnteredBarcode_arg.Substring(6, 1))
                        + Int32.Parse(EnteredBarcode_arg.Substring(4, 1))
                        + Int32.Parse(EnteredBarcode_arg.Substring(2, 1))
                        + Int32.Parse(EnteredBarcode_arg.Substring(0, 1));
                    if (
                        ((10 - (step2 + step3) % 10) % 10) == Int32.Parse(EnteredBarcode_arg.Substring(12, 1))
                        )
                    {
                        RetVal = true;
                    }
                }
            }
            return RetVal;
        }

        private void sell_grid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //EVERYTIME, ON ANY CONTROL Home key is clicked, move focus to first column
            e.Control.KeyUp -= sell_grid_EditingControlShowing_Control_KeyUp;
            e.Control.KeyUp += new KeyEventHandler(sell_grid_EditingControlShowing_Control_KeyUp);
            //
            if (sell_grid.CurrentCell.ColumnIndex == sell_barcode_col.Index)
            {
                TextBox SellGridBarcode_txt = (TextBox)e.Control;
                SellGridBarcode_txt.TextChanged += new EventHandler(SellGridBarcode_txt_TextChanged);
            }
            else if (sell_grid.CurrentCell.ColumnIndex == sell_prodname_col.Index)
            {
                ComboBox SellGridProdName_cb = (ComboBox)e.Control;
                SellGridProdName_cb.DropDownStyle = ComboBoxStyle.DropDown;
                SellGridProdName_cb.TextChanged += new EventHandler(SellGridProdName_cb_TextChanged);
                SellGridProdName_cb.DropDown += new EventHandler(SellGridProdName_cb_DropDown);

                SellGridProdName_cb.SelectedIndexChanged += new EventHandler(delegate(object sendereIndexChanged, EventArgs eIndexChanged)
                {
                    if (sell_grid.CurrentCell.ColumnIndex != sell_prodname_col.Index)
                    {
                        return;
                    }
                    string SelectedItem = SellGridProdName_cb.Items[SellGridProdName_cb.SelectedIndex].ToString();
                    //update the barcode immediately after the product name combobox value has changed
                    string ProdNameForThisRow = (SelectedItem ?? "").ToString();
                    string MatchedProductBarcode = (from Product p in AllProducts
                                                    where p.name == ProdNameForThisRow
                                                    select p.barcode
                                                 ).ToArray()[0];
                    var MatchedRemainders = (from r in SellableRemainders
                                             where r.product_barcode == MatchedProductBarcode
                                             select r
                        ).ToArray();
                    if (0 < MatchedRemainders.Length)
                    {
                        sell_grid.Rows[sell_grid.CurrentRow.Index].Cells[sell_piece_price_col.Index].Value = Math.Round(MatchedRemainders.Max(w => w.sell_price), 2);//price for the oldest remainder
                        sell_grid.Rows[sell_grid.CurrentRow.Index].Cells[sell_barcode_col.Index].Value = MatchedProductBarcode;
                    }
                    //by changing the product name, we thereby changed the sell_price (sell_piece_count_col), so update sum price for that row automatically
                    sell_grid.Rows[sell_grid.CurrentRow.Index].Cells[sell_sum_price_col.Index].Value
                        =
                        ParseDecimal((sell_grid.Rows[sell_grid.CurrentRow.Index].Cells[sell_piece_count_col.Index].Value ?? 0.0m).ToString())
                        *
                        ParseDecimal((sell_grid.Rows[sell_grid.CurrentRow.Index].Cells[sell_piece_price_col.Index].Value ?? 0.0m).ToString());
                    //
                    UpdateSumSellPrice();
                });

            }
            else if (sell_grid.CurrentCell.ColumnIndex == sell_piece_count_col.Index)
            {
                TextBox SellGridPieceCount_txt = (TextBox)e.Control;
                SellGridPieceCount_txt.TextChanged += new EventHandler(delegate(object senderTextChanged, EventArgs eTextChanged)
                {
                    if (sell_grid.CurrentCell.ColumnIndex != sell_piece_count_col.Index)
                    {
                        return;
                    }
                    sell_grid.Rows[sell_grid.CurrentRow.Index].Cells[sell_sum_price_col.Index].Value
                        =
                        ParseDecimal(SellGridPieceCount_txt.Text)
                        *
                        ParseDecimal((sell_grid.Rows[sell_grid.CurrentRow.Index].Cells[sell_piece_price_col.Index].Value ?? 0.0m).ToString());
                    //
                    sell_grid.Rows[sell_grid.CurrentRow.Index].Cells[sell_piece_count_col.Index].Value = SellGridPieceCount_txt.Text;
                    UpdateSumSellPrice();
                });
            }
            else if (sell_grid.CurrentCell.ColumnIndex == sell_sum_price_col.Index)
            {
                TextBox SellGridSumPrice_txt = (TextBox)e.Control;
                SellGridSumPrice_txt.TextChanged += new EventHandler(delegate(object senderTextChanged, EventArgs eTextChanged)
                {
                    if (sell_grid.CurrentCell.ColumnIndex != sell_sum_price_col.Index)
                    {
                        return;
                    }
                    if ((null != SellGridSumPrice_txt.Text && "" != SellGridSumPrice_txt.Text)
                        &&
                        (0.0m != ParseDecimal(SellGridSumPrice_txt.Text)))
                    {
                        sell_grid.Rows[sell_grid.CurrentRow.Index].Cells[sell_piece_count_col.Index].Value
                            =
                            Math.Round(
                            ParseDecimal(SellGridSumPrice_txt.Text)
                            /
                            ((ParseDecimal((sell_grid.Rows[sell_grid.CurrentRow.Index].Cells[sell_piece_price_col.Index].Value ?? 1.0m).ToString()) == 0) ?
                                1.0m
                                :
                                ParseDecimal((sell_grid.Rows[sell_grid.CurrentRow.Index].Cells[sell_piece_price_col.Index].Value ?? 1.0m).ToString())
                             )
                             , 2);//end round
                    }
                    else
                    {
                        SellGridSumPrice_txt.Text
                            =
                            (
                            ParseDecimal((sell_grid.Rows[sell_grid.CurrentRow.Index].Cells[sell_piece_count_col.Index].Value ?? 0.0m).ToString())
                            *
                            ParseDecimal((sell_grid.Rows[sell_grid.CurrentRow.Index].Cells[sell_piece_price_col.Index].Value ?? 0.0m).ToString())
                            ).ToString();
                    }
                    //
                    sell_grid.Rows[sell_grid.CurrentRow.Index].Cells[sell_grid.CurrentCell.ColumnIndex].Value = SellGridSumPrice_txt.Text;
                    UpdateSumSellPrice();
                });
            }
        }

        void SellGridProdName_cb_DropDown(object sender, EventArgs e)
        {
            //sometimes you realize using ms products actually suck
            ComboBox SellGridProdName_cb = (ComboBox)sender;
            SellGridProdName_cb.BackColor = Color.White;
        }

        void SellGridProdName_cb_TextChanged(object sender, EventArgs e)
        {
            if (sell_grid.CurrentCell.ColumnIndex != sell_prodname_col.Index)
            {
                return;
            }
            ComboBox SellGridProdName_cb = (ComboBox)sender;
            string SelectedItem = SellGridProdName_cb.Text;
            //update the barcode immediately after the product name combobox value has changed
            string ProdNameForThisRow = (SelectedItem ?? "").ToString();
            string[] MatchedProductBarcodes = (from Product p in AllProducts
                                               where p.name == ProdNameForThisRow
                                               select p.barcode
                                         ).ToArray();
            if (MatchedProductBarcodes.Length > 0)
            {
                string MatchedProductBarcode = MatchedProductBarcodes[0];

                IEnumerable<Remainder> query = new List<Remainder>();
                query = from r in SellableRemainders
                        where r.product_barcode == MatchedProductBarcode
                        select r;
                var MatchedRemainders = query.ToArray();
                if (0 < MatchedRemainders.Length)
                {
                    sell_grid.Rows[sell_grid.CurrentRow.Index].Cells[sell_piece_price_col.Index].Value = Math.Round(MatchedRemainders.Max(w => w.sell_price), 2);//price for the oldest remainder
                    sell_grid.Rows[sell_grid.CurrentRow.Index].Cells[sell_barcode_col.Index].Value = MatchedProductBarcode;

                    //begin show remaining items
                    /*var StoreRems = from rem in query
                                    group rem by rem.storehouse_id into storrem
                                    select new { StoreID = storrem.Key, remaining_items = storrem.Sum(rem => rem.remaining_pieces) };
                    var rem_rem = (from sr in StoreRems
                                   where ActiveStoreID == sr.StoreID
                                   select sr.remaining_items).ToArray();
                    if (rem_rem.Length > 0)
                    {
                        sell_grid.CurrentRow.Cells[sell_remaining_items_col.Index].Value = rem_rem[0].ToString("G4");// +" (#" + ActiveStoreID.ToString() + ")";
                    }
                    else
                    {
                        sell_grid.CurrentRow.Cells[sell_remaining_items_col.Index].Value = 0.ToString("G4");// +" (#" + ActiveStoreID.ToString() + ")";
                    }*/
                    //if (query.ToArray().Length > 0)
                    //{
                    sell_grid.CurrentRow.Cells[sell_remaining_items_col.Index].Value = query.ToArray().Sum(w => w.remaining_pieces).ToString("G4");// +" (#" + ActiveStoreID.ToString() + ")";
                    //}
                    //end show remaining items
                }
                //else
                //{
                //    sell_grid.CurrentRow.Cells[sell_remaining_items_col.Index].Value = 0.ToString("G4");// +" (#" + ActiveStoreID.ToString() + ")";
                //}
                //by changing the product name, we thereby changed the sell_price (sell_piece_count_col), so update sum price for that row automatically
                sell_grid.Rows[sell_grid.CurrentRow.Index].Cells[sell_sum_price_col.Index].Value
                    =
                    ParseDecimal((sell_grid.Rows[sell_grid.CurrentRow.Index].Cells[sell_piece_count_col.Index].EditedFormattedValue ?? 0.0m).ToString())
                    *
                    ParseDecimal((sell_grid.Rows[sell_grid.CurrentRow.Index].Cells[sell_piece_price_col.Index].EditedFormattedValue ?? 0.0m).ToString());
            }
            else
            {
                sell_grid.Rows[sell_grid.CurrentRow.Index].Cells[sell_piece_price_col.Index].Value = 0.0m;
                sell_grid.Rows[sell_grid.CurrentRow.Index].Cells[sell_barcode_col.Index].Value = "";

                sell_grid.CurrentRow.Cells[sell_remaining_items_col.Index].Value = 0.ToString("G4");// +" (#" + ActiveStoreID.ToString() + ")";

                sell_grid.Rows[sell_grid.CurrentRow.Index].Cells[sell_sum_price_col.Index].Value
                    =
                    ParseDecimal((sell_grid.Rows[sell_grid.CurrentRow.Index].Cells[sell_piece_count_col.Index].Value ?? 0.0m).ToString())
                    *
                    ParseDecimal((sell_grid.Rows[sell_grid.CurrentRow.Index].Cells[sell_piece_price_col.Index].Value ?? 0.0m).ToString());
            }
            //
            UpdateSumSellPrice();
        }

        private void UpdateCurrentRowAccordingToBarcode(string barcode_arg)
        {
            string BarcodeForThisRow = barcode_arg;
            if ("" != BarcodeForThisRow && AllProducts.Select(s => s.barcode).ToArray().Contains(BarcodeForThisRow))
            {
                IEnumerable<Remainder> query = new List<Remainder>();
                query = from Remainder r in SellableRemainders
                        where r.product_barcode == BarcodeForThisRow
                        //In ShopInfo, we assign MAXIMUM sell price instead of OLDEST
                        //(ShopInfo-shi maximum fass vigebt da ara dzvels): order by shemotanis tarigi. TODO: GetValidRemainders unda sheicvalos da barcodestan ertad prod saxeli da shemotanis tarigic daematos
                        //orderby r.product_barcode ascending
                        select r;
                var MatchedRemainders = query.ToArray();
                if (0 < MatchedRemainders.Length)
                {
                    sell_grid.Rows[sell_grid.CurrentRow.Index].Cells[sell_piece_price_col.Index].Value = Math.Round(MatchedRemainders.Max(w => w.sell_price), 2);//price for the oldest remainder
                    var nextRemProdName = (from Product p in AllProducts
                                           where p.barcode == BarcodeForThisRow
                                           select p.name).ToArray()[0];
                    sell_grid.Rows[sell_grid.CurrentRow.Index].Cells[sell_prodname_col.Index].Value = nextRemProdName;

                    //begin show remaining items
                    /*var StoreRems = from rem in query
                                    group rem by rem.storehouse_id into storrem
                                    select new { StoreID = storrem.Key, remaining_items = storrem.Sum(rem => rem.remaining_pieces) };
                    var rem_rem = (from sr in StoreRems
                                   where ActiveStoreID == sr.StoreID
                                   select sr.remaining_items).ToArray();
                    if (rem_rem.Length > 0)
                    {
                        sell_grid.CurrentRow.Cells[sell_remaining_items_col.Index].Value = rem_rem[0].ToString("G4");// +" (#" + ActiveStoreID.ToString() + ")";
                    }
                    else
                    {
                        sell_grid.CurrentRow.Cells[sell_remaining_items_col.Index].Value = 0.ToString("G4");// +" (#" + ActiveStoreID.ToString() + ")";
                    }*/
                    //if (query.ToArray().Length > 0)
                    //{
                    sell_grid.CurrentRow.Cells[sell_remaining_items_col.Index].Value = query.ToArray().Sum(w => w.remaining_pieces).ToString("G4");// +" (#" + ActiveStoreID.ToString() + ")";
                    //}
                    //end show remaining items
                }
                //else
                //{
                //    sell_grid.CurrentRow.Cells[sell_remaining_items_col.Index].Value = 0.ToString("G4");// +" (#" + ActiveStoreID.ToString() + ")";
                //}
            }
            else
            {
                sell_grid.Rows[sell_grid.CurrentRow.Index].Cells[sell_piece_price_col.Index].Value = 0.0m;
                sell_grid.Rows[sell_grid.CurrentRow.Index].Cells[sell_prodname_col.Index].Value = "";

                sell_grid.CurrentRow.Cells[sell_remaining_items_col.Index].Value = 0.ToString("G4");// +" (#" + ActiveStoreID.ToString() + ")";
            }
            //by changing the product name, we thereby changed the sell_price (sell_piece_count_col), so update sum price for that row automatically
            sell_grid.Rows[sell_grid.CurrentRow.Index].Cells[sell_sum_price_col.Index].Value
                =
                ParseDecimal((sell_grid.Rows[sell_grid.CurrentRow.Index].Cells[sell_piece_count_col.Index].Value ?? 0.0m).ToString())
                *
                ParseDecimal((sell_grid.Rows[sell_grid.CurrentRow.Index].Cells[sell_piece_price_col.Index].Value ?? 0.0m).ToString());
            //
            UpdateSumSellPrice();
        }

        void SellGridBarcode_txt_TextChanged(object sender, EventArgs e)
        {
            if (sell_grid.CurrentCell.ColumnIndex != sell_barcode_col.Index)
            {
                return;
            }
            TextBox SellGridBarcode_txt = (TextBox)sender;
            UpdateCurrentRowAccordingToBarcode(SellGridBarcode_txt.Text);
        }

        void sell_grid_EditingControlShowing_Control_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Home)
            {
                sell_grid.EndEdit();
                sell_grid.CurrentCell = sell_grid.CurrentRow.Cells[0];
            }
        }

        private void sell_grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == sell_piece_count_col.Index)
            {
                if (sell_grid.Rows.Count > 0 && (-1 != e.RowIndex))
                {
                    if (false == sell_grid.Rows[e.RowIndex].IsNewRow)
                    {
                        if (0 >= ParseDecimal((sell_grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value ?? 0.0m).ToString()))
                        {
                            sell_grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0.0m;
                            //
                            sell_grid.Rows[e.RowIndex].Cells[sell_sum_price_col.Index].Value
                                =
                                ParseDecimal((sell_grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value ?? 0.0m).ToString())
                                *
                                ParseDecimal((sell_grid.Rows[e.RowIndex].Cells[sell_piece_price_col.Index].Value ?? 0.0m).ToString());
                            //
                        }
                    }
                }
            }
            UpdateSumSellPrice();
            UpdateCashChange();
        }

        private void sell_grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void ShopInfo_Main_Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                SellFormSubmit();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.F5)
            {
                cash_handled_txt.Focus();
                cash_handled_txt.Text = "";
            }
            else if (e.KeyCode == Keys.Home)
            {
                if (false == sell_grid.Focused)
                {
                    sell_grid.Focus();
                }
            }
        }

        private void cash_handled_txt_TextChanged(object sender, EventArgs e)
        {
            UpdateCashChange();
        }

        private void UpdateCashChange()
        {
            decimal TotalCashHandled = ParseDecimal(cash_handled_txt.Text);

            cash_handled_txt.ForeColor = (TotalCashHandled > 0.0m) ? SystemColors.ControlText : Color.Red;

            decimal TotalSellOrderCost = 0.0m;
            foreach (DataGridViewRow dr in sell_grid.Rows)
            {
                if (false == dr.IsNewRow)
                {
                    TotalSellOrderCost += ParseDecimal(dr.Cells[sell_sum_price_col.Index].Value.ToString());
                }
            }
            decimal TotalChange = TotalCashHandled - TotalSellOrderCost;
            cash_change_txt.Text = Math.Round(TotalChange, 2).ToString();
            cash_change_txt.ForeColor = (TotalChange >= 0.0m) ? SystemColors.ControlText : Color.Red;
            //
        }

        private bool IsHandledCashEnough()
        {
            decimal TotalCashHandled = ParseDecimal(cash_handled_txt.Text);

            decimal TotalSellOrderCost = 0.0m;
            foreach (DataGridViewRow dr in sell_grid.Rows)
            {
                if (false == dr.IsNewRow)
                {
                    TotalSellOrderCost += ParseDecimal(dr.Cells[sell_sum_price_col.Index].Value.ToString());
                }
            }
            decimal TotalChange = TotalCashHandled - TotalSellOrderCost;
            //
            return TotalCashHandled >= TotalSellOrderCost;
        }

        private void sell_grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == sell_remove_col.Index)
            {
                if (!sell_grid.Rows[e.RowIndex].IsNewRow && null != sell_grid.Rows[e.RowIndex])
                {
                    string ProdToDel = (null != sell_grid.Rows[e.RowIndex].Cells[sell_prodname_col.Index].Value) ? sell_grid.Rows[e.RowIndex].Cells[sell_prodname_col.Index].Value.ToString() : "პროდუქტი";
                    if (DialogResult.Yes == MessageBox.Show("ნამდვილად გსურთ სიიდან " + ProdToDel + "-ს ამოშლა?", "დადასტურება", MessageBoxButtons.YesNo))
                    {
                        sell_grid.Rows.Remove(sell_grid.Rows[e.RowIndex]);
                        UpdateSumSellPrice();
                    }
                }
            }
        }

        private void sell_grid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

        }

        private void cash_handled_txt_Enter(object sender, EventArgs e)
        {
            cash_handled_txt.SelectAll();
        }

        private void cash_handled_txt_Click(object sender, EventArgs e)
        {
            cash_handled_txt.SelectAll();
        }

        private void ShopInfo_Main_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            //<<<step1>>>--Start
            if (m_Drawer != null)
            {
                try
                {
                    //Cancel the device
                    m_Drawer.DeviceEnabled = false;

                    //Release the device exclusive control right.
                    m_Drawer.Release();

                }
                catch (PosControlException)
                {
                }
                finally
                {
                    //Finish using the device.
                    m_Drawer.Close();
                }
            }
            //<<<step1>>>--End
        }

        private void btnRefreshTableStates_Click(object sender, EventArgs e)
        {
            RefreshDBStateTables();
        }





        //
    }
}
