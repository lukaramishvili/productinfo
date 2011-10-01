namespace ProductInfo_UI
{
    partial class MoneyTransfer_Form
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
            this.client_chooser = new System.Windows.Forms.ComboBox();
            this.rb_supplier = new System.Windows.Forms.RadioButton();
            this.rb_buyer = new System.Windows.Forms.RadioButton();
            this.giving_txt = new System.Windows.Forms.TextBox();
            this.taking_txt = new System.Windows.Forms.TextBox();
            this.transfer_submit_btn = new System.Windows.Forms.Button();
            this.rb_taking = new System.Windows.Forms.RadioButton();
            this.rb_giving = new System.Windows.Forms.RadioButton();
            this.panel_client_type_chooser = new System.Windows.Forms.Panel();
            this.lbl_mt_store_id = new System.Windows.Forms.Label();
            this.cb_mt_store_id = new System.Windows.Forms.ComboBox();
            this.transfer_purpose_chooser = new System.Windows.Forms.ComboBox();
            this.target_type_chooser = new System.Windows.Forms.ComboBox();
            this.lbl_mt_target_type = new System.Windows.Forms.Label();
            this.lbl_mt_target_ident = new System.Windows.Forms.Label();
            this.target_ident_chooser = new System.Windows.Forms.ComboBox();
            this.lbl_mt_transfer_purpose = new System.Windows.Forms.Label();
            this.gpbox_cashbox_operation = new System.Windows.Forms.GroupBox();
            this.lbl_cashbox_id = new System.Windows.Forms.Label();
            this.lbl_cashier_id = new System.Windows.Forms.Label();
            this.cmb_cashbox_id = new System.Windows.Forms.ComboBox();
            this.cmb_cashier_id = new System.Windows.Forms.ComboBox();
            this.panel_client_type_chooser.SuspendLayout();
            this.gpbox_cashbox_operation.SuspendLayout();
            this.SuspendLayout();
            // 
            // client_chooser
            // 
            this.client_chooser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.client_chooser.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.client_chooser.FormattingEnabled = true;
            this.client_chooser.Location = new System.Drawing.Point(12, 70);
            this.client_chooser.Name = "client_chooser";
            this.client_chooser.Size = new System.Drawing.Size(210, 24);
            this.client_chooser.TabIndex = 0;
            // 
            // rb_supplier
            // 
            this.rb_supplier.AutoSize = true;
            this.rb_supplier.Checked = true;
            this.rb_supplier.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rb_supplier.Location = new System.Drawing.Point(12, 12);
            this.rb_supplier.Name = "rb_supplier";
            this.rb_supplier.Size = new System.Drawing.Size(117, 20);
            this.rb_supplier.TabIndex = 1;
            this.rb_supplier.TabStop = true;
            this.rb_supplier.Text = "მომწოდებელი";
            this.rb_supplier.UseVisualStyleBackColor = true;
            this.rb_supplier.CheckedChanged += new System.EventHandler(this.rb_supplier_CheckedChanged);
            // 
            // rb_buyer
            // 
            this.rb_buyer.AutoSize = true;
            this.rb_buyer.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rb_buyer.Location = new System.Drawing.Point(12, 36);
            this.rb_buyer.Name = "rb_buyer";
            this.rb_buyer.Size = new System.Drawing.Size(90, 20);
            this.rb_buyer.TabIndex = 1;
            this.rb_buyer.TabStop = true;
            this.rb_buyer.Text = "მყიდველი";
            this.rb_buyer.UseVisualStyleBackColor = true;
            this.rb_buyer.CheckedChanged += new System.EventHandler(this.rb_buyer_CheckedChanged);
            // 
            // giving_txt
            // 
            this.giving_txt.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.giving_txt.Location = new System.Drawing.Point(104, 187);
            this.giving_txt.Name = "giving_txt";
            this.giving_txt.Size = new System.Drawing.Size(118, 23);
            this.giving_txt.TabIndex = 3;
            this.giving_txt.Text = "0";
            // 
            // taking_txt
            // 
            this.taking_txt.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.taking_txt.Location = new System.Drawing.Point(104, 227);
            this.taking_txt.Name = "taking_txt";
            this.taking_txt.Size = new System.Drawing.Size(118, 23);
            this.taking_txt.TabIndex = 3;
            this.taking_txt.Text = "0";
            // 
            // transfer_submit_btn
            // 
            this.transfer_submit_btn.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.transfer_submit_btn.Location = new System.Drawing.Point(12, 265);
            this.transfer_submit_btn.Name = "transfer_submit_btn";
            this.transfer_submit_btn.Size = new System.Drawing.Size(87, 28);
            this.transfer_submit_btn.TabIndex = 4;
            this.transfer_submit_btn.Text = "გადატანა";
            this.transfer_submit_btn.UseVisualStyleBackColor = true;
            this.transfer_submit_btn.Click += new System.EventHandler(this.transfer_submit_btn_Click);
            // 
            // rb_taking
            // 
            this.rb_taking.AutoSize = true;
            this.rb_taking.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rb_taking.Location = new System.Drawing.Point(12, 229);
            this.rb_taking.Name = "rb_taking";
            this.rb_taking.Size = new System.Drawing.Size(90, 20);
            this.rb_taking.TabIndex = 5;
            this.rb_taking.TabStop = true;
            this.rb_taking.Text = "ვართმევთ";
            this.rb_taking.UseVisualStyleBackColor = true;
            this.rb_taking.CheckedChanged += new System.EventHandler(this.rb_taking_CheckedChanged);
            // 
            // rb_giving
            // 
            this.rb_giving.AutoSize = true;
            this.rb_giving.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rb_giving.Location = new System.Drawing.Point(12, 189);
            this.rb_giving.Name = "rb_giving";
            this.rb_giving.Size = new System.Drawing.Size(82, 20);
            this.rb_giving.TabIndex = 6;
            this.rb_giving.TabStop = true;
            this.rb_giving.Text = "ვაძლევთ";
            this.rb_giving.UseVisualStyleBackColor = true;
            this.rb_giving.CheckedChanged += new System.EventHandler(this.rb_giving_CheckedChanged);
            // 
            // panel_client_type_chooser
            // 
            this.panel_client_type_chooser.Controls.Add(this.rb_supplier);
            this.panel_client_type_chooser.Controls.Add(this.rb_buyer);
            this.panel_client_type_chooser.Location = new System.Drawing.Point(0, 0);
            this.panel_client_type_chooser.Name = "panel_client_type_chooser";
            this.panel_client_type_chooser.Size = new System.Drawing.Size(237, 64);
            this.panel_client_type_chooser.TabIndex = 7;
            // 
            // lbl_mt_store_id
            // 
            this.lbl_mt_store_id.AutoSize = true;
            this.lbl_mt_store_id.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbl_mt_store_id.Location = new System.Drawing.Point(11, 147);
            this.lbl_mt_store_id.Name = "lbl_mt_store_id";
            this.lbl_mt_store_id.Size = new System.Drawing.Size(64, 16);
            this.lbl_mt_store_id.TabIndex = 8;
            this.lbl_mt_store_id.Text = "სალარო:";
            // 
            // cb_mt_store_id
            // 
            this.cb_mt_store_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_mt_store_id.FormattingEnabled = true;
            this.cb_mt_store_id.Location = new System.Drawing.Point(104, 146);
            this.cb_mt_store_id.Name = "cb_mt_store_id";
            this.cb_mt_store_id.Size = new System.Drawing.Size(118, 21);
            this.cb_mt_store_id.TabIndex = 9;
            // 
            // transfer_purpose_chooser
            // 
            this.transfer_purpose_chooser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.transfer_purpose_chooser.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.transfer_purpose_chooser.FormattingEnabled = true;
            this.transfer_purpose_chooser.Location = new System.Drawing.Point(111, 107);
            this.transfer_purpose_chooser.Name = "transfer_purpose_chooser";
            this.transfer_purpose_chooser.Size = new System.Drawing.Size(111, 21);
            this.transfer_purpose_chooser.TabIndex = 0;
            this.transfer_purpose_chooser.SelectedIndexChanged += new System.EventHandler(this.transfer_purpose_chooser_SelectedIndexChanged);
            // 
            // target_type_chooser
            // 
            this.target_type_chooser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.target_type_chooser.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.target_type_chooser.FormattingEnabled = true;
            this.target_type_chooser.Items.AddRange(new object[] {
            "ზედნადები"});
            this.target_type_chooser.Location = new System.Drawing.Point(361, 70);
            this.target_type_chooser.Name = "target_type_chooser";
            this.target_type_chooser.Size = new System.Drawing.Size(133, 24);
            this.target_type_chooser.TabIndex = 0;
            this.target_type_chooser.SelectedIndexChanged += new System.EventHandler(this.target_type_chooser_SelectedIndexChanged);
            // 
            // lbl_mt_target_type
            // 
            this.lbl_mt_target_type.AutoSize = true;
            this.lbl_mt_target_type.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbl_mt_target_type.Location = new System.Drawing.Point(233, 74);
            this.lbl_mt_target_type.Name = "lbl_mt_target_type";
            this.lbl_mt_target_type.Size = new System.Drawing.Size(125, 16);
            this.lbl_mt_target_type.TabIndex = 10;
            this.lbl_mt_target_type.Text = "დოკუმენტის ტიპი:";
            // 
            // lbl_mt_target_ident
            // 
            this.lbl_mt_target_ident.AutoSize = true;
            this.lbl_mt_target_ident.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbl_mt_target_ident.Location = new System.Drawing.Point(228, 111);
            this.lbl_mt_target_ident.Name = "lbl_mt_target_ident";
            this.lbl_mt_target_ident.Size = new System.Drawing.Size(130, 16);
            this.lbl_mt_target_ident.TabIndex = 12;
            this.lbl_mt_target_ident.Text = "დოკ. იდენტ. კოდი:";
            // 
            // target_ident_chooser
            // 
            this.target_ident_chooser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.target_ident_chooser.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.target_ident_chooser.FormattingEnabled = true;
            this.target_ident_chooser.Location = new System.Drawing.Point(360, 107);
            this.target_ident_chooser.Name = "target_ident_chooser";
            this.target_ident_chooser.Size = new System.Drawing.Size(134, 24);
            this.target_ident_chooser.TabIndex = 11;
            // 
            // lbl_mt_transfer_purpose
            // 
            this.lbl_mt_transfer_purpose.AutoSize = true;
            this.lbl_mt_transfer_purpose.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbl_mt_transfer_purpose.Location = new System.Drawing.Point(11, 110);
            this.lbl_mt_transfer_purpose.Name = "lbl_mt_transfer_purpose";
            this.lbl_mt_transfer_purpose.Size = new System.Drawing.Size(98, 16);
            this.lbl_mt_transfer_purpose.TabIndex = 8;
            this.lbl_mt_transfer_purpose.Text = "დანიშნულება:";
            // 
            // gpbox_cashbox_operation
            // 
            this.gpbox_cashbox_operation.Controls.Add(this.cmb_cashier_id);
            this.gpbox_cashbox_operation.Controls.Add(this.cmb_cashbox_id);
            this.gpbox_cashbox_operation.Controls.Add(this.lbl_cashier_id);
            this.gpbox_cashbox_operation.Controls.Add(this.lbl_cashbox_id);
            this.gpbox_cashbox_operation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbox_cashbox_operation.Location = new System.Drawing.Point(236, 173);
            this.gpbox_cashbox_operation.Name = "gpbox_cashbox_operation";
            this.gpbox_cashbox_operation.Size = new System.Drawing.Size(258, 96);
            this.gpbox_cashbox_operation.TabIndex = 13;
            this.gpbox_cashbox_operation.TabStop = false;
            this.gpbox_cashbox_operation.Text = "სალარო ოპერაცია";
            // 
            // lbl_cashbox_id
            // 
            this.lbl_cashbox_id.AutoSize = true;
            this.lbl_cashbox_id.Location = new System.Drawing.Point(7, 30);
            this.lbl_cashbox_id.Name = "lbl_cashbox_id";
            this.lbl_cashbox_id.Size = new System.Drawing.Size(118, 16);
            this.lbl_cashbox_id.TabIndex = 0;
            this.lbl_cashbox_id.Text = "სალაროს ნომერი";
            // 
            // lbl_cashier_id
            // 
            this.lbl_cashier_id.AutoSize = true;
            this.lbl_cashier_id.Location = new System.Drawing.Point(7, 63);
            this.lbl_cashier_id.Name = "lbl_cashier_id";
            this.lbl_cashier_id.Size = new System.Drawing.Size(60, 16);
            this.lbl_cashier_id.TabIndex = 1;
            this.lbl_cashier_id.Text = "მოლარე";
            this.lbl_cashier_id.Visible = false;
            // 
            // cmb_cashbox_id
            // 
            this.cmb_cashbox_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_cashbox_id.FormattingEnabled = true;
            this.cmb_cashbox_id.Location = new System.Drawing.Point(129, 26);
            this.cmb_cashbox_id.Name = "cmb_cashbox_id";
            this.cmb_cashbox_id.Size = new System.Drawing.Size(121, 24);
            this.cmb_cashbox_id.TabIndex = 2;
            // 
            // cmb_cashier_id
            // 
            this.cmb_cashier_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_cashier_id.FormattingEnabled = true;
            this.cmb_cashier_id.Location = new System.Drawing.Point(129, 59);
            this.cmb_cashier_id.Name = "cmb_cashier_id";
            this.cmb_cashier_id.Size = new System.Drawing.Size(121, 24);
            this.cmb_cashier_id.TabIndex = 3;
            this.cmb_cashier_id.Visible = false;
            // 
            // MoneyTransfer_Form
            // 
            this.AcceptButton = this.transfer_submit_btn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 310);
            this.Controls.Add(this.gpbox_cashbox_operation);
            this.Controls.Add(this.lbl_mt_target_ident);
            this.Controls.Add(this.target_ident_chooser);
            this.Controls.Add(this.lbl_mt_target_type);
            this.Controls.Add(this.cb_mt_store_id);
            this.Controls.Add(this.lbl_mt_transfer_purpose);
            this.Controls.Add(this.lbl_mt_store_id);
            this.Controls.Add(this.panel_client_type_chooser);
            this.Controls.Add(this.rb_giving);
            this.Controls.Add(this.rb_taking);
            this.Controls.Add(this.transfer_submit_btn);
            this.Controls.Add(this.taking_txt);
            this.Controls.Add(this.giving_txt);
            this.Controls.Add(this.transfer_purpose_chooser);
            this.Controls.Add(this.target_type_chooser);
            this.Controls.Add(this.client_chooser);
            this.Name = "MoneyTransfer_Form";
            this.Text = "MoneyTransfer";
            this.Load += new System.EventHandler(this.MoneyTransfer_Form_Load);
            this.panel_client_type_chooser.ResumeLayout(false);
            this.panel_client_type_chooser.PerformLayout();
            this.gpbox_cashbox_operation.ResumeLayout(false);
            this.gpbox_cashbox_operation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox client_chooser;
        private System.Windows.Forms.RadioButton rb_supplier;
        private System.Windows.Forms.RadioButton rb_buyer;
        private System.Windows.Forms.TextBox giving_txt;
        private System.Windows.Forms.TextBox taking_txt;
        private System.Windows.Forms.Button transfer_submit_btn;
        private System.Windows.Forms.RadioButton rb_taking;
        private System.Windows.Forms.RadioButton rb_giving;
        private System.Windows.Forms.Panel panel_client_type_chooser;
        private System.Windows.Forms.Label lbl_mt_store_id;
        private System.Windows.Forms.ComboBox cb_mt_store_id;
        private System.Windows.Forms.ComboBox transfer_purpose_chooser;
        private System.Windows.Forms.ComboBox target_type_chooser;
        private System.Windows.Forms.Label lbl_mt_target_type;
        private System.Windows.Forms.Label lbl_mt_target_ident;
        private System.Windows.Forms.ComboBox target_ident_chooser;
        private System.Windows.Forms.Label lbl_mt_transfer_purpose;
        private System.Windows.Forms.GroupBox gpbox_cashbox_operation;
        private System.Windows.Forms.Label lbl_cashbox_id;
        private System.Windows.Forms.ComboBox cmb_cashier_id;
        private System.Windows.Forms.ComboBox cmb_cashbox_id;
        private System.Windows.Forms.Label lbl_cashier_id;
    }
}