namespace ProductInfo_UI
{
    partial class AddProduct_Form
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
            this.label1 = new System.Windows.Forms.Label();
            this.barcode_txt = new System.Windows.Forms.TextBox();
            this.barcode_label = new System.Windows.Forms.Label();
            this.name_label = new System.Windows.Forms.Label();
            this.name_txt = new System.Windows.Forms.TextBox();
            this.vat_ckb = new System.Windows.Forms.CheckBox();
            this.prod_add_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(268, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "ინფორმაცია პროდუქტის ტიპზე";
            // 
            // barcode_txt
            // 
            this.barcode_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.barcode_txt.Location = new System.Drawing.Point(12, 81);
            this.barcode_txt.Name = "barcode_txt";
            this.barcode_txt.Size = new System.Drawing.Size(261, 26);
            this.barcode_txt.TabIndex = 1;
            // 
            // barcode_label
            // 
            this.barcode_label.AutoSize = true;
            this.barcode_label.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.barcode_label.Location = new System.Drawing.Point(12, 55);
            this.barcode_label.Name = "barcode_label";
            this.barcode_label.Size = new System.Drawing.Size(106, 23);
            this.barcode_label.TabIndex = 2;
            this.barcode_label.Text = "შტრიხ–კოდი";
            // 
            // name_label
            // 
            this.name_label.AutoSize = true;
            this.name_label.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.name_label.Location = new System.Drawing.Point(12, 114);
            this.name_label.Name = "name_label";
            this.name_label.Size = new System.Drawing.Size(93, 23);
            this.name_label.TabIndex = 3;
            this.name_label.Text = "დასახელება";
            // 
            // name_txt
            // 
            this.name_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.name_txt.Location = new System.Drawing.Point(12, 141);
            this.name_txt.Name = "name_txt";
            this.name_txt.Size = new System.Drawing.Size(261, 26);
            this.name_txt.TabIndex = 4;
            // 
            // vat_ckb
            // 
            this.vat_ckb.AutoSize = true;
            this.vat_ckb.Checked = true;
            this.vat_ckb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.vat_ckb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.vat_ckb.Location = new System.Drawing.Point(13, 181);
            this.vat_ckb.Name = "vat_ckb";
            this.vat_ckb.Size = new System.Drawing.Size(144, 24);
            this.vat_ckb.TabIndex = 5;
            this.vat_ckb.Text = "იბეგრება დღგ–თი";
            this.vat_ckb.UseVisualStyleBackColor = true;
            // 
            // prod_add_btn
            // 
            this.prod_add_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.prod_add_btn.Location = new System.Drawing.Point(12, 219);
            this.prod_add_btn.Name = "prod_add_btn";
            this.prod_add_btn.Size = new System.Drawing.Size(114, 36);
            this.prod_add_btn.TabIndex = 6;
            this.prod_add_btn.Text = "დამატება";
            this.prod_add_btn.UseVisualStyleBackColor = true;
            this.prod_add_btn.Click += new System.EventHandler(this.prod_add_btn_Click);
            // 
            // AddProduct_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 268);
            this.Controls.Add(this.prod_add_btn);
            this.Controls.Add(this.vat_ckb);
            this.Controls.Add(this.name_txt);
            this.Controls.Add(this.name_label);
            this.Controls.Add(this.barcode_label);
            this.Controls.Add(this.barcode_txt);
            this.Controls.Add(this.label1);
            this.Name = "AddProduct_Form";
            this.Text = "დასახელების დამატება";
            this.Load += new System.EventHandler(this.ProductAdd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox barcode_txt;
        private System.Windows.Forms.Label barcode_label;
        private System.Windows.Forms.Label name_label;
        private System.Windows.Forms.TextBox name_txt;
        private System.Windows.Forms.CheckBox vat_ckb;
        private System.Windows.Forms.Button prod_add_btn;
    }
}