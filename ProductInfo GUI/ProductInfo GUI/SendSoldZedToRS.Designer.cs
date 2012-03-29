namespace ProductInfo_UI
{
    partial class SendSoldZedToRS
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
            this.btnSendZedToRS = new System.Windows.Forms.Button();
            this.lbl_start_address = new System.Windows.Forms.Label();
            this.txt_start_address = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSendZedToRS
            // 
            this.btnSendZedToRS.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendZedToRS.Location = new System.Drawing.Point(158, 331);
            this.btnSendZedToRS.Name = "btnSendZedToRS";
            this.btnSendZedToRS.Size = new System.Drawing.Size(100, 48);
            this.btnSendZedToRS.TabIndex = 0;
            this.btnSendZedToRS.Text = "გაგზავნა";
            this.btnSendZedToRS.UseVisualStyleBackColor = true;
            this.btnSendZedToRS.Click += new System.EventHandler(this.btnSendZedToRS_Click);
            // 
            // lbl_start_address
            // 
            this.lbl_start_address.AutoSize = true;
            this.lbl_start_address.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_start_address.Location = new System.Drawing.Point(9, 45);
            this.lbl_start_address.Name = "lbl_start_address";
            this.lbl_start_address.Size = new System.Drawing.Size(242, 18);
            this.lbl_start_address.TabIndex = 1;
            this.lbl_start_address.Text = "ტრანსპორტირების დაწყების ადგილი";
            // 
            // txt_start_address
            // 
            this.txt_start_address.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_start_address.Location = new System.Drawing.Point(12, 75);
            this.txt_start_address.Name = "txt_start_address";
            this.txt_start_address.Size = new System.Drawing.Size(194, 26);
            this.txt_start_address.TabIndex = 2;
            // 
            // SendSoldZedToRS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 391);
            this.Controls.Add(this.txt_start_address);
            this.Controls.Add(this.lbl_start_address);
            this.Controls.Add(this.btnSendZedToRS);
            this.Name = "SendSoldZedToRS";
            this.Text = "SendSoldZedToRS";
            this.Load += new System.EventHandler(this.SendSoldZedToRS_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSendZedToRS;
        private System.Windows.Forms.Label lbl_start_address;
        private System.Windows.Forms.TextBox txt_start_address;
    }
}