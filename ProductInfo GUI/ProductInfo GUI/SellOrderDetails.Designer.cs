namespace ProductInfo_UI
{
    partial class SellOrderDetails_Form
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
            this.attributes_lbl = new System.Windows.Forms.Label();
            this.close_btn = new System.Windows.Forms.Button();
            this.sold_rem_list = new System.Windows.Forms.ListView();
            this.SOd_id_col = new System.Windows.Forms.ColumnHeader();
            this.SOd_barcode_col = new System.Windows.Forms.ColumnHeader();
            this.SOd_prodname_col = new System.Windows.Forms.ColumnHeader();
            this.SOd_count_col = new System.Windows.Forms.ColumnHeader();
            this.SOd_piece_cost_col = new System.Windows.Forms.ColumnHeader();
            this.SOd_cost_col = new System.Windows.Forms.ColumnHeader();
            this.SOd_piece_price_col = new System.Windows.Forms.ColumnHeader();
            this.SOd_whole_price_col = new System.Windows.Forms.ColumnHeader();
            this.SOd_mogeba_col = new System.Windows.Forms.ColumnHeader();
            this.SOd_cost_without_col = new System.Windows.Forms.ColumnHeader();
            this.SOd_storeID_col = new System.Windows.Forms.ColumnHeader();
            this.cm_SellOrder_edit = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmi_SellOrder_item_edit = new System.Windows.Forms.ToolStripMenuItem();
            this.cmi_SellOrder_item_delete = new System.Windows.Forms.ToolStripMenuItem();
            this.SOd_print_btn = new System.Windows.Forms.Button();
            this.txt_af_seria = new System.Windows.Forms.TextBox();
            this.datetime_zed_tarigi = new System.Windows.Forms.DateTimePicker();
            this.lbl_edit_af_seria = new System.Windows.Forms.Label();
            this.txt_af_nomeri = new System.Windows.Forms.TextBox();
            this.lbl_edit_af_nomeri = new System.Windows.Forms.Label();
            this.btn_zed_update = new System.Windows.Forms.Button();
            this.lbl_editzed_af_date = new System.Windows.Forms.Label();
            this.datepicker_af_date = new System.Windows.Forms.DateTimePicker();
            this.SOd_print_gasavali_btn = new System.Windows.Forms.Button();
            this.lblZedIdent = new System.Windows.Forms.Label();
            this.txtZedIdent = new System.Windows.Forms.TextBox();
            this.btnEnableEditingZedIdent = new System.Windows.Forms.Button();
            this.btn_exportCSV_SOd = new System.Windows.Forms.Button();
            this.btn_add_soldrems = new System.Windows.Forms.Button();
            this.cm_SellOrder_edit.SuspendLayout();
            this.SuspendLayout();
            // 
            // attributes_lbl
            // 
            this.attributes_lbl.AutoSize = true;
            this.attributes_lbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.attributes_lbl.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.attributes_lbl.Location = new System.Drawing.Point(0, 0);
            this.attributes_lbl.Name = "attributes_lbl";
            this.attributes_lbl.Size = new System.Drawing.Size(274, 96);
            this.attributes_lbl.TabIndex = 0;
            this.attributes_lbl.Text = "გაყიდვის დრო: 08/08/08 45:45:45 PM\r\nზედნადების ნომერი: 0145\r\nჩეკით\r\n\r\n\r\n\r\n";
            // 
            // close_btn
            // 
            this.close_btn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.close_btn.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.close_btn.Location = new System.Drawing.Point(0, 578);
            this.close_btn.Name = "close_btn";
            this.close_btn.Size = new System.Drawing.Size(742, 32);
            this.close_btn.TabIndex = 1;
            this.close_btn.Text = "დახურვა";
            this.close_btn.UseVisualStyleBackColor = true;
            this.close_btn.Click += new System.EventHandler(this.close_btn_Click);
            // 
            // sold_rem_list
            // 
            this.sold_rem_list.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SOd_id_col,
            this.SOd_barcode_col,
            this.SOd_prodname_col,
            this.SOd_count_col,
            this.SOd_piece_cost_col,
            this.SOd_cost_col,
            this.SOd_piece_price_col,
            this.SOd_whole_price_col,
            this.SOd_mogeba_col,
            this.SOd_cost_without_col,
            this.SOd_storeID_col});
            this.sold_rem_list.ContextMenuStrip = this.cm_SellOrder_edit;
            this.sold_rem_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sold_rem_list.FullRowSelect = true;
            this.sold_rem_list.GridLines = true;
            this.sold_rem_list.Location = new System.Drawing.Point(0, 96);
            this.sold_rem_list.MultiSelect = false;
            this.sold_rem_list.Name = "sold_rem_list";
            this.sold_rem_list.Size = new System.Drawing.Size(742, 482);
            this.sold_rem_list.TabIndex = 2;
            this.sold_rem_list.UseCompatibleStateImageBehavior = false;
            this.sold_rem_list.View = System.Windows.Forms.View.Details;
            // 
            // SOd_id_col
            // 
            this.SOd_id_col.Text = "id";
            this.SOd_id_col.Width = 32;
            // 
            // SOd_barcode_col
            // 
            this.SOd_barcode_col.Text = "შტრიხ–კოდი";
            this.SOd_barcode_col.Width = 98;
            // 
            // SOd_prodname_col
            // 
            this.SOd_prodname_col.Text = "დასახელება";
            this.SOd_prodname_col.Width = 76;
            // 
            // SOd_count_col
            // 
            this.SOd_count_col.Text = "რ–ბა";
            this.SOd_count_col.Width = 42;
            // 
            // SOd_piece_cost_col
            // 
            this.SOd_piece_cost_col.Text = "საც. თვითღირ.";
            this.SOd_piece_cost_col.Width = 80;
            // 
            // SOd_cost_col
            // 
            this.SOd_cost_col.Text = "თვითღირ.";
            // 
            // SOd_piece_price_col
            // 
            this.SOd_piece_price_col.Text = "საც. ფასი";
            this.SOd_piece_price_col.Width = 62;
            // 
            // SOd_whole_price_col
            // 
            this.SOd_whole_price_col.Text = "საერთო ფასი";
            this.SOd_whole_price_col.Width = 75;
            // 
            // SOd_mogeba_col
            // 
            this.SOd_mogeba_col.Text = "მოგება";
            this.SOd_mogeba_col.Width = 45;
            // 
            // SOd_cost_without_col
            // 
            this.SOd_cost_without_col.Text = "ღირ. (დღგ–ს გარეშე)";
            this.SOd_cost_without_col.Width = 114;
            // 
            // SOd_storeID_col
            // 
            this.SOd_storeID_col.Text = "საწყობის N.";
            this.SOd_storeID_col.Width = 77;
            // 
            // cm_SellOrder_edit
            // 
            this.cm_SellOrder_edit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmi_SellOrder_item_edit,
            this.cmi_SellOrder_item_delete});
            this.cm_SellOrder_edit.Name = "cm_SellOrder_edit";
            this.cm_SellOrder_edit.Size = new System.Drawing.Size(111, 48);
            // 
            // cmi_SellOrder_item_edit
            // 
            this.cmi_SellOrder_item_edit.Name = "cmi_SellOrder_item_edit";
            this.cmi_SellOrder_item_edit.Size = new System.Drawing.Size(110, 22);
            this.cmi_SellOrder_item_edit.Text = "შეცვლა";
            this.cmi_SellOrder_item_edit.Click += new System.EventHandler(this.cmi_SellOrder_item_edit_Click);
            // 
            // cmi_SellOrder_item_delete
            // 
            this.cmi_SellOrder_item_delete.Name = "cmi_SellOrder_item_delete";
            this.cmi_SellOrder_item_delete.Size = new System.Drawing.Size(110, 22);
            this.cmi_SellOrder_item_delete.Text = "ამოშლა";
            this.cmi_SellOrder_item_delete.Click += new System.EventHandler(this.cmi_SellOrder_item_delete_Click);
            // 
            // SOd_print_btn
            // 
            this.SOd_print_btn.Enabled = false;
            this.SOd_print_btn.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SOd_print_btn.Location = new System.Drawing.Point(631, 5);
            this.SOd_print_btn.Name = "SOd_print_btn";
            this.SOd_print_btn.Size = new System.Drawing.Size(103, 30);
            this.SOd_print_btn.TabIndex = 3;
            this.SOd_print_btn.Text = "ამობეჭდვა";
            this.SOd_print_btn.UseVisualStyleBackColor = true;
            this.SOd_print_btn.Click += new System.EventHandler(this.SOd_print_btn_Click);
            // 
            // txt_af_seria
            // 
            this.txt_af_seria.Location = new System.Drawing.Point(402, 34);
            this.txt_af_seria.Name = "txt_af_seria";
            this.txt_af_seria.Size = new System.Drawing.Size(120, 20);
            this.txt_af_seria.TabIndex = 4;
            // 
            // datetime_zed_tarigi
            // 
            this.datetime_zed_tarigi.Location = new System.Drawing.Point(322, 6);
            this.datetime_zed_tarigi.Name = "datetime_zed_tarigi";
            this.datetime_zed_tarigi.Size = new System.Drawing.Size(200, 20);
            this.datetime_zed_tarigi.TabIndex = 5;
            // 
            // lbl_edit_af_seria
            // 
            this.lbl_edit_af_seria.AutoSize = true;
            this.lbl_edit_af_seria.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_edit_af_seria.Location = new System.Drawing.Point(322, 36);
            this.lbl_edit_af_seria.Name = "lbl_edit_af_seria";
            this.lbl_edit_af_seria.Size = new System.Drawing.Size(64, 16);
            this.lbl_edit_af_seria.TabIndex = 6;
            this.lbl_edit_af_seria.Text = "ა/ფ სერია";
            // 
            // txt_af_nomeri
            // 
            this.txt_af_nomeri.Location = new System.Drawing.Point(402, 62);
            this.txt_af_nomeri.Name = "txt_af_nomeri";
            this.txt_af_nomeri.Size = new System.Drawing.Size(120, 20);
            this.txt_af_nomeri.TabIndex = 4;
            // 
            // lbl_edit_af_nomeri
            // 
            this.lbl_edit_af_nomeri.AutoSize = true;
            this.lbl_edit_af_nomeri.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_edit_af_nomeri.Location = new System.Drawing.Point(322, 64);
            this.lbl_edit_af_nomeri.Name = "lbl_edit_af_nomeri";
            this.lbl_edit_af_nomeri.Size = new System.Drawing.Size(74, 16);
            this.lbl_edit_af_nomeri.TabIndex = 6;
            this.lbl_edit_af_nomeri.Text = "ა/ფ ნომერი";
            // 
            // btn_zed_update
            // 
            this.btn_zed_update.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_zed_update.Location = new System.Drawing.Point(528, 61);
            this.btn_zed_update.Name = "btn_zed_update";
            this.btn_zed_update.Size = new System.Drawing.Size(97, 23);
            this.btn_zed_update.TabIndex = 7;
            this.btn_zed_update.Text = "დამახსოვრება";
            this.btn_zed_update.UseVisualStyleBackColor = true;
            this.btn_zed_update.Click += new System.EventHandler(this.btn_zed_update_Click);
            // 
            // lbl_editzed_af_date
            // 
            this.lbl_editzed_af_date.AutoSize = true;
            this.lbl_editzed_af_date.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_editzed_af_date.Location = new System.Drawing.Point(47, 68);
            this.lbl_editzed_af_date.Name = "lbl_editzed_af_date";
            this.lbl_editzed_af_date.Size = new System.Drawing.Size(76, 16);
            this.lbl_editzed_af_date.TabIndex = 6;
            this.lbl_editzed_af_date.Text = "ა/ფ თარიღი";
            // 
            // datepicker_af_date
            // 
            this.datepicker_af_date.Location = new System.Drawing.Point(129, 67);
            this.datepicker_af_date.Name = "datepicker_af_date";
            this.datepicker_af_date.Size = new System.Drawing.Size(187, 20);
            this.datepicker_af_date.TabIndex = 5;
            // 
            // SOd_print_gasavali_btn
            // 
            this.SOd_print_gasavali_btn.Enabled = false;
            this.SOd_print_gasavali_btn.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SOd_print_gasavali_btn.Location = new System.Drawing.Point(631, 38);
            this.SOd_print_gasavali_btn.Name = "SOd_print_gasavali_btn";
            this.SOd_print_gasavali_btn.Size = new System.Drawing.Size(103, 24);
            this.SOd_print_gasavali_btn.TabIndex = 15;
            this.SOd_print_gasavali_btn.Text = "გასავალი";
            this.SOd_print_gasavali_btn.UseVisualStyleBackColor = true;
            this.SOd_print_gasavali_btn.Click += new System.EventHandler(this.SOd_print_gasavali_btn_Click);
            // 
            // lblZedIdent
            // 
            this.lblZedIdent.AutoSize = true;
            this.lblZedIdent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZedIdent.Location = new System.Drawing.Point(44, 46);
            this.lblZedIdent.Name = "lblZedIdent";
            this.lblZedIdent.Size = new System.Drawing.Size(79, 16);
            this.lblZedIdent.TabIndex = 16;
            this.lblZedIdent.Text = "ზედ. ნომერი";
            // 
            // txtZedIdent
            // 
            this.txtZedIdent.Enabled = false;
            this.txtZedIdent.Location = new System.Drawing.Point(129, 43);
            this.txtZedIdent.Name = "txtZedIdent";
            this.txtZedIdent.Size = new System.Drawing.Size(164, 20);
            this.txtZedIdent.TabIndex = 17;
            // 
            // btnEnableEditingZedIdent
            // 
            this.btnEnableEditingZedIdent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnableEditingZedIdent.ForeColor = System.Drawing.SystemColors.Control;
            this.btnEnableEditingZedIdent.Image = global::ProductInfo_UI.Properties.Resources.pencil_16x16;
            this.btnEnableEditingZedIdent.Location = new System.Drawing.Point(294, 40);
            this.btnEnableEditingZedIdent.Name = "btnEnableEditingZedIdent";
            this.btnEnableEditingZedIdent.Size = new System.Drawing.Size(25, 23);
            this.btnEnableEditingZedIdent.TabIndex = 18;
            this.btnEnableEditingZedIdent.UseVisualStyleBackColor = true;
            this.btnEnableEditingZedIdent.Click += new System.EventHandler(this.btnEnableEditingZedIdent_Click);
            // 
            // btn_exportCSV_SOd
            // 
            this.btn_exportCSV_SOd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exportCSV_SOd.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_exportCSV_SOd.Image = global::ProductInfo_UI.Properties.Resources.csv_h261;
            this.btn_exportCSV_SOd.Location = new System.Drawing.Point(596, 7);
            this.btn_exportCSV_SOd.Name = "btn_exportCSV_SOd";
            this.btn_exportCSV_SOd.Size = new System.Drawing.Size(29, 26);
            this.btn_exportCSV_SOd.TabIndex = 14;
            this.btn_exportCSV_SOd.UseVisualStyleBackColor = true;
            this.btn_exportCSV_SOd.Click += new System.EventHandler(this.btn_exportCSV_SOd_Click);
            // 
            // btn_add_soldrems
            // 
            this.btn_add_soldrems.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_add_soldrems.Image = global::ProductInfo_UI.Properties.Resources.item_add_21x21;
            this.btn_add_soldrems.Location = new System.Drawing.Point(0, 75);
            this.btn_add_soldrems.Name = "btn_add_soldrems";
            this.btn_add_soldrems.Size = new System.Drawing.Size(21, 21);
            this.btn_add_soldrems.TabIndex = 13;
            this.btn_add_soldrems.UseVisualStyleBackColor = true;
            this.btn_add_soldrems.Click += new System.EventHandler(this.btn_add_soldrems_Click);
            // 
            // SellOrderDetails_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 610);
            this.Controls.Add(this.btnEnableEditingZedIdent);
            this.Controls.Add(this.txtZedIdent);
            this.Controls.Add(this.lblZedIdent);
            this.Controls.Add(this.SOd_print_gasavali_btn);
            this.Controls.Add(this.btn_exportCSV_SOd);
            this.Controls.Add(this.btn_add_soldrems);
            this.Controls.Add(this.btn_zed_update);
            this.Controls.Add(this.lbl_edit_af_nomeri);
            this.Controls.Add(this.lbl_edit_af_seria);
            this.Controls.Add(this.txt_af_nomeri);
            this.Controls.Add(this.lbl_editzed_af_date);
            this.Controls.Add(this.datepicker_af_date);
            this.Controls.Add(this.datetime_zed_tarigi);
            this.Controls.Add(this.txt_af_seria);
            this.Controls.Add(this.sold_rem_list);
            this.Controls.Add(this.close_btn);
            this.Controls.Add(this.SOd_print_btn);
            this.Controls.Add(this.attributes_lbl);
            this.Name = "SellOrderDetails_Form";
            this.Text = "გაყიდვის დეტალები";
            this.Load += new System.EventHandler(this.SellOrderDetails_Form_Load);
            this.cm_SellOrder_edit.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label attributes_lbl;
        private System.Windows.Forms.Button close_btn;
        private System.Windows.Forms.ListView sold_rem_list;
        private System.Windows.Forms.ColumnHeader SOd_barcode_col;
        private System.Windows.Forms.ColumnHeader SOd_prodname_col;
        private System.Windows.Forms.ColumnHeader SOd_count_col;
        private System.Windows.Forms.ColumnHeader SOd_cost_col;
        private System.Windows.Forms.ColumnHeader SOd_whole_price_col;
        private System.Windows.Forms.ColumnHeader SOd_mogeba_col;
        private System.Windows.Forms.ColumnHeader SOd_cost_without_col;
        private System.Windows.Forms.Button SOd_print_btn;
        private System.Windows.Forms.ContextMenuStrip cm_SellOrder_edit;
        private System.Windows.Forms.ToolStripMenuItem cmi_SellOrder_item_edit;
        private System.Windows.Forms.ColumnHeader SOd_id_col;
        private System.Windows.Forms.ToolStripMenuItem cmi_SellOrder_item_delete;
        private System.Windows.Forms.ColumnHeader SOd_storeID_col;
        private System.Windows.Forms.TextBox txt_af_seria;
        private System.Windows.Forms.DateTimePicker datetime_zed_tarigi;
        private System.Windows.Forms.Label lbl_edit_af_seria;
        private System.Windows.Forms.TextBox txt_af_nomeri;
        private System.Windows.Forms.Label lbl_edit_af_nomeri;
        private System.Windows.Forms.Button btn_zed_update;
        private System.Windows.Forms.Label lbl_editzed_af_date;
        private System.Windows.Forms.DateTimePicker datepicker_af_date;
        private System.Windows.Forms.Button btn_add_soldrems;
        private System.Windows.Forms.Button btn_exportCSV_SOd;
        private System.Windows.Forms.Button SOd_print_gasavali_btn;
        private System.Windows.Forms.ColumnHeader SOd_piece_cost_col;
        private System.Windows.Forms.ColumnHeader SOd_piece_price_col;
        private System.Windows.Forms.Label lblZedIdent;
        private System.Windows.Forms.TextBox txtZedIdent;
        private System.Windows.Forms.Button btnEnableEditingZedIdent;

    }
}