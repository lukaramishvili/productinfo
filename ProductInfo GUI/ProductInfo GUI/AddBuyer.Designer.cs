namespace ProductInfo_UI
{
    partial class AddBuyer_Form
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
            this.submit_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_supplier_ident_code = new System.Windows.Forms.Label();
            this.lbl_addsupplier = new System.Windows.Forms.Label();
            this.buyer_address_txt = new System.Windows.Forms.TextBox();
            this.buyer_ident_code_txt = new System.Windows.Forms.TextBox();
            this.buyer_name_txt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // submit_btn
            // 
            this.submit_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submit_btn.Location = new System.Drawing.Point(16, 249);
            this.submit_btn.Name = "submit_btn";
            this.submit_btn.Size = new System.Drawing.Size(87, 36);
            this.submit_btn.TabIndex = 10;
            this.submit_btn.Text = "შენახვა";
            this.submit_btn.UseVisualStyleBackColor = true;
            this.submit_btn.Click += new System.EventHandler(this.submit_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(13, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 23);
            this.label1.TabIndex = 7;
            this.label1.Text = "მისამართი:";
            // 
            // lbl_supplier_ident_code
            // 
            this.lbl_supplier_ident_code.AutoSize = true;
            this.lbl_supplier_ident_code.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_supplier_ident_code.Location = new System.Drawing.Point(13, 74);
            this.lbl_supplier_ident_code.Name = "lbl_supplier_ident_code";
            this.lbl_supplier_ident_code.Size = new System.Drawing.Size(192, 23);
            this.lbl_supplier_ident_code.TabIndex = 8;
            this.lbl_supplier_ident_code.Text = "საიდენტიფიკაციო კოდი:";
            // 
            // lbl_addsupplier
            // 
            this.lbl_addsupplier.AutoSize = true;
            this.lbl_addsupplier.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_addsupplier.Location = new System.Drawing.Point(12, 9);
            this.lbl_addsupplier.Name = "lbl_addsupplier";
            this.lbl_addsupplier.Size = new System.Drawing.Size(157, 23);
            this.lbl_addsupplier.TabIndex = 5;
            this.lbl_addsupplier.Text = "მყიდველის სახელი:";
            // 
            // buyer_address_txt
            // 
            this.buyer_address_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buyer_address_txt.Location = new System.Drawing.Point(15, 171);
            this.buyer_address_txt.Multiline = true;
            this.buyer_address_txt.Name = "buyer_address_txt";
            this.buyer_address_txt.Size = new System.Drawing.Size(336, 59);
            this.buyer_address_txt.TabIndex = 9;
            // 
            // buyer_ident_code_txt
            // 
            this.buyer_ident_code_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buyer_ident_code_txt.Location = new System.Drawing.Point(15, 106);
            this.buyer_ident_code_txt.Name = "buyer_ident_code_txt";
            this.buyer_ident_code_txt.Size = new System.Drawing.Size(241, 26);
            this.buyer_ident_code_txt.TabIndex = 6;
            // 
            // buyer_name_txt
            // 
            this.buyer_name_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buyer_name_txt.Location = new System.Drawing.Point(15, 39);
            this.buyer_name_txt.Name = "buyer_name_txt";
            this.buyer_name_txt.Size = new System.Drawing.Size(300, 26);
            this.buyer_name_txt.TabIndex = 4;
            // 
            // AddBuyer_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 302);
            this.Controls.Add(this.submit_btn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_supplier_ident_code);
            this.Controls.Add(this.lbl_addsupplier);
            this.Controls.Add(this.buyer_address_txt);
            this.Controls.Add(this.buyer_ident_code_txt);
            this.Controls.Add(this.buyer_name_txt);
            this.Name = "AddBuyer_Form";
            this.Text = "მყიდველის დამატება";
            this.Load += new System.EventHandler(this.AddBuyer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button submit_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_supplier_ident_code;
        private System.Windows.Forms.Label lbl_addsupplier;
        public System.Windows.Forms.TextBox buyer_address_txt;
        public System.Windows.Forms.TextBox buyer_ident_code_txt;
        public System.Windows.Forms.TextBox buyer_name_txt;
    }
}