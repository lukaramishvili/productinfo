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
    public partial class Sell_Form : Form
    {
        public Sell_Form()
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

        Buyer[] all_buyers = null;
        Product[] all_products = null;
        public int ActiveStoreID = 0;

        decimal[] Row_Pricing = new decimal[2000];

        bool submit_clicked = false;

        Remainder[] all_rems = null;

        DataTable all_stores;

        public string pressed_name_keystrokes = "";
        public string pressed_buyer_name_keystrokes = "";


        private void HighlightNonCompleteFields(DataGridViewRow nextRow)
        {
            if (null == nextRow.Cells["sell_rem_barcode_col"].Value)
            {
                nextRow.Cells["sell_rem_barcode_col"].Style.BackColor = Color.Red;
            }
            else
            {
                nextRow.Cells["sell_rem_barcode_col"].Style.BackColor = Color.White;
            }
            if (null == nextRow.Cells["sell_rem_capacity_col"].Value)
            {
                nextRow.Cells["sell_rem_capacity_col"].Style.BackColor = Color.Red;
            }
            else
            {
                nextRow.Cells["sell_rem_capacity_col"].Style.BackColor = Color.White;
            }
            if (null == nextRow.Cells["sell_rem_count_type_col"].Value)
            {
                nextRow.Cells["sell_rem_count_type_col"].Style.BackColor = Color.Red;
            }
            else
            {
                nextRow.Cells["sell_rem_count_type_col"].Style.BackColor = Color.White;
            }
            if (null == nextRow.Cells[sell_rem_storeid_col.Index].Value)
            {
                nextRow.Cells[sell_rem_storeid_col.Index].Style.BackColor = Color.Red;
            }
            else
            {
                nextRow.Cells[sell_rem_storeid_col.Index].Style.BackColor = Color.White;
            }
            if (null == nextRow.Cells[sell_rem_piece_count_col.Index].Value)
            {
                nextRow.Cells[sell_rem_piece_count_col.Index].Style.BackColor = Color.Red;
            }
            else
            {
                nextRow.Cells[sell_rem_piece_count_col.Index].Style.BackColor = Color.White;
            }
            if (null == nextRow.Cells["sell_rem_piece_price_col"].Value)
            {
                nextRow.Cells["sell_rem_piece_price_col"].Style.BackColor = Color.Red;
            }
            else
            {
                nextRow.Cells["sell_rem_piece_price_col"].Style.BackColor = Color.White;
            }
        }

        private void Sell_Form_Load(object sender, EventArgs e)
        {
            all_stores = ProductInfo_Main_Form.conn.AllStores();
            sell_rem_storeid_col.DataSource = all_stores;//romel qveyanashic mixval is qudi daixure =)))
            sell_rem_storeid_col.ValueMember = "id";
            sell_rem_storeid_col.DisplayMember = "Name";
            //

            all_buyers = ProductInfo_Main_Form.conn.AllBuyers();
            foreach (Buyer nextBuyer in all_buyers)
            {
                buyer_chooser.Items.Add(nextBuyer.saxeli);
            }

            //
            try
            {
                //zed_ident_code_txt.Text = (Int32.Parse(ProductInfo_Main_Form.conn.MaxZedIdent()) + 1).ToString();
                zed_ident_code_txt.Text = ProductInfo_Main_Form.conn.NextZedIdent(ProductInfo_Main_Form.ActiveStoreID);
            }
            catch (FormatException)
            {
            }
            catch (OverflowException)
            {
            }
            //

            all_rems = ProductInfo_Main_Form.conn.GetValidRemainders(0, true);
            all_products = ProductInfo_Main_Form.conn.GetProductSuggestions("");
            if (all_rems.Length > 0)
            {
                sell_rem_name_col.Items.Clear();

                foreach (Remainder nrem in all_rems)
                {
                    foreach (Product nprod in all_products)
                    {
                        if (nprod.barcode == nrem.product_barcode && !sell_rem_name_col.Items.Contains(nprod.name))
                        {
                            sell_rem_name_col.Items.Add(nprod.name);
                            break;
                        }
                    }
                }
            }

            ckb_pay_method.SelectedIndex = 1;
            /*if (all_products.Length > 0)
            {
                sell_rem_name_col.Items.Clear();
                foreach (Product nprod in all_products)
                {
                    sell_rem_name_col.Items.Add(nprod.name);
                }
            }*/
        }

        private void buyer_chooser_SelectedIndexChanged(object sender, EventArgs e)
        {
            status_bar_lbl.Text = "შეიყვანეთ ზედნადების ნომერი. ";
        }

        private void submit_btn_Click(object sender, EventArgs e)
        {
            submit_clicked = true;

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

            if (buyer_chooser.SelectedIndex >= 0 && buyer_chooser.SelectedIndex < all_buyers.Length)
            {
                if ("" == zed_ident_code_txt.Text)
                {
                    MessageBox.Show("ზედნადების საიდენტიფიკაციო კოდი არ არის მითითებული!");
                    return;
                }
                gayidva_zed = new Zednadebi(zed_ident_code_txt.Text, zed_dro_datechooser.Value, add_rem_af_seria.Text, add_rem_af_nomeri.Text, DataProvider.OperationType.Sell, all_buyers[buyer_chooser.SelectedIndex].saidentifikacio_kodi, paying_method_now);
            }
            else
            {
                MessageBox.Show("მყიდველი არ არის მითითებული!");
                return;
            }

            foreach (DataGridViewRow nextRow in add_remainders_list.Rows)
            {
                if (!nextRow.IsNewRow)
                {
                    Remainder nextRemS1 = new Remainder();

                    if (null == nextRow.Cells["sell_rem_barcode_col"].Value |
                        null == nextRow.Cells["sell_rem_capacity_col"].Value |
                        null == nextRow.Cells["sell_rem_count_type_col"].Value |
                        null == nextRow.Cells[sell_rem_storeid_col.Index].Value |
                        null == nextRow.Cells[sell_rem_piece_count_col.Index].Value |
                        null == nextRow.Cells["sell_rem_piece_price_col"].Value)
                    {
                        HighlightNonCompleteFields(nextRow);

                        status_bar_lbl.Text = "გთხოვთ შეავსოთ აუცილებელი ველები!";
                        return;
                    }
                    else
                    {
                        string nbarcode = nextRow.Cells["sell_rem_barcode_col"].Value.ToString();
                        string nzedid = zed_ident_code_txt.Text;
                        decimal ncapacity = ParseDecimal(nextRow.Cells["sell_rem_capacity_col"].Value.ToString());
                        decimal npiece_price = ParseDecimal(nextRow.Cells["sell_rem_piece_price_col"].Value.ToString());
                        int nstore_id = Int32.Parse(nextRow.Cells[sell_rem_storeid_col.Index].Value.ToString());

                        decimal npiece_count = 0.0m;
                        if (null != nextRow.Cells[sell_rem_piece_count_col.Index].Value)
                        {
                            npiece_count = ParseDecimal(nextRow.Cells[sell_rem_piece_count_col.Index].Value.ToString());
                        }

                        if ("ყუთები" == nextRow.Cells["sell_rem_count_type_col"].Value.ToString())
                        {
                            npiece_count *= ncapacity;
                        }
                        else
                        {
                        }
                        nextRemS1.storehouse_id = nstore_id;
                        nextRemS1.product_barcode = nbarcode;
                        nextRemS1.supplier_ident = all_buyers[buyer_chooser.SelectedIndex].saidentifikacio_kodi;
                        nextRemS1.zednadebis_nomeri = nzedid;
                        nextRemS1.pack_capacity = ncapacity;
                        nextRemS1.buy_price = npiece_price;
                        nextRemS1.formal_buy_price = npiece_price;
                        nextRemS1.sell_price = npiece_price;
                        nextRemS1.formal_sell_price = npiece_price;
                        nextRemS1.initial_pieces = npiece_count;
                        nextRemS1.remaining_pieces = npiece_count;
                        /*
                        nextRemS2.storehouse_id = 2;
                        nextRemS2.product_barcode = nbarcode;
                        nextRemS2.supplier_ident = all_buyers[buyer_chooser.SelectedIndex].saidentifikacio_kodi;
                        nextRemS2.zednadebis_nomeri = nzedid;
                        nextRemS2.pack_capacity = ncapacity;
                        nextRemS2.buy_price = npiece_price;
                        nextRemS2.formal_buy_price = npiece_price;
                        nextRemS2.sell_price = npiece_price;
                        nextRemS2.formal_sell_price = npiece_price;
                        nextRemS2.initial_pieces = nstore2_count;
                        nextRemS2.remaining_pieces = nstore2_count;
                        */
                        if (npiece_count > 0)
                        {
                            zed_prod_list.Add(nextRemS1);
                        }/*
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

            if (zed_prod_list.Count <= 0)
            {
                MessageBox.Show("ცარიელი ზედნადების გაყიდვა არაა დაშვებული!");
                return;
            }

            if (zed_prod_list.Count > 23)
            {
                MessageBox.Show("ზედნადების ფორმით 23–ზე მეტი პროდუქტის გაყიდვა არაა დაშვებული!");
                return;
            }

            SellOrder shemotana_SO;
            if (using_af_ckb.Checked && "" != add_rem_af_seria.Text && "" != add_rem_af_nomeri.Text)
            {
                gayidva_af = new AngarishFaqtura(add_rem_af_seria.Text, add_rem_af_nomeri.Text, add_rem_af_date_chooser.Value, DataProvider.OperationType.Sell, all_buyers[buyer_chooser.SelectedIndex].saidentifikacio_kodi);
                shemotana_SO = new SellOrder(gayidva_zed.dro, true, paying_method_now, all_buyers[buyer_chooser.SelectedIndex], gayidva_zed, zed_prod_list.ToArray(), gayidva_af);
            }
            else
            {
                shemotana_SO = new SellOrder(gayidva_zed.dro, true, paying_method_now, all_buyers[buyer_chooser.SelectedIndex], gayidva_zed, zed_prod_list.ToArray(), null);
            }
            //this variable will be initialized by the AddSellOrder call, but not neccessery in this code because this SellOrder is Zednadebi (Invoice)
            int SellOrderInsertID;
            info trans_res = ProductInfo_Main_Form.conn.AddSellOrder(shemotana_SO, out SellOrderInsertID);
            MessageBox.Show("TODO in DataProvider: SPROC RETVAL??? " + trans_res.errcode.ToString() + ":" + trans_res.details);
            if (501 == trans_res.errcode | 0 == trans_res.errcode)
            {
                MessageBox.Show("ზედნადები გაყიდულია.");

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
                    info payforsellingzed_info = ProductInfo_Main_Form.conn.TransferMoney(
                        all_buyers[buyer_chooser.SelectedIndex].saidentifikacio_kodi
                        , DataProvider.MoneyTransferType.Take
                        , DateTime.Now
                        , selling_rem_sum
                        , typeof(Buyer)
                        , DataProvider.MoneyTransferPurpose.PayFor
                        , cb_mt_store_id.SelectedIndex
                        , typeof(Zednadebi)
                        , zed_ident_code_txt.Text
                        //zednadebistvis gadaxdaze mgoni ar girs gaformeba cashier-ze da cashbox-ze
                        , 0//ProductInfo_Main_Form.ActiveCashBoxID
                        , 0//ProductInfo_Main_Form.ActiveCashierID
                        );
                    MessageBox.Show(payforsellingzed_info.details, payforsellingzed_info.errcode.ToString());
                }
                this.Close();
            }
            else if (404 == trans_res.errcode)
            {
                MessageBox.Show("ამ რაოდენობის პროდუქტები საწყობში აღარაა დარჩენილი! ");
            }
            else
            {
                MessageBox.Show("მოხდა შეცდომა. ზედნადები არ გაყიდულა! ");
            }
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
                    if (null != add_remainders_list.Rows[index].Cells["sell_rem_barcode_col"].Value)
                    {
                        if (false == ProductInfo_Main_Form.conn.GetProductByBarCode(add_remainders_list.Rows[index].Cells["sell_rem_barcode_col"].Value.ToString()).usesVAT)
                            VATforCurProd = 1.0m;
                    }
                }
                SumPriceWithoutVAT += nXprice * VATforCurProd;

                index++;
            }
            lbl_sum_price.Text = "საერთო ფასი " + SumPrice.ToString() + " ლარი";
            lbl_sum_price_without_vat.Text = "ჯამი დღგ–ს გარეშე " + SumPriceWithoutVAT.ToString() + " ლარი";
        }

        private void sell_list_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == sell_rem_delete_col.Index)
            {
                if (!add_remainders_list.Rows[e.RowIndex].IsNewRow && null != add_remainders_list.Rows[e.RowIndex])
                {
                    string ProdToDel = (null != add_remainders_list.Rows[e.RowIndex].Cells["sell_rem_name_col"].Value) ? add_remainders_list.Rows[e.RowIndex].Cells["sell_rem_name_col"].Value.ToString() : "პროდუქტი";
                    if (DialogResult.Yes == MessageBox.Show("ნამდვილად გსურთ სიიდან " + ProdToDel + "-ს ამოშლა?", "დადასტურება", MessageBoxButtons.YesNo))
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

        private void add_remainders_list_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            pressed_name_keystrokes = "";
            if (submit_clicked && !add_remainders_list.Rows[e.RowIndex].IsNewRow)
            {
                HighlightNonCompleteFields(add_remainders_list.Rows[e.RowIndex]);
            }
            if (add_remainders_list.Columns["sell_rem_barcode_col"].Index == e.ColumnIndex && null != add_remainders_list.Rows[e.RowIndex].Cells[e.ColumnIndex].Value)
            {

                Product ProdJustScanned = ProductInfo_Main_Form.conn.GetProductByBarCode(add_remainders_list.Rows[e.RowIndex].Cells["sell_rem_barcode_col"].EditedFormattedValue.ToString());
                if ("nameless" == ProdJustScanned.name)
                {
                    if (DialogResult.Yes == MessageBox.Show("შტრიხ–კოდი არ არის დარეგისტრირებული. გსურთ პროდუქტის ბაზაში დამატება?", "შეცდომა!", MessageBoxButtons.YesNo))
                    {
                        AddProduct_Form add_scanned_frm = new AddProduct_Form();
                        add_scanned_frm.Show();
                        add_scanned_frm.Controls["barcode_txt"].Text = add_remainders_list.Rows[e.RowIndex].Cells["sell_rem_barcode_col"].Value.ToString();
                        add_scanned_frm.Controls["name_txt"].Focus();
                        add_scanned_frm.Controls["prod_add_btn"].Click += new EventHandler(Sell_Form_Click);
                    }
                    else
                    {
                        add_remainders_list.Rows[e.RowIndex].Cells["sell_rem_barcode_col"].Value = "000000000";
                    }
                }
                else
                {
                    add_remainders_list.Rows[e.RowIndex].Cells["sell_rem_name_col"].Value = ProdJustScanned.name;
                }

                IEnumerable<Remainder> query = new List<Remainder>();
                query = from r in all_rems
                        where r.product_barcode == add_remainders_list.Rows[e.RowIndex].Cells[sell_rem_barcode_col.Index].Value.ToString()
                        select r;
                Remainder[] query_toarray = query.ToArray();

                add_remainders_list.Rows[e.RowIndex].Cells["sell_rem_remaining_col"].Value = query.Sum(r => r.remaining_pieces).ToString("G4") + " (სულ)";

                if (query_toarray.Length > 0)
                {
                    add_remainders_list.Rows[e.RowIndex].Cells[sell_rem_capacity_col.Index].Value = query_toarray[0].pack_capacity.ToString("G4");
                    add_remainders_list.Rows[e.RowIndex].Cells[sell_rem_initial_price_col.Index].Value = query_toarray[0].buy_price.ToString("G4") + " (#" + query_toarray[0].storehouse_id.ToString() + ")";
                }
                else
                {
                    MessageBox.Show("ეს პროდუქტი საწყობების ბაზაში არაა დარჩენილი. ");
                    add_remainders_list.Rows[e.RowIndex].Cells[sell_rem_barcode_col.Index].Value = "000000000";
                }
            }

            if (add_remainders_list.Columns[sell_rem_name_col.Index].Index == e.ColumnIndex && null != add_remainders_list.Rows[e.RowIndex].Cells[e.ColumnIndex].Value)
            {
                foreach (Product nXprod in all_products)
                {
                    if (add_remainders_list.Rows[e.RowIndex].Cells[sell_rem_name_col.Index].Value.ToString() == nXprod.name)
                    {
                        add_remainders_list.Rows[e.RowIndex].Cells[sell_rem_barcode_col.Index].Value = nXprod.barcode;

                        IEnumerable<Remainder> query = new List<Remainder>();
                        query = from r in all_rems
                                where r.product_barcode == add_remainders_list.Rows[e.RowIndex].Cells[sell_rem_barcode_col.Index].Value.ToString()
                                select r;
                        Remainder[] query_toarray = query.ToArray();

                        add_remainders_list.Rows[e.RowIndex].Cells["sell_rem_remaining_col"].Value = query.Sum(r => r.remaining_pieces).ToString("G4") + " (სულ)";

                        if (query_toarray.Length > 0)
                        {
                            add_remainders_list.Rows[e.RowIndex].Cells[sell_rem_capacity_col.Index].Value = query_toarray[0].pack_capacity.ToString("G4");
                            add_remainders_list.Rows[e.RowIndex].Cells[sell_rem_initial_price_col.Index].Value = query_toarray[0].buy_price.ToString("G4") + " (#" + query_toarray[0].storehouse_id.ToString() + ")";
                        }
                        else
                        {
                            MessageBox.Show("ეს პროდუქტი საწყობების ბაზაში არაა დარჩენილი. ");
                            add_remainders_list.Rows[e.RowIndex].Cells["sell_rem_barcode_col"].Value = "000000000";
                        }

                        break;
                    }
                }
            }

            if (add_remainders_list.Columns[sell_rem_storeid_col.Index].Index == e.ColumnIndex && null != add_remainders_list.Rows[e.RowIndex].Cells[e.ColumnIndex].Value && null != add_remainders_list.Rows[e.RowIndex].Cells[sell_rem_barcode_col.Index].Value)
            {
                int CurrentStoreID = Int32.Parse(add_remainders_list.Rows[e.RowIndex].Cells[sell_rem_storeid_col.Index].Value.ToString());
                IEnumerable<Remainder> query = new List<Remainder>();
                query = from r in all_rems
                        where r.product_barcode == add_remainders_list.Rows[e.RowIndex].Cells[sell_rem_barcode_col.Index].Value.ToString()
                                && CurrentStoreID == r.storehouse_id
                        select r;

                var StoreRems = from rem in query
                                group rem by rem.storehouse_id into storrem
                                select new { StoreID = storrem.Key, remaining_items = storrem.Sum(rem => rem.remaining_pieces) };
                var rem_rem = (from sr in StoreRems
                               where CurrentStoreID == sr.StoreID
                               select sr.remaining_items).ToArray();
                if (rem_rem.Length > 0)
                {
                    add_remainders_list.Rows[e.RowIndex].Cells["sell_rem_remaining_col"].Value = rem_rem[0].ToString("G4") + " (#" + CurrentStoreID.ToString() + ")";
                }
                else
                {
                    add_remainders_list.Rows[e.RowIndex].Cells["sell_rem_remaining_col"].Value = 0.ToString("G4") + " (#" + CurrentStoreID.ToString() + ")";
                }

                Remainder[] query_toarray = query.ToArray();
                if (query_toarray.Length > 0)
                {
                    add_remainders_list.Rows[e.RowIndex].Cells[sell_rem_initial_price_col.Index].Value = query_toarray[0].buy_price.ToString("G4") + " (#" + query_toarray[0].storehouse_id.ToString() + ")";
                }
            }

            if (add_remainders_list.Columns[sell_rem_piece_count_col.Index].Index == e.ColumnIndex && null != add_remainders_list.Rows[e.RowIndex].Cells[e.ColumnIndex].Value && null != add_remainders_list.Rows[e.RowIndex].Cells[sell_rem_barcode_col.Index].Value)
            {
                int CurrentStoreID = Int32.Parse(add_remainders_list.Rows[e.RowIndex].Cells[sell_rem_storeid_col.Index].Value.ToString());
                IEnumerable<Remainder> query = new List<Remainder>();
                query = from r in all_rems
                        where r.product_barcode == add_remainders_list.Rows[e.RowIndex].Cells[sell_rem_barcode_col.Index].Value.ToString()
                                && CurrentStoreID == r.storehouse_id
                        select r;

                var StoreRems = from rem in query
                                group rem by rem.storehouse_id into storrem
                                select new { StoreID = storrem.Key, remaining_items = storrem.Sum(rem => rem.remaining_pieces) };
                var rem_rem = (from sr in StoreRems
                               where CurrentStoreID == sr.StoreID
                               select sr.remaining_items).ToArray();
                if (rem_rem.Length > 0)
                {
                    add_remainders_list.Rows[e.RowIndex].Cells["sell_rem_remaining_col"].Value = rem_rem[0].ToString("G4") + " (#" + CurrentStoreID.ToString() + ")";
                }
                else
                {
                    add_remainders_list.Rows[e.RowIndex].Cells["sell_rem_remaining_col"].Value = 0.ToString("G4") + " (#" + CurrentStoreID.ToString() + ")";
                }

                Remainder[] query_toarray = query.ToArray();
                if (query_toarray.Length > 0)
                {
                    add_remainders_list.Rows[e.RowIndex].Cells[sell_rem_initial_price_col.Index].Value = query_toarray[0].buy_price.ToString("G4") + " (#" + query_toarray[0].storehouse_id.ToString() + ")";
                }
            }

            if (add_remainders_list.Columns[sell_rem_pack_price_col.Index].Index == e.ColumnIndex && null != add_remainders_list.Rows[e.RowIndex].Cells[e.ColumnIndex].Value)
            {
                if (null != add_remainders_list.Rows[e.RowIndex].Cells[sell_rem_capacity_col.Index].Value)
                {
                    decimal entered_capacity = ParseDecimal(add_remainders_list.Rows[e.RowIndex].Cells[sell_rem_capacity_col.Index].Value.ToString());
                    decimal entered_pack_price = ParseDecimal(add_remainders_list.Rows[e.RowIndex].Cells[sell_rem_pack_price_col.Index].Value.ToString());
                    add_remainders_list.Rows[e.RowIndex].Cells[sell_rem_piece_price_col.Index].Value = entered_pack_price / entered_capacity;
                }
            }

            if (add_remainders_list.Columns[sell_rem_piece_price_col.Index].Index == e.ColumnIndex && null != add_remainders_list.Rows[e.RowIndex].Cells[e.ColumnIndex].Value)
            {
                if (null != add_remainders_list.Rows[e.RowIndex].Cells[sell_rem_capacity_col.Index].Value)
                {
                    decimal entered_capacity = ParseDecimal(add_remainders_list.Rows[e.RowIndex].Cells[sell_rem_capacity_col.Index].Value.ToString());
                    decimal entered_piece_price = ParseDecimal(add_remainders_list.Rows[e.RowIndex].Cells[sell_rem_piece_price_col.Index].Value.ToString());
                    add_remainders_list.Rows[e.RowIndex].Cells[sell_rem_pack_price_col.Index].Value = entered_piece_price * entered_capacity;
                }
            }

            try
            {
                if (null != add_remainders_list.Rows[e.RowIndex].Cells[sell_rem_piece_count_col.Index].Value)
                {
                    if (null != add_remainders_list.Rows[e.RowIndex].Cells["sell_rem_count_type_col"].Value)
                    {
                        if ("ცალობით" == add_remainders_list.Rows[e.RowIndex].Cells["sell_rem_count_type_col"].Value.ToString())
                        {
                            decimal piece_price = 0.0m;
                            decimal row_sum_price = 0.0m;
                            decimal piece_count = 0.0m;
                            if (null != add_remainders_list.Rows[e.RowIndex].Cells[sell_rem_piece_count_col.Index].Value)
                            {
                                piece_count = ParseDecimal(add_remainders_list.Rows[e.RowIndex].Cells[sell_rem_piece_count_col.Index].Value.ToString());
                            }
                            if (null != add_remainders_list.Rows[e.RowIndex].Cells["sell_rem_piece_price_col"].Value)
                            {
                                piece_price = ParseDecimal(add_remainders_list.Rows[e.RowIndex].Cells["sell_rem_piece_price_col"].Value.ToString());
                                row_sum_price = piece_count * piece_price;
                                add_remainders_list.Rows[e.RowIndex].Cells["sell_rem_sum_price_col"].Value = row_sum_price; // * ((decimal)add_remainders_list.Rows[e.RowIndex].Cells[sell_rem_storeid_col.Index].Value + (decimal)add_remainders_list.Rows[e.RowIndex].Cells["sell_rem_piece_price_col"].Value);
                                Row_Pricing[e.RowIndex] = row_sum_price;
                                UpdateSumPrice();
                            }
                        }
                        else
                        {
                            decimal pack_count = 0.0m;
                            decimal piece_price = 0.0m;
                            decimal row_sum_price = 0.0m;
                            decimal piece_count = 0.0m;
                            if (null != add_remainders_list.Rows[e.RowIndex].Cells[sell_rem_piece_count_col.Index].Value)
                            {
                                piece_count = ParseDecimal(add_remainders_list.Rows[e.RowIndex].Cells[sell_rem_piece_count_col.Index].Value.ToString());
                            }
                            if (null != add_remainders_list.Rows[e.RowIndex].Cells["sell_rem_piece_price_col"].Value && null != add_remainders_list.Rows[e.RowIndex].Cells["sell_rem_capacity_col"].Value)
                            {
                                piece_price = ParseDecimal(add_remainders_list.Rows[e.RowIndex].Cells["sell_rem_piece_price_col"].Value.ToString());
                                pack_count = ParseDecimal(add_remainders_list.Rows[e.RowIndex].Cells["sell_rem_capacity_col"].Value.ToString());
                                row_sum_price = piece_count * pack_count * piece_price;
                                add_remainders_list.Rows[e.RowIndex].Cells["sell_rem_sum_price_col"].Value = row_sum_price; // * ((decimal)add_remainders_list.Rows[e.RowIndex].Cells[sell_rem_storeid_col.Index].Value + (decimal)add_remainders_list.Rows[e.RowIndex].Cells["sell_rem_piece_price_col"].Value);
                                Row_Pricing[e.RowIndex] = row_sum_price;
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

        void Sell_Form_Click(object sender, EventArgs e)
        {
            all_products = ProductInfo_Main_Form.conn.GetProductSuggestions("");
            if (all_products.Length > 0)
            {
                sell_rem_name_col.Items.Clear();
                foreach (Product nprod in all_products)
                {
                    sell_rem_name_col.Items.Add(nprod.name);
                }
            }
        }

        private void add_remainders_list_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (sell_rem_name_col.Index == add_remainders_list.CurrentCell.ColumnIndex)
            {
                ComboBox cb = (ComboBox)e.Control;
                cb.DropDownStyle = ComboBoxStyle.DropDown;
            }
            else if (sell_rem_storeid_col.Index == add_remainders_list.CurrentCell.ColumnIndex)
            {
                ComboBox StoreIdChooser = (ComboBox)e.Control;
            }

            e.Control.KeyDown -= add_rem_list_Control_KeyDown;
            e.Control.KeyDown += new KeyEventHandler(add_rem_list_Control_KeyDown);

            e.Control.KeyPress -= add_rem_list_Control_KeyPress;
            e.Control.KeyPress += new KeyPressEventHandler(add_rem_list_Control_KeyPress);
        }

        void add_rem_list_Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (sell_rem_name_col.Index == add_remainders_list.CurrentCell.ColumnIndex)
            {
                Control ctl = (Control)sender;
                //e.SuppressKeyPress = false;
                //e.Handled = true;
                //string pressedKey = ((char)e.KeyCode).ToString();
                string pressedKey = e.KeyChar.ToString();
                //if (!e.Shift)
                //{
                //   pressedKey = pressedKey.ToLower();
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
                            add_remainders_list.CurrentRow.Cells["sell_rem_barcode_col"].Value = prod_suggestions[0].barcode;
                            foreach (object nextItem in sell_rem_name_col.Items)
                            {
                                if (nextItem.ToString() == prod_suggestions[0].name)
                                {
                                    add_remainders_list.CurrentRow.Cells["sell_rem_name_col"].Value = nextItem.ToString();//prod_suggestions[0].name;
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

        void add_rem_list_Control_KeyDown(object sender, KeyEventArgs e)
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
                    add_remainders_list.Rows[currentRowIndex].Cells["sell_rem_barcode_col"].Selected = true;
                }
                catch (NullReferenceException)
                {
                    add_remainders_list.Rows.Add();
                }
            }


        }

        private void btn_add_buyers_Click(object sender, EventArgs e)
        {
            AddBuyer_Form add_buyer_form = new AddBuyer_Form();
            add_buyer_form.Show();
            add_buyer_form.FormClosed += new FormClosedEventHandler(add_buyer_form_FormClosed);
        }

        void add_buyer_form_FormClosed(object sender, FormClosedEventArgs e)
        {
            all_buyers = ProductInfo_Main_Form.conn.AllBuyers();
            buyer_chooser.Items.Clear();
            foreach (Buyer nextBuyer in all_buyers)
            {
                buyer_chooser.Items.Add(nextBuyer.saxeli);
            }
            //
        }

        private void ckb_pay_method_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ckb_pay_method.SelectedItem.ToString())
            {
                case "ნაღდი":
                    cb_mt_store_id.Visible = true;
                    cb_mt_store_id.SelectedIndex = ActiveStoreID;
                    lbl_mt_store_id.Visible = true;
                    break;
                case "უნაღდო":
                    cb_mt_store_id.Visible = false;
                    lbl_mt_store_id.Visible = false;
                    break;
                case "კონსიგნაცია":
                    cb_mt_store_id.Visible = false;
                    lbl_mt_store_id.Visible = false;
                    break;
                default:
                    cb_mt_store_id.Visible = false;
                    lbl_mt_store_id.Visible = false;
                    break;
            }
        }

        private void add_remainders_list_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //better do nothing or cancel editing than continuously show MessageBoxes. 
            add_remainders_list.CancelEdit();
        }

        private void add_remainders_list_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (add_remainders_list.Rows.Count > 23)
            {
                MessageBox.Show("ზედნადების ფორმით 23–ზე მეტი პროდუქტის გაყიდვა არაა დაშვებული!");
                return;
            }
        }

        private void buyer_chooser_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void btn_find_buyer_Click(object sender, EventArgs e)
        {
            if ("" != pressed_buyer_name_keystrokes)
            {
                try
                {
                    Buyer[] matched_buyers = (from Buyer b in all_buyers
                                              where b.saxeli.Contains(pressed_buyer_name_keystrokes)
                                              select b).ToArray();
                    if (matched_buyers.Length > 0)
                    {
                        buyer_chooser.SelectedItem = matched_buyers[0].saxeli;
                        buyer_chooser.Text = matched_buyers[0].saxeli;
                    }
                    else
                    {
                        status_bar.Text = "მსგავსი მყიდველი არ მოიძებნა!";
                    }
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("null ref");
                }
            }
        }

        private void buyer_chooser_Enter(object sender, EventArgs e)
        {
            pressed_buyer_name_keystrokes = "";
        }

        private void buyer_chooser_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control ctl = (Control)sender;
            //e.SuppressKeyPress = false;
            e.Handled = true;
            //string pressedKey = ((char)e.KeyValue).ToString();
            /*
            if (!e.Shift)
            {
                pressedKey = pressedKey.ToLower();
            }
            else
            {
                return;//shift was pressed
                pressed_buyer_name_keystrokes += ProductInfo_Main_Form.UTF8String(ProductInfo_Main_Form.EngFromUTF8String(pressedKey).ToUpper());
            }*/
            string pressedKey = e.KeyChar.ToString();
            pressed_buyer_name_keystrokes += ProductInfo_Main_Form.UTF8String(pressedKey);

            status_bar_lbl.Text = pressed_buyer_name_keystrokes;
            if ("" != pressed_buyer_name_keystrokes)
            {
                try
                {
                    Buyer[] matched_buyers = (from Buyer b in all_buyers
                                              where b.saxeli.Contains(pressed_buyer_name_keystrokes)
                                              select b).ToArray();
                    if (matched_buyers.Length > 0)
                    {
                        buyer_chooser.SelectedItem = matched_buyers[0].saxeli;
                        buyer_chooser.Text = matched_buyers[0].saxeli;
                    }
                    else
                    {
                        status_bar.Text = "მსგავსი მყიდველი არ მოიძებნა!";
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


        //
    }
}
