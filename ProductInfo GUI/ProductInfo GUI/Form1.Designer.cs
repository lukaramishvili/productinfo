using System.Windows.Forms;
namespace ProductInfo_UI
{
    partial class ProductInfo_Main_Form
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.main_menu = new System.Windows.Forms.MenuStrip();
            this.mm_nashtebi = new System.Windows.Forms.ToolStripMenuItem();
            this.mm_add_remainders = new System.Windows.Forms.ToolStripMenuItem();
            this.mm_sell_remainders = new System.Windows.Forms.ToolStripMenuItem();
            this.mm_suppliers = new System.Windows.Forms.ToolStripMenuItem();
            this.mm_add_supplier = new System.Windows.Forms.ToolStripMenuItem();
            this.mm_buyers = new System.Windows.Forms.ToolStripMenuItem();
            this.mm_add_buyer = new System.Windows.Forms.ToolStripMenuItem();
            this.mm_productnames = new System.Windows.Forms.ToolStripMenuItem();
            this.mm_product_add = new System.Windows.Forms.ToolStripMenuItem();
            this.mm_productlist_add = new System.Windows.Forms.ToolStripMenuItem();
            this.toolbar = new System.Windows.Forms.ToolStrip();
            this.search_text = new System.Windows.Forms.ToolStripTextBox();
            this.lbl_tb_store = new System.Windows.Forms.ToolStripLabel();
            this.tb_store_chooser = new System.Windows.Forms.ToolStripComboBox();
            this.tb_print_btn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_export_csv = new System.Windows.Forms.ToolStripButton();
            this.tb_sep_after_csv_export_btn = new System.Windows.Forms.ToolStripSeparator();
            this.btn_export_list = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.status_bar = new System.Windows.Forms.StatusStrip();
            this.status_bar_text = new System.Windows.Forms.ToolStripStatusLabel();
            this.status_progress_bar = new System.Windows.Forms.ToolStripProgressBar();
            this.sb_sum_lbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.sb_sum_withoutVAT_lbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.sb_refresh_btn = new System.Windows.Forms.ToolStripStatusLabel();
            this.tab_container = new System.Windows.Forms.TabControl();
            this.sell_tabpage = new System.Windows.Forms.TabPage();
            this.ckb_pay_method = new System.Windows.Forms.ComboBox();
            this.cmb_xelze_myidveli = new System.Windows.Forms.ComboBox();
            this.lbl_xelze_myidveli = new System.Windows.Forms.Label();
            this.using_check_ckb = new System.Windows.Forms.CheckBox();
            this.sell_panel = new System.Windows.Forms.Panel();
            this.sell_list = new System.Windows.Forms.DataGridView();
            this.sell_barcode_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sell_name_col = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.sell_capacity_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sell_pack_amount_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sell_pack_price_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sell_piece_amount_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sell_piece_price_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sell_piece_amount_info = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sell_initial_price_info_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sell_remaining_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sell_sum_price_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sell_delete_col = new System.Windows.Forms.DataGridViewButtonColumn();
            this.sell_status_bar = new System.Windows.Forms.StatusStrip();
            this.sell_status_lbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.sell_status_sum_price_lbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.sell_submit_btn = new System.Windows.Forms.Button();
            this.nashtebi_tabpage = new System.Windows.Forms.TabPage();
            this.rem_list = new System.Windows.Forms.ListView();
            this.rem_list_barcode_header = new System.Windows.Forms.ColumnHeader();
            this.rem_list_prodname_header = new System.Windows.Forms.ColumnHeader();
            this.rem_list_supplier_header = new System.Windows.Forms.ColumnHeader();
            this.rem_list_capacity_header = new System.Windows.Forms.ColumnHeader();
            this.rem_list_store_col = new System.Windows.Forms.ColumnHeader();
            this.rem_list_packs_header = new System.Windows.Forms.ColumnHeader();
            this.rem_list_piece_price_col = new System.Windows.Forms.ColumnHeader();
            this.rem_list_piece_sell_price_col = new System.Windows.Forms.ColumnHeader();
            this.rem_list_initial_whole_price_col = new System.Windows.Forms.ColumnHeader();
            this.rem_list_remaining_whole_price_col = new System.Windows.Forms.ColumnHeader();
            this.rem_list_cost_withoutVAT_col = new System.Windows.Forms.ColumnHeader();
            this.cm_rem_list = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmi_rem_list_supplier_info = new System.Windows.Forms.ToolStripMenuItem();
            this.cmi_split_rems = new System.Windows.Forms.ToolStripMenuItem();
            this.zednadebebi_tabpage = new System.Windows.Forms.TabPage();
            this.zed_list = new System.Windows.Forms.ListView();
            this.zed_ident_col = new System.Windows.Forms.ColumnHeader();
            this.zed_date_col = new System.Windows.Forms.ColumnHeader();
            this.zed_supplier_col = new System.Windows.Forms.ColumnHeader();
            this.zed_list_af_seria_col = new System.Windows.Forms.ColumnHeader();
            this.zed_list_af_saident_col = new System.Windows.Forms.ColumnHeader();
            this.zed_list_costwithVAT_col = new System.Windows.Forms.ColumnHeader();
            this.zed_list_costwithoutVAT_col = new System.Windows.Forms.ColumnHeader();
            this.cm_incoming_zeds = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmi_incoming_zeds_details = new System.Windows.Forms.ToolStripMenuItem();
            this.cmi_incoming_zeds_payfor = new System.Windows.Forms.ToolStripMenuItem();
            this.cmi_incoming_zeds_edit = new System.Windows.Forms.ToolStripMenuItem();
            this.cmi_incoming_zeds_remove = new System.Windows.Forms.ToolStripMenuItem();
            this.sold_zednadebebi_tabpage = new System.Windows.Forms.TabPage();
            this.sold_zed_list = new System.Windows.Forms.ListView();
            this.sold_z_ident_code_col = new System.Windows.Forms.ColumnHeader();
            this.sold_z_date_col = new System.Windows.Forms.ColumnHeader();
            this.sold_z_buyer_col = new System.Windows.Forms.ColumnHeader();
            this.sold_z_af_seria_col = new System.Windows.Forms.ColumnHeader();
            this.sold_z_af_nomeri_col = new System.Windows.Forms.ColumnHeader();
            this.sold_z_cost_col = new System.Windows.Forms.ColumnHeader();
            this.sold_z_cost_withoutVAT_col = new System.Windows.Forms.ColumnHeader();
            this.sold_z_income_amount_col = new System.Windows.Forms.ColumnHeader();
            this.sold_z_price = new System.Windows.Forms.ColumnHeader();
            this.sold_z_roi_col = new System.Windows.Forms.ColumnHeader();
            this.sold_z_roi_withoutVAT_col = new System.Windows.Forms.ColumnHeader();
            this.sold_z_VAT_tax_amount = new System.Windows.Forms.ColumnHeader();
            this.sold_z_zed_price_withoutVAT = new System.Windows.Forms.ColumnHeader();
            this.cm_sold_zednadebi = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmi_sold_zed_details = new System.Windows.Forms.ToolStripMenuItem();
            this.cmi_sold_zed_payfor = new System.Windows.Forms.ToolStripMenuItem();
            this.cmi_zed_print = new System.Windows.Forms.ToolStripMenuItem();
            this.cmi_sold_zed_remove = new System.Windows.Forms.ToolStripMenuItem();
            this.suppliers_tabpage = new System.Windows.Forms.TabPage();
            this.suppliers_list = new System.Windows.Forms.ListView();
            this.suppliers_list_name_header = new System.Windows.Forms.ColumnHeader();
            this.suppliers_list_ident_code_header = new System.Windows.Forms.ColumnHeader();
            this.suppliers_list_address_header = new System.Windows.Forms.ColumnHeader();
            this.supplier_mosacemi_col = new System.Windows.Forms.ColumnHeader();
            this.supplier_misacemi_col = new System.Windows.Forms.ColumnHeader();
            this.cm_supplier_list = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmi_this_supplier_zeds = new System.Windows.Forms.ToolStripMenuItem();
            this.cmi_this_supplier_remainders = new System.Windows.Forms.ToolStripMenuItem();
            this.cm_supplier_edit = new System.Windows.Forms.ToolStripMenuItem();
            this.cmi_supplier_money_transfer = new System.Windows.Forms.ToolStripMenuItem();
            this.cmi_supp_oper_hist = new System.Windows.Forms.ToolStripMenuItem();
            this.buyers_tabpage = new System.Windows.Forms.TabPage();
            this.buyers_list = new System.Windows.Forms.ListView();
            this.buyer_name_col = new System.Windows.Forms.ColumnHeader();
            this.buyer_ident_col = new System.Windows.Forms.ColumnHeader();
            this.buyer_address_col = new System.Windows.Forms.ColumnHeader();
            this.buyer_mosacemi_col = new System.Windows.Forms.ColumnHeader();
            this.buyer_misacemi_col = new System.Windows.Forms.ColumnHeader();
            this.cm_buyer_list = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmi_buyer_money_transfer = new System.Windows.Forms.ToolStripMenuItem();
            this.cmi_buyer_oper_hist = new System.Windows.Forms.ToolStripMenuItem();
            this.cmi_buyer_edit = new System.Windows.Forms.ToolStripMenuItem();
            this.productnames_tabpage = new System.Windows.Forms.TabPage();
            this.prod_names_list = new System.Windows.Forms.ListView();
            this.pnames_bcode_col = new System.Windows.Forms.ColumnHeader();
            this.pnames_name_col = new System.Windows.Forms.ColumnHeader();
            this.pnames_capacity_col = new System.Windows.Forms.ColumnHeader();
            this.pnames_initial_count_col = new System.Windows.Forms.ColumnHeader();
            this.pnames_initial_sum_cost_col = new System.Windows.Forms.ColumnHeader();
            this.pnames_remaining_col = new System.Windows.Forms.ColumnHeader();
            this.pnames_piece_price_col = new System.Windows.Forms.ColumnHeader();
            this.pnames_remaining_amount_col = new System.Windows.Forms.ColumnHeader();
            this.pnames_costwithoutVAT_col = new System.Windows.Forms.ColumnHeader();
            this.prod_list_cm = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.prod_list_edit_cmi = new System.Windows.Forms.ToolStripMenuItem();
            this.cmi_prod_list_delete_dublicates = new System.Windows.Forms.ToolStripMenuItem();
            this.sold_tabpage = new System.Windows.Forms.TabPage();
            this.sold_list = new System.Windows.Forms.ListView();
            this.sold_id_col = new System.Windows.Forms.ColumnHeader();
            this.sold_tarigi_col = new System.Windows.Forms.ColumnHeader();
            this.sold_buyer_col = new System.Windows.Forms.ColumnHeader();
            this.sold_storeid_col = new System.Windows.Forms.ColumnHeader();
            this.sold_zed_ident_col = new System.Windows.Forms.ColumnHeader();
            this.sold_using_check_col = new System.Windows.Forms.ColumnHeader();
            this.sold_cost_col = new System.Windows.Forms.ColumnHeader();
            this.sold_cost_withoutVAT_col = new System.Windows.Forms.ColumnHeader();
            this.sold_price_col = new System.Windows.Forms.ColumnHeader();
            this.sold_income_col = new System.Windows.Forms.ColumnHeader();
            this.sold_roi_col = new System.Windows.Forms.ColumnHeader();
            this.sold_price_diff_withoutVAT_col = new System.Windows.Forms.ColumnHeader();
            this.cm_sold = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmi_sold_details = new System.Windows.Forms.ToolStripMenuItem();
            this.cmi_sold_edit = new System.Windows.Forms.ToolStripMenuItem();
            this.agcera_tabpage = new System.Windows.Forms.TabPage();
            this.agcera_rem_list = new System.Windows.Forms.ListView();
            this.agcera_barcode_col = new System.Windows.Forms.ColumnHeader();
            this.agcera_name_col = new System.Windows.Forms.ColumnHeader();
            this.agcera_storeid_col = new System.Windows.Forms.ColumnHeader();
            this.agcera_supplier_name_col = new System.Windows.Forms.ColumnHeader();
            this.agcera_zed_ident_code = new System.Windows.Forms.ColumnHeader();
            this.agcera_zed_date_col = new System.Windows.Forms.ColumnHeader();
            this.agcera_af_seria_col = new System.Windows.Forms.ColumnHeader();
            this.agcera_af_nomeri_col = new System.Windows.Forms.ColumnHeader();
            this.agcera_af_date_col = new System.Windows.Forms.ColumnHeader();
            this.agcera_remaining_count_col = new System.Windows.Forms.ColumnHeader();
            this.piece_price_without_vat_col = new System.Windows.Forms.ColumnHeader();
            this.piece_price_with_vat_col = new System.Windows.Forms.ColumnHeader();
            this.bought_afs_tabpage = new System.Windows.Forms.TabPage();
            this.bought_af_list = new System.Windows.Forms.ListView();
            this.af_supplier_barcode_col = new System.Windows.Forms.ColumnHeader();
            this.af_supplier_col = new System.Windows.Forms.ColumnHeader();
            this.af_seria_col = new System.Windows.Forms.ColumnHeader();
            this.af_ident_col = new System.Windows.Forms.ColumnHeader();
            this.af_date_col = new System.Windows.Forms.ColumnHeader();
            this.af_operation_col = new System.Windows.Forms.ColumnHeader();
            this.af_zed_count_col = new System.Windows.Forms.ColumnHeader();
            this.af_whole_cost_col = new System.Windows.Forms.ColumnHeader();
            this.af_whole_cost_withoutVAT_col = new System.Windows.Forms.ColumnHeader();
            this.af_VAT_col = new System.Windows.Forms.ColumnHeader();
            this.cm_bought_afs = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sold_afs_tabpage = new System.Windows.Forms.TabPage();
            this.sold_af_list = new System.Windows.Forms.ListView();
            this.sold_af_buyer_col = new System.Windows.Forms.ColumnHeader();
            this.sold_af_seria_col = new System.Windows.Forms.ColumnHeader();
            this.sold_af_ident_col = new System.Windows.Forms.ColumnHeader();
            this.sold_af_date_col = new System.Windows.Forms.ColumnHeader();
            this.sold_af_operation_col = new System.Windows.Forms.ColumnHeader();
            this.sold_af_zeds_col = new System.Windows.Forms.ColumnHeader();
            this.sold_af_cost_col = new System.Windows.Forms.ColumnHeader();
            this.sold_af_cost_withoutVAT_col = new System.Windows.Forms.ColumnHeader();
            this.sold_prods_tabpage = new System.Windows.Forms.TabPage();
            this.sold_prodrem_list = new System.Windows.Forms.ListView();
            this.sold_prods_barcode_col = new System.Windows.Forms.ColumnHeader();
            this.sold_prods_name_col = new System.Windows.Forms.ColumnHeader();
            this.sold_prods_count_col = new System.Windows.Forms.ColumnHeader();
            this.sold_prods_piece_price_col = new System.Windows.Forms.ColumnHeader();
            this.sold_prods_cost_col = new System.Windows.Forms.ColumnHeader();
            this.sold_prods_cost_withoutVAT_col = new System.Windows.Forms.ColumnHeader();
            this.moneytransfers_tabpage = new System.Windows.Forms.TabPage();
            this.moneytransfer_list = new System.Windows.Forms.ListView();
            this.mt_id_col = new System.Windows.Forms.ColumnHeader();
            this.mt_client_type_col = new System.Windows.Forms.ColumnHeader();
            this.mt_client_name_col = new System.Windows.Forms.ColumnHeader();
            this.mt_oper_type_col = new System.Windows.Forms.ColumnHeader();
            this.mt_date_col = new System.Windows.Forms.ColumnHeader();
            this.mt_amount_col = new System.Windows.Forms.ColumnHeader();
            this.mt_purpose_col = new System.Windows.Forms.ColumnHeader();
            this.mt_storeid_col = new System.Windows.Forms.ColumnHeader();
            this.mt_targettype_col = new System.Windows.Forms.ColumnHeader();
            this.mt_targetident_col = new System.Windows.Forms.ColumnHeader();
            this.cm_moneytransfer = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmi_mt_remove = new System.Windows.Forms.ToolStripMenuItem();
            this.summary_tabpage = new System.Windows.Forms.TabPage();
            this.summary_cash_amount = new System.Windows.Forms.TextBox();
            this.lbl_summary_currency = new System.Windows.Forms.Label();
            this.lbl_summary_cash = new System.Windows.Forms.Label();
            this.bought_af_standard_list_tabpage = new System.Windows.Forms.TabPage();
            this.bought_af_standard_list = new System.Windows.Forms.ListView();
            this.bought_af_std_serie_col = new System.Windows.Forms.ColumnHeader();
            this.bought_af_std_invoicenum_col = new System.Windows.Forms.ColumnHeader();
            this.bought_af_std_date_col = new System.Windows.Forms.ColumnHeader();
            this.bought_af_std_supp_ident_col = new System.Windows.Forms.ColumnHeader();
            this.bought_af_std_VAT_col = new System.Windows.Forms.ColumnHeader();
            this.tb_since_datepicker = new System.Windows.Forms.DateTimePicker();
            this.tb_until_datepicker = new System.Windows.Forms.DateTimePicker();
            this.tb_since_lbl = new System.Windows.Forms.ToolStripLabel();
            this.tb_until_lbl = new System.Windows.Forms.ToolStripLabel();
            this.cmi_mt_edit = new System.Windows.Forms.ToolStripMenuItem();
            this.mt_cashbox_id_col = new System.Windows.Forms.ColumnHeader();
            this.mt_cashier_id_col = new System.Windows.Forms.ColumnHeader();
            this.cashbox_sum_txt = new System.Windows.Forms.TextBox();
            this.lbl_cashbox_sum_currency = new System.Windows.Forms.Label();
            this.lbl_cashbox_sum = new System.Windows.Forms.Label();
            this.main_menu.SuspendLayout();
            this.toolbar.SuspendLayout();
            this.status_bar.SuspendLayout();
            this.tab_container.SuspendLayout();
            this.sell_tabpage.SuspendLayout();
            this.sell_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sell_list)).BeginInit();
            this.sell_status_bar.SuspendLayout();
            this.nashtebi_tabpage.SuspendLayout();
            this.cm_rem_list.SuspendLayout();
            this.zednadebebi_tabpage.SuspendLayout();
            this.cm_incoming_zeds.SuspendLayout();
            this.sold_zednadebebi_tabpage.SuspendLayout();
            this.cm_sold_zednadebi.SuspendLayout();
            this.suppliers_tabpage.SuspendLayout();
            this.cm_supplier_list.SuspendLayout();
            this.buyers_tabpage.SuspendLayout();
            this.cm_buyer_list.SuspendLayout();
            this.productnames_tabpage.SuspendLayout();
            this.prod_list_cm.SuspendLayout();
            this.sold_tabpage.SuspendLayout();
            this.cm_sold.SuspendLayout();
            this.agcera_tabpage.SuspendLayout();
            this.bought_afs_tabpage.SuspendLayout();
            this.sold_afs_tabpage.SuspendLayout();
            this.sold_prods_tabpage.SuspendLayout();
            this.moneytransfers_tabpage.SuspendLayout();
            this.cm_moneytransfer.SuspendLayout();
            this.summary_tabpage.SuspendLayout();
            this.bought_af_standard_list_tabpage.SuspendLayout();
            this.SuspendLayout();
            // 
            // main_menu
            // 
            this.main_menu.Font = new System.Drawing.Font("Tahoma", 11F);
            this.main_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mm_nashtebi,
            this.mm_suppliers,
            this.mm_buyers,
            this.mm_productnames});
            this.main_menu.Location = new System.Drawing.Point(0, 0);
            this.main_menu.Name = "main_menu";
            this.main_menu.Size = new System.Drawing.Size(1215, 26);
            this.main_menu.TabIndex = 0;
            this.main_menu.Text = "menuStrip1";
            // 
            // mm_nashtebi
            // 
            this.mm_nashtebi.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mm_add_remainders,
            this.mm_sell_remainders});
            this.mm_nashtebi.Name = "mm_nashtebi";
            this.mm_nashtebi.Size = new System.Drawing.Size(92, 22);
            this.mm_nashtebi.Text = "ზედნადები";
            // 
            // mm_add_remainders
            // 
            this.mm_add_remainders.Name = "mm_add_remainders";
            this.mm_add_remainders.Size = new System.Drawing.Size(135, 22);
            this.mm_add_remainders.Text = "შემოტანა";
            this.mm_add_remainders.Click += new System.EventHandler(this.mm_add_remainders_Click);
            // 
            // mm_sell_remainders
            // 
            this.mm_sell_remainders.Name = "mm_sell_remainders";
            this.mm_sell_remainders.Size = new System.Drawing.Size(135, 22);
            this.mm_sell_remainders.Text = "გატანა";
            this.mm_sell_remainders.Click += new System.EventHandler(this.mm_sell_remainders_Click);
            // 
            // mm_suppliers
            // 
            this.mm_suppliers.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mm_add_supplier});
            this.mm_suppliers.Name = "mm_suppliers";
            this.mm_suppliers.Size = new System.Drawing.Size(117, 22);
            this.mm_suppliers.Text = "მომწოდებლები";
            // 
            // mm_add_supplier
            // 
            this.mm_add_supplier.Name = "mm_add_supplier";
            this.mm_add_supplier.Size = new System.Drawing.Size(136, 22);
            this.mm_add_supplier.Text = "დამატება";
            this.mm_add_supplier.Click += new System.EventHandler(this.mm_add_supplier_Click);
            // 
            // mm_buyers
            // 
            this.mm_buyers.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mm_add_buyer});
            this.mm_buyers.Name = "mm_buyers";
            this.mm_buyers.Size = new System.Drawing.Size(99, 22);
            this.mm_buyers.Text = "მყიდველები";
            // 
            // mm_add_buyer
            // 
            this.mm_add_buyer.Name = "mm_add_buyer";
            this.mm_add_buyer.Size = new System.Drawing.Size(136, 22);
            this.mm_add_buyer.Text = "დამატება";
            this.mm_add_buyer.Click += new System.EventHandler(this.mm_add_buyer_Click);
            // 
            // mm_productnames
            // 
            this.mm_productnames.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mm_product_add,
            this.mm_productlist_add});
            this.mm_productnames.Name = "mm_productnames";
            this.mm_productnames.Size = new System.Drawing.Size(156, 22);
            this.mm_productnames.Text = "პროდ. დასახელებები";
            // 
            // mm_product_add
            // 
            this.mm_product_add.Name = "mm_product_add";
            this.mm_product_add.Size = new System.Drawing.Size(169, 22);
            this.mm_product_add.Text = "დამატება";
            this.mm_product_add.Click += new System.EventHandler(this.mm_product_add_Click);
            // 
            // mm_productlist_add
            // 
            this.mm_productlist_add.Name = "mm_productlist_add";
            this.mm_productlist_add.Size = new System.Drawing.Size(169, 22);
            this.mm_productlist_add.Text = "სიის დამატება";
            this.mm_productlist_add.Click += new System.EventHandler(this.mm_productlist_add_Click);
            // 
            // toolbar
            // 
            this.toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.search_text,
            this.lbl_tb_store,
            this.tb_store_chooser,
            this.tb_print_btn,
            this.toolStripSeparator1,
            this.btn_export_csv,
            this.tb_sep_after_csv_export_btn,
            this.btn_export_list,
            this.toolStripSeparator2});
            this.toolbar.Location = new System.Drawing.Point(0, 26);
            this.toolbar.Name = "toolbar";
            this.toolbar.Size = new System.Drawing.Size(1215, 25);
            this.toolbar.TabIndex = 1;
            this.toolbar.Text = "toolStrip1";
            // 
            // search_text
            // 
            this.search_text.Name = "search_text";
            this.search_text.Size = new System.Drawing.Size(150, 25);
            this.search_text.Text = "ძებნა";
            this.search_text.TextChanged += new System.EventHandler(this.search_text_TextChanged);
            this.search_text.Click += new System.EventHandler(this.search_text_Click);
            // 
            // lbl_tb_store
            // 
            this.lbl_tb_store.Name = "lbl_tb_store";
            this.lbl_tb_store.Size = new System.Drawing.Size(48, 22);
            this.lbl_tb_store.Text = "საწყობი:";
            // 
            // tb_store_chooser
            // 
            this.tb_store_chooser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tb_store_chooser.Name = "tb_store_chooser";
            this.tb_store_chooser.Size = new System.Drawing.Size(121, 25);
            this.tb_store_chooser.SelectedIndexChanged += new System.EventHandler(this.tb_store_chooser_SelectedIndexChanged);
            // 
            // tb_print_btn
            // 
            this.tb_print_btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tb_print_btn.Image = global::ProductInfo_UI.Properties.Resources.print_h22;
            this.tb_print_btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tb_print_btn.Name = "tb_print_btn";
            this.tb_print_btn.Size = new System.Drawing.Size(23, 22);
            this.tb_print_btn.Text = "ამობეჭდვა";
            this.tb_print_btn.Click += new System.EventHandler(this.tb_print_btn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btn_export_csv
            // 
            this.btn_export_csv.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_export_csv.Image = global::ProductInfo_UI.Properties.Resources.csv_22x22;
            this.btn_export_csv.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_export_csv.Name = "btn_export_csv";
            this.btn_export_csv.Size = new System.Drawing.Size(23, 22);
            this.btn_export_csv.Text = "CSV ფაილის შენახვა";
            this.btn_export_csv.Click += new System.EventHandler(this.btn_export_csv_Click);
            // 
            // tb_sep_after_csv_export_btn
            // 
            this.tb_sep_after_csv_export_btn.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.tb_sep_after_csv_export_btn.Name = "tb_sep_after_csv_export_btn";
            this.tb_sep_after_csv_export_btn.Size = new System.Drawing.Size(6, 25);
            // 
            // btn_export_list
            // 
            this.btn_export_list.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_export_list.Image = global::ProductInfo_UI.Properties.Resources.grocery_list_16x22;
            this.btn_export_list.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_export_list.Name = "btn_export_list";
            this.btn_export_list.Size = new System.Drawing.Size(23, 22);
            this.btn_export_list.Text = "სიის ექსპორტი";
            this.btn_export_list.Click += new System.EventHandler(this.btn_export_list_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // status_bar
            // 
            this.status_bar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status_bar_text,
            this.status_progress_bar,
            this.sb_sum_lbl,
            this.sb_sum_withoutVAT_lbl,
            this.sb_refresh_btn});
            this.status_bar.Location = new System.Drawing.Point(0, 571);
            this.status_bar.Name = "status_bar";
            this.status_bar.Size = new System.Drawing.Size(1215, 22);
            this.status_bar.TabIndex = 2;
            this.status_bar.Text = "statusStrip1";
            // 
            // status_bar_text
            // 
            this.status_bar_text.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.status_bar_text.Name = "status_bar_text";
            this.status_bar_text.Size = new System.Drawing.Size(123, 17);
            this.status_bar_text.Text = "Not working yet. ";
            // 
            // status_progress_bar
            // 
            this.status_progress_bar.Name = "status_progress_bar";
            this.status_progress_bar.Size = new System.Drawing.Size(100, 16);
            this.status_progress_bar.Value = 100;
            this.status_progress_bar.Visible = false;
            // 
            // sb_sum_lbl
            // 
            this.sb_sum_lbl.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sb_sum_lbl.Name = "sb_sum_lbl";
            this.sb_sum_lbl.Size = new System.Drawing.Size(530, 17);
            this.sb_sum_lbl.Spring = true;
            this.sb_sum_lbl.Text = "ჯამი: 0.0 ლარი";
            // 
            // sb_sum_withoutVAT_lbl
            // 
            this.sb_sum_withoutVAT_lbl.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sb_sum_withoutVAT_lbl.Name = "sb_sum_withoutVAT_lbl";
            this.sb_sum_withoutVAT_lbl.Size = new System.Drawing.Size(530, 17);
            this.sb_sum_withoutVAT_lbl.Spring = true;
            this.sb_sum_withoutVAT_lbl.Text = "ჯამი დღგ–ს გარეშე: 0.0 ლარი";
            // 
            // sb_refresh_btn
            // 
            this.sb_refresh_btn.Image = global::ProductInfo_UI.Properties.Resources.refresh_16x16;
            this.sb_refresh_btn.IsLink = true;
            this.sb_refresh_btn.Name = "sb_refresh_btn";
            this.sb_refresh_btn.Size = new System.Drawing.Size(16, 17);
            this.sb_refresh_btn.Click += new System.EventHandler(this.sb_refresh_btn_Click);
            // 
            // tab_container
            // 
            this.tab_container.Controls.Add(this.sell_tabpage);
            this.tab_container.Controls.Add(this.nashtebi_tabpage);
            this.tab_container.Controls.Add(this.zednadebebi_tabpage);
            this.tab_container.Controls.Add(this.sold_zednadebebi_tabpage);
            this.tab_container.Controls.Add(this.suppliers_tabpage);
            this.tab_container.Controls.Add(this.buyers_tabpage);
            this.tab_container.Controls.Add(this.productnames_tabpage);
            this.tab_container.Controls.Add(this.sold_tabpage);
            this.tab_container.Controls.Add(this.agcera_tabpage);
            this.tab_container.Controls.Add(this.bought_afs_tabpage);
            this.tab_container.Controls.Add(this.sold_afs_tabpage);
            this.tab_container.Controls.Add(this.sold_prods_tabpage);
            this.tab_container.Controls.Add(this.moneytransfers_tabpage);
            this.tab_container.Controls.Add(this.summary_tabpage);
            this.tab_container.Controls.Add(this.bought_af_standard_list_tabpage);
            this.tab_container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab_container.Font = new System.Drawing.Font("Sylfaen", 11F);
            this.tab_container.Location = new System.Drawing.Point(0, 51);
            this.tab_container.Multiline = true;
            this.tab_container.Name = "tab_container";
            this.tab_container.SelectedIndex = 0;
            this.tab_container.Size = new System.Drawing.Size(1215, 520);
            this.tab_container.TabIndex = 3;
            this.tab_container.SelectedIndexChanged += new System.EventHandler(this.tab_container_SelectedIndexChanged);
            // 
            // sell_tabpage
            // 
            this.sell_tabpage.Controls.Add(this.ckb_pay_method);
            this.sell_tabpage.Controls.Add(this.cmb_xelze_myidveli);
            this.sell_tabpage.Controls.Add(this.lbl_xelze_myidveli);
            this.sell_tabpage.Controls.Add(this.using_check_ckb);
            this.sell_tabpage.Controls.Add(this.sell_panel);
            this.sell_tabpage.Controls.Add(this.sell_status_bar);
            this.sell_tabpage.Controls.Add(this.sell_submit_btn);
            this.sell_tabpage.Location = new System.Drawing.Point(4, 52);
            this.sell_tabpage.Name = "sell_tabpage";
            this.sell_tabpage.Size = new System.Drawing.Size(1207, 464);
            this.sell_tabpage.TabIndex = 6;
            this.sell_tabpage.Text = "გაყიდვა";
            this.sell_tabpage.UseVisualStyleBackColor = true;
            // 
            // ckb_pay_method
            // 
            this.ckb_pay_method.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ckb_pay_method.Enabled = false;
            this.ckb_pay_method.FormattingEnabled = true;
            this.ckb_pay_method.Items.AddRange(new object[] {
            "ნაღდი",
            "კონსიგნაცია"});
            this.ckb_pay_method.Location = new System.Drawing.Point(374, 3);
            this.ckb_pay_method.Name = "ckb_pay_method";
            this.ckb_pay_method.Size = new System.Drawing.Size(84, 27);
            this.ckb_pay_method.TabIndex = 12;
            // 
            // cmb_xelze_myidveli
            // 
            this.cmb_xelze_myidveli.FormattingEnabled = true;
            this.cmb_xelze_myidveli.Location = new System.Drawing.Point(172, 3);
            this.cmb_xelze_myidveli.Name = "cmb_xelze_myidveli";
            this.cmb_xelze_myidveli.Size = new System.Drawing.Size(194, 27);
            this.cmb_xelze_myidveli.TabIndex = 4;
            this.cmb_xelze_myidveli.SelectedIndexChanged += new System.EventHandler(this.cmb_xelze_myidveli_SelectedIndexChanged);
            this.cmb_xelze_myidveli.TextChanged += new System.EventHandler(this.cmb_xelze_myidveli_TextChanged);
            // 
            // lbl_xelze_myidveli
            // 
            this.lbl_xelze_myidveli.AutoSize = true;
            this.lbl_xelze_myidveli.Location = new System.Drawing.Point(76, 4);
            this.lbl_xelze_myidveli.Name = "lbl_xelze_myidveli";
            this.lbl_xelze_myidveli.Size = new System.Drawing.Size(89, 19);
            this.lbl_xelze_myidveli.TabIndex = 5;
            this.lbl_xelze_myidveli.Text = "მყიდველი: ";
            // 
            // using_check_ckb
            // 
            this.using_check_ckb.AutoSize = true;
            this.using_check_ckb.Checked = true;
            this.using_check_ckb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.using_check_ckb.Font = new System.Drawing.Font("Sylfaen", 14F);
            this.using_check_ckb.Location = new System.Drawing.Point(3, 0);
            this.using_check_ckb.Name = "using_check_ckb";
            this.using_check_ckb.Size = new System.Drawing.Size(70, 29);
            this.using_check_ckb.TabIndex = 2;
            this.using_check_ckb.Text = "ჩეკი";
            this.using_check_ckb.UseVisualStyleBackColor = true;
            this.using_check_ckb.CheckedChanged += new System.EventHandler(this.using_check_ckb_CheckedChanged);
            // 
            // sell_panel
            // 
            this.sell_panel.Controls.Add(this.sell_list);
            this.sell_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sell_panel.Location = new System.Drawing.Point(0, 0);
            this.sell_panel.Name = "sell_panel";
            this.sell_panel.Size = new System.Drawing.Size(1207, 399);
            this.sell_panel.TabIndex = 13;
            // 
            // sell_list
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.sell_list.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Sylfaen", 11F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.sell_list.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.sell_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sell_list.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sell_barcode_col,
            this.sell_name_col,
            this.sell_capacity_col,
            this.sell_pack_amount_col,
            this.sell_pack_price_col,
            this.sell_piece_amount_col,
            this.sell_piece_price_col,
            this.sell_piece_amount_info,
            this.sell_initial_price_info_col,
            this.sell_remaining_col,
            this.sell_sum_price_col,
            this.sell_delete_col});
            this.sell_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sell_list.Location = new System.Drawing.Point(0, 0);
            this.sell_list.Name = "sell_list";
            this.sell_list.Size = new System.Drawing.Size(1207, 399);
            this.sell_list.TabIndex = 0;
            this.sell_list.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.sell_list_RowEnter);
            this.sell_list.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.sell_list_CellEndEdit);
            this.sell_list.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.sell_list_EditingControlShowing);
            this.sell_list.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.sell_list_DataError);
            this.sell_list.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sell_list_KeyDown);
            this.sell_list.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.sell_list_CellContentClick);
            // 
            // sell_barcode_col
            // 
            this.sell_barcode_col.Frozen = true;
            this.sell_barcode_col.HeaderText = "შტრიხ–კოდი";
            this.sell_barcode_col.Name = "sell_barcode_col";
            this.sell_barcode_col.Width = 130;
            // 
            // sell_name_col
            // 
            this.sell_name_col.Frozen = true;
            this.sell_name_col.HeaderText = "დასახელება";
            this.sell_name_col.MaxDropDownItems = 30;
            this.sell_name_col.Name = "sell_name_col";
            this.sell_name_col.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.sell_name_col.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.sell_name_col.Width = 150;
            // 
            // sell_capacity_col
            // 
            this.sell_capacity_col.Frozen = true;
            this.sell_capacity_col.HeaderText = "ყუთის ტევადობა";
            this.sell_capacity_col.Name = "sell_capacity_col";
            this.sell_capacity_col.ReadOnly = true;
            this.sell_capacity_col.Width = 80;
            // 
            // sell_pack_amount_col
            // 
            this.sell_pack_amount_col.Frozen = true;
            this.sell_pack_amount_col.HeaderText = "რაოდენობა (ყუთების)";
            this.sell_pack_amount_col.Name = "sell_pack_amount_col";
            // 
            // sell_pack_price_col
            // 
            this.sell_pack_price_col.Frozen = true;
            this.sell_pack_price_col.HeaderText = "ყუთის ფასი";
            this.sell_pack_price_col.Name = "sell_pack_price_col";
            this.sell_pack_price_col.Width = 70;
            // 
            // sell_piece_amount_col
            // 
            this.sell_piece_amount_col.Frozen = true;
            this.sell_piece_amount_col.HeaderText = "რაოდენობა (ცალობით)";
            this.sell_piece_amount_col.Name = "sell_piece_amount_col";
            // 
            // sell_piece_price_col
            // 
            this.sell_piece_price_col.Frozen = true;
            this.sell_piece_price_col.HeaderText = "საცალო ფასი";
            this.sell_piece_price_col.Name = "sell_piece_price_col";
            this.sell_piece_price_col.Width = 70;
            // 
            // sell_piece_amount_info
            // 
            this.sell_piece_amount_info.Frozen = true;
            this.sell_piece_amount_info.HeaderText = "სულ იყიდება (ცალი)";
            this.sell_piece_amount_info.Name = "sell_piece_amount_info";
            this.sell_piece_amount_info.ReadOnly = true;
            this.sell_piece_amount_info.Width = 70;
            // 
            // sell_initial_price_info_col
            // 
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            this.sell_initial_price_info_col.DefaultCellStyle = dataGridViewCellStyle8;
            this.sell_initial_price_info_col.Frozen = true;
            this.sell_initial_price_info_col.HeaderText = "ასაღები ფასი (საცალო)";
            this.sell_initial_price_info_col.Name = "sell_initial_price_info_col";
            this.sell_initial_price_info_col.ReadOnly = true;
            // 
            // sell_remaining_col
            // 
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.sell_remaining_col.DefaultCellStyle = dataGridViewCellStyle9;
            this.sell_remaining_col.HeaderText = "დარჩ.";
            this.sell_remaining_col.Name = "sell_remaining_col";
            this.sell_remaining_col.ReadOnly = true;
            // 
            // sell_sum_price_col
            // 
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.Gray;
            this.sell_sum_price_col.DefaultCellStyle = dataGridViewCellStyle10;
            this.sell_sum_price_col.HeaderText = "ჯამი";
            this.sell_sum_price_col.Name = "sell_sum_price_col";
            this.sell_sum_price_col.ReadOnly = true;
            this.sell_sum_price_col.Width = 65;
            // 
            // sell_delete_col
            // 
            this.sell_delete_col.HeaderText = "ამოშლა";
            this.sell_delete_col.Name = "sell_delete_col";
            this.sell_delete_col.Text = "ამოშლა";
            this.sell_delete_col.UseColumnTextForButtonValue = true;
            this.sell_delete_col.Width = 65;
            // 
            // sell_status_bar
            // 
            this.sell_status_bar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sell_status_lbl,
            this.sell_status_sum_price_lbl});
            this.sell_status_bar.Location = new System.Drawing.Point(0, 399);
            this.sell_status_bar.Name = "sell_status_bar";
            this.sell_status_bar.Size = new System.Drawing.Size(1207, 23);
            this.sell_status_bar.TabIndex = 3;
            this.sell_status_bar.Text = "sell_statusstrip";
            // 
            // sell_status_lbl
            // 
            this.sell_status_lbl.Name = "sell_status_lbl";
            this.sell_status_lbl.Size = new System.Drawing.Size(192, 18);
            this.sell_status_lbl.Text = "შეიყვანეთ შტრიხ–კოდი ან დასახელება";
            // 
            // sell_status_sum_price_lbl
            // 
            this.sell_status_sum_price_lbl.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sell_status_sum_price_lbl.Name = "sell_status_sum_price_lbl";
            this.sell_status_sum_price_lbl.Size = new System.Drawing.Size(1000, 18);
            this.sell_status_sum_price_lbl.Spring = true;
            this.sell_status_sum_price_lbl.Text = "საერთო ფასი 0.0 ლარი";
            // 
            // sell_submit_btn
            // 
            this.sell_submit_btn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.sell_submit_btn.Font = new System.Drawing.Font("Sylfaen", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sell_submit_btn.Location = new System.Drawing.Point(0, 422);
            this.sell_submit_btn.Name = "sell_submit_btn";
            this.sell_submit_btn.Size = new System.Drawing.Size(1207, 42);
            this.sell_submit_btn.TabIndex = 1;
            this.sell_submit_btn.Text = "გაყიდვა";
            this.sell_submit_btn.UseVisualStyleBackColor = true;
            this.sell_submit_btn.Click += new System.EventHandler(this.sell_submit_btn_Click);
            // 
            // nashtebi_tabpage
            // 
            this.nashtebi_tabpage.Controls.Add(this.rem_list);
            this.nashtebi_tabpage.Location = new System.Drawing.Point(4, 52);
            this.nashtebi_tabpage.Name = "nashtebi_tabpage";
            this.nashtebi_tabpage.Size = new System.Drawing.Size(1207, 464);
            this.nashtebi_tabpage.TabIndex = 0;
            this.nashtebi_tabpage.Text = "ნაშთები";
            this.nashtebi_tabpage.UseVisualStyleBackColor = true;
            // 
            // rem_list
            // 
            this.rem_list.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.rem_list_barcode_header,
            this.rem_list_prodname_header,
            this.rem_list_supplier_header,
            this.rem_list_capacity_header,
            this.rem_list_store_col,
            this.rem_list_packs_header,
            this.rem_list_piece_price_col,
            this.rem_list_piece_sell_price_col,
            this.rem_list_initial_whole_price_col,
            this.rem_list_remaining_whole_price_col,
            this.rem_list_cost_withoutVAT_col});
            this.rem_list.ContextMenuStrip = this.cm_rem_list;
            this.rem_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rem_list.Font = new System.Drawing.Font("Sylfaen", 10F);
            this.rem_list.FullRowSelect = true;
            this.rem_list.GridLines = true;
            this.rem_list.Location = new System.Drawing.Point(0, 0);
            this.rem_list.MultiSelect = false;
            this.rem_list.Name = "rem_list";
            this.rem_list.Size = new System.Drawing.Size(1207, 464);
            this.rem_list.TabIndex = 0;
            this.rem_list.UseCompatibleStateImageBehavior = false;
            this.rem_list.View = System.Windows.Forms.View.Details;
            // 
            // rem_list_barcode_header
            // 
            this.rem_list_barcode_header.Text = "შტრიხ–კოდი";
            this.rem_list_barcode_header.Width = 106;
            // 
            // rem_list_prodname_header
            // 
            this.rem_list_prodname_header.Text = "დასახელება";
            this.rem_list_prodname_header.Width = 126;
            // 
            // rem_list_supplier_header
            // 
            this.rem_list_supplier_header.Text = "შემომტანი";
            this.rem_list_supplier_header.Width = 103;
            // 
            // rem_list_capacity_header
            // 
            this.rem_list_capacity_header.Text = "ყუთის ტევადობა";
            this.rem_list_capacity_header.Width = 123;
            // 
            // rem_list_store_col
            // 
            this.rem_list_store_col.Text = "საწყობი";
            this.rem_list_store_col.Width = 69;
            // 
            // rem_list_packs_header
            // 
            this.rem_list_packs_header.Text = "ყუთები (დარჩა/სულ):ცალობით";
            this.rem_list_packs_header.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.rem_list_packs_header.Width = 213;
            // 
            // rem_list_piece_price_col
            // 
            this.rem_list_piece_price_col.Text = "საცალო ფასი";
            this.rem_list_piece_price_col.Width = 98;
            // 
            // rem_list_piece_sell_price_col
            // 
            this.rem_list_piece_sell_price_col.Text = "გასაყიდი ფასი";
            this.rem_list_piece_sell_price_col.Width = 105;
            // 
            // rem_list_initial_whole_price_col
            // 
            this.rem_list_initial_whole_price_col.Text = "საწყისი ღირ.";
            this.rem_list_initial_whole_price_col.Width = 108;
            // 
            // rem_list_remaining_whole_price_col
            // 
            this.rem_list_remaining_whole_price_col.Text = "დარჩენილის ღირ.";
            this.rem_list_remaining_whole_price_col.Width = 181;
            // 
            // rem_list_cost_withoutVAT_col
            // 
            this.rem_list_cost_withoutVAT_col.Text = "ღირ. დღგ–ს გარეშე";
            this.rem_list_cost_withoutVAT_col.Width = 137;
            // 
            // cm_rem_list
            // 
            this.cm_rem_list.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmi_rem_list_supplier_info,
            this.cmi_split_rems});
            this.cm_rem_list.Name = "cm_rem_list";
            this.cm_rem_list.Size = new System.Drawing.Size(205, 48);
            // 
            // cmi_rem_list_supplier_info
            // 
            this.cmi_rem_list_supplier_info.Name = "cmi_rem_list_supplier_info";
            this.cmi_rem_list_supplier_info.Size = new System.Drawing.Size(204, 22);
            this.cmi_rem_list_supplier_info.Text = "ინფორმაცია ამ შემომტანზე";
            this.cmi_rem_list_supplier_info.Click += new System.EventHandler(this.cmi_rem_list_supplier_info_Click);
            // 
            // cmi_split_rems
            // 
            this.cmi_split_rems.Name = "cmi_split_rems";
            this.cmi_split_rems.Size = new System.Drawing.Size(204, 22);
            this.cmi_split_rems.Text = "საწყობებში განაწილება";
            this.cmi_split_rems.Click += new System.EventHandler(this.cmi_split_rems_Click);
            // 
            // zednadebebi_tabpage
            // 
            this.zednadebebi_tabpage.Controls.Add(this.zed_list);
            this.zednadebebi_tabpage.Location = new System.Drawing.Point(4, 52);
            this.zednadebebi_tabpage.Name = "zednadebebi_tabpage";
            this.zednadebebi_tabpage.Size = new System.Drawing.Size(1207, 464);
            this.zednadebebi_tabpage.TabIndex = 3;
            this.zednadebebi_tabpage.Text = "შემოსული ზედნადებები";
            this.zednadebebi_tabpage.UseVisualStyleBackColor = true;
            // 
            // zed_list
            // 
            this.zed_list.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.zed_ident_col,
            this.zed_date_col,
            this.zed_supplier_col,
            this.zed_list_af_seria_col,
            this.zed_list_af_saident_col,
            this.zed_list_costwithVAT_col,
            this.zed_list_costwithoutVAT_col});
            this.zed_list.ContextMenuStrip = this.cm_incoming_zeds;
            this.zed_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zed_list.Font = new System.Drawing.Font("Sylfaen", 10F);
            this.zed_list.FullRowSelect = true;
            this.zed_list.GridLines = true;
            this.zed_list.Location = new System.Drawing.Point(0, 0);
            this.zed_list.Name = "zed_list";
            this.zed_list.Size = new System.Drawing.Size(1207, 464);
            this.zed_list.TabIndex = 1;
            this.zed_list.UseCompatibleStateImageBehavior = false;
            this.zed_list.View = System.Windows.Forms.View.Details;
            // 
            // zed_ident_col
            // 
            this.zed_ident_col.Text = "ზედ. კოდი";
            this.zed_ident_col.Width = 109;
            // 
            // zed_date_col
            // 
            this.zed_date_col.Text = "თარიღი";
            this.zed_date_col.Width = 92;
            // 
            // zed_supplier_col
            // 
            this.zed_supplier_col.Text = "მომწოდებელი";
            this.zed_supplier_col.Width = 122;
            // 
            // zed_list_af_seria_col
            // 
            this.zed_list_af_seria_col.Text = "ა/ფ სერია";
            this.zed_list_af_seria_col.Width = 83;
            // 
            // zed_list_af_saident_col
            // 
            this.zed_list_af_saident_col.Text = "ა/ფ ნომერი";
            this.zed_list_af_saident_col.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.zed_list_af_saident_col.Width = 90;
            // 
            // zed_list_costwithVAT_col
            // 
            this.zed_list_costwithVAT_col.Text = "ღირებულება";
            this.zed_list_costwithVAT_col.Width = 100;
            // 
            // zed_list_costwithoutVAT_col
            // 
            this.zed_list_costwithoutVAT_col.Text = "ღირებულება დღგ–ს გარეშე";
            this.zed_list_costwithoutVAT_col.Width = 192;
            // 
            // cm_incoming_zeds
            // 
            this.cm_incoming_zeds.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmi_incoming_zeds_details,
            this.cmi_incoming_zeds_payfor,
            this.cmi_incoming_zeds_edit,
            this.cmi_incoming_zeds_remove});
            this.cm_incoming_zeds.Name = "cm_sold";
            this.cm_incoming_zeds.Size = new System.Drawing.Size(172, 92);
            // 
            // cmi_incoming_zeds_details
            // 
            this.cmi_incoming_zeds_details.Name = "cmi_incoming_zeds_details";
            this.cmi_incoming_zeds_details.Size = new System.Drawing.Size(171, 22);
            this.cmi_incoming_zeds_details.Text = "დეტალური სია";
            this.cmi_incoming_zeds_details.Click += new System.EventHandler(this.cmi_incoming_zeds_details_Click);
            // 
            // cmi_incoming_zeds_payfor
            // 
            this.cmi_incoming_zeds_payfor.Name = "cmi_incoming_zeds_payfor";
            this.cmi_incoming_zeds_payfor.Size = new System.Drawing.Size(171, 22);
            this.cmi_incoming_zeds_payfor.Text = "ვალის დაფარვა";
            this.cmi_incoming_zeds_payfor.Click += new System.EventHandler(this.cmi_incoming_zeds_payfor_Click);
            // 
            // cmi_incoming_zeds_edit
            // 
            this.cmi_incoming_zeds_edit.Name = "cmi_incoming_zeds_edit";
            this.cmi_incoming_zeds_edit.Size = new System.Drawing.Size(171, 22);
            this.cmi_incoming_zeds_edit.Text = "ჩასწორება";
            this.cmi_incoming_zeds_edit.Click += new System.EventHandler(this.cmi_incoming_zeds_edit_Click);
            // 
            // cmi_incoming_zeds_remove
            // 
            this.cmi_incoming_zeds_remove.Name = "cmi_incoming_zeds_remove";
            this.cmi_incoming_zeds_remove.Size = new System.Drawing.Size(171, 22);
            this.cmi_incoming_zeds_remove.Text = "ზედნადების ამოშლა";
            this.cmi_incoming_zeds_remove.Click += new System.EventHandler(this.cmi_incoming_zeds_remove_Click);
            // 
            // sold_zednadebebi_tabpage
            // 
            this.sold_zednadebebi_tabpage.Controls.Add(this.sold_zed_list);
            this.sold_zednadebebi_tabpage.Location = new System.Drawing.Point(4, 52);
            this.sold_zednadebebi_tabpage.Name = "sold_zednadebebi_tabpage";
            this.sold_zednadebebi_tabpage.Size = new System.Drawing.Size(1207, 464);
            this.sold_zednadebebi_tabpage.TabIndex = 9;
            this.sold_zednadebebi_tabpage.Text = "გასული ზედნადებები";
            this.sold_zednadebebi_tabpage.UseVisualStyleBackColor = true;
            // 
            // sold_zed_list
            // 
            this.sold_zed_list.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.sold_z_ident_code_col,
            this.sold_z_date_col,
            this.sold_z_buyer_col,
            this.sold_z_af_seria_col,
            this.sold_z_af_nomeri_col,
            this.sold_z_cost_col,
            this.sold_z_cost_withoutVAT_col,
            this.sold_z_income_amount_col,
            this.sold_z_price,
            this.sold_z_roi_col,
            this.sold_z_roi_withoutVAT_col,
            this.sold_z_VAT_tax_amount,
            this.sold_z_zed_price_withoutVAT});
            this.sold_zed_list.ContextMenuStrip = this.cm_sold_zednadebi;
            this.sold_zed_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sold_zed_list.Font = new System.Drawing.Font("Sylfaen", 10F);
            this.sold_zed_list.FullRowSelect = true;
            this.sold_zed_list.GridLines = true;
            this.sold_zed_list.Location = new System.Drawing.Point(0, 0);
            this.sold_zed_list.Name = "sold_zed_list";
            this.sold_zed_list.Size = new System.Drawing.Size(1207, 464);
            this.sold_zed_list.TabIndex = 2;
            this.sold_zed_list.UseCompatibleStateImageBehavior = false;
            this.sold_zed_list.View = System.Windows.Forms.View.Details;
            // 
            // sold_z_ident_code_col
            // 
            this.sold_z_ident_code_col.Text = "ზედ. კოდი";
            this.sold_z_ident_code_col.Width = 109;
            // 
            // sold_z_date_col
            // 
            this.sold_z_date_col.Text = "თარიღი";
            this.sold_z_date_col.Width = 92;
            // 
            // sold_z_buyer_col
            // 
            this.sold_z_buyer_col.Text = "მყიდველი";
            this.sold_z_buyer_col.Width = 122;
            // 
            // sold_z_af_seria_col
            // 
            this.sold_z_af_seria_col.Text = "ა/ფ სერია";
            this.sold_z_af_seria_col.Width = 83;
            // 
            // sold_z_af_nomeri_col
            // 
            this.sold_z_af_nomeri_col.Text = "ა/ფ ნომერი";
            this.sold_z_af_nomeri_col.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.sold_z_af_nomeri_col.Width = 90;
            // 
            // sold_z_cost_col
            // 
            this.sold_z_cost_col.Text = "თვითღირ.";
            this.sold_z_cost_col.Width = 85;
            // 
            // sold_z_cost_withoutVAT_col
            // 
            this.sold_z_cost_withoutVAT_col.Text = "თვითღირ. დღგ–ს გარეშე";
            this.sold_z_cost_withoutVAT_col.Width = 171;
            // 
            // sold_z_income_amount_col
            // 
            this.sold_z_income_amount_col.Text = "აღებული თანხა";
            this.sold_z_income_amount_col.Width = 132;
            // 
            // sold_z_price
            // 
            this.sold_z_price.Text = "ზედ. ღირ.";
            this.sold_z_price.Width = 83;
            // 
            // sold_z_roi_col
            // 
            this.sold_z_roi_col.Text = "მოგება";
            // 
            // sold_z_roi_withoutVAT_col
            // 
            this.sold_z_roi_withoutVAT_col.Text = "მოგება დღგ–ს გარეშე";
            this.sold_z_roi_withoutVAT_col.Width = 150;
            // 
            // sold_z_VAT_tax_amount
            // 
            this.sold_z_VAT_tax_amount.Text = "დღგ";
            // 
            // sold_z_zed_price_withoutVAT
            // 
            this.sold_z_zed_price_withoutVAT.Text = "ზედ. ღირ. დღგ–ს გარეშე";
            // 
            // cm_sold_zednadebi
            // 
            this.cm_sold_zednadebi.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmi_sold_zed_details,
            this.cmi_sold_zed_payfor,
            this.cmi_zed_print,
            this.cmi_sold_zed_remove});
            this.cm_sold_zednadebi.Name = "cm_sold_zednadebi";
            this.cm_sold_zednadebi.Size = new System.Drawing.Size(172, 92);
            // 
            // cmi_sold_zed_details
            // 
            this.cmi_sold_zed_details.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.cmi_sold_zed_details.Name = "cmi_sold_zed_details";
            this.cmi_sold_zed_details.Size = new System.Drawing.Size(171, 22);
            this.cmi_sold_zed_details.Text = "დეტალური სია";
            this.cmi_sold_zed_details.Click += new System.EventHandler(this.cmi_sold_zed_details_Click);
            // 
            // cmi_sold_zed_payfor
            // 
            this.cmi_sold_zed_payfor.Name = "cmi_sold_zed_payfor";
            this.cmi_sold_zed_payfor.Size = new System.Drawing.Size(171, 22);
            this.cmi_sold_zed_payfor.Text = "ვალის დაფარვა";
            this.cmi_sold_zed_payfor.Click += new System.EventHandler(this.cmi_sold_zed_payfor_Click);
            // 
            // cmi_zed_print
            // 
            this.cmi_zed_print.Name = "cmi_zed_print";
            this.cmi_zed_print.Size = new System.Drawing.Size(171, 22);
            this.cmi_zed_print.Text = "ამობეჭდვა";
            this.cmi_zed_print.Click += new System.EventHandler(this.cmi_zed_print_Click);
            // 
            // cmi_sold_zed_remove
            // 
            this.cmi_sold_zed_remove.Name = "cmi_sold_zed_remove";
            this.cmi_sold_zed_remove.Size = new System.Drawing.Size(171, 22);
            this.cmi_sold_zed_remove.Text = "ზედნადების ამოშლა";
            this.cmi_sold_zed_remove.Click += new System.EventHandler(this.cmi_sold_zed_remove_Click);
            // 
            // suppliers_tabpage
            // 
            this.suppliers_tabpage.Controls.Add(this.suppliers_list);
            this.suppliers_tabpage.Location = new System.Drawing.Point(4, 52);
            this.suppliers_tabpage.Name = "suppliers_tabpage";
            this.suppliers_tabpage.Size = new System.Drawing.Size(1207, 464);
            this.suppliers_tabpage.TabIndex = 1;
            this.suppliers_tabpage.Text = "მომწოდებლები";
            this.suppliers_tabpage.UseVisualStyleBackColor = true;
            // 
            // suppliers_list
            // 
            this.suppliers_list.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.suppliers_list_name_header,
            this.suppliers_list_ident_code_header,
            this.suppliers_list_address_header,
            this.supplier_mosacemi_col,
            this.supplier_misacemi_col});
            this.suppliers_list.ContextMenuStrip = this.cm_supplier_list;
            this.suppliers_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.suppliers_list.FullRowSelect = true;
            this.suppliers_list.GridLines = true;
            this.suppliers_list.Location = new System.Drawing.Point(0, 0);
            this.suppliers_list.MultiSelect = false;
            this.suppliers_list.Name = "suppliers_list";
            this.suppliers_list.Size = new System.Drawing.Size(1207, 464);
            this.suppliers_list.TabIndex = 0;
            this.suppliers_list.UseCompatibleStateImageBehavior = false;
            this.suppliers_list.View = System.Windows.Forms.View.Details;
            // 
            // suppliers_list_name_header
            // 
            this.suppliers_list_name_header.Text = "მომწოდებლის სახელი";
            this.suppliers_list_name_header.Width = 250;
            // 
            // suppliers_list_ident_code_header
            // 
            this.suppliers_list_ident_code_header.Text = "საიდენტიფიკაციო კოდი";
            this.suppliers_list_ident_code_header.Width = 250;
            // 
            // suppliers_list_address_header
            // 
            this.suppliers_list_address_header.Text = "მისამართი";
            this.suppliers_list_address_header.Width = 147;
            // 
            // supplier_mosacemi_col
            // 
            this.supplier_mosacemi_col.Text = "მოსაცემი აქვს";
            this.supplier_mosacemi_col.Width = 130;
            // 
            // supplier_misacemi_col
            // 
            this.supplier_misacemi_col.Text = "მისაცემი გვაქვს";
            this.supplier_misacemi_col.Width = 134;
            // 
            // cm_supplier_list
            // 
            this.cm_supplier_list.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmi_this_supplier_zeds,
            this.cmi_this_supplier_remainders,
            this.cm_supplier_edit,
            this.cmi_supplier_money_transfer,
            this.cmi_supp_oper_hist});
            this.cm_supplier_list.Name = "cm_supplier_list";
            this.cm_supplier_list.Size = new System.Drawing.Size(208, 114);
            // 
            // cmi_this_supplier_zeds
            // 
            this.cmi_this_supplier_zeds.Name = "cmi_this_supplier_zeds";
            this.cmi_this_supplier_zeds.Size = new System.Drawing.Size(207, 22);
            this.cmi_this_supplier_zeds.Text = "ამ შემომტანის ზედნადებები";
            this.cmi_this_supplier_zeds.Click += new System.EventHandler(this.cmi_this_supplier_zeds_Click);
            // 
            // cmi_this_supplier_remainders
            // 
            this.cmi_this_supplier_remainders.Name = "cmi_this_supplier_remainders";
            this.cmi_this_supplier_remainders.Size = new System.Drawing.Size(207, 22);
            this.cmi_this_supplier_remainders.Text = "ამ შემომტანის საქონელი";
            this.cmi_this_supplier_remainders.Click += new System.EventHandler(this.cmi_this_supplier_remainders_Click);
            // 
            // cm_supplier_edit
            // 
            this.cm_supplier_edit.Name = "cm_supplier_edit";
            this.cm_supplier_edit.Size = new System.Drawing.Size(207, 22);
            this.cm_supplier_edit.Text = "ინფორმაციის შეცვლა";
            this.cm_supplier_edit.Click += new System.EventHandler(this.cm_supplier_edit_Click);
            // 
            // cmi_supplier_money_transfer
            // 
            this.cmi_supplier_money_transfer.Name = "cmi_supplier_money_transfer";
            this.cmi_supplier_money_transfer.Size = new System.Drawing.Size(207, 22);
            this.cmi_supplier_money_transfer.Text = "ფულადი ოპერაცია";
            this.cmi_supplier_money_transfer.Click += new System.EventHandler(this.cmi_supplier_money_transfer_Click);
            // 
            // cmi_supp_oper_hist
            // 
            this.cmi_supp_oper_hist.Name = "cmi_supp_oper_hist";
            this.cmi_supp_oper_hist.Size = new System.Drawing.Size(207, 22);
            this.cmi_supp_oper_hist.Text = "ოპერაციების ისტორია";
            this.cmi_supp_oper_hist.Click += new System.EventHandler(this.cmi_supp_oper_hist_Click);
            // 
            // buyers_tabpage
            // 
            this.buyers_tabpage.Controls.Add(this.buyers_list);
            this.buyers_tabpage.Location = new System.Drawing.Point(4, 52);
            this.buyers_tabpage.Name = "buyers_tabpage";
            this.buyers_tabpage.Size = new System.Drawing.Size(1207, 464);
            this.buyers_tabpage.TabIndex = 4;
            this.buyers_tabpage.Text = "მყიდველები";
            this.buyers_tabpage.UseVisualStyleBackColor = true;
            // 
            // buyers_list
            // 
            this.buyers_list.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.buyer_name_col,
            this.buyer_ident_col,
            this.buyer_address_col,
            this.buyer_mosacemi_col,
            this.buyer_misacemi_col});
            this.buyers_list.ContextMenuStrip = this.cm_buyer_list;
            this.buyers_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buyers_list.FullRowSelect = true;
            this.buyers_list.GridLines = true;
            this.buyers_list.Location = new System.Drawing.Point(0, 0);
            this.buyers_list.MultiSelect = false;
            this.buyers_list.Name = "buyers_list";
            this.buyers_list.Size = new System.Drawing.Size(1207, 464);
            this.buyers_list.TabIndex = 1;
            this.buyers_list.UseCompatibleStateImageBehavior = false;
            this.buyers_list.View = System.Windows.Forms.View.Details;
            // 
            // buyer_name_col
            // 
            this.buyer_name_col.Text = "მყიდველის სახელი";
            this.buyer_name_col.Width = 253;
            // 
            // buyer_ident_col
            // 
            this.buyer_ident_col.Text = "საიდენტიფიკაციო კოდი";
            this.buyer_ident_col.Width = 187;
            // 
            // buyer_address_col
            // 
            this.buyer_address_col.Text = "მისამართი";
            this.buyer_address_col.Width = 283;
            // 
            // buyer_mosacemi_col
            // 
            this.buyer_mosacemi_col.Text = "მისაცემი გვაქვს";
            this.buyer_mosacemi_col.Width = 133;
            // 
            // buyer_misacemi_col
            // 
            this.buyer_misacemi_col.Text = "მოსაცემი აქვს";
            this.buyer_misacemi_col.Width = 135;
            // 
            // cm_buyer_list
            // 
            this.cm_buyer_list.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmi_buyer_money_transfer,
            this.cmi_buyer_oper_hist,
            this.cmi_buyer_edit});
            this.cm_buyer_list.Name = "cm_buyer_list";
            this.cm_buyer_list.Size = new System.Drawing.Size(185, 70);
            // 
            // cmi_buyer_money_transfer
            // 
            this.cmi_buyer_money_transfer.Name = "cmi_buyer_money_transfer";
            this.cmi_buyer_money_transfer.Size = new System.Drawing.Size(184, 22);
            this.cmi_buyer_money_transfer.Text = "ფულადი ოპერაცია";
            this.cmi_buyer_money_transfer.Click += new System.EventHandler(this.cmi_buyer_money_transfer_Click);
            // 
            // cmi_buyer_oper_hist
            // 
            this.cmi_buyer_oper_hist.Name = "cmi_buyer_oper_hist";
            this.cmi_buyer_oper_hist.Size = new System.Drawing.Size(184, 22);
            this.cmi_buyer_oper_hist.Text = "ოპერაციების ისტორია";
            this.cmi_buyer_oper_hist.Click += new System.EventHandler(this.cmi_buyer_oper_hist_Click);
            // 
            // cmi_buyer_edit
            // 
            this.cmi_buyer_edit.Name = "cmi_buyer_edit";
            this.cmi_buyer_edit.Size = new System.Drawing.Size(184, 22);
            this.cmi_buyer_edit.Text = "ინფორმაციის შეცვლა";
            this.cmi_buyer_edit.Click += new System.EventHandler(this.cmi_buyer_edit_Click);
            // 
            // productnames_tabpage
            // 
            this.productnames_tabpage.Controls.Add(this.prod_names_list);
            this.productnames_tabpage.Location = new System.Drawing.Point(4, 52);
            this.productnames_tabpage.Name = "productnames_tabpage";
            this.productnames_tabpage.Size = new System.Drawing.Size(1207, 464);
            this.productnames_tabpage.TabIndex = 5;
            this.productnames_tabpage.Text = "დასახელებები";
            this.productnames_tabpage.UseVisualStyleBackColor = true;
            // 
            // prod_names_list
            // 
            this.prod_names_list.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.pnames_bcode_col,
            this.pnames_name_col,
            this.pnames_capacity_col,
            this.pnames_initial_count_col,
            this.pnames_initial_sum_cost_col,
            this.pnames_remaining_col,
            this.pnames_piece_price_col,
            this.pnames_remaining_amount_col,
            this.pnames_costwithoutVAT_col});
            this.prod_names_list.ContextMenuStrip = this.prod_list_cm;
            this.prod_names_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prod_names_list.Font = new System.Drawing.Font("Sylfaen", 10F);
            this.prod_names_list.FullRowSelect = true;
            this.prod_names_list.GridLines = true;
            this.prod_names_list.Location = new System.Drawing.Point(0, 0);
            this.prod_names_list.MultiSelect = false;
            this.prod_names_list.Name = "prod_names_list";
            this.prod_names_list.Size = new System.Drawing.Size(1207, 464);
            this.prod_names_list.TabIndex = 1;
            this.prod_names_list.UseCompatibleStateImageBehavior = false;
            this.prod_names_list.View = System.Windows.Forms.View.Details;
            this.prod_names_list.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.prod_names_list_ColumnClick);
            // 
            // pnames_bcode_col
            // 
            this.pnames_bcode_col.Text = "შტრიხ–კოდი";
            this.pnames_bcode_col.Width = 107;
            // 
            // pnames_name_col
            // 
            this.pnames_name_col.Text = "დასახელება";
            this.pnames_name_col.Width = 96;
            // 
            // pnames_capacity_col
            // 
            this.pnames_capacity_col.Text = "ტევადობა";
            this.pnames_capacity_col.Width = 77;
            // 
            // pnames_initial_count_col
            // 
            this.pnames_initial_count_col.Text = "საწყისი ჯამ. საცალო რაოდ.";
            this.pnames_initial_count_col.Width = 181;
            // 
            // pnames_initial_sum_cost_col
            // 
            this.pnames_initial_sum_cost_col.Text = "საწყისი ჯამ. ღირ.";
            this.pnames_initial_sum_cost_col.Width = 120;
            // 
            // pnames_remaining_col
            // 
            this.pnames_remaining_col.Text = "დარჩენილია (ცალობით)";
            this.pnames_remaining_col.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.pnames_remaining_col.Width = 201;
            // 
            // pnames_piece_price_col
            // 
            this.pnames_piece_price_col.Text = "საშუალო საცალო ფასი";
            this.pnames_piece_price_col.Width = 152;
            // 
            // pnames_remaining_amount_col
            // 
            this.pnames_remaining_amount_col.Text = "დარჩენილის ღირებულება";
            this.pnames_remaining_amount_col.Width = 178;
            // 
            // pnames_costwithoutVAT_col
            // 
            this.pnames_costwithoutVAT_col.Text = "ღირ. დღგ–ს გარეშე";
            this.pnames_costwithoutVAT_col.Width = 137;
            // 
            // prod_list_cm
            // 
            this.prod_list_cm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prod_list_edit_cmi,
            this.cmi_prod_list_delete_dublicates});
            this.prod_list_cm.Name = "prod_list_cm";
            this.prod_list_cm.Size = new System.Drawing.Size(172, 48);
            // 
            // prod_list_edit_cmi
            // 
            this.prod_list_edit_cmi.Name = "prod_list_edit_cmi";
            this.prod_list_edit_cmi.Size = new System.Drawing.Size(171, 22);
            this.prod_list_edit_cmi.Text = "ჩასწორება";
            this.prod_list_edit_cmi.Click += new System.EventHandler(this.prod_list_edit_cmi_Click);
            // 
            // cmi_prod_list_delete_dublicates
            // 
            this.cmi_prod_list_delete_dublicates.Name = "cmi_prod_list_delete_dublicates";
            this.cmi_prod_list_delete_dublicates.Size = new System.Drawing.Size(171, 22);
            this.cmi_prod_list_delete_dublicates.Text = "გამეორებების წაშლა";
            this.cmi_prod_list_delete_dublicates.Click += new System.EventHandler(this.cmi_prod_list_delete_dublicates_Click);
            // 
            // sold_tabpage
            // 
            this.sold_tabpage.Controls.Add(this.sold_list);
            this.sold_tabpage.Location = new System.Drawing.Point(4, 52);
            this.sold_tabpage.Name = "sold_tabpage";
            this.sold_tabpage.Size = new System.Drawing.Size(1207, 464);
            this.sold_tabpage.TabIndex = 8;
            this.sold_tabpage.Text = "გაყიდვები";
            this.sold_tabpage.UseVisualStyleBackColor = true;
            // 
            // sold_list
            // 
            this.sold_list.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.sold_id_col,
            this.sold_tarigi_col,
            this.sold_buyer_col,
            this.sold_storeid_col,
            this.sold_zed_ident_col,
            this.sold_using_check_col,
            this.sold_cost_col,
            this.sold_cost_withoutVAT_col,
            this.sold_price_col,
            this.sold_income_col,
            this.sold_roi_col,
            this.sold_price_diff_withoutVAT_col});
            this.sold_list.ContextMenuStrip = this.cm_sold;
            this.sold_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sold_list.Font = new System.Drawing.Font("Sylfaen", 10F);
            this.sold_list.FullRowSelect = true;
            this.sold_list.GridLines = true;
            this.sold_list.Location = new System.Drawing.Point(0, 0);
            this.sold_list.Name = "sold_list";
            this.sold_list.Size = new System.Drawing.Size(1207, 464);
            this.sold_list.TabIndex = 3;
            this.sold_list.UseCompatibleStateImageBehavior = false;
            this.sold_list.View = System.Windows.Forms.View.Details;
            // 
            // sold_id_col
            // 
            this.sold_id_col.Text = "id";
            this.sold_id_col.Width = 23;
            // 
            // sold_tarigi_col
            // 
            this.sold_tarigi_col.Text = "თარიღი";
            this.sold_tarigi_col.Width = 127;
            // 
            // sold_buyer_col
            // 
            this.sold_buyer_col.Text = "მყიდველი";
            this.sold_buyer_col.Width = 132;
            // 
            // sold_storeid_col
            // 
            this.sold_storeid_col.Text = "საწყობის N.";
            this.sold_storeid_col.Width = 85;
            // 
            // sold_zed_ident_col
            // 
            this.sold_zed_ident_col.Text = "ზედნადების ნომერი";
            this.sold_zed_ident_col.Width = 142;
            // 
            // sold_using_check_col
            // 
            this.sold_using_check_col.Text = "ჩეკით";
            this.sold_using_check_col.Width = 49;
            // 
            // sold_cost_col
            // 
            this.sold_cost_col.Text = "ღირ.";
            this.sold_cost_col.Width = 52;
            // 
            // sold_cost_withoutVAT_col
            // 
            this.sold_cost_withoutVAT_col.Text = "ღირ. დღგ–ს გარეშე";
            this.sold_cost_withoutVAT_col.Width = 131;
            // 
            // sold_price_col
            // 
            this.sold_price_col.Text = "გასაყიდი ფასი";
            this.sold_price_col.Width = 102;
            // 
            // sold_income_col
            // 
            this.sold_income_col.Text = "აღებული თანხა";
            this.sold_income_col.Width = 110;
            // 
            // sold_roi_col
            // 
            this.sold_roi_col.Text = "მოგება";
            this.sold_roi_col.Width = 55;
            // 
            // sold_price_diff_withoutVAT_col
            // 
            this.sold_price_diff_withoutVAT_col.Text = "ფასთა სხვაობა დღგ–ს გარეშე";
            this.sold_price_diff_withoutVAT_col.Width = 195;
            // 
            // cm_sold
            // 
            this.cm_sold.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmi_sold_details,
            this.cmi_sold_edit});
            this.cm_sold.Name = "cm_sold";
            this.cm_sold.Size = new System.Drawing.Size(148, 48);
            // 
            // cmi_sold_details
            // 
            this.cmi_sold_details.Name = "cmi_sold_details";
            this.cmi_sold_details.Size = new System.Drawing.Size(147, 22);
            this.cmi_sold_details.Text = "დეტალური სია";
            this.cmi_sold_details.Click += new System.EventHandler(this.cmi_sold_details_Click);
            // 
            // cmi_sold_edit
            // 
            this.cmi_sold_edit.Name = "cmi_sold_edit";
            this.cmi_sold_edit.Size = new System.Drawing.Size(147, 22);
            this.cmi_sold_edit.Text = "ჩასწორება";
            this.cmi_sold_edit.Click += new System.EventHandler(this.cmi_sold_edit_Click);
            // 
            // agcera_tabpage
            // 
            this.agcera_tabpage.Controls.Add(this.agcera_rem_list);
            this.agcera_tabpage.Location = new System.Drawing.Point(4, 52);
            this.agcera_tabpage.Name = "agcera_tabpage";
            this.agcera_tabpage.Size = new System.Drawing.Size(1207, 464);
            this.agcera_tabpage.TabIndex = 7;
            this.agcera_tabpage.Text = "აღწერა";
            this.agcera_tabpage.UseVisualStyleBackColor = true;
            // 
            // agcera_rem_list
            // 
            this.agcera_rem_list.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.agcera_barcode_col,
            this.agcera_name_col,
            this.agcera_storeid_col,
            this.agcera_supplier_name_col,
            this.agcera_zed_ident_code,
            this.agcera_zed_date_col,
            this.agcera_af_seria_col,
            this.agcera_af_nomeri_col,
            this.agcera_af_date_col,
            this.agcera_remaining_count_col,
            this.piece_price_without_vat_col,
            this.piece_price_with_vat_col});
            this.agcera_rem_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.agcera_rem_list.Font = new System.Drawing.Font("Sylfaen", 10F);
            this.agcera_rem_list.FullRowSelect = true;
            this.agcera_rem_list.GridLines = true;
            this.agcera_rem_list.Location = new System.Drawing.Point(0, 0);
            this.agcera_rem_list.MultiSelect = false;
            this.agcera_rem_list.Name = "agcera_rem_list";
            this.agcera_rem_list.Size = new System.Drawing.Size(1207, 464);
            this.agcera_rem_list.TabIndex = 1;
            this.agcera_rem_list.UseCompatibleStateImageBehavior = false;
            this.agcera_rem_list.View = System.Windows.Forms.View.Details;
            this.agcera_rem_list.SelectedIndexChanged += new System.EventHandler(this.agcera_rem_list_SelectedIndexChanged);
            // 
            // agcera_barcode_col
            // 
            this.agcera_barcode_col.Text = "შტრიხ–კოდი";
            this.agcera_barcode_col.Width = 99;
            // 
            // agcera_name_col
            // 
            this.agcera_name_col.Text = "დასახელება";
            this.agcera_name_col.Width = 99;
            // 
            // agcera_storeid_col
            // 
            this.agcera_storeid_col.Text = "საწყობი";
            // 
            // agcera_supplier_name_col
            // 
            this.agcera_supplier_name_col.Text = "შემომტანი";
            this.agcera_supplier_name_col.Width = 82;
            // 
            // agcera_zed_ident_code
            // 
            this.agcera_zed_ident_code.Text = "ზედ. ნომერი";
            this.agcera_zed_ident_code.Width = 97;
            // 
            // agcera_zed_date_col
            // 
            this.agcera_zed_date_col.Text = "ზედ. თარიღი";
            this.agcera_zed_date_col.Width = 98;
            // 
            // agcera_af_seria_col
            // 
            this.agcera_af_seria_col.Text = "ა/ფ სერია";
            this.agcera_af_seria_col.Width = 73;
            // 
            // agcera_af_nomeri_col
            // 
            this.agcera_af_nomeri_col.Text = "ა/ფ ნომერი";
            this.agcera_af_nomeri_col.Width = 84;
            // 
            // agcera_af_date_col
            // 
            this.agcera_af_date_col.Text = "ა/ფ თარიღი";
            this.agcera_af_date_col.Width = 92;
            // 
            // agcera_remaining_count_col
            // 
            this.agcera_remaining_count_col.Text = "დარჩა";
            this.agcera_remaining_count_col.Width = 65;
            // 
            // piece_price_without_vat_col
            // 
            this.piece_price_without_vat_col.Text = "საც. ფასი დღგ–ს გარეშე";
            this.piece_price_without_vat_col.Width = 165;
            // 
            // piece_price_with_vat_col
            // 
            this.piece_price_with_vat_col.Text = "საც. ფასი დღგ–თი";
            this.piece_price_with_vat_col.Width = 130;
            // 
            // bought_afs_tabpage
            // 
            this.bought_afs_tabpage.Controls.Add(this.bought_af_list);
            this.bought_afs_tabpage.Location = new System.Drawing.Point(4, 52);
            this.bought_afs_tabpage.Name = "bought_afs_tabpage";
            this.bought_afs_tabpage.Size = new System.Drawing.Size(1207, 464);
            this.bought_afs_tabpage.TabIndex = 2;
            this.bought_afs_tabpage.Text = "შემოსული ფაქტურები";
            this.bought_afs_tabpage.UseVisualStyleBackColor = true;
            // 
            // bought_af_list
            // 
            this.bought_af_list.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.af_supplier_barcode_col,
            this.af_supplier_col,
            this.af_seria_col,
            this.af_ident_col,
            this.af_date_col,
            this.af_operation_col,
            this.af_zed_count_col,
            this.af_whole_cost_col,
            this.af_whole_cost_withoutVAT_col,
            this.af_VAT_col});
            this.bought_af_list.ContextMenuStrip = this.cm_bought_afs;
            this.bought_af_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bought_af_list.Font = new System.Drawing.Font("Sylfaen", 10F);
            this.bought_af_list.FullRowSelect = true;
            this.bought_af_list.GridLines = true;
            this.bought_af_list.Location = new System.Drawing.Point(0, 0);
            this.bought_af_list.MultiSelect = false;
            this.bought_af_list.Name = "bought_af_list";
            this.bought_af_list.Size = new System.Drawing.Size(1207, 464);
            this.bought_af_list.TabIndex = 2;
            this.bought_af_list.UseCompatibleStateImageBehavior = false;
            this.bought_af_list.View = System.Windows.Forms.View.Details;
            // 
            // af_supplier_barcode_col
            // 
            this.af_supplier_barcode_col.Text = "მომწ. საიდენტ.";
            this.af_supplier_barcode_col.Width = 115;
            // 
            // af_supplier_col
            // 
            this.af_supplier_col.Text = "მომწოდებელი";
            this.af_supplier_col.Width = 109;
            // 
            // af_seria_col
            // 
            this.af_seria_col.Text = "სერია";
            this.af_seria_col.Width = 78;
            // 
            // af_ident_col
            // 
            this.af_ident_col.Text = "საიდენტ. ნომერი";
            this.af_ident_col.Width = 179;
            // 
            // af_date_col
            // 
            this.af_date_col.Text = "თარიღი";
            this.af_date_col.Width = 123;
            // 
            // af_operation_col
            // 
            this.af_operation_col.Text = "ოპერაცია";
            this.af_operation_col.Width = 85;
            // 
            // af_zed_count_col
            // 
            this.af_zed_count_col.Text = "ზედნადებები";
            this.af_zed_count_col.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.af_zed_count_col.Width = 214;
            // 
            // af_whole_cost_col
            // 
            this.af_whole_cost_col.Text = "საერთო ღირებულება";
            // 
            // af_whole_cost_withoutVAT_col
            // 
            this.af_whole_cost_withoutVAT_col.Text = "საერთო ღირ. დღგ–ს გარეშე";
            // 
            // af_VAT_col
            // 
            this.af_VAT_col.Text = "დღგ–ს თანხა";
            // 
            // cm_bought_afs
            // 
            this.cm_bought_afs.Name = "cm_afs";
            this.cm_bought_afs.Size = new System.Drawing.Size(61, 4);
            // 
            // sold_afs_tabpage
            // 
            this.sold_afs_tabpage.Controls.Add(this.sold_af_list);
            this.sold_afs_tabpage.Location = new System.Drawing.Point(4, 52);
            this.sold_afs_tabpage.Name = "sold_afs_tabpage";
            this.sold_afs_tabpage.Size = new System.Drawing.Size(1207, 464);
            this.sold_afs_tabpage.TabIndex = 10;
            this.sold_afs_tabpage.Text = "გასული ფაქტურები";
            this.sold_afs_tabpage.UseVisualStyleBackColor = true;
            // 
            // sold_af_list
            // 
            this.sold_af_list.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.sold_af_buyer_col,
            this.sold_af_seria_col,
            this.sold_af_ident_col,
            this.sold_af_date_col,
            this.sold_af_operation_col,
            this.sold_af_zeds_col,
            this.sold_af_cost_col,
            this.sold_af_cost_withoutVAT_col});
            this.sold_af_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sold_af_list.Font = new System.Drawing.Font("Sylfaen", 10F);
            this.sold_af_list.FullRowSelect = true;
            this.sold_af_list.GridLines = true;
            this.sold_af_list.Location = new System.Drawing.Point(0, 0);
            this.sold_af_list.MultiSelect = false;
            this.sold_af_list.Name = "sold_af_list";
            this.sold_af_list.Size = new System.Drawing.Size(1207, 464);
            this.sold_af_list.TabIndex = 3;
            this.sold_af_list.UseCompatibleStateImageBehavior = false;
            this.sold_af_list.View = System.Windows.Forms.View.Details;
            // 
            // sold_af_buyer_col
            // 
            this.sold_af_buyer_col.Text = "მყიდველი";
            this.sold_af_buyer_col.Width = 109;
            // 
            // sold_af_seria_col
            // 
            this.sold_af_seria_col.Text = "სერია";
            this.sold_af_seria_col.Width = 123;
            // 
            // sold_af_ident_col
            // 
            this.sold_af_ident_col.Text = "საიდენტ. ნომერი";
            this.sold_af_ident_col.Width = 179;
            // 
            // sold_af_date_col
            // 
            this.sold_af_date_col.Text = "თარიღი";
            this.sold_af_date_col.Width = 123;
            // 
            // sold_af_operation_col
            // 
            this.sold_af_operation_col.Text = "ოპერაცია";
            this.sold_af_operation_col.Width = 85;
            // 
            // sold_af_zeds_col
            // 
            this.sold_af_zeds_col.Text = "ზედნადებები";
            this.sold_af_zeds_col.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.sold_af_zeds_col.Width = 214;
            // 
            // sold_af_cost_col
            // 
            this.sold_af_cost_col.Text = "საერთო ღირებულება";
            // 
            // sold_af_cost_withoutVAT_col
            // 
            this.sold_af_cost_withoutVAT_col.Text = "საერთო ღირ. დღგ–ს გარეშე";
            // 
            // sold_prods_tabpage
            // 
            this.sold_prods_tabpage.Controls.Add(this.sold_prodrem_list);
            this.sold_prods_tabpage.Location = new System.Drawing.Point(4, 52);
            this.sold_prods_tabpage.Name = "sold_prods_tabpage";
            this.sold_prods_tabpage.Size = new System.Drawing.Size(1207, 464);
            this.sold_prods_tabpage.TabIndex = 11;
            this.sold_prods_tabpage.Text = "გაყიდული დასახელებები";
            this.sold_prods_tabpage.UseVisualStyleBackColor = true;
            // 
            // sold_prodrem_list
            // 
            this.sold_prodrem_list.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.sold_prods_barcode_col,
            this.sold_prods_name_col,
            this.sold_prods_count_col,
            this.sold_prods_piece_price_col,
            this.sold_prods_cost_col,
            this.sold_prods_cost_withoutVAT_col});
            this.sold_prodrem_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sold_prodrem_list.Font = new System.Drawing.Font("Sylfaen", 10F);
            this.sold_prodrem_list.FullRowSelect = true;
            this.sold_prodrem_list.GridLines = true;
            this.sold_prodrem_list.Location = new System.Drawing.Point(0, 0);
            this.sold_prodrem_list.MultiSelect = false;
            this.sold_prodrem_list.Name = "sold_prodrem_list";
            this.sold_prodrem_list.Size = new System.Drawing.Size(1207, 464);
            this.sold_prodrem_list.TabIndex = 2;
            this.sold_prodrem_list.UseCompatibleStateImageBehavior = false;
            this.sold_prodrem_list.View = System.Windows.Forms.View.Details;
            // 
            // sold_prods_barcode_col
            // 
            this.sold_prods_barcode_col.Text = "შტრიხ–კოდი";
            this.sold_prods_barcode_col.Width = 107;
            // 
            // sold_prods_name_col
            // 
            this.sold_prods_name_col.Text = "დასახელება";
            this.sold_prods_name_col.Width = 180;
            // 
            // sold_prods_count_col
            // 
            this.sold_prods_count_col.Text = "რაოდენობა (ცალობით)";
            this.sold_prods_count_col.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.sold_prods_count_col.Width = 214;
            // 
            // sold_prods_piece_price_col
            // 
            this.sold_prods_piece_price_col.Text = "საშუალო ფასი";
            this.sold_prods_piece_price_col.Width = 175;
            // 
            // sold_prods_cost_col
            // 
            this.sold_prods_cost_col.Text = "საშუალო ღირებულება";
            this.sold_prods_cost_col.Width = 181;
            // 
            // sold_prods_cost_withoutVAT_col
            // 
            this.sold_prods_cost_withoutVAT_col.Text = "საშუალო ღირ. დღგ–ს გარეშე";
            this.sold_prods_cost_withoutVAT_col.Width = 207;
            // 
            // moneytransfers_tabpage
            // 
            this.moneytransfers_tabpage.Controls.Add(this.moneytransfer_list);
            this.moneytransfers_tabpage.Location = new System.Drawing.Point(4, 52);
            this.moneytransfers_tabpage.Name = "moneytransfers_tabpage";
            this.moneytransfers_tabpage.Size = new System.Drawing.Size(1207, 464);
            this.moneytransfers_tabpage.TabIndex = 12;
            this.moneytransfers_tabpage.Text = "ფულადი ოპერაციები";
            this.moneytransfers_tabpage.UseVisualStyleBackColor = true;
            // 
            // moneytransfer_list
            // 
            this.moneytransfer_list.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.mt_id_col,
            this.mt_client_type_col,
            this.mt_client_name_col,
            this.mt_oper_type_col,
            this.mt_date_col,
            this.mt_amount_col,
            this.mt_purpose_col,
            this.mt_storeid_col,
            this.mt_targettype_col,
            this.mt_targetident_col,
            this.mt_cashbox_id_col,
            this.mt_cashier_id_col});
            this.moneytransfer_list.ContextMenuStrip = this.cm_moneytransfer;
            this.moneytransfer_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.moneytransfer_list.Font = new System.Drawing.Font("Sylfaen", 10F);
            this.moneytransfer_list.FullRowSelect = true;
            this.moneytransfer_list.GridLines = true;
            this.moneytransfer_list.Location = new System.Drawing.Point(0, 0);
            this.moneytransfer_list.MultiSelect = false;
            this.moneytransfer_list.Name = "moneytransfer_list";
            this.moneytransfer_list.Size = new System.Drawing.Size(1207, 464);
            this.moneytransfer_list.TabIndex = 2;
            this.moneytransfer_list.UseCompatibleStateImageBehavior = false;
            this.moneytransfer_list.View = System.Windows.Forms.View.Details;
            // 
            // mt_id_col
            // 
            this.mt_id_col.Text = "id";
            this.mt_id_col.Width = 31;
            // 
            // mt_client_type_col
            // 
            this.mt_client_type_col.Text = "კლიენტის ტიპი";
            this.mt_client_type_col.Width = 114;
            // 
            // mt_client_name_col
            // 
            this.mt_client_name_col.Text = "კლიენტის სახელი";
            this.mt_client_name_col.Width = 159;
            // 
            // mt_oper_type_col
            // 
            this.mt_oper_type_col.Text = "ოპერაციის ტიპი";
            this.mt_oper_type_col.Width = 116;
            // 
            // mt_date_col
            // 
            this.mt_date_col.Text = "ოპერაციის თარიღი";
            this.mt_date_col.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mt_date_col.Width = 178;
            // 
            // mt_amount_col
            // 
            this.mt_amount_col.Text = "რაოდენობა";
            this.mt_amount_col.Width = 113;
            // 
            // mt_purpose_col
            // 
            this.mt_purpose_col.Text = "დანიშნულება";
            this.mt_purpose_col.Width = 108;
            // 
            // mt_storeid_col
            // 
            this.mt_storeid_col.Text = "სალარო (საწყობი)";
            this.mt_storeid_col.Width = 125;
            // 
            // mt_targettype_col
            // 
            this.mt_targettype_col.Text = "დოკუმენტის ტიპი";
            this.mt_targettype_col.Width = 130;
            // 
            // mt_targetident_col
            // 
            this.mt_targetident_col.Text = "საიდენტ. კოდი";
            this.mt_targetident_col.Width = 109;
            // 
            // cm_moneytransfer
            // 
            this.cm_moneytransfer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmi_mt_edit,
            this.cmi_mt_remove});
            this.cm_moneytransfer.Name = "cm_moneytransfer";
            this.cm_moneytransfer.Size = new System.Drawing.Size(171, 48);
            // 
            // cmi_mt_remove
            // 
            this.cmi_mt_remove.Name = "cmi_mt_remove";
            this.cmi_mt_remove.Size = new System.Drawing.Size(170, 22);
            this.cmi_mt_remove.Text = "ოპერაციის გაუქმება";
            this.cmi_mt_remove.Click += new System.EventHandler(this.cmi_mt_remove_Click);
            // 
            // summary_tabpage
            // 
            this.summary_tabpage.Controls.Add(this.cashbox_sum_txt);
            this.summary_tabpage.Controls.Add(this.lbl_cashbox_sum_currency);
            this.summary_tabpage.Controls.Add(this.lbl_cashbox_sum);
            this.summary_tabpage.Controls.Add(this.summary_cash_amount);
            this.summary_tabpage.Controls.Add(this.lbl_summary_currency);
            this.summary_tabpage.Controls.Add(this.lbl_summary_cash);
            this.summary_tabpage.Location = new System.Drawing.Point(4, 52);
            this.summary_tabpage.Name = "summary_tabpage";
            this.summary_tabpage.Size = new System.Drawing.Size(1207, 464);
            this.summary_tabpage.TabIndex = 13;
            this.summary_tabpage.Text = "ჯამი";
            this.summary_tabpage.UseVisualStyleBackColor = true;
            // 
            // summary_cash_amount
            // 
            this.summary_cash_amount.Enabled = false;
            this.summary_cash_amount.Location = new System.Drawing.Point(199, 149);
            this.summary_cash_amount.Name = "summary_cash_amount";
            this.summary_cash_amount.Size = new System.Drawing.Size(130, 27);
            this.summary_cash_amount.TabIndex = 1;
            // 
            // lbl_summary_currency
            // 
            this.lbl_summary_currency.AutoSize = true;
            this.lbl_summary_currency.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_summary_currency.Location = new System.Drawing.Point(331, 149);
            this.lbl_summary_currency.Name = "lbl_summary_currency";
            this.lbl_summary_currency.Size = new System.Drawing.Size(46, 18);
            this.lbl_summary_currency.TabIndex = 0;
            this.lbl_summary_currency.Text = "ლარი";
            // 
            // lbl_summary_cash
            // 
            this.lbl_summary_cash.AutoSize = true;
            this.lbl_summary_cash.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_summary_cash.Location = new System.Drawing.Point(17, 150);
            this.lbl_summary_cash.Name = "lbl_summary_cash";
            this.lbl_summary_cash.Size = new System.Drawing.Size(134, 18);
            this.lbl_summary_cash.TabIndex = 0;
            this.lbl_summary_cash.Text = "სექციის ბალანსი:";
            // 
            // bought_af_standard_list_tabpage
            // 
            this.bought_af_standard_list_tabpage.Controls.Add(this.bought_af_standard_list);
            this.bought_af_standard_list_tabpage.Location = new System.Drawing.Point(4, 52);
            this.bought_af_standard_list_tabpage.Name = "bought_af_standard_list_tabpage";
            this.bought_af_standard_list_tabpage.Size = new System.Drawing.Size(1207, 464);
            this.bought_af_standard_list_tabpage.TabIndex = 14;
            this.bought_af_standard_list_tabpage.Text = "შემოსული ფაქტურების საგადასახადოს ფორმა";
            this.bought_af_standard_list_tabpage.UseVisualStyleBackColor = true;
            // 
            // bought_af_standard_list
            // 
            this.bought_af_standard_list.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.bought_af_std_serie_col,
            this.bought_af_std_invoicenum_col,
            this.bought_af_std_date_col,
            this.bought_af_std_supp_ident_col,
            this.bought_af_std_VAT_col});
            this.bought_af_standard_list.ContextMenuStrip = this.cm_bought_afs;
            this.bought_af_standard_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bought_af_standard_list.Font = new System.Drawing.Font("Sylfaen", 10F);
            this.bought_af_standard_list.FullRowSelect = true;
            this.bought_af_standard_list.GridLines = true;
            this.bought_af_standard_list.Location = new System.Drawing.Point(0, 0);
            this.bought_af_standard_list.MultiSelect = false;
            this.bought_af_standard_list.Name = "bought_af_standard_list";
            this.bought_af_standard_list.Size = new System.Drawing.Size(1207, 464);
            this.bought_af_standard_list.TabIndex = 3;
            this.bought_af_standard_list.UseCompatibleStateImageBehavior = false;
            this.bought_af_standard_list.View = System.Windows.Forms.View.Details;
            // 
            // bought_af_std_serie_col
            // 
            this.bought_af_std_serie_col.Text = "seriesNumber";
            this.bought_af_std_serie_col.Width = 78;
            // 
            // bought_af_std_invoicenum_col
            // 
            this.bought_af_std_invoicenum_col.Text = "invoiceNumber";
            this.bought_af_std_invoicenum_col.Width = 179;
            // 
            // bought_af_std_date_col
            // 
            this.bought_af_std_date_col.Text = "invoiceIssueDate";
            this.bought_af_std_date_col.Width = 123;
            // 
            // bought_af_std_supp_ident_col
            // 
            this.bought_af_std_supp_ident_col.Text = "pairedIdentificationNumber";
            this.bought_af_std_supp_ident_col.Width = 115;
            // 
            // bought_af_std_VAT_col
            // 
            this.bought_af_std_VAT_col.Text = "invoiceAmount";
            // 
            // tb_since_datepicker
            // 
            this.tb_since_datepicker.Location = new System.Drawing.Point(402, 29);
            this.tb_since_datepicker.Name = "tb_since_datepicker";
            this.tb_since_datepicker.Size = new System.Drawing.Size(200, 20);
            this.tb_since_datepicker.TabIndex = 4;
            // 
            // tb_until_datepicker
            // 
            this.tb_until_datepicker.Location = new System.Drawing.Point(658, 29);
            this.tb_until_datepicker.Name = "tb_until_datepicker";
            this.tb_until_datepicker.Size = new System.Drawing.Size(200, 20);
            this.tb_until_datepicker.TabIndex = 5;
            // 
            // tb_since_lbl
            // 
            this.tb_since_lbl.Name = "tb_since_lbl";
            this.tb_since_lbl.Size = new System.Drawing.Size(31, 22);
            this.tb_since_lbl.Text = "–დან";
            // 
            // tb_until_lbl
            // 
            this.tb_until_lbl.Name = "tb_until_lbl";
            this.tb_until_lbl.Size = new System.Drawing.Size(30, 22);
            this.tb_until_lbl.Text = "–მდე";
            // 
            // cmi_mt_edit
            // 
            this.cmi_mt_edit.Name = "cmi_mt_edit";
            this.cmi_mt_edit.Size = new System.Drawing.Size(170, 22);
            this.cmi_mt_edit.Text = "ჩასწორება";
            this.cmi_mt_edit.Click += new System.EventHandler(this.cmi_mt_edit_Click);
            // 
            // mt_cashbox_id_col
            // 
            this.mt_cashbox_id_col.Text = "სალაროს N.";
            this.mt_cashbox_id_col.Width = 100;
            // 
            // mt_cashier_id_col
            // 
            this.mt_cashier_id_col.Text = "მოლარის N.";
            this.mt_cashier_id_col.Width = 100;
            // 
            // cashbox_sum_txt
            // 
            this.cashbox_sum_txt.Enabled = false;
            this.cashbox_sum_txt.Location = new System.Drawing.Point(199, 69);
            this.cashbox_sum_txt.Name = "cashbox_sum_txt";
            this.cashbox_sum_txt.Size = new System.Drawing.Size(130, 27);
            this.cashbox_sum_txt.TabIndex = 4;
            // 
            // lbl_cashbox_sum_currency
            // 
            this.lbl_cashbox_sum_currency.AutoSize = true;
            this.lbl_cashbox_sum_currency.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_cashbox_sum_currency.Location = new System.Drawing.Point(331, 69);
            this.lbl_cashbox_sum_currency.Name = "lbl_cashbox_sum_currency";
            this.lbl_cashbox_sum_currency.Size = new System.Drawing.Size(46, 18);
            this.lbl_cashbox_sum_currency.TabIndex = 3;
            this.lbl_cashbox_sum_currency.Text = "ლარი";
            // 
            // lbl_cashbox_sum
            // 
            this.lbl_cashbox_sum.AutoSize = true;
            this.lbl_cashbox_sum.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_cashbox_sum.Location = new System.Drawing.Point(17, 70);
            this.lbl_cashbox_sum.Name = "lbl_cashbox_sum";
            this.lbl_cashbox_sum.Size = new System.Drawing.Size(179, 18);
            this.lbl_cashbox_sum.TabIndex = 2;
            this.lbl_cashbox_sum.Text = "სალაროში დარჩენილია:";
            // 
            // ProductInfo_Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1215, 593);
            this.Controls.Add(this.tab_container);
            this.Controls.Add(this.status_bar);
            this.Controls.Add(this.toolbar);
            this.Controls.Add(this.main_menu);
            this.MainMenuStrip = this.main_menu;
            this.Name = "ProductInfo_Main_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProductInfo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.main_menu.ResumeLayout(false);
            this.main_menu.PerformLayout();
            this.toolbar.ResumeLayout(false);
            this.toolbar.PerformLayout();
            this.status_bar.ResumeLayout(false);
            this.status_bar.PerformLayout();
            this.tab_container.ResumeLayout(false);
            this.sell_tabpage.ResumeLayout(false);
            this.sell_tabpage.PerformLayout();
            this.sell_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sell_list)).EndInit();
            this.sell_status_bar.ResumeLayout(false);
            this.sell_status_bar.PerformLayout();
            this.nashtebi_tabpage.ResumeLayout(false);
            this.cm_rem_list.ResumeLayout(false);
            this.zednadebebi_tabpage.ResumeLayout(false);
            this.cm_incoming_zeds.ResumeLayout(false);
            this.sold_zednadebebi_tabpage.ResumeLayout(false);
            this.cm_sold_zednadebi.ResumeLayout(false);
            this.suppliers_tabpage.ResumeLayout(false);
            this.cm_supplier_list.ResumeLayout(false);
            this.buyers_tabpage.ResumeLayout(false);
            this.cm_buyer_list.ResumeLayout(false);
            this.productnames_tabpage.ResumeLayout(false);
            this.prod_list_cm.ResumeLayout(false);
            this.sold_tabpage.ResumeLayout(false);
            this.cm_sold.ResumeLayout(false);
            this.agcera_tabpage.ResumeLayout(false);
            this.bought_afs_tabpage.ResumeLayout(false);
            this.sold_afs_tabpage.ResumeLayout(false);
            this.sold_prods_tabpage.ResumeLayout(false);
            this.moneytransfers_tabpage.ResumeLayout(false);
            this.cm_moneytransfer.ResumeLayout(false);
            this.summary_tabpage.ResumeLayout(false);
            this.summary_tabpage.PerformLayout();
            this.bought_af_standard_list_tabpage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip main_menu;
        private System.Windows.Forms.ToolStrip toolbar;
        private System.Windows.Forms.StatusStrip status_bar;
        private System.Windows.Forms.ToolStripTextBox search_text;
        private System.Windows.Forms.TabControl tab_container;
        private System.Windows.Forms.TabPage nashtebi_tabpage;
        private System.Windows.Forms.TabPage suppliers_tabpage;
        private System.Windows.Forms.TabPage bought_afs_tabpage;
        private System.Windows.Forms.TabPage zednadebebi_tabpage;
        private System.Windows.Forms.TabPage buyers_tabpage;
        private System.Windows.Forms.TabPage productnames_tabpage;
        private System.Windows.Forms.ToolStripMenuItem mm_nashtebi;
        private System.Windows.Forms.ToolStripMenuItem mm_suppliers;
        private System.Windows.Forms.ToolStripMenuItem mm_buyers;
        private System.Windows.Forms.ToolStripMenuItem mm_productnames;
        private System.Windows.Forms.ToolStripMenuItem mm_product_add;
        private System.Windows.Forms.ToolStripStatusLabel status_bar_text;
        private System.Windows.Forms.ToolStripMenuItem mm_productlist_add;
        private System.Windows.Forms.ToolStripMenuItem mm_add_supplier;
        private System.Windows.Forms.ToolStripMenuItem mm_add_remainders;
        private System.Windows.Forms.ListView suppliers_list;
        private System.Windows.Forms.ColumnHeader suppliers_list_name_header;
        private System.Windows.Forms.ColumnHeader suppliers_list_ident_code_header;
        private System.Windows.Forms.ColumnHeader suppliers_list_address_header;
        private System.Windows.Forms.ListView rem_list;
        private System.Windows.Forms.ColumnHeader rem_list_barcode_header;
        private System.Windows.Forms.ColumnHeader rem_list_supplier_header;
        private System.Windows.Forms.ColumnHeader rem_list_packs_header;
        private System.Windows.Forms.ColumnHeader rem_list_prodname_header;
        private System.Windows.Forms.ColumnHeader rem_list_capacity_header;
        private System.Windows.Forms.ToolStripMenuItem mm_sell_remainders;
        private System.Windows.Forms.TabPage sell_tabpage;
        private System.Windows.Forms.DataGridView sell_list;
        private System.Windows.Forms.ToolStripMenuItem mm_add_buyer;
        private System.Windows.Forms.CheckBox using_check_ckb;
        private System.Windows.Forms.ColumnHeader rem_list_remaining_whole_price_col;
        private System.Windows.Forms.TabPage agcera_tabpage;
        private System.Windows.Forms.ListView agcera_rem_list;
        private System.Windows.Forms.ColumnHeader agcera_barcode_col;
        private System.Windows.Forms.ColumnHeader agcera_name_col;
        private System.Windows.Forms.ColumnHeader agcera_zed_ident_code;
        private System.Windows.Forms.ToolStripLabel lbl_tb_store;
        private System.Windows.Forms.ToolStripComboBox tb_store_chooser;
        private System.Windows.Forms.ListView prod_names_list;
        private System.Windows.Forms.ColumnHeader pnames_bcode_col;
        private System.Windows.Forms.ColumnHeader pnames_name_col;
        private System.Windows.Forms.ColumnHeader pnames_remaining_col;
        private System.Windows.Forms.ColumnHeader pnames_remaining_amount_col;
        private System.Windows.Forms.ListView buyers_list;
        private System.Windows.Forms.ColumnHeader buyer_name_col;
        private System.Windows.Forms.ColumnHeader buyer_ident_col;
        private System.Windows.Forms.ColumnHeader buyer_address_col;
        private System.Windows.Forms.ListView zed_list;
        private System.Windows.Forms.ColumnHeader zed_supplier_col;
        private System.Windows.Forms.ColumnHeader zed_date_col;
        private System.Windows.Forms.ColumnHeader zed_ident_col;
        private System.Windows.Forms.ColumnHeader zed_list_af_seria_col;
        private System.Windows.Forms.ColumnHeader zed_list_af_saident_col;
        private System.Windows.Forms.ListView bought_af_list;
        private System.Windows.Forms.ColumnHeader af_supplier_col;
        private System.Windows.Forms.ColumnHeader af_seria_col;
        private System.Windows.Forms.ColumnHeader af_ident_col;
        private System.Windows.Forms.ColumnHeader af_date_col;
        private System.Windows.Forms.ColumnHeader af_zed_count_col;
        private System.Windows.Forms.ColumnHeader supplier_misacemi_col;
        private System.Windows.Forms.ColumnHeader supplier_mosacemi_col;
        private System.Windows.Forms.ColumnHeader buyer_mosacemi_col;
        private System.Windows.Forms.ColumnHeader buyer_misacemi_col;
        private System.Windows.Forms.ToolStripButton tb_print_btn;
        private System.Windows.Forms.ColumnHeader af_operation_col;
        private System.Windows.Forms.ColumnHeader pnames_piece_price_col;
        private System.Windows.Forms.ColumnHeader rem_list_piece_price_col;
        private System.Windows.Forms.ColumnHeader agcera_supplier_name_col;
        private System.Windows.Forms.ColumnHeader agcera_zed_date_col;
        private System.Windows.Forms.ColumnHeader agcera_af_seria_col;
        private System.Windows.Forms.ColumnHeader agcera_af_nomeri_col;
        private System.Windows.Forms.ColumnHeader agcera_af_date_col;
        private System.Windows.Forms.ColumnHeader agcera_remaining_count_col;
        private System.Windows.Forms.ColumnHeader piece_price_without_vat_col;
        private System.Windows.Forms.ColumnHeader piece_price_with_vat_col;
        private System.Windows.Forms.ContextMenuStrip prod_list_cm;
        private System.Windows.Forms.ToolStripMenuItem prod_list_edit_cmi;
        private System.Windows.Forms.ColumnHeader rem_list_store_col;
        private System.Windows.Forms.TabPage sold_tabpage;
        private System.Windows.Forms.StatusStrip sell_status_bar;
        private System.Windows.Forms.ToolStripStatusLabel sell_status_lbl;
        private System.Windows.Forms.ToolStripStatusLabel sell_status_sum_price_lbl;
        private System.Windows.Forms.ListView sold_list;
        private System.Windows.Forms.ColumnHeader sold_income_col;
        private System.Windows.Forms.ColumnHeader sold_roi_col;
        private System.Windows.Forms.ColumnHeader sold_tarigi_col;
        private System.Windows.Forms.DateTimePicker tb_since_datepicker;
        private System.Windows.Forms.DateTimePicker tb_until_datepicker;
        private System.Windows.Forms.ToolStripLabel tb_since_lbl;
        private System.Windows.Forms.ToolStripLabel tb_until_lbl;
        private ColumnHeader sold_cost_col;
        private ContextMenuStrip cm_rem_list;
        private ToolStripMenuItem cmi_rem_list_supplier_info;
        private ContextMenuStrip cm_supplier_list;
        private ToolStripMenuItem cmi_this_supplier_remainders;
        private ToolStripMenuItem cmi_supplier_money_transfer;
        private ColumnHeader sold_zed_ident_col;
        private ColumnHeader sold_using_check_col;
        private ToolStripMenuItem cm_supplier_edit;
        private ContextMenuStrip cm_sold;
        private ToolStripMenuItem cmi_sold_details;
        private ColumnHeader sold_cost_withoutVAT_col;
        private ColumnHeader zed_list_costwithVAT_col;
        private ColumnHeader zed_list_costwithoutVAT_col;
        private ColumnHeader rem_list_cost_withoutVAT_col;
        private ColumnHeader pnames_costwithoutVAT_col;
        private ColumnHeader af_whole_cost_col;
        private ColumnHeader af_whole_cost_withoutVAT_col;
        private ContextMenuStrip cm_sold_zednadebi;
        private ToolStripMenuItem cmi_zed_print;
        private TabPage sold_zednadebebi_tabpage;
        private ListView sold_zed_list;
        private ColumnHeader sold_z_ident_code_col;
        private ColumnHeader sold_z_date_col;
        private ColumnHeader sold_z_buyer_col;
        private ColumnHeader sold_z_af_seria_col;
        private ColumnHeader sold_z_af_nomeri_col;
        private ColumnHeader sold_z_cost_col;
        private ColumnHeader sold_z_cost_withoutVAT_col;
        private ColumnHeader sold_z_income_amount_col;
        private ColumnHeader sold_z_price;
        private ColumnHeader sold_z_roi_col;
        private ColumnHeader sold_z_roi_withoutVAT_col;
        private ToolStripProgressBar status_progress_bar;
        private ContextMenuStrip cm_incoming_zeds;
        private ToolStripMenuItem cmi_incoming_zeds_details;
        private ToolStripMenuItem cmi_sold_zed_details;
        private ToolStripMenuItem cmi_prod_list_delete_dublicates;
        private ToolStripMenuItem cmi_this_supplier_zeds;
        private ToolStripStatusLabel sb_sum_lbl;
        private ToolStripStatusLabel sb_sum_withoutVAT_lbl;
        private ContextMenuStrip cm_bought_afs;
        private TabPage sold_afs_tabpage;
        private ListView sold_af_list;
        private ColumnHeader sold_af_buyer_col;
        private ColumnHeader sold_af_seria_col;
        private ColumnHeader sold_af_ident_col;
        private ColumnHeader sold_af_date_col;
        private ColumnHeader sold_af_operation_col;
        private ColumnHeader sold_af_zeds_col;
        private ColumnHeader sold_af_cost_col;
        private ColumnHeader sold_af_cost_withoutVAT_col;
        private ContextMenuStrip cm_buyer_list;
        private ToolStripMenuItem cmi_buyer_money_transfer;
        private ToolStripMenuItem cmi_incoming_zeds_edit;
        private ToolStripMenuItem cmi_sold_edit;
        private ColumnHeader sold_storeid_col;
        private TabPage sold_prods_tabpage;
        private ListView sold_prodrem_list;
        private ColumnHeader sold_prods_barcode_col;
        private ColumnHeader sold_prods_name_col;
        private ColumnHeader sold_prods_count_col;
        private ColumnHeader sold_prods_piece_price_col;
        private ColumnHeader sold_prods_cost_col;
        private ColumnHeader sold_prods_cost_withoutVAT_col;
        private ToolStripMenuItem cmi_split_rems;
        private Label lbl_xelze_myidveli;
        private ComboBox cmb_xelze_myidveli;
        private TabPage moneytransfers_tabpage;
        private ListView moneytransfer_list;
        private ColumnHeader mt_client_type_col;
        private ColumnHeader mt_client_name_col;
        private ColumnHeader mt_oper_type_col;
        private ColumnHeader mt_date_col;
        private ColumnHeader mt_amount_col;
        private ToolStripMenuItem cmi_supp_oper_hist;
        private ToolStripMenuItem cmi_buyer_oper_hist;
        private ComboBox ckb_pay_method;
        private ColumnHeader agcera_storeid_col;
        private ToolStripMenuItem cmi_incoming_zeds_remove;
        private TabPage summary_tabpage;
        private Label lbl_summary_cash;
        private TextBox summary_cash_amount;
        private Label lbl_summary_currency;
        private ToolStripStatusLabel sb_refresh_btn;
        private ColumnHeader mt_purpose_col;
        private ColumnHeader mt_storeid_col;
        private ColumnHeader mt_targettype_col;
        private ColumnHeader mt_targetident_col;
        private ToolStripMenuItem cmi_incoming_zeds_payfor;
        private ToolStripMenuItem cmi_sold_zed_payfor;
        private ColumnHeader mt_id_col;
        private ContextMenuStrip cm_moneytransfer;
        private ToolStripMenuItem cmi_mt_remove;
        private ToolStripMenuItem cmi_sold_zed_remove;
        private ToolStripMenuItem cmi_buyer_edit;
        private ColumnHeader sold_z_VAT_tax_amount;
        private ColumnHeader sold_z_zed_price_withoutVAT;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton btn_export_csv;
        private ToolStripSeparator tb_sep_after_csv_export_btn;
        private ColumnHeader af_supplier_barcode_col;
        private ColumnHeader af_VAT_col;
        private ColumnHeader sold_price_col;
        private ColumnHeader sold_price_diff_withoutVAT_col;
        private TabPage bought_af_standard_list_tabpage;
        private ListView bought_af_standard_list;
        private ColumnHeader bought_af_std_supp_ident_col;
        private ColumnHeader bought_af_std_serie_col;
        private ColumnHeader bought_af_std_invoicenum_col;
        private ColumnHeader bought_af_std_date_col;
        private ColumnHeader bought_af_std_VAT_col;
        private Button sell_submit_btn;
        private ColumnHeader sold_id_col;
        private DataGridViewTextBoxColumn sell_barcode_col;
        private DataGridViewComboBoxColumn sell_name_col;
        private DataGridViewTextBoxColumn sell_capacity_col;
        private DataGridViewTextBoxColumn sell_pack_amount_col;
        private DataGridViewTextBoxColumn sell_pack_price_col;
        private DataGridViewTextBoxColumn sell_piece_amount_col;
        private DataGridViewTextBoxColumn sell_piece_price_col;
        private DataGridViewTextBoxColumn sell_piece_amount_info;
        private DataGridViewTextBoxColumn sell_initial_price_info_col;
        private DataGridViewTextBoxColumn sell_remaining_col;
        private DataGridViewTextBoxColumn sell_sum_price_col;
        private DataGridViewButtonColumn sell_delete_col;
        private ColumnHeader sold_buyer_col;
        private Panel sell_panel;
        private ToolStripButton btn_export_list;
        private ToolStripSeparator toolStripSeparator2;
        private ColumnHeader rem_list_initial_whole_price_col;
        private ColumnHeader pnames_initial_count_col;
        private ColumnHeader pnames_initial_sum_cost_col;
        private ColumnHeader pnames_capacity_col;
        private ColumnHeader rem_list_piece_sell_price_col;
        private ToolStripMenuItem cmi_mt_edit;
        private ColumnHeader mt_cashbox_id_col;
        private ColumnHeader mt_cashier_id_col;
        private TextBox cashbox_sum_txt;
        private Label lbl_cashbox_sum_currency;
        private Label lbl_cashbox_sum;




    }
}

