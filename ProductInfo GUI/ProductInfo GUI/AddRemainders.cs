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
    public partial class AddRemainders_Form : Form
    {
        public AddRemainders_Form()
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

        public delegate void AddRemsThreadSafeLoad();
        public AddRemsThreadSafeLoad mydelegate;

        DataTable all_stores;

        Supplier[] all_suppliers = null;
        Product[] all_products = null;

        decimal[] Row_Pricing = new decimal[2000];

        bool submit_clicked = false;

        public string pressed_name_keystrokes = "";

        public string pressed_supp_name_keystrokes = "";



        public void AddRemainders_Form_Load_ThreadSafe()
        {
            all_stores = ProductInfo_Main_Form.conn.AllStores();
            add_rem_storeid_col.DataSource = all_stores;//romel qveyanashic mixval is qudi daixure =)))
            add_rem_storeid_col.ValueMember = "id";
            add_rem_storeid_col.DisplayMember = "Name";

            //add_rem_storeid_col.DefaultCellStyle.NullValue = ProductInfo_Main_Form.ActiveStoreID;


            foreach (Supplier nextSupplier in all_suppliers)
            {
                supplier_chooser.Items.Add(nextSupplier.saxeli);

            }

            if (all_products.Length > 0)
            {
                add_rem_name_col.Items.Clear();
                foreach (Product nprod in all_products)
                {
                    add_rem_name_col.Items.Add(nprod.name);
                }
            }
        }

        private void AddRemainders_Form_Load(object sender, EventArgs e)
        {
            mydelegate = new AddRemsThreadSafeLoad(AddRemainders_Form_Load_ThreadSafe);

            System.ComponentModel.BackgroundWorker loadSuppliers_bw = new System.ComponentModel.BackgroundWorker();
            loadSuppliers_bw.DoWork += new DoWorkEventHandler(loadSuppliers_bw_DoWork);
            loadSuppliers_bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(loadSuppliers_bw_RunWorkerCompleted);

            loadSuppliers_bw.RunWorkerAsync();
        }

        void loadSuppliers_bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Invoke(mydelegate);
        }

        public void loadSuppliers_bw_DoWork(object sender, DoWorkEventArgs e)
        {
            all_suppliers = ProductInfo_Main_Form.conn.AllSuppliers();
            all_products = ProductInfo_Main_Form.conn.GetProductSuggestions("");
        }
        //

        private void submit_btn_Click(object sender, EventArgs e)
        {
            submit_clicked = true;

            Zednadebi shetana_zed = null;
            AngarishFaqtura shetana_af = null;
            List<Remainder> zed_prod_list = new List<Remainder>();

            if (supplier_chooser.SelectedIndex >= 0 && supplier_chooser.SelectedIndex < all_suppliers.Length)
            {
                if ("" == zed_ident_code_txt.Text)
                {
                    MessageBox.Show("ზედნადების საიდენტიფიკაციო კოდი არ არის მითითებული!");
                    return;
                }
                shetana_zed = new Zednadebi(zed_ident_code_txt.Text, zed_dro_datechooser.Value, add_rem_af_seria.Text, add_rem_af_nomeri.Text, DataProvider.OperationType.Buy, all_suppliers[supplier_chooser.SelectedIndex].saidentifikacio_kodi, DataProvider.PaymentType.Nagdi);
            }
            else
            {
                MessageBox.Show("მომწოდებელი არ არის მითითებული!");
                return;
            }

            foreach (DataGridViewRow nextRow in add_remainders_list.Rows)
            {
                if (!nextRow.IsNewRow)
                {
                    Remainder nextRemS1 = new Remainder();

                    if (null == nextRow.Cells[add_rem_barcode_col.Index].Value |
                        null == nextRow.Cells[add_rem_capacity_col.Index].Value |
                        null == nextRow.Cells[add_rem_count_type_col.Index].Value |
                        null == nextRow.Cells[add_rem_storeid_col.Index].Value |
                        0 >= Convert.ToInt32((nextRow.Cells[add_rem_storeid_col.Index].Value ?? 0).ToString()) |
                        null == nextRow.Cells[add_rem_piece_count_col.Index].Value |
                        null == nextRow.Cells[add_rem_piece_price_col.Index].Value |
                        0 > ParseDecimal((nextRow.Cells[add_rem_sell_price_col.Index].Value ?? 0).ToString()))
                    {
                        HighlightNonCompleteFields(nextRow);

                        status_bar_lbl.Text = "გთხოვთ შეავსოთ აუცილებელი ველები!";
                        return;
                    }
                    else
                    {
                        string nbarcode = nextRow.Cells[add_rem_barcode_col.Index].Value.ToString();
                        string nzedid = zed_ident_code_txt.Text;
                        decimal ncapacity = ParseDecimal(nextRow.Cells[add_rem_capacity_col.Index].Value.ToString());
                        decimal npiece_price = ParseDecimal(nextRow.Cells[add_rem_piece_price_col.Index].Value.ToString());

                        int nstore_id = 0;
                        decimal npiece_count = 0.0m;
                        decimal nsell_price = 0.0m;

                        nstore_id = Convert.ToInt32(nextRow.Cells[add_rem_storeid_col.Index].Value.ToString());
                        npiece_count = ParseDecimal(nextRow.Cells[add_rem_piece_count_col.Index].Value.ToString());
                        nsell_price = ParseDecimal((nextRow.Cells[add_rem_sell_price_col.Index].Value ?? 0).ToString());


                        if ("ყუთები" == nextRow.Cells[add_rem_count_type_col.Index].Value.ToString())
                        {
                            npiece_count *= ncapacity;
                        }
                        else
                        {
                        }
                        nextRemS1.storehouse_id = nstore_id;
                        nextRemS1.product_barcode = nbarcode;
                        nextRemS1.supplier_ident = all_suppliers[supplier_chooser.SelectedIndex].saidentifikacio_kodi;
                        nextRemS1.zednadebis_nomeri = nzedid;
                        nextRemS1.pack_capacity = ncapacity;
                        nextRemS1.buy_price = npiece_price;
                        nextRemS1.formal_buy_price = npiece_price;
                        nextRemS1.sell_price = nsell_price;
                        nextRemS1.formal_sell_price = nsell_price;
                        nextRemS1.initial_pieces = npiece_count;
                        nextRemS1.remaining_pieces = npiece_count;

                        if (npiece_count > 0)
                        {
                            zed_prod_list.Add(nextRemS1);
                        }

                    }


                }
                else
                {
                    //Last, unused row (IsNewRow)
                }
            }//foreach datagridviewrow

            if (!(zed_prod_list.Count > 0))
            {
                status_bar_lbl.Text = "პროდუქტების სიის გარეშე გაყიდვა არ მოხდება!";
                return;
            }

            PurchaseOrder shemotana_pur;
            if (using_af_ckb.Checked && "" != add_rem_af_seria.Text && "" != add_rem_af_nomeri.Text)
            {
                shetana_af = new AngarishFaqtura(add_rem_af_seria.Text, add_rem_af_nomeri.Text, add_rem_af_date_chooser.Value, DataProvider.OperationType.Buy, all_suppliers[supplier_chooser.SelectedIndex].saidentifikacio_kodi);
                shemotana_pur = new PurchaseOrder(DateTime.Now, all_suppliers[supplier_chooser.SelectedIndex], shetana_zed, zed_prod_list.ToArray(), shetana_af);
            }
            else
            {
                shemotana_pur = new PurchaseOrder(DateTime.Now, all_suppliers[supplier_chooser.SelectedIndex], shetana_zed, zed_prod_list.ToArray(), null);
            }
            info trans_res = ProductInfo_Main_Form.conn.AddPurchaseOrder(shemotana_pur);
            MessageBox.Show(trans_res.errcode.ToString() + ":" + trans_res.details);
            //MessageBox.Show("TODO in DataProvider: SPROC RETVAL??? " + trans_res.errcode.ToString() + ":" + trans_res.details);
            if (501 == trans_res.errcode | 0 == trans_res.errcode)
            {
                MessageBox.Show("ზედნადები დამატებულია.");
                this.Close();
            }
            else
            {
                MessageBox.Show("მოხდა შეცდომა. ზედნადები არ დამატებულა! ");
            }
        }

        private void HighlightNonCompleteFields(DataGridViewRow nextRow)
        {
            if (null == nextRow.Cells[add_rem_barcode_col.Index].Value)
            {
                nextRow.Cells[add_rem_barcode_col.Index].Style.BackColor = Color.Red;
            }
            else
            {
                nextRow.Cells[add_rem_barcode_col.Index].Style.BackColor = Color.White;
            }
            if (null == nextRow.Cells[add_rem_capacity_col.Index].Value)
            {
                nextRow.Cells[add_rem_capacity_col.Index].Style.BackColor = Color.Red;
            }
            else
            {
                nextRow.Cells[add_rem_capacity_col.Index].Style.BackColor = Color.White;
            }
            if (null == nextRow.Cells[add_rem_count_type_col.Index].Value)
            {
                nextRow.Cells[add_rem_count_type_col.Index].Style.BackColor = Color.Red;
            }
            else
            {
                nextRow.Cells[add_rem_count_type_col.Index].Style.BackColor = Color.White;
            }
            if (null == nextRow.Cells[add_rem_storeid_col.Index].Value)
            {
                nextRow.Cells[add_rem_storeid_col.Index].Style.BackColor = Color.Red;
            }
            else
            {
                nextRow.Cells[add_rem_storeid_col.Index].Style.BackColor = Color.White;
            }
            if (null == nextRow.Cells[add_rem_piece_count_col.Index].Value)
            {
                nextRow.Cells[add_rem_piece_count_col.Index].Style.BackColor = Color.Red;
            }
            else
            {
                nextRow.Cells[add_rem_piece_count_col.Index].Style.BackColor = Color.White;
            }
            if (null == nextRow.Cells[add_rem_piece_price_col.Index].Value)
            {
                nextRow.Cells[add_rem_piece_price_col.Index].Style.BackColor = Color.Red;
            }
            else
            {
                nextRow.Cells[add_rem_piece_price_col.Index].Style.BackColor = Color.White;
            }
        }

        private void add_remainders_list_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void add_remainders_list_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F8)
            {
                try
                {
                    int currentRowIndex = add_remainders_list.CurrentRow.Index;
                    add_remainders_list.ClearSelection();
                    add_remainders_list.EndEdit();
                    add_remainders_list.Rows[currentRowIndex].Cells[add_rem_barcode_col.Index].Selected = true;
                }
                catch (NullReferenceException)
                {
                    add_remainders_list.Rows.Add();
                }
            }
        }

        private void add_remainders_list_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (add_rem_name_col.Index == add_remainders_list.CurrentCell.ColumnIndex)
            {
                ComboBox cb = (ComboBox)e.Control;
                cb.DropDownStyle = ComboBoxStyle.DropDown;
            }
            else if (add_rem_storeid_col.Index == add_remainders_list.CurrentCell.ColumnIndex)
            {
                ComboBox StoreIdChooser = (ComboBox)e.Control;
            }

            e.Control.KeyDown -= add_list_Control_KeyDown;
            e.Control.KeyDown += new KeyEventHandler(add_list_Control_KeyDown);

            e.Control.KeyPress -= add_list_Control_KeyPress;
            e.Control.KeyPress += new KeyPressEventHandler(add_list_Control_KeyPress);
        }

        void add_list_Control_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (add_rem_name_col.Index == add_remainders_list.CurrentCell.ColumnIndex)
            {
                Control ctl = (Control)sender;
                //e.SuppressKeyPress = false;
                //e.Handled = true;
                //string pressedKey = ((char)e.KeyCode).ToString();
                string pressedKey = e.KeyChar.ToString();
                //if (!e.Shift)
                //{
                //    pressedKey = pressedKey.ToLower();
                //}
                //if (e.KeyData != Keys.Shift)
                //{
                if (pressed_name_keystrokes != ProductInfo_Main_Form.UTF8String(pressedKey))
                {
                    pressed_name_keystrokes += ProductInfo_Main_Form.UTF8String(pressedKey);
                }
                //}

                status_bar_lbl.Text = pressed_name_keystrokes;
                if ("" != pressed_name_keystrokes)
                {
                    try
                    {
                        Product[] prod_suggestions = ProductInfo_Main_Form.conn.GetProductSuggestions(pressed_name_keystrokes);
                        if (prod_suggestions.Length > 0)
                        {
                            add_remainders_list.CurrentRow.Cells[add_rem_barcode_col.Index].Value = prod_suggestions[0].barcode;
                            foreach (object nextItem in add_rem_name_col.Items)
                            {
                                if (nextItem.ToString() == prod_suggestions[0].name)
                                {
                                    add_remainders_list.CurrentRow.Cells[add_rem_name_col.Index].Value = nextItem.ToString();//prod_suggestions[0].name;
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

        void Control_KeyUp(object sender, KeyEventArgs e)
        {

        }

        void add_list_Control_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Home)
            {
                add_remainders_list.EndEdit();
                add_remainders_list.CurrentCell = add_remainders_list.CurrentRow.Cells[0];
            }
            if (e.KeyCode == Keys.F8)
            {
                try
                {
                    int currentRowIndex = add_remainders_list.CurrentRow.Index;
                    add_remainders_list.ClearSelection();
                    add_remainders_list.EndEdit();
                    add_remainders_list.Rows[currentRowIndex].Cells[add_rem_barcode_col.Index].Selected = true;
                }
                catch (NullReferenceException)
                {
                    add_remainders_list.Rows.Add();
                }
            }



        }

        private void add_remainders_list_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            pressed_name_keystrokes = "";
            if (submit_clicked && !add_remainders_list.Rows[e.RowIndex].IsNewRow)
            {
                HighlightNonCompleteFields(add_remainders_list.Rows[e.RowIndex]);
            }
            if (add_remainders_list.Columns[add_rem_barcode_col.Index].Index == e.ColumnIndex && null != add_remainders_list.Rows[e.RowIndex].Cells[e.ColumnIndex].Value)
            {
                Product ProdJustScanned = ProductInfo_Main_Form.conn.GetProductByBarCode(add_remainders_list.Rows[e.RowIndex].Cells[add_rem_barcode_col.Index].EditedFormattedValue.ToString());
                if ("nameless" == ProdJustScanned.name)
                {
                    if (DialogResult.Yes == MessageBox.Show("შტრიხ–კოდი არ არის დარეგისტრირებული. გსურთ პროდუქტის ბაზაში დამატება?", "შეცდომა!", MessageBoxButtons.YesNo))
                    {
                        AddProduct_Form add_scanned_frm = new AddProduct_Form();
                        add_scanned_frm.Show();
                        add_scanned_frm.Controls["barcode_txt"].Text = add_remainders_list.Rows[e.RowIndex].Cells[add_rem_barcode_col.Index].Value.ToString();
                        add_scanned_frm.Controls["name_txt"].Focus();
                        add_scanned_frm.Controls["prod_add_btn"].Click += new EventHandler(AddRemainders_Form_Click);
                    }
                    else
                    {
                        add_remainders_list.Rows[e.RowIndex].Cells[add_rem_barcode_col.Index].Value = "000000000";
                    }
                }
                else
                {
                    try
                    {
                        add_remainders_list.Rows[e.RowIndex].Cells[add_rem_name_col.Index].Value = ProdJustScanned.name;
                    }
                    catch (System.ArgumentException)
                    {
                    }
                    finally
                    {
                    }
                }
            }

            if (add_remainders_list.Columns[add_rem_name_col.Index].Index == e.ColumnIndex && null != add_remainders_list.Rows[e.RowIndex].Cells[e.ColumnIndex].Value)
            {
                foreach (Product nXprod in all_products)
                {
                    if (add_remainders_list.Rows[e.RowIndex].Cells[add_rem_name_col.Index].Value.ToString() == nXprod.name)
                    {
                        add_remainders_list.Rows[e.RowIndex].Cells[add_rem_barcode_col.Index].Value = nXprod.barcode;
                        break;
                    }
                }
            }

            try
            {
                if (null != add_remainders_list.Rows[e.RowIndex].Cells[add_rem_piece_count_col.Index].Value)
                {
                    if (null != add_remainders_list.Rows[e.RowIndex].Cells[add_rem_count_type_col.Index].Value)
                    {
                        if ("ცალობით" == add_remainders_list.Rows[e.RowIndex].Cells[add_rem_count_type_col.Index].Value.ToString())
                        {
                            decimal row_piece_price = 0.0m;
                            decimal row_sum_price = 0.0m;

                            decimal row_piece_count = 0.0m;
                            if (null != add_remainders_list.Rows[e.RowIndex].Cells[add_rem_piece_count_col.Index].Value)
                            {
                                row_piece_count = ParseDecimal(add_remainders_list.Rows[e.RowIndex].Cells[add_rem_piece_count_col.Index].Value.ToString());
                            }

                            if (null != add_remainders_list.Rows[e.RowIndex].Cells[add_rem_piece_price_col.Index].Value)
                            {
                                row_piece_price = ParseDecimal(add_remainders_list.Rows[e.RowIndex].Cells[add_rem_piece_price_col.Index].Value.ToString());
                                row_sum_price = row_piece_count * row_piece_price;
                                add_remainders_list.Rows[e.RowIndex].Cells[add_rem_sum_price_col.Index].Value = row_sum_price; // * ((decimal)add_remainders_list.Rows[e.RowIndex].Cells[add_rem_storeid_col.Index].Value + (decimal)add_remainders_list.Rows[e.RowIndex].Cells[add_rem_piece_price_col.Index].Value);
                                Row_Pricing[e.RowIndex] = row_sum_price;
                                //
                                decimal row_sell_price = ParseDecimal(add_remainders_list.Rows[e.RowIndex].Cells[add_rem_sell_price_col.Index].Value.ToString());
                                add_remainders_list.Rows[e.RowIndex].Cells[add_rem_namati_col.Index].Value
                                    = ((row_sell_price >= row_piece_price) ? "+" : "") + Math.Round(((row_sell_price - row_piece_price) / row_piece_price) * 100, 2) + "%";
                                add_remainders_list.Rows[e.RowIndex].Cells[add_rem_namati_col.Index].Style.BackColor
                                    = (row_sell_price >= row_piece_price) ? Color.LightGray : Color.Red;
                                //add_remainders_list.Rows[e.RowIndex].Cells[add_rem_namati_col.Index].Style.ForeColor
                                //    = (row_sell_price >= row_piece_price) ? Color.Black : Color.White;
                                //
                                UpdateSumPrice();
                            }
                        }
                        else
                        {
                            decimal pack_count = 0.0m;
                            decimal row_piece_price = 0.0m;
                            decimal row_sum_price = 0.0m;

                            decimal row_piece_count = 0.0m;
                            if (null != add_remainders_list.Rows[e.RowIndex].Cells[add_rem_piece_count_col.Index].Value)
                            {
                                row_piece_count = ParseDecimal(add_remainders_list.Rows[e.RowIndex].Cells[add_rem_piece_count_col.Index].Value.ToString());
                            }

                            if (null != add_remainders_list.Rows[e.RowIndex].Cells[add_rem_piece_price_col.Index].Value && null != add_remainders_list.Rows[e.RowIndex].Cells[add_rem_capacity_col.Index].Value)
                            {
                                row_piece_price = ParseDecimal(add_remainders_list.Rows[e.RowIndex].Cells[add_rem_piece_price_col.Index].Value.ToString());
                                pack_count = ParseDecimal(add_remainders_list.Rows[e.RowIndex].Cells[add_rem_capacity_col.Index].Value.ToString());
                                row_sum_price = row_piece_count * pack_count * row_piece_price;
                                add_remainders_list.Rows[e.RowIndex].Cells[add_rem_sum_price_col.Index].Value = row_sum_price; // * ((decimal)add_remainders_list.Rows[e.RowIndex].Cells[add_rem_storeid_col.Index].Value + (decimal)add_remainders_list.Rows[e.RowIndex].Cells[add_rem_piece_price_col.Index].Value);
                                Row_Pricing[e.RowIndex] = row_sum_price;
                                //
                                decimal row_sell_price = ParseDecimal(add_remainders_list.Rows[e.RowIndex].Cells[add_rem_sell_price_col.Index].Value.ToString());
                                add_remainders_list.Rows[e.RowIndex].Cells[add_rem_namati_col.Index].Value
                                    = ((row_sell_price >= row_piece_price) ? "+" : "") + Math.Round(((row_sell_price - row_piece_price) / row_piece_price) * 100, 2) + "%";
                                add_remainders_list.Rows[e.RowIndex].Cells[add_rem_namati_col.Index].Style.BackColor
                                    = (row_sell_price >= row_piece_price) ? Color.LightGray : Color.Red;
                                //add_remainders_list.Rows[e.RowIndex].Cells[add_rem_namati_col.Index].Style.ForeColor
                                //    = (row_sell_price >= row_piece_price) ? Color.Black : Color.White;
                                //
                                UpdateSumPrice();
                            }
                        }
                    }
                }
            }
            catch (FormatException)
            {
                status_bar_lbl.Text = "შეავსეთ ველები შესაბამისი ფორმატით. ";
            }
            catch (NullReferenceException)//not needed
            {
                status_bar_lbl.Text = "ყველა ველი არაა შევსებული. ";
            }
        }

        void AddRemainders_Form_Click(object sender, EventArgs e)
        {
            all_products = ProductInfo_Main_Form.conn.GetProductSuggestions("");
            if (all_products.Length > 0)
            {
                add_rem_name_col.Items.Clear();
                foreach (Product nprod in all_products)
                {
                    add_rem_name_col.Items.Add(nprod.name);
                }
            }
        }

        private void AddRemainders_Form_KeyDown(object sender, KeyEventArgs e)
        {
            //MessageBox.Show("Key Down");
        }

        private void supplier_chooser_SelectedIndexChanged(object sender, EventArgs e)
        {
            status_bar_lbl.Text = "შეიყვანეთ ზედნადების ნომერი. ";
        }

        private void zed_ident_code_txt_TextChanged(object sender, EventArgs e)
        {
            status_bar_lbl.Text = "შეიყვანეთ ზედნადების თარიღი თუ განსხვავდება დღევანდელისგან, შეავსეთ ა/ფ ინფორმაცია თუ არსებობს, ან დაიწყეთ ნაშთების შეყვანა. ";
        }

        public void UpdateSumPrice()
        {
            decimal SumPrice = 0.0m;
            decimal SumPriceWithoutVAT = 0.0m;
            int index = 0;
            foreach (decimal nXprice in Row_Pricing)
            {
                SumPrice += nXprice;
                decimal VATforCurProd = (1.0m / 1.18m);

                if (0.0m != nXprice)
                {
                    if (null != add_remainders_list.Rows[index].Cells[add_rem_barcode_col.Index].Value)
                    {
                        if (false == ProductInfo_Main_Form.conn.GetProductByBarCode(add_remainders_list.Rows[index].Cells[add_rem_barcode_col.Index].Value.ToString()).usesVAT)
                            VATforCurProd = 1.0m;
                    }
                }
                SumPriceWithoutVAT += nXprice * VATforCurProd;

                index++;
            }
            lbl_sum_price.Text = "საერთო ფასი " + SumPrice.ToString() + " ლარი";
            lbl_sum_price_without_vat.Text = "ჯამი დღგ–ს გარეშე " + SumPriceWithoutVAT.ToString() + " ლარი";
        }

        private void add_remainders_list_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == add_rem_delete_col.Index)
            {
                if (!add_remainders_list.Rows[e.RowIndex].IsNewRow && null != add_remainders_list.Rows[e.RowIndex])
                {
                    string deleting_row_prod_name = (null != add_remainders_list.Rows[e.RowIndex].Cells[add_rem_name_col.Index].Value) ? add_remainders_list.Rows[e.RowIndex].Cells[add_rem_name_col.Index].Value.ToString() : "პროდუქტი";
                    if (DialogResult.Yes == MessageBox.Show("ნამდვილად გსურთ სიიდან " + deleting_row_prod_name + "-ს ამოშლა?", "დადასტურება", MessageBoxButtons.YesNo))
                    {
                        add_remainders_list.Rows.Remove(add_remainders_list.Rows[e.RowIndex]);
                        UpdateSumPrice();
                    }
                }
            }
        }

        private void using_af_ckb_CheckedChanged(object sender, EventArgs e)
        {
            lbl_af_seria.Visible = !lbl_af_seria.Visible;
            add_rem_af_seria.Visible = !add_rem_af_seria.Visible;
            lbl_af_ident_code.Visible = !lbl_af_ident_code.Visible;
            add_rem_af_nomeri.Visible = !add_rem_af_nomeri.Visible;
            lbl_addrem_af_tarigi.Visible = !lbl_addrem_af_tarigi.Visible;
            add_rem_af_date_chooser.Visible = !add_rem_af_date_chooser.Visible;
        }

        private void btn_add_suppliers_Click(object sender, EventArgs e)
        {
            AddSupplier_Form add_supp_form = new AddSupplier_Form();
            add_supp_form.Show();
            add_supp_form.FormClosed += new FormClosedEventHandler(add_supp_form_FormClosed);
        }

        void add_supp_form_FormClosed(object sender, FormClosedEventArgs e)
        {
            all_suppliers = ProductInfo_Main_Form.conn.AllSuppliers();
            supplier_chooser.Items.Clear();
            foreach (Supplier nextSupplier in all_suppliers)
            {
                supplier_chooser.Items.Add(nextSupplier.saxeli);

            }
            //
        }

        private void add_remainders_list_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //better do nothing or cancel editing than continuously show MessageBoxes. 
            add_remainders_list.CancelEdit();
        }

        private void supplier_chooser_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void btn_find_supplier_Click(object sender, EventArgs e)
        {
            if ("" != pressed_supp_name_keystrokes)
            {
                try
                {
                    Supplier[] matched_supps = (from Supplier s in all_suppliers
                                                where s.saxeli.Contains(pressed_supp_name_keystrokes)
                                                select s).ToArray();
                    if (matched_supps.Length > 0)
                    {
                        supplier_chooser.SelectedItem = matched_supps[0].saxeli;
                        supplier_chooser.Text = matched_supps[0].saxeli;
                    }
                    else
                    {
                        status_bar.Text = "მსგავსი მომწოდებელი არ მოიძებნა!";
                    }
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("null ref");
                }
            }
        }

        private void supplier_chooser_Enter(object sender, EventArgs e)
        {
            pressed_supp_name_keystrokes = "";
        }

        private void supplier_chooser_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control ctl = (Control)sender;
            //e.SuppressKeyPress = false;
            e.Handled = true;
            //string pressedKey = ((char)e.KeyValue).ToString();
            /*if (!e.Shift)
            {
                pressedKey = pressedKey.ToLower();
            }
            if (e.KeyData != Keys.Shift)
            {
                pressed_supp_name_keystrokes += ProductInfo_Main_Form.UTF8String(pressedKey);
            }*/
            string pressedKey = e.KeyChar.ToString();
            pressed_supp_name_keystrokes += ProductInfo_Main_Form.UTF8String(pressedKey);

            status_bar_lbl.Text = pressed_supp_name_keystrokes;
            if ("" != pressed_supp_name_keystrokes)
            {
                try
                {
                    Supplier[] matched_supps = (from Supplier s in all_suppliers
                                                where s.saxeli.Contains(pressed_supp_name_keystrokes)
                                                select s).ToArray();
                    if (matched_supps.Length > 0)
                    {
                        supplier_chooser.SelectedItem = matched_supps[0].saxeli;
                        supplier_chooser.Text = matched_supps[0].saxeli;
                    }
                    else
                    {
                        status_bar.Text = "მსგავსი მომწოდებელი არ მოიძებნა!";
                    }
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("null ref");
                }
            }
        }

        private void add_remainders_list_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow dgrow in add_remainders_list.Rows)
            {
                if (dgrow.IsNewRow)
                {
                    continue;
                }
                dgrow.HeaderCell.Value = String.Format((dgrow.Index + 1).ToString(), "0");
            }
            add_remainders_list.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
        }

        private void btn_get_from_rs_ge_Click(object sender, EventArgs e)
        {
            //placeholder for zednadebi downloaded from rs.ge
            Zednadebi zed = ProductInfo_Main_Form.conn.GetZednadebi("001", DataProvider.OperationType.Buy.ToString(), "123123123");
            ChooseRSIncomingZed frmRcvZed = new ChooseRSIncomingZed();
            frmRcvZed.InitIncomingZed(zed);
            frmRcvZed.ShowDialog();
        }

        //
    }
}
