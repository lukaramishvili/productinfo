namespace ProductInfo_UI
{
    partial class AddProductList_Form
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
            this.label1 = new System.Windows.Forms.Label();
            this.prodlist_data = new System.Windows.Forms.DataGridView();
            this.barcode_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vat_col = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.submit_list_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.prodlist_data)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(316, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "ინფორმაცია პროდუქტების დასახელებებზე";
            // 
            // prodlist_data
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.prodlist_data.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.prodlist_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.prodlist_data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.barcode_col,
            this.name_col,
            this.vat_col});
            this.prodlist_data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prodlist_data.Location = new System.Drawing.Point(0, 18);
            this.prodlist_data.Name = "prodlist_data";
            this.prodlist_data.Size = new System.Drawing.Size(463, 516);
            this.prodlist_data.TabIndex = 2;
            this.prodlist_data.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.prodlist_data_CellEndEdit);
            this.prodlist_data.KeyDown += new System.Windows.Forms.KeyEventHandler(this.prodlist_data_KeyDown);
            // 
            // barcode_col
            // 
            this.barcode_col.HeaderText = "შტრიხ–კოდი";
            this.barcode_col.Name = "barcode_col";
            this.barcode_col.Width = 120;
            // 
            // name_col
            // 
            this.name_col.HeaderText = "დასახელება";
            this.name_col.Name = "name_col";
            this.name_col.Width = 200;
            // 
            // vat_col
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = "true";
            this.vat_col.DefaultCellStyle = dataGridViewCellStyle2;
            this.vat_col.HeaderText = "იბეგრება დღგ–თი";
            this.vat_col.Name = "vat_col";
            // 
            // submit_list_btn
            // 
            this.submit_list_btn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.submit_list_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.submit_list_btn.Location = new System.Drawing.Point(0, 501);
            this.submit_list_btn.Name = "submit_list_btn";
            this.submit_list_btn.Size = new System.Drawing.Size(463, 33);
            this.submit_list_btn.TabIndex = 3;
            this.submit_list_btn.Text = "დამახსოვრება";
            this.submit_list_btn.UseVisualStyleBackColor = true;
            this.submit_list_btn.Click += new System.EventHandler(this.submit_list_btn_Click);
            // 
            // AddProductList_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 534);
            this.Controls.Add(this.submit_list_btn);
            this.Controls.Add(this.prodlist_data);
            this.Controls.Add(this.label1);
            this.Name = "AddProductList_Form";
            this.Text = "პროდ. დასახელებების სიის დამატება";
            this.Load += new System.EventHandler(this.AddProductList_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.prodlist_data)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView prodlist_data;
        private System.Windows.Forms.Button submit_list_btn;
        private System.Windows.Forms.DataGridViewTextBoxColumn barcode_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn name_col;
        private System.Windows.Forms.DataGridViewCheckBoxColumn vat_col;
    }
}