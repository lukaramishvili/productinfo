namespace ProductInfo_UI
{
    partial class Sell_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbl_af_seria = new System.Windows.Forms.Label();
            this.lbl_sum_price = new System.Windows.Forms.ToolStripStatusLabel();
            this.status_bar_lbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.status_bar = new System.Windows.Forms.StatusStrip();
            this.lbl_sum_price_without_vat = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.submit_btn = new System.Windows.Forms.Button();
            this.add_remainders_list = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_find_buyer = new System.Windows.Forms.Button();
            this.cb_mt_store_id = new System.Windows.Forms.ComboBox();
            this.lbl_mt_store_id = new System.Windows.Forms.Label();
            this.btn_add_buyers = new System.Windows.Forms.Button();
            this.ckb_pay_method = new System.Windows.Forms.ComboBox();
            this.using_af_ckb = new System.Windows.Forms.CheckBox();
            this.add_rem_af_date_chooser = new System.Windows.Forms.DateTimePicker();
            this.lbl_addrem_af_tarigi = new System.Windows.Forms.Label();
            this.lbl_af_ident_code = new System.Windows.Forms.Label();
            this.add_rem_af_nomeri = new System.Windows.Forms.TextBox();
            this.add_rem_af_seria = new System.Windows.Forms.TextBox();
            this.lbl_zed_tarigi = new System.Windows.Forms.Label();
            this.zed_dro_datechooser = new System.Windows.Forms.DateTimePicker();
            this.zed_ident_code_txt = new System.Windows.Forms.TextBox();
            this.lbl_zed_id_code = new System.Windows.Forms.Label();
            this.lbl_company_name = new System.Windows.Forms.Label();
            this.buyer_chooser = new System.Windows.Forms.ComboBox();
            this.sell_rem_barcode_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sell_rem_name_col = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.sell_rem_capacity_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sell_rem_count_type_col = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.sell_rem_store1_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sell_rem_store2_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sell_rem_piece_price_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sell_rem_pack_price_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sell_rem_initial_price_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sell_rem_remaining_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sell_rem_sum_price_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sell_rem_delete_col = new System.Windows.Forms.DataGridViewButtonColumn();
            this.status_bar.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.add_remainders_list)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_af_seria
            // 
            this.lbl_af_seria.AutoSize = true;
            this.lbl_af_seria.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_af_seria.Location = new System.Drawing.Point(113, 49);
            this.lbl_af_seria.Name = "lbl_af_seria";
            this.lbl_af_seria.Size = new System.Drawing.Size(81, 18);
            this.lbl_af_seria.TabIndex = 7;
            this.lbl_af_seria.Text = "ა/ფ სერია";
            this.lbl_af_seria.Visible = false;
            // 
            // lbl_sum_price
            // 
            this.lbl_sum_price.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_sum_price.Name = "lbl_sum_price";
            this.lbl_sum_price.Size = new System.Drawing.Size(411, 18);
            this.lbl_sum_price.Spring = true;
            this.lbl_sum_price.Text = "საერთო ფასი 0.0 ლარი";
            // 
            // status_bar_lbl
            // 
            this.status_bar_lbl.Name = "status_bar_lbl";
            this.status_bar_lbl.Size = new System.Drawing.Size(166, 18);
            this.status_bar_lbl.Text = "შეიყვანეთ მომწოდებლის სახელი";
            // 
            // status_bar
            // 
            this.status_bar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status_bar_lbl,
            this.lbl_sum_price,
            this.lbl_sum_price_without_vat});
            this.status_bar.Location = new System.Drawing.Point(0, 495);
            this.status_bar.Name = "status_bar";
            this.status_bar.Size = new System.Drawing.Size(1004, 23);
            this.status_bar.TabIndex = 7;
            this.status_bar.Text = "statusStrip1";
            // 
            // lbl_sum_price_without_vat
            // 
            this.lbl_sum_price_without_vat.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_sum_price_without_vat.Name = "lbl_sum_price_without_vat";
            this.lbl_sum_price_without_vat.Size = new System.Drawing.Size(411, 18);
            this.lbl_sum_price_without_vat.Spring = true;
            this.lbl_sum_price_without_vat.Text = "ჯამი დღგ–ს გარეშე 0.0 ლარი";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.status_bar);
            this.panel2.Controls.Add(this.submit_btn);
            this.panel2.Controls.Add(this.add_remainders_list);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 112);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1004, 560);
            this.panel2.TabIndex = 8;
            // 
            // submit_btn
            // 
            this.submit_btn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.submit_btn.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submit_btn.Location = new System.Drawing.Point(0, 518);
            this.submit_btn.Name = "submit_btn";
            this.submit_btn.Size = new System.Drawing.Size(1004, 42);
            this.submit_btn.TabIndex = 5;
            this.submit_btn.Text = "შენახვა";
            this.submit_btn.UseVisualStyleBackColor = true;
            this.submit_btn.Click += new System.EventHandler(this.submit_btn_Click);
            // 
            // add_remainders_list
            // 
            this.add_remainders_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.add_remainders_list.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sell_rem_barcode_col,
            this.sell_rem_name_col,
            this.sell_rem_capacity_col,
            this.sell_rem_count_type_col,
            this.sell_rem_store1_col,
            this.sell_rem_store2_col,
            this.sell_rem_piece_price_col,
            this.sell_rem_pack_price_col,
            this.sell_rem_initial_price_col,
            this.sell_rem_remaining_col,
            this.sell_rem_sum_price_col,
            this.sell_rem_delete_col});
            this.add_remainders_list.Dock = System.Windows.Forms.DockStyle.Top;
            this.add_remainders_list.Location = new System.Drawing.Point(0, 0);
            this.add_remainders_list.Name = "add_remainders_list";
            this.add_remainders_list.Size = new System.Drawing.Size(1004, 495);
            this.add_remainders_list.TabIndex = 6;
            this.add_remainders_list.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.add_remainders_list_RowEnter);
            this.add_remainders_list.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.add_remainders_list_RowsAdded);
            this.add_remainders_list.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.add_remainders_list_CellEndEdit);
            this.add_remainders_list.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.add_remainders_list_EditingControlShowing);
            this.add_remainders_list.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.add_remainders_list_DataError);
            this.add_remainders_list.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.sell_list_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_find_buyer);
            this.panel1.Controls.Add(this.cb_mt_store_id);
            this.panel1.Controls.Add(this.lbl_mt_store_id);
            this.panel1.Controls.Add(this.btn_add_buyers);
            this.panel1.Controls.Add(this.ckb_pay_method);
            this.panel1.Controls.Add(this.using_af_ckb);
            this.panel1.Controls.Add(this.add_rem_af_date_chooser);
            this.panel1.Controls.Add(this.lbl_addrem_af_tarigi);
            this.panel1.Controls.Add(this.lbl_af_ident_code);
            this.panel1.Controls.Add(this.lbl_af_seria);
            this.panel1.Controls.Add(this.add_rem_af_nomeri);
            this.panel1.Controls.Add(this.add_rem_af_seria);
            this.panel1.Controls.Add(this.lbl_zed_tarigi);
            this.panel1.Controls.Add(this.zed_dro_datechooser);
            this.panel1.Controls.Add(this.zed_ident_code_txt);
            this.panel1.Controls.Add(this.lbl_zed_id_code);
            this.panel1.Controls.Add(this.lbl_company_name);
            this.panel1.Controls.Add(this.buyer_chooser);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1004, 123);
            this.panel1.TabIndex = 7;
            // 
            // btn_find_buyer
            // 
            this.btn_find_buyer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_find_buyer.Image = global::ProductInfo_UI.Properties.Resources.find_21x21;
            this.btn_find_buyer.Location = new System.Drawing.Point(94, 12);
            this.btn_find_buyer.Name = "btn_find_buyer";
            this.btn_find_buyer.Size = new System.Drawing.Size(21, 21);
            this.btn_find_buyer.TabIndex = 15;
            this.btn_find_buyer.UseVisualStyleBackColor = true;
            this.btn_find_buyer.Click += new System.EventHandler(this.btn_find_buyer_Click);
            // 
            // cb_mt_store_id
            // 
            this.cb_mt_store_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_mt_store_id.FormattingEnabled = true;
            this.cb_mt_store_id.Items.AddRange(new object[] {
            "ბიუჯეტი",
            "პირველი",
            "მეორე"});
            this.cb_mt_store_id.Location = new System.Drawing.Point(82, 83);
            this.cb_mt_store_id.Name = "cb_mt_store_id";
            this.cb_mt_store_id.Size = new System.Drawing.Size(118, 21);
            this.cb_mt_store_id.TabIndex = 14;
            // 
            // lbl_mt_store_id
            // 
            this.lbl_mt_store_id.AutoSize = true;
            this.lbl_mt_store_id.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbl_mt_store_id.Location = new System.Drawing.Point(12, 84);
            this.lbl_mt_store_id.Name = "lbl_mt_store_id";
            this.lbl_mt_store_id.Size = new System.Drawing.Size(64, 16);
            this.lbl_mt_store_id.TabIndex = 13;
            this.lbl_mt_store_id.Text = "სალარო:";
            // 
            // btn_add_buyers
            // 
            this.btn_add_buyers.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_add_buyers.Image = global::ProductInfo_UI.Properties.Resources.item_add_21x21;
            this.btn_add_buyers.Location = new System.Drawing.Point(314, 11);
            this.btn_add_buyers.Name = "btn_add_buyers";
            this.btn_add_buyers.Size = new System.Drawing.Size(21, 21);
            this.btn_add_buyers.TabIndex = 12;
            this.btn_add_buyers.UseVisualStyleBackColor = true;
            this.btn_add_buyers.Click += new System.EventHandler(this.btn_add_buyers_Click);
            // 
            // ckb_pay_method
            // 
            this.ckb_pay_method.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ckb_pay_method.FormattingEnabled = true;
            this.ckb_pay_method.Items.AddRange(new object[] {
            "ნაღდი",
            "კონსიგნაცია"});
            this.ckb_pay_method.Location = new System.Drawing.Point(13, 49);
            this.ckb_pay_method.Name = "ckb_pay_method";
            this.ckb_pay_method.Size = new System.Drawing.Size(84, 21);
            this.ckb_pay_method.TabIndex = 11;
            this.ckb_pay_method.SelectedIndexChanged += new System.EventHandler(this.ckb_pay_method_SelectedIndexChanged);
            // 
            // using_af_ckb
            // 
            this.using_af_ckb.AutoSize = true;
            this.using_af_ckb.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.using_af_ckb.Location = new System.Drawing.Point(348, 11);
            this.using_af_ckb.Name = "using_af_ckb";
            this.using_af_ckb.Size = new System.Drawing.Size(169, 22);
            this.using_af_ckb.TabIndex = 10;
            this.using_af_ckb.Text = "ანგარიშ/ფაქტურით";
            this.using_af_ckb.UseVisualStyleBackColor = true;
            this.using_af_ckb.CheckedChanged += new System.EventHandler(this.using_af_ckb_CheckedChanged);
            // 
            // add_rem_af_date_chooser
            // 
            this.add_rem_af_date_chooser.Location = new System.Drawing.Point(317, 82);
            this.add_rem_af_date_chooser.Name = "add_rem_af_date_chooser";
            this.add_rem_af_date_chooser.Size = new System.Drawing.Size(193, 20);
            this.add_rem_af_date_chooser.TabIndex = 9;
            this.add_rem_af_date_chooser.Visible = false;
            // 
            // lbl_addrem_af_tarigi
            // 
            this.lbl_addrem_af_tarigi.AutoSize = true;
            this.lbl_addrem_af_tarigi.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_addrem_af_tarigi.Location = new System.Drawing.Point(220, 82);
            this.lbl_addrem_af_tarigi.Name = "lbl_addrem_af_tarigi";
            this.lbl_addrem_af_tarigi.Size = new System.Drawing.Size(95, 18);
            this.lbl_addrem_af_tarigi.TabIndex = 8;
            this.lbl_addrem_af_tarigi.Text = "ა/ფ თარიღი";
            this.lbl_addrem_af_tarigi.Visible = false;
            // 
            // lbl_af_ident_code
            // 
            this.lbl_af_ident_code.AutoSize = true;
            this.lbl_af_ident_code.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_af_ident_code.Location = new System.Drawing.Point(284, 49);
            this.lbl_af_ident_code.Name = "lbl_af_ident_code";
            this.lbl_af_ident_code.Size = new System.Drawing.Size(92, 18);
            this.lbl_af_ident_code.TabIndex = 7;
            this.lbl_af_ident_code.Text = "ა/ფ ნომერი";
            this.lbl_af_ident_code.Visible = false;
            // 
            // add_rem_af_nomeri
            // 
            this.add_rem_af_nomeri.Location = new System.Drawing.Point(385, 48);
            this.add_rem_af_nomeri.Name = "add_rem_af_nomeri";
            this.add_rem_af_nomeri.Size = new System.Drawing.Size(125, 20);
            this.add_rem_af_nomeri.TabIndex = 6;
            this.add_rem_af_nomeri.Visible = false;
            // 
            // add_rem_af_seria
            // 
            this.add_rem_af_seria.Location = new System.Drawing.Point(205, 48);
            this.add_rem_af_seria.Name = "add_rem_af_seria";
            this.add_rem_af_seria.Size = new System.Drawing.Size(68, 20);
            this.add_rem_af_seria.TabIndex = 6;
            this.add_rem_af_seria.Visible = false;
            // 
            // lbl_zed_tarigi
            // 
            this.lbl_zed_tarigi.AutoSize = true;
            this.lbl_zed_tarigi.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_zed_tarigi.Location = new System.Drawing.Point(526, 47);
            this.lbl_zed_tarigi.Name = "lbl_zed_tarigi";
            this.lbl_zed_tarigi.Size = new System.Drawing.Size(157, 18);
            this.lbl_zed_tarigi.TabIndex = 5;
            this.lbl_zed_tarigi.Text = "ზედნადების თარიღი";
            // 
            // zed_dro_datechooser
            // 
            this.zed_dro_datechooser.Location = new System.Drawing.Point(698, 47);
            this.zed_dro_datechooser.Name = "zed_dro_datechooser";
            this.zed_dro_datechooser.Size = new System.Drawing.Size(200, 20);
            this.zed_dro_datechooser.TabIndex = 4;
            // 
            // zed_ident_code_txt
            // 
            this.zed_ident_code_txt.Location = new System.Drawing.Point(757, 14);
            this.zed_ident_code_txt.Name = "zed_ident_code_txt";
            this.zed_ident_code_txt.Size = new System.Drawing.Size(141, 20);
            this.zed_ident_code_txt.TabIndex = 3;
            // 
            // lbl_zed_id_code
            // 
            this.lbl_zed_id_code.AutoSize = true;
            this.lbl_zed_id_code.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_zed_id_code.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_zed_id_code.Location = new System.Drawing.Point(562, 14);
            this.lbl_zed_id_code.Name = "lbl_zed_id_code";
            this.lbl_zed_id_code.Size = new System.Drawing.Size(189, 18);
            this.lbl_zed_id_code.TabIndex = 2;
            this.lbl_zed_id_code.Text = "სასაქონლო ზედნადები N";
            // 
            // lbl_company_name
            // 
            this.lbl_company_name.AutoSize = true;
            this.lbl_company_name.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_company_name.Location = new System.Drawing.Point(6, 12);
            this.lbl_company_name.Name = "lbl_company_name";
            this.lbl_company_name.Size = new System.Drawing.Size(87, 18);
            this.lbl_company_name.TabIndex = 0;
            this.lbl_company_name.Text = "მყიდველი:";
            // 
            // buyer_chooser
            // 
            this.buyer_chooser.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.buyer_chooser.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.buyer_chooser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buyer_chooser.FormattingEnabled = true;
            this.buyer_chooser.Location = new System.Drawing.Point(116, 10);
            this.buyer_chooser.MaxDropDownItems = 24;
            this.buyer_chooser.Name = "buyer_chooser";
            this.buyer_chooser.Size = new System.Drawing.Size(195, 24);
            this.buyer_chooser.TabIndex = 1;
            this.buyer_chooser.SelectedIndexChanged += new System.EventHandler(this.buyer_chooser_SelectedIndexChanged);
            this.buyer_chooser.Enter += new System.EventHandler(this.buyer_chooser_Enter);
            this.buyer_chooser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.buyer_chooser_KeyPress);
            this.buyer_chooser.KeyDown += new System.Windows.Forms.KeyEventHandler(this.buyer_chooser_KeyDown);
            // 
            // sell_rem_barcode_col
            // 
            dataGridViewCellStyle1.NullValue = "000000000";
            this.sell_rem_barcode_col.DefaultCellStyle = dataGridViewCellStyle1;
            this.sell_rem_barcode_col.Frozen = true;
            this.sell_rem_barcode_col.HeaderText = "პროდუქტის შტრიხ–კოდი";
            this.sell_rem_barcode_col.Name = "sell_rem_barcode_col";
            this.sell_rem_barcode_col.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // sell_rem_name_col
            // 
            this.sell_rem_name_col.Frozen = true;
            this.sell_rem_name_col.HeaderText = "დასახელება";
            this.sell_rem_name_col.MaxDropDownItems = 55;
            this.sell_rem_name_col.Name = "sell_rem_name_col";
            this.sell_rem_name_col.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.sell_rem_name_col.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.sell_rem_name_col.Width = 250;
            // 
            // sell_rem_capacity_col
            // 
            this.sell_rem_capacity_col.Frozen = true;
            this.sell_rem_capacity_col.HeaderText = "ყუთის ტევადობა";
            this.sell_rem_capacity_col.Name = "sell_rem_capacity_col";
            this.sell_rem_capacity_col.Width = 55;
            // 
            // sell_rem_count_type_col
            // 
            this.sell_rem_count_type_col.Frozen = true;
            this.sell_rem_count_type_col.HeaderText = "დათვლის ტიპი";
            this.sell_rem_count_type_col.Items.AddRange(new object[] {
            "ყუთები",
            "ცალობით"});
            this.sell_rem_count_type_col.Name = "sell_rem_count_type_col";
            this.sell_rem_count_type_col.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.sell_rem_count_type_col.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.sell_rem_count_type_col.Width = 85;
            // 
            // sell_rem_store1_col
            // 
            dataGridViewCellStyle2.NullValue = "0";
            this.sell_rem_store1_col.DefaultCellStyle = dataGridViewCellStyle2;
            this.sell_rem_store1_col.Frozen = true;
            this.sell_rem_store1_col.HeaderText = "რაოდენობა (საწყობი 1)";
            this.sell_rem_store1_col.Name = "sell_rem_store1_col";
            this.sell_rem_store1_col.Width = 70;
            // 
            // sell_rem_store2_col
            // 
            dataGridViewCellStyle3.NullValue = "0";
            this.sell_rem_store2_col.DefaultCellStyle = dataGridViewCellStyle3;
            this.sell_rem_store2_col.Frozen = true;
            this.sell_rem_store2_col.HeaderText = "რაოდენობა (საწყობი 2)";
            this.sell_rem_store2_col.Name = "sell_rem_store2_col";
            this.sell_rem_store2_col.Width = 70;
            // 
            // sell_rem_piece_price_col
            // 
            dataGridViewCellStyle4.NullValue = "0";
            this.sell_rem_piece_price_col.DefaultCellStyle = dataGridViewCellStyle4;
            this.sell_rem_piece_price_col.Frozen = true;
            this.sell_rem_piece_price_col.HeaderText = "საცალო ფასი";
            this.sell_rem_piece_price_col.Name = "sell_rem_piece_price_col";
            this.sell_rem_piece_price_col.Width = 70;
            // 
            // sell_rem_pack_price_col
            // 
            dataGridViewCellStyle5.NullValue = "0";
            this.sell_rem_pack_price_col.DefaultCellStyle = dataGridViewCellStyle5;
            this.sell_rem_pack_price_col.HeaderText = "ყუთის ფასი";
            this.sell_rem_pack_price_col.Name = "sell_rem_pack_price_col";
            this.sell_rem_pack_price_col.Width = 60;
            // 
            // sell_rem_initial_price_col
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.sell_rem_initial_price_col.DefaultCellStyle = dataGridViewCellStyle6;
            this.sell_rem_initial_price_col.FillWeight = 20F;
            this.sell_rem_initial_price_col.HeaderText = "პ.ას";
            this.sell_rem_initial_price_col.MinimumWidth = 10;
            this.sell_rem_initial_price_col.Name = "sell_rem_initial_price_col";
            this.sell_rem_initial_price_col.ReadOnly = true;
            this.sell_rem_initial_price_col.Width = 48;
            // 
            // sell_rem_remaining_col
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.sell_rem_remaining_col.DefaultCellStyle = dataGridViewCellStyle7;
            this.sell_rem_remaining_col.HeaderText = "დარჩ.";
            this.sell_rem_remaining_col.Name = "sell_rem_remaining_col";
            this.sell_rem_remaining_col.ReadOnly = true;
            this.sell_rem_remaining_col.Width = 50;
            // 
            // sell_rem_sum_price_col
            // 
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            dataGridViewCellStyle8.NullValue = "0";
            this.sell_rem_sum_price_col.DefaultCellStyle = dataGridViewCellStyle8;
            this.sell_rem_sum_price_col.HeaderText = "ჯამური ფასი";
            this.sell_rem_sum_price_col.Name = "sell_rem_sum_price_col";
            this.sell_rem_sum_price_col.ReadOnly = true;
            this.sell_rem_sum_price_col.Width = 55;
            // 
            // sell_rem_delete_col
            // 
            this.sell_rem_delete_col.HeaderText = "ამოშლა";
            this.sell_rem_delete_col.Name = "sell_rem_delete_col";
            this.sell_rem_delete_col.Text = "ამოშლა";
            this.sell_rem_delete_col.UseColumnTextForButtonValue = true;
            this.sell_rem_delete_col.Width = 50;
            // 
            // Sell_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 672);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Sell_Form";
            this.Text = "ზედნადებით გაყიდვა";
            this.Load += new System.EventHandler(this.Sell_Form_Load);
            this.status_bar.ResumeLayout(false);
            this.status_bar.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.add_remainders_list)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_af_seria;
        private System.Windows.Forms.ToolStripStatusLabel lbl_sum_price;
        private System.Windows.Forms.ToolStripStatusLabel status_bar_lbl;
        private System.Windows.Forms.StatusStrip status_bar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button submit_btn;
        private System.Windows.Forms.DataGridView add_remainders_list;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox using_af_ckb;
        private System.Windows.Forms.DateTimePicker add_rem_af_date_chooser;
        private System.Windows.Forms.Label lbl_addrem_af_tarigi;
        private System.Windows.Forms.Label lbl_af_ident_code;
        private System.Windows.Forms.TextBox add_rem_af_nomeri;
        private System.Windows.Forms.TextBox add_rem_af_seria;
        private System.Windows.Forms.Label lbl_zed_tarigi;
        private System.Windows.Forms.DateTimePicker zed_dro_datechooser;
        private System.Windows.Forms.TextBox zed_ident_code_txt;
        private System.Windows.Forms.Label lbl_zed_id_code;
        private System.Windows.Forms.Label lbl_company_name;
        private System.Windows.Forms.ComboBox buyer_chooser;
        private System.Windows.Forms.ToolStripStatusLabel lbl_sum_price_without_vat;
        private System.Windows.Forms.ComboBox ckb_pay_method;
        private System.Windows.Forms.Button btn_add_buyers;
        private System.Windows.Forms.ComboBox cb_mt_store_id;
        private System.Windows.Forms.Label lbl_mt_store_id;
        private System.Windows.Forms.Button btn_find_buyer;
        private System.Windows.Forms.DataGridViewTextBoxColumn sell_rem_barcode_col;
        private System.Windows.Forms.DataGridViewComboBoxColumn sell_rem_name_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn sell_rem_capacity_col;
        private System.Windows.Forms.DataGridViewComboBoxColumn sell_rem_count_type_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn sell_rem_store1_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn sell_rem_store2_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn sell_rem_piece_price_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn sell_rem_pack_price_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn sell_rem_initial_price_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn sell_rem_remaining_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn sell_rem_sum_price_col;
        private System.Windows.Forms.DataGridViewButtonColumn sell_rem_delete_col;
    }
}