namespace ShopInfo_GUI
{
    partial class frmShopInfoLoginForm
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
            this.cmb_cashier_id = new System.Windows.Forms.ComboBox();
            this.lbl_enter_cashier_name = new System.Windows.Forms.Label();
            this.lbl_enter_cashier_passwd = new System.Windows.Forms.Label();
            this.txtPasswd = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmb_cashier_id
            // 
            this.cmb_cashier_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_cashier_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_cashier_id.FormattingEnabled = true;
            this.cmb_cashier_id.Location = new System.Drawing.Point(67, 95);
            this.cmb_cashier_id.Name = "cmb_cashier_id";
            this.cmb_cashier_id.Size = new System.Drawing.Size(244, 28);
            this.cmb_cashier_id.TabIndex = 0;
            // 
            // lbl_enter_cashier_name
            // 
            this.lbl_enter_cashier_name.AutoSize = true;
            this.lbl_enter_cashier_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_enter_cashier_name.Location = new System.Drawing.Point(62, 43);
            this.lbl_enter_cashier_name.Name = "lbl_enter_cashier_name";
            this.lbl_enter_cashier_name.Size = new System.Drawing.Size(251, 25);
            this.lbl_enter_cashier_name.TabIndex = 1;
            this.lbl_enter_cashier_name.Text = "შეიყვანეთ მოლარის სახელი";
            // 
            // lbl_enter_cashier_passwd
            // 
            this.lbl_enter_cashier_passwd.AutoSize = true;
            this.lbl_enter_cashier_passwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_enter_cashier_passwd.Location = new System.Drawing.Point(100, 156);
            this.lbl_enter_cashier_passwd.Name = "lbl_enter_cashier_passwd";
            this.lbl_enter_cashier_passwd.Size = new System.Drawing.Size(174, 25);
            this.lbl_enter_cashier_passwd.TabIndex = 2;
            this.lbl_enter_cashier_passwd.Text = "შეიყვანეთ პაროლი";
            // 
            // txtPasswd
            // 
            this.txtPasswd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPasswd.Location = new System.Drawing.Point(67, 216);
            this.txtPasswd.Name = "txtPasswd";
            this.txtPasswd.Size = new System.Drawing.Size(244, 26);
            this.txtPasswd.TabIndex = 3;
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(118, 283);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(146, 44);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "შესვლა";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // frmShopInfoLoginForm
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 385);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPasswd);
            this.Controls.Add(this.lbl_enter_cashier_passwd);
            this.Controls.Add(this.lbl_enter_cashier_name);
            this.Controls.Add(this.cmb_cashier_id);
            this.Name = "frmShopInfoLoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "შესვლა";
            this.Load += new System.EventHandler(this.frmShopInfoLoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_cashier_id;
        private System.Windows.Forms.Label lbl_enter_cashier_name;
        private System.Windows.Forms.Label lbl_enter_cashier_passwd;
        private System.Windows.Forms.TextBox txtPasswd;
        private System.Windows.Forms.Button btnLogin;
    }
}