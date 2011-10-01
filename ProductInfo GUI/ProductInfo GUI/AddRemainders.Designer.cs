namespace ProductInfo_UI
{
    partial class AddRemainders_Form
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
            this.lbl_company_name = new System.Windows.Forms.Label();
            this.supplier_chooser = new System.Windows.Forms.ComboBox();
            this.lbl_zed_id_code = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_find_supplier = new System.Windows.Forms.Button();
            this.btn_add_suppliers = new System.Windows.Forms.Button();
            this.using_af_ckb = new System.Windows.Forms.CheckBox();
            this.add_rem_af_date_chooser = new System.Windows.Forms.DateTimePicker();
            this.lbl_addrem_af_tarigi = new System.Windows.Forms.Label();
            this.lbl_af_ident_code = new System.Windows.Forms.Label();
            this.lbl_af_seria = new System.Windows.Forms.Label();
            this.add_rem_af_nomeri = new System.Windows.Forms.TextBox();
            this.add_rem_af_seria = new System.Windows.Forms.TextBox();
            this.lbl_zed_tarigi = new System.Windows.Forms.Label();
            this.zed_dro_datechooser = new System.Windows.Forms.DateTimePicker();
            this.zed_ident_code_txt = new System.Windows.Forms.TextBox();
            this.submit_btn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.status_bar = new System.Windows.Forms.StatusStrip();
            this.status_bar_lbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl_sum_price = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl_sum_price_without_vat = new System.Windows.Forms.ToolStripStatusLabel();
            this.add_remainders_list = new System.Windows.Forms.DataGridView();
            this.add_rem_barcode_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.add_rem_name_col = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.add_rem_capacity_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.add_rem_count_type_col = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.add_rem_storeid_col = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.add_rem_piece_count_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.add_rem_piece_price_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.add_rem_sum_price_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.add_rem_sell_price_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.add_rem_delete_col = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.status_bar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.add_remainders_list)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_company_name
            // 
            this.lbl_company_name.AutoSize = true;
            this.lbl_company_name.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_company_name.Location = new System.Drawing.Point(6, 19);
            this.lbl_company_name.Name = "lbl_company_name";
            this.lbl_company_name.Size = new System.Drawing.Size(115, 18);
            this.lbl_company_name.TabIndex = 0;
            this.lbl_company_name.Text = "მომწოდებელი:";
            // 
            // supplier_chooser
            // 
            this.supplier_chooser.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.supplier_chooser.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.supplier_chooser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.supplier_chooser.FormattingEnabled = true;
            this.supplier_chooser.ItemHeight = 16;
            this.supplier_chooser.Location = new System.Drawing.Point(141, 17);
            this.supplier_chooser.MaxDropDownItems = 24;
            this.supplier_chooser.Name = "supplier_chooser";
            this.supplier_chooser.Size = new System.Drawing.Size(173, 24);
            this.supplier_chooser.TabIndex = 1;
            this.supplier_chooser.SelectedIndexChanged += new System.EventHandler(this.supplier_chooser_SelectedIndexChanged);
            this.supplier_chooser.Enter += new System.EventHandler(this.supplier_chooser_Enter);
            this.supplier_chooser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.supplier_chooser_KeyPress);
            this.supplier_chooser.KeyDown += new System.Windows.Forms.KeyEventHandler(this.supplier_chooser_KeyDown);
            // 
            // lbl_zed_id_code
            // 
            this.lbl_zed_id_code.AutoSize = true;
            this.lbl_zed_id_code.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_zed_id_code.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_zed_id_code.Location = new System.Drawing.Point(562, 24);
            this.lbl_zed_id_code.Name = "lbl_zed_id_code";
            this.lbl_zed_id_code.Size = new System.Drawing.Size(189, 18);
            this.lbl_zed_id_code.TabIndex = 2;
            this.lbl_zed_id_code.Text = "სასაქონლო ზედნადები N";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_find_supplier);
            this.panel1.Controls.Add(this.btn_add_suppliers);
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
            this.panel1.Controls.Add(this.supplier_chooser);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(999, 123);
            this.panel1.TabIndex = 4;
            // 
            // btn_find_supplier
            // 
            this.btn_find_supplier.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_find_supplier.Image = global::ProductInfo_UI.Properties.Resources.find_21x21;
            this.btn_find_supplier.Location = new System.Drawing.Point(119, 18);
            this.btn_find_supplier.Name = "btn_find_supplier";
            this.btn_find_supplier.Size = new System.Drawing.Size(21, 21);
            this.btn_find_supplier.TabIndex = 12;
            this.btn_find_supplier.UseVisualStyleBackColor = true;
            this.btn_find_supplier.Click += new System.EventHandler(this.btn_find_supplier_Click);
            // 
            // btn_add_suppliers
            // 
            this.btn_add_suppliers.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_add_suppliers.Image = global::ProductInfo_UI.Properties.Resources.item_add_21x21;
            this.btn_add_suppliers.Location = new System.Drawing.Point(316, 18);
            this.btn_add_suppliers.Name = "btn_add_suppliers";
            this.btn_add_suppliers.Size = new System.Drawing.Size(21, 21);
            this.btn_add_suppliers.TabIndex = 11;
            this.btn_add_suppliers.UseVisualStyleBackColor = true;
            this.btn_add_suppliers.Click += new System.EventHandler(this.btn_add_suppliers_Click);
            // 
            // using_af_ckb
            // 
            this.using_af_ckb.AutoSize = true;
            this.using_af_ckb.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.using_af_ckb.Location = new System.Drawing.Point(348, 18);
            this.using_af_ckb.Name = "using_af_ckb";
            this.using_af_ckb.Size = new System.Drawing.Size(169, 22);
            this.using_af_ckb.TabIndex = 10;
            this.using_af_ckb.Text = "ანგარიშ/ფაქტურით";
            this.using_af_ckb.UseVisualStyleBackColor = true;
            this.using_af_ckb.CheckedChanged += new System.EventHandler(this.using_af_ckb_CheckedChanged);
            // 
            // add_rem_af_date_chooser
            // 
            this.add_rem_af_date_chooser.Location = new System.Drawing.Point(317, 89);
            this.add_rem_af_date_chooser.Name = "add_rem_af_date_chooser";
            this.add_rem_af_date_chooser.Size = new System.Drawing.Size(193, 20);
            this.add_rem_af_date_chooser.TabIndex = 9;
            this.add_rem_af_date_chooser.Visible = false;
            // 
            // lbl_addrem_af_tarigi
            // 
            this.lbl_addrem_af_tarigi.AutoSize = true;
            this.lbl_addrem_af_tarigi.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_addrem_af_tarigi.Location = new System.Drawing.Point(37, 89);
            this.lbl_addrem_af_tarigi.Name = "lbl_addrem_af_tarigi";
            this.lbl_addrem_af_tarigi.Size = new System.Drawing.Size(256, 18);
            this.lbl_addrem_af_tarigi.TabIndex = 8;
            this.lbl_addrem_af_tarigi.Text = "ა/ფ თარიღი (ახლის შემთხვევაში)";
            this.lbl_addrem_af_tarigi.Visible = false;
            // 
            // lbl_af_ident_code
            // 
            this.lbl_af_ident_code.AutoSize = true;
            this.lbl_af_ident_code.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_af_ident_code.Location = new System.Drawing.Point(284, 56);
            this.lbl_af_ident_code.Name = "lbl_af_ident_code";
            this.lbl_af_ident_code.Size = new System.Drawing.Size(92, 18);
            this.lbl_af_ident_code.TabIndex = 7;
            this.lbl_af_ident_code.Text = "ა/ფ ნომერი";
            this.lbl_af_ident_code.Visible = false;
            // 
            // lbl_af_seria
            // 
            this.lbl_af_seria.AutoSize = true;
            this.lbl_af_seria.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_af_seria.Location = new System.Drawing.Point(113, 56);
            this.lbl_af_seria.Name = "lbl_af_seria";
            this.lbl_af_seria.Size = new System.Drawing.Size(81, 18);
            this.lbl_af_seria.TabIndex = 7;
            this.lbl_af_seria.Text = "ა/ფ სერია";
            this.lbl_af_seria.Visible = false;
            // 
            // add_rem_af_nomeri
            // 
            this.add_rem_af_nomeri.Location = new System.Drawing.Point(385, 55);
            this.add_rem_af_nomeri.Name = "add_rem_af_nomeri";
            this.add_rem_af_nomeri.Size = new System.Drawing.Size(125, 20);
            this.add_rem_af_nomeri.TabIndex = 6;
            this.add_rem_af_nomeri.Visible = false;
            // 
            // add_rem_af_seria
            // 
            this.add_rem_af_seria.Location = new System.Drawing.Point(205, 55);
            this.add_rem_af_seria.Name = "add_rem_af_seria";
            this.add_rem_af_seria.Size = new System.Drawing.Size(68, 20);
            this.add_rem_af_seria.TabIndex = 6;
            this.add_rem_af_seria.Visible = false;
            // 
            // lbl_zed_tarigi
            // 
            this.lbl_zed_tarigi.AutoSize = true;
            this.lbl_zed_tarigi.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_zed_tarigi.Location = new System.Drawing.Point(526, 57);
            this.lbl_zed_tarigi.Name = "lbl_zed_tarigi";
            this.lbl_zed_tarigi.Size = new System.Drawing.Size(157, 18);
            this.lbl_zed_tarigi.TabIndex = 5;
            this.lbl_zed_tarigi.Text = "ზედნადების თარიღი";
            // 
            // zed_dro_datechooser
            // 
            this.zed_dro_datechooser.Location = new System.Drawing.Point(698, 57);
            this.zed_dro_datechooser.Name = "zed_dro_datechooser";
            this.zed_dro_datechooser.Size = new System.Drawing.Size(200, 20);
            this.zed_dro_datechooser.TabIndex = 4;
            // 
            // zed_ident_code_txt
            // 
            this.zed_ident_code_txt.Location = new System.Drawing.Point(757, 24);
            this.zed_ident_code_txt.Name = "zed_ident_code_txt";
            this.zed_ident_code_txt.Size = new System.Drawing.Size(141, 20);
            this.zed_ident_code_txt.TabIndex = 3;
            this.zed_ident_code_txt.TextChanged += new System.EventHandler(this.zed_ident_code_txt_TextChanged);
            // 
            // submit_btn
            // 
            this.submit_btn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.submit_btn.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submit_btn.Location = new System.Drawing.Point(0, 518);
            this.submit_btn.Name = "submit_btn";
            this.submit_btn.Size = new System.Drawing.Size(999, 42);
            this.submit_btn.TabIndex = 5;
            this.submit_btn.Text = "შენახვა";
            this.submit_btn.UseVisualStyleBackColor = true;
            this.submit_btn.Click += new System.EventHandler(this.submit_btn_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.status_bar);
            this.panel2.Controls.Add(this.submit_btn);
            this.panel2.Controls.Add(this.add_remainders_list);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 123);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(999, 560);
            this.panel2.TabIndex = 6;
            // 
            // status_bar
            // 
            this.status_bar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status_bar_lbl,
            this.lbl_sum_price,
            this.lbl_sum_price_without_vat});
            this.status_bar.Location = new System.Drawing.Point(0, 495);
            this.status_bar.Name = "status_bar";
            this.status_bar.Size = new System.Drawing.Size(999, 23);
            this.status_bar.TabIndex = 7;
            this.status_bar.Text = "statusStrip1";
            // 
            // status_bar_lbl
            // 
            this.status_bar_lbl.Name = "status_bar_lbl";
            this.status_bar_lbl.Size = new System.Drawing.Size(166, 18);
            this.status_bar_lbl.Text = "შეიყვანეთ მომწოდებლის სახელი";
            // 
            // lbl_sum_price
            // 
            this.lbl_sum_price.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_sum_price.Name = "lbl_sum_price";
            this.lbl_sum_price.Size = new System.Drawing.Size(409, 18);
            this.lbl_sum_price.Spring = true;
            this.lbl_sum_price.Text = "საერთო ფასი 0.0 ლარი";
            // 
            // lbl_sum_price_without_vat
            // 
            this.lbl_sum_price_without_vat.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_sum_price_without_vat.Name = "lbl_sum_price_without_vat";
            this.lbl_sum_price_without_vat.Size = new System.Drawing.Size(409, 18);
            this.lbl_sum_price_without_vat.Spring = true;
            this.lbl_sum_price_without_vat.Text = "ჯამი დღგ–ს გარეშე 0.0 ლარი";
            // 
            // add_remainders_list
            // 
            this.add_remainders_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.add_remainders_list.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.add_rem_barcode_col,
            this.add_rem_name_col,
            this.add_rem_capacity_col,
            this.add_rem_count_type_col,
            this.add_rem_storeid_col,
            this.add_rem_piece_count_col,
            this.add_rem_piece_price_col,
            this.add_rem_sum_price_col,
            this.add_rem_sell_price_col,
            this.add_rem_delete_col});
            this.add_remainders_list.Dock = System.Windows.Forms.DockStyle.Top;
            this.add_remainders_list.Location = new System.Drawing.Point(0, 0);
            this.add_remainders_list.Name = "add_remainders_list";
            this.add_remainders_list.Size = new System.Drawing.Size(999, 495);
            this.add_remainders_list.TabIndex = 6;
            this.add_remainders_list.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.add_remainders_list_CellEndEdit);
            this.add_remainders_list.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.add_remainders_list_RowEnter);
            this.add_remainders_list.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.add_remainders_list_CellEndEdit);
            this.add_remainders_list.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.add_remainders_list_EditingControlShowing);
            this.add_remainders_list.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.add_remainders_list_DataError);
            this.add_remainders_list.KeyDown += new System.Windows.Forms.KeyEventHandler(this.add_remainders_list_KeyDown);
            this.add_remainders_list.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.add_remainders_list_CellContentClick);
            // 
            // add_rem_barcode_col
            // 
            dataGridViewCellStyle1.NullValue = "000000000";
            this.add_rem_barcode_col.DefaultCellStyle = dataGridViewCellStyle1;
            this.add_rem_barcode_col.Frozen = true;
            this.add_rem_barcode_col.HeaderText = "პროდუქტის შტრიხ–კოდი";
            this.add_rem_barcode_col.Name = "add_rem_barcode_col";
            this.add_rem_barcode_col.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // add_rem_name_col
            // 
            this.add_rem_name_col.Frozen = true;
            this.add_rem_name_col.HeaderText = "დასახელება";
            this.add_rem_name_col.MaxDropDownItems = 55;
            this.add_rem_name_col.Name = "add_rem_name_col";
            this.add_rem_name_col.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.add_rem_name_col.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.add_rem_name_col.Width = 250;
            // 
            // add_rem_capacity_col
            // 
            this.add_rem_capacity_col.Frozen = true;
            this.add_rem_capacity_col.HeaderText = "ყუთის ტევადობა";
            this.add_rem_capacity_col.Name = "add_rem_capacity_col";
            this.add_rem_capacity_col.Width = 55;
            // 
            // add_rem_count_type_col
            // 
            this.add_rem_count_type_col.Frozen = true;
            this.add_rem_count_type_col.HeaderText = "დათვლის ტიპი";
            this.add_rem_count_type_col.Items.AddRange(new object[] {
            "ყუთები",
            "ცალობით"});
            this.add_rem_count_type_col.Name = "add_rem_count_type_col";
            this.add_rem_count_type_col.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.add_rem_count_type_col.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // add_rem_storeid_col
            // 
            dataGridViewCellStyle2.NullValue = "0";
            this.add_rem_storeid_col.DefaultCellStyle = dataGridViewCellStyle2;
            this.add_rem_storeid_col.Frozen = true;
            this.add_rem_storeid_col.HeaderText = "საწყობი";
            this.add_rem_storeid_col.Name = "add_rem_storeid_col";
            this.add_rem_storeid_col.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.add_rem_storeid_col.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.add_rem_storeid_col.Width = 70;
            // 
            // add_rem_piece_count_col
            // 
            dataGridViewCellStyle3.NullValue = "0";
            this.add_rem_piece_count_col.DefaultCellStyle = dataGridViewCellStyle3;
            this.add_rem_piece_count_col.Frozen = true;
            this.add_rem_piece_count_col.HeaderText = "რაოდენობა";
            this.add_rem_piece_count_col.Name = "add_rem_piece_count_col";
            this.add_rem_piece_count_col.Width = 70;
            // 
            // add_rem_piece_price_col
            // 
            dataGridViewCellStyle4.NullValue = "0";
            this.add_rem_piece_price_col.DefaultCellStyle = dataGridViewCellStyle4;
            this.add_rem_piece_price_col.Frozen = true;
            this.add_rem_piece_price_col.HeaderText = "საცალო ფასი";
            this.add_rem_piece_price_col.Name = "add_rem_piece_price_col";
            // 
            // add_rem_sum_price_col
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            dataGridViewCellStyle5.NullValue = "0";
            this.add_rem_sum_price_col.DefaultCellStyle = dataGridViewCellStyle5;
            this.add_rem_sum_price_col.Frozen = true;
            this.add_rem_sum_price_col.HeaderText = "ჯამური ფასი";
            this.add_rem_sum_price_col.Name = "add_rem_sum_price_col";
            this.add_rem_sum_price_col.ReadOnly = true;
            this.add_rem_sum_price_col.Width = 60;
            // 
            // add_rem_sell_price_col
            // 
            dataGridViewCellStyle6.NullValue = "0";
            this.add_rem_sell_price_col.DefaultCellStyle = dataGridViewCellStyle6;
            this.add_rem_sell_price_col.Frozen = true;
            this.add_rem_sell_price_col.HeaderText = "გასაყიდი ფასი";
            this.add_rem_sell_price_col.Name = "add_rem_sell_price_col";
            // 
            // add_rem_delete_col
            // 
            this.add_rem_delete_col.Frozen = true;
            this.add_rem_delete_col.HeaderText = "ამოშლა";
            this.add_rem_delete_col.Name = "add_rem_delete_col";
            this.add_rem_delete_col.Text = "ამოშლა";
            this.add_rem_delete_col.UseColumnTextForButtonValue = true;
            this.add_rem_delete_col.Width = 50;
            // 
            // AddRemainders_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 683);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "AddRemainders_Form";
            this.Text = "პროდუქტების შემოტანა";
            this.Load += new System.EventHandler(this.AddRemainders_Form_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddRemainders_Form_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.status_bar.ResumeLayout(false);
            this.status_bar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.add_remainders_list)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_company_name;
        private System.Windows.Forms.ComboBox supplier_chooser;
        private System.Windows.Forms.Label lbl_zed_id_code;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button submit_btn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView add_remainders_list;
        private System.Windows.Forms.TextBox zed_ident_code_txt;
        private System.Windows.Forms.Label lbl_zed_tarigi;
        private System.Windows.Forms.DateTimePicker zed_dro_datechooser;
        private System.Windows.Forms.Label lbl_af_seria;
        private System.Windows.Forms.TextBox add_rem_af_seria;
        private System.Windows.Forms.Label lbl_af_ident_code;
        private System.Windows.Forms.TextBox add_rem_af_nomeri;
        private System.Windows.Forms.Label lbl_addrem_af_tarigi;
        private System.Windows.Forms.DateTimePicker add_rem_af_date_chooser;
        private System.Windows.Forms.StatusStrip status_bar;
        private System.Windows.Forms.ToolStripStatusLabel status_bar_lbl;
        private System.Windows.Forms.ToolStripStatusLabel lbl_sum_price;
        private System.Windows.Forms.CheckBox using_af_ckb;
        private System.Windows.Forms.ToolStripStatusLabel lbl_sum_price_without_vat;
        private System.Windows.Forms.Button btn_add_suppliers;
        private System.Windows.Forms.Button btn_find_supplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn add_rem_barcode_col;
        private System.Windows.Forms.DataGridViewComboBoxColumn add_rem_name_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn add_rem_capacity_col;
        private System.Windows.Forms.DataGridViewComboBoxColumn add_rem_count_type_col;
        private System.Windows.Forms.DataGridViewComboBoxColumn add_rem_storeid_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn add_rem_piece_count_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn add_rem_piece_price_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn add_rem_sum_price_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn add_rem_sell_price_col;
        private System.Windows.Forms.DataGridViewButtonColumn add_rem_delete_col;
    }
}