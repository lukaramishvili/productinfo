namespace ProductInfo_UI
{
    partial class ChooseRSIncomingZed
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
            this.table_incoming_zeds = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_rs_zed_ident = new System.Windows.Forms.TextBox();
            this.lbl_rs_zed_ident = new System.Windows.Forms.Label();
            this.btn_save_rs_incoming_zed = new System.Windows.Forms.Button();
            this.barcode_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.piece_price_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbl_rs_buyer_ident = new System.Windows.Forms.Label();
            this.txt_rs_buyer_ident = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_rs_buyer_name = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.table_incoming_zeds)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // table_incoming_zeds
            // 
            this.table_incoming_zeds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table_incoming_zeds.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.barcode_col,
            this.name_col,
            this.quantity_col,
            this.piece_price_col});
            this.table_incoming_zeds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table_incoming_zeds.Location = new System.Drawing.Point(0, 0);
            this.table_incoming_zeds.Name = "table_incoming_zeds";
            this.table_incoming_zeds.Size = new System.Drawing.Size(655, 498);
            this.table_incoming_zeds.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.table_incoming_zeds);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 40);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 30, 3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(655, 498);
            this.panel1.TabIndex = 3;
            // 
            // txt_rs_zed_ident
            // 
            this.txt_rs_zed_ident.Enabled = false;
            this.txt_rs_zed_ident.Location = new System.Drawing.Point(91, 12);
            this.txt_rs_zed_ident.Name = "txt_rs_zed_ident";
            this.txt_rs_zed_ident.Size = new System.Drawing.Size(130, 20);
            this.txt_rs_zed_ident.TabIndex = 0;
            // 
            // lbl_rs_zed_ident
            // 
            this.lbl_rs_zed_ident.AutoSize = true;
            this.lbl_rs_zed_ident.Location = new System.Drawing.Point(10, 15);
            this.lbl_rs_zed_ident.Name = "lbl_rs_zed_ident";
            this.lbl_rs_zed_ident.Size = new System.Drawing.Size(77, 13);
            this.lbl_rs_zed_ident.TabIndex = 1;
            this.lbl_rs_zed_ident.Text = "ზედნადების N.";
            // 
            // btn_save_rs_incoming_zed
            // 
            this.btn_save_rs_incoming_zed.Location = new System.Drawing.Point(211, 544);
            this.btn_save_rs_incoming_zed.Name = "btn_save_rs_incoming_zed";
            this.btn_save_rs_incoming_zed.Size = new System.Drawing.Size(159, 40);
            this.btn_save_rs_incoming_zed.TabIndex = 4;
            this.btn_save_rs_incoming_zed.Text = "დამახსოვრება";
            this.btn_save_rs_incoming_zed.UseVisualStyleBackColor = true;
            this.btn_save_rs_incoming_zed.Click += new System.EventHandler(this.btn_save_rs_incoming_zed_Click);
            // 
            // barcode_col
            // 
            this.barcode_col.HeaderText = "შტრიხ–კოდი";
            this.barcode_col.Name = "barcode_col";
            // 
            // name_col
            // 
            this.name_col.HeaderText = "დასახელება";
            this.name_col.Name = "name_col";
            // 
            // quantity_col
            // 
            this.quantity_col.HeaderText = "რაოდენობა";
            this.quantity_col.Name = "quantity_col";
            // 
            // piece_price_col
            // 
            this.piece_price_col.HeaderText = "საცალო ფასი";
            this.piece_price_col.Name = "piece_price_col";
            // 
            // lbl_rs_buyer_ident
            // 
            this.lbl_rs_buyer_ident.AutoSize = true;
            this.lbl_rs_buyer_ident.Location = new System.Drawing.Point(227, 15);
            this.lbl_rs_buyer_ident.Name = "lbl_rs_buyer_ident";
            this.lbl_rs_buyer_ident.Size = new System.Drawing.Size(108, 13);
            this.lbl_rs_buyer_ident.TabIndex = 6;
            this.lbl_rs_buyer_ident.Text = "მყიდვ. საიდენტ. კოდი";
            // 
            // txt_rs_buyer_ident
            // 
            this.txt_rs_buyer_ident.Enabled = false;
            this.txt_rs_buyer_ident.Location = new System.Drawing.Point(341, 12);
            this.txt_rs_buyer_ident.Name = "txt_rs_buyer_ident";
            this.txt_rs_buyer_ident.Size = new System.Drawing.Size(100, 20);
            this.txt_rs_buyer_ident.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(448, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "მყიდვ. სახელი";
            // 
            // txt_rs_buyer_name
            // 
            this.txt_rs_buyer_name.Enabled = false;
            this.txt_rs_buyer_name.Location = new System.Drawing.Point(526, 12);
            this.txt_rs_buyer_name.Name = "txt_rs_buyer_name";
            this.txt_rs_buyer_name.Size = new System.Drawing.Size(113, 20);
            this.txt_rs_buyer_name.TabIndex = 7;
            // 
            // ChooseRSIncomingZed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 588);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_rs_buyer_name);
            this.Controls.Add(this.lbl_rs_buyer_ident);
            this.Controls.Add(this.txt_rs_buyer_ident);
            this.Controls.Add(this.btn_save_rs_incoming_zed);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbl_rs_zed_ident);
            this.Controls.Add(this.txt_rs_zed_ident);
            this.Name = "ChooseRSIncomingZed";
            this.Padding = new System.Windows.Forms.Padding(0, 40, 0, 50);
            this.Text = "ChooseRSIncomingZed";
            this.Load += new System.EventHandler(this.ChooseRSIncomingZed_Load);
            ((System.ComponentModel.ISupportInitialize)(this.table_incoming_zeds)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView table_incoming_zeds;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_rs_zed_ident;
        private System.Windows.Forms.Label lbl_rs_zed_ident;
        private System.Windows.Forms.Button btn_save_rs_incoming_zed;
        private System.Windows.Forms.DataGridViewTextBoxColumn barcode_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn name_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn piece_price_col;
        private System.Windows.Forms.Label lbl_rs_buyer_ident;
        private System.Windows.Forms.TextBox txt_rs_buyer_ident;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_rs_buyer_name;
    }
}