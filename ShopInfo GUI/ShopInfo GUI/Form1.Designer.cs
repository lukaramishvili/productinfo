namespace ShopInfo_GUI
{
    partial class ShopInfo_Main_Form
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.sell_panel = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lbl_status_sum = new System.Windows.Forms.ToolStripStatusLabel();
            this.sell_grid = new System.Windows.Forms.DataGridView();
            this.sell_barcode_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sell_prodname_col = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.sell_piece_count_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sell_remaining_items_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sell_piece_price_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sell_sum_price_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sell_remove_col = new System.Windows.Forms.DataGridViewButtonColumn();
            this.box_for_change = new System.Windows.Forms.GroupBox();
            this.cash_change_txt = new System.Windows.Forms.TextBox();
            this.cash_change_lbl = new System.Windows.Forms.Label();
            this.cash_handled_txt = new System.Windows.Forms.TextBox();
            this.cash_handled_lbl = new System.Windows.Forms.Label();
            this.sell_btn = new System.Windows.Forms.Button();
            this.sell_panel.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sell_grid)).BeginInit();
            this.box_for_change.SuspendLayout();
            this.SuspendLayout();
            // 
            // sell_panel
            // 
            this.sell_panel.Controls.Add(this.statusStrip1);
            this.sell_panel.Controls.Add(this.sell_grid);
            this.sell_panel.Controls.Add(this.box_for_change);
            this.sell_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sell_panel.Location = new System.Drawing.Point(0, 0);
            this.sell_panel.Name = "sell_panel";
            this.sell_panel.Padding = new System.Windows.Forms.Padding(0, 130, 0, 60);
            this.sell_panel.Size = new System.Drawing.Size(1577, 752);
            this.sell_panel.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbl_status_sum});
            this.statusStrip1.Location = new System.Drawing.Point(0, 658);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1577, 34);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lbl_status_sum
            // 
            this.lbl_status_sum.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_status_sum.Name = "lbl_status_sum";
            this.lbl_status_sum.Padding = new System.Windows.Forms.Padding(4);
            this.lbl_status_sum.Size = new System.Drawing.Size(1562, 29);
            this.lbl_status_sum.Spring = true;
            this.lbl_status_sum.Text = "ჯამი: 0 ლარი";
            // 
            // sell_grid
            // 
            this.sell_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.sell_grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.sell_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sell_grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sell_barcode_col,
            this.sell_prodname_col,
            this.sell_piece_count_col,
            this.sell_remaining_items_col,
            this.sell_piece_price_col,
            this.sell_sum_price_col,
            this.sell_remove_col});
            this.sell_grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sell_grid.Location = new System.Drawing.Point(0, 130);
            this.sell_grid.Name = "sell_grid";
            this.sell_grid.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.sell_grid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sell_grid.RowTemplate.Height = 42;
            this.sell_grid.Size = new System.Drawing.Size(1577, 562);
            this.sell_grid.TabIndex = 0;
            this.sell_grid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.sell_grid_CellValueChanged);
            this.sell_grid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.sell_grid_CellEndEdit);
            this.sell_grid.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.sell_grid_EditingControlShowing);
            this.sell_grid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.sell_grid_DataError);
            this.sell_grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.sell_grid_CellContentClick);
            // 
            // sell_barcode_col
            // 
            this.sell_barcode_col.HeaderText = "შტრიხ–კოდი";
            this.sell_barcode_col.Name = "sell_barcode_col";
            // 
            // sell_prodname_col
            // 
            this.sell_prodname_col.HeaderText = "დასახელება";
            this.sell_prodname_col.Name = "sell_prodname_col";
            // 
            // sell_piece_count_col
            // 
            this.sell_piece_count_col.HeaderText = "რაოდენობა";
            this.sell_piece_count_col.Name = "sell_piece_count_col";
            // 
            // sell_remaining_items_col
            // 
            this.sell_remaining_items_col.HeaderText = "დარჩენილია";
            this.sell_remaining_items_col.Name = "sell_remaining_items_col";
            this.sell_remaining_items_col.ReadOnly = true;
            // 
            // sell_piece_price_col
            // 
            this.sell_piece_price_col.HeaderText = "ფასი";
            this.sell_piece_price_col.Name = "sell_piece_price_col";
            this.sell_piece_price_col.ReadOnly = true;
            // 
            // sell_sum_price_col
            // 
            this.sell_sum_price_col.HeaderText = "სულ";
            this.sell_sum_price_col.Name = "sell_sum_price_col";
            this.sell_sum_price_col.ReadOnly = true;
            // 
            // sell_remove_col
            // 
            this.sell_remove_col.HeaderText = "ამოშლა";
            this.sell_remove_col.Name = "sell_remove_col";
            this.sell_remove_col.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.sell_remove_col.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.sell_remove_col.Text = "ამოშლა";
            this.sell_remove_col.UseColumnTextForButtonValue = true;
            // 
            // box_for_change
            // 
            this.box_for_change.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.box_for_change.Controls.Add(this.cash_change_txt);
            this.box_for_change.Controls.Add(this.cash_change_lbl);
            this.box_for_change.Controls.Add(this.cash_handled_txt);
            this.box_for_change.Controls.Add(this.cash_handled_lbl);
            this.box_for_change.Location = new System.Drawing.Point(1282, 12);
            this.box_for_change.Name = "box_for_change";
            this.box_for_change.Size = new System.Drawing.Size(283, 110);
            this.box_for_change.TabIndex = 2;
            this.box_for_change.TabStop = false;
            // 
            // cash_change_txt
            // 
            this.cash_change_txt.Enabled = false;
            this.cash_change_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cash_change_txt.Location = new System.Drawing.Point(119, 61);
            this.cash_change_txt.Name = "cash_change_txt";
            this.cash_change_txt.Size = new System.Drawing.Size(158, 38);
            this.cash_change_txt.TabIndex = 3;
            this.cash_change_txt.Text = "0.0";
            this.cash_change_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cash_change_lbl
            // 
            this.cash_change_lbl.AutoSize = true;
            this.cash_change_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cash_change_lbl.Location = new System.Drawing.Point(7, 64);
            this.cash_change_lbl.Name = "cash_change_lbl";
            this.cash_change_lbl.Size = new System.Drawing.Size(93, 29);
            this.cash_change_lbl.TabIndex = 2;
            this.cash_change_lbl.Text = "ხურდა:";
            // 
            // cash_handled_txt
            // 
            this.cash_handled_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cash_handled_txt.Location = new System.Drawing.Point(119, 17);
            this.cash_handled_txt.Name = "cash_handled_txt";
            this.cash_handled_txt.Size = new System.Drawing.Size(158, 38);
            this.cash_handled_txt.TabIndex = 1;
            this.cash_handled_txt.Text = "0.0";
            this.cash_handled_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cash_handled_txt.TextChanged += new System.EventHandler(this.cash_handled_txt_TextChanged);
            this.cash_handled_txt.Click += new System.EventHandler(this.cash_handled_txt_Click);
            this.cash_handled_txt.Enter += new System.EventHandler(this.cash_handled_txt_Enter);
            // 
            // cash_handled_lbl
            // 
            this.cash_handled_lbl.AutoSize = true;
            this.cash_handled_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cash_handled_lbl.Location = new System.Drawing.Point(7, 20);
            this.cash_handled_lbl.Name = "cash_handled_lbl";
            this.cash_handled_lbl.Size = new System.Drawing.Size(112, 29);
            this.cash_handled_lbl.TabIndex = 0;
            this.cash_handled_lbl.Text = "მივიღეთ:";
            // 
            // sell_btn
            // 
            this.sell_btn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.sell_btn.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sell_btn.Location = new System.Drawing.Point(0, 692);
            this.sell_btn.Name = "sell_btn";
            this.sell_btn.Size = new System.Drawing.Size(1577, 60);
            this.sell_btn.TabIndex = 2;
            this.sell_btn.Text = "გაყიდვა";
            this.sell_btn.UseVisualStyleBackColor = true;
            this.sell_btn.Click += new System.EventHandler(this.sell_btn_Click);
            // 
            // ShopInfo_Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1577, 752);
            this.Controls.Add(this.sell_btn);
            this.Controls.Add(this.sell_panel);
            this.KeyPreview = true;
            this.Name = "ShopInfo_Main_Form";
            this.Text = "ShopInfo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ShopInfo_Main_Form_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ShopInfo_Main_Form_KeyDown);
            this.sell_panel.ResumeLayout(false);
            this.sell_panel.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sell_grid)).EndInit();
            this.box_for_change.ResumeLayout(false);
            this.box_for_change.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel sell_panel;
        private System.Windows.Forms.GroupBox box_for_change;
        private System.Windows.Forms.Button sell_btn;
        private System.Windows.Forms.DataGridView sell_grid;
        private System.Windows.Forms.TextBox cash_change_txt;
        private System.Windows.Forms.Label cash_change_lbl;
        private System.Windows.Forms.TextBox cash_handled_txt;
        private System.Windows.Forms.Label cash_handled_lbl;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lbl_status_sum;
        private System.Windows.Forms.DataGridViewTextBoxColumn sell_barcode_col;
        private System.Windows.Forms.DataGridViewComboBoxColumn sell_prodname_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn sell_piece_count_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn sell_remaining_items_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn sell_piece_price_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn sell_sum_price_col;
        private System.Windows.Forms.DataGridViewButtonColumn sell_remove_col;
    }
}

