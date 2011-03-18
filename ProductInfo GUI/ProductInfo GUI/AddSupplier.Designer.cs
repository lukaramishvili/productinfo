namespace ProductInfo_UI
{
    partial class AddSupplier_Form
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
            this.supplier_name_txt = new System.Windows.Forms.TextBox();
            this.lbl_addsupplier = new System.Windows.Forms.Label();
            this.lbl_supplier_ident_code = new System.Windows.Forms.Label();
            this.supplier_ident_code_txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.supplier_address_txt = new System.Windows.Forms.TextBox();
            this.submit_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // supplier_name_txt
            // 
            this.supplier_name_txt.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.supplier_name_txt.Location = new System.Drawing.Point(12, 43);
            this.supplier_name_txt.Name = "supplier_name_txt";
            this.supplier_name_txt.Size = new System.Drawing.Size(300, 27);
            this.supplier_name_txt.TabIndex = 0;
            // 
            // lbl_addsupplier
            // 
            this.lbl_addsupplier.AutoSize = true;
            this.lbl_addsupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_addsupplier.Location = new System.Drawing.Point(9, 13);
            this.lbl_addsupplier.Name = "lbl_addsupplier";
            this.lbl_addsupplier.Size = new System.Drawing.Size(191, 24);
            this.lbl_addsupplier.TabIndex = 1;
            this.lbl_addsupplier.Text = "მომწოდებლის სახელი:";
            // 
            // lbl_supplier_ident_code
            // 
            this.lbl_supplier_ident_code.AutoSize = true;
            this.lbl_supplier_ident_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_supplier_ident_code.Location = new System.Drawing.Point(10, 78);
            this.lbl_supplier_ident_code.Name = "lbl_supplier_ident_code";
            this.lbl_supplier_ident_code.Size = new System.Drawing.Size(208, 24);
            this.lbl_supplier_ident_code.TabIndex = 1;
            this.lbl_supplier_ident_code.Text = "საიდენტიფიკაციო კოდი:";
            // 
            // supplier_ident_code_txt
            // 
            this.supplier_ident_code_txt.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.supplier_ident_code_txt.Location = new System.Drawing.Point(12, 110);
            this.supplier_ident_code_txt.Name = "supplier_ident_code_txt";
            this.supplier_ident_code_txt.Size = new System.Drawing.Size(241, 27);
            this.supplier_ident_code_txt.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(10, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "მისამართი:";
            // 
            // supplier_address_txt
            // 
            this.supplier_address_txt.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.supplier_address_txt.Location = new System.Drawing.Point(12, 175);
            this.supplier_address_txt.Multiline = true;
            this.supplier_address_txt.Name = "supplier_address_txt";
            this.supplier_address_txt.Size = new System.Drawing.Size(336, 59);
            this.supplier_address_txt.TabIndex = 2;
            // 
            // submit_btn
            // 
            this.submit_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.submit_btn.Location = new System.Drawing.Point(13, 253);
            this.submit_btn.Name = "submit_btn";
            this.submit_btn.Size = new System.Drawing.Size(92, 32);
            this.submit_btn.TabIndex = 3;
            this.submit_btn.Text = "შენახვა";
            this.submit_btn.UseVisualStyleBackColor = true;
            this.submit_btn.Click += new System.EventHandler(this.submit_btn_Click);
            // 
            // AddSupplier_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 303);
            this.Controls.Add(this.submit_btn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_supplier_ident_code);
            this.Controls.Add(this.lbl_addsupplier);
            this.Controls.Add(this.supplier_address_txt);
            this.Controls.Add(this.supplier_ident_code_txt);
            this.Controls.Add(this.supplier_name_txt);
            this.Name = "AddSupplier_Form";
            this.Text = "მომწოდებლის დამატება";
            this.Load += new System.EventHandler(this.AddSupplier_Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox supplier_name_txt;
        private System.Windows.Forms.Label lbl_addsupplier;
        private System.Windows.Forms.Label lbl_supplier_ident_code;
        public System.Windows.Forms.TextBox supplier_ident_code_txt;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox supplier_address_txt;
        private System.Windows.Forms.Button submit_btn;
    }
}