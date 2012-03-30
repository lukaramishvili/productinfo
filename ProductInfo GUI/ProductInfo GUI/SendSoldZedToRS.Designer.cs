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
            this.ck_buyer_is_georgian = new System.Windows.Forms.CheckBox();
            this.txt_end_address = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ck_driver_is_georgian = new System.Windows.Forms.CheckBox();
            this.txt_driver_name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_driver_ident = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_transp_cost = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_car_number = new System.Windows.Forms.TextBox();
            this.dt_begin_date = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.ck_trans_cost_payer = new System.Windows.Forms.CheckBox();
            this.cb_rs_trans_type_id = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_transp_type_name = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cb_rs_wb_type = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnSendZedToRS
            // 
            this.btnSendZedToRS.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendZedToRS.Location = new System.Drawing.Point(164, 623);
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
            this.lbl_start_address.Location = new System.Drawing.Point(9, 86);
            this.lbl_start_address.Name = "lbl_start_address";
            this.lbl_start_address.Size = new System.Drawing.Size(242, 18);
            this.lbl_start_address.TabIndex = 1;
            this.lbl_start_address.Text = "ტრანსპორტირების დაწყების ადგილი";
            // 
            // txt_start_address
            // 
            this.txt_start_address.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_start_address.Location = new System.Drawing.Point(281, 82);
            this.txt_start_address.Name = "txt_start_address";
            this.txt_start_address.Size = new System.Drawing.Size(335, 26);
            this.txt_start_address.TabIndex = 2;
            // 
            // ck_buyer_is_georgian
            // 
            this.ck_buyer_is_georgian.AutoSize = true;
            this.ck_buyer_is_georgian.Checked = true;
            this.ck_buyer_is_georgian.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ck_buyer_is_georgian.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ck_buyer_is_georgian.Location = new System.Drawing.Point(12, 54);
            this.ck_buyer_is_georgian.Name = "ck_buyer_is_georgian";
            this.ck_buyer_is_georgian.Size = new System.Drawing.Size(252, 22);
            this.ck_buyer_is_georgian.TabIndex = 3;
            this.ck_buyer_is_georgian.Text = "მყიდველი საქართველოს მოქალაქეა";
            this.ck_buyer_is_georgian.UseVisualStyleBackColor = true;
            // 
            // txt_end_address
            // 
            this.txt_end_address.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_end_address.Location = new System.Drawing.Point(281, 130);
            this.txt_end_address.Name = "txt_end_address";
            this.txt_end_address.Size = new System.Drawing.Size(335, 26);
            this.txt_end_address.TabIndex = 5;
            this.txt_end_address.TextChanged += new System.EventHandler(this.txt_end_address_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "ტრანსპორტირების დასრულების ადგილი";
            // 
            // ck_driver_is_georgian
            // 
            this.ck_driver_is_georgian.AutoSize = true;
            this.ck_driver_is_georgian.Checked = true;
            this.ck_driver_is_georgian.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ck_driver_is_georgian.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ck_driver_is_georgian.Location = new System.Drawing.Point(12, 216);
            this.ck_driver_is_georgian.Name = "ck_driver_is_georgian";
            this.ck_driver_is_georgian.Size = new System.Drawing.Size(238, 22);
            this.ck_driver_is_georgian.TabIndex = 8;
            this.ck_driver_is_georgian.Text = "მძღოლი საქართველოს მოქალაქეა";
            this.ck_driver_is_georgian.UseVisualStyleBackColor = true;
            // 
            // txt_driver_name
            // 
            this.txt_driver_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_driver_name.Location = new System.Drawing.Point(281, 252);
            this.txt_driver_name.Name = "txt_driver_name";
            this.txt_driver_name.Size = new System.Drawing.Size(335, 26);
            this.txt_driver_name.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 256);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 18);
            this.label3.TabIndex = 9;
            this.label3.Text = "მძღოლის სახელი";
            // 
            // txt_driver_ident
            // 
            this.txt_driver_ident.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_driver_ident.Location = new System.Drawing.Point(281, 172);
            this.txt_driver_ident.Name = "txt_driver_ident";
            this.txt_driver_ident.Size = new System.Drawing.Size(335, 26);
            this.txt_driver_ident.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(219, 18);
            this.label2.TabIndex = 10;
            this.label2.Text = "მძღოლის საიდენტიფიკაციო კოდი";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 296);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 18);
            this.label4.TabIndex = 13;
            this.label4.Text = "ტრანსპორტირების ფასი";
            // 
            // txt_transp_cost
            // 
            this.txt_transp_cost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_transp_cost.Location = new System.Drawing.Point(281, 292);
            this.txt_transp_cost.Name = "txt_transp_cost";
            this.txt_transp_cost.Size = new System.Drawing.Size(335, 26);
            this.txt_transp_cost.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 337);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 18);
            this.label5.TabIndex = 15;
            this.label5.Text = "მანქანის ნომერი";
            // 
            // txt_car_number
            // 
            this.txt_car_number.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_car_number.Location = new System.Drawing.Point(281, 333);
            this.txt_car_number.Name = "txt_car_number";
            this.txt_car_number.Size = new System.Drawing.Size(335, 26);
            this.txt_car_number.TabIndex = 14;
            // 
            // dt_begin_date
            // 
            this.dt_begin_date.CustomFormat = "ddMMMMyyyy, hh:mm:ss";
            this.dt_begin_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_begin_date.Location = new System.Drawing.Point(281, 376);
            this.dt_begin_date.Name = "dt_begin_date";
            this.dt_begin_date.Size = new System.Drawing.Size(335, 20);
            this.dt_begin_date.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 378);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 18);
            this.label6.TabIndex = 17;
            this.label6.Text = "აქტივაციის თარიღი";
            // 
            // ck_trans_cost_payer
            // 
            this.ck_trans_cost_payer.AutoSize = true;
            this.ck_trans_cost_payer.Checked = true;
            this.ck_trans_cost_payer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ck_trans_cost_payer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ck_trans_cost_payer.Location = new System.Drawing.Point(12, 419);
            this.ck_trans_cost_payer.Name = "ck_trans_cost_payer";
            this.ck_trans_cost_payer.Size = new System.Drawing.Size(341, 22);
            this.ck_trans_cost_payer.TabIndex = 18;
            this.ck_trans_cost_payer.Text = "ტრანპორტირების ღირებულებას იხდის მყიდველი";
            this.ck_trans_cost_payer.UseVisualStyleBackColor = true;
            // 
            // cb_rs_trans_type_id
            // 
            this.cb_rs_trans_type_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_rs_trans_type_id.FormattingEnabled = true;
            this.cb_rs_trans_type_id.Location = new System.Drawing.Point(281, 455);
            this.cb_rs_trans_type_id.Name = "cb_rs_trans_type_id";
            this.cb_rs_trans_type_id.Size = new System.Drawing.Size(121, 21);
            this.cb_rs_trans_type_id.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(7, 497);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(221, 18);
            this.label7.TabIndex = 20;
            this.label7.Text = "ტრანსპ. სახე (თუ ტიპი არის სხვა)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(9, 458);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(159, 18);
            this.label8.TabIndex = 21;
            this.label8.Text = "ტრანსპორტირების ტიპი";
            // 
            // txt_transp_type_name
            // 
            this.txt_transp_type_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_transp_type_name.Location = new System.Drawing.Point(281, 493);
            this.txt_transp_type_name.Name = "txt_transp_type_name";
            this.txt_transp_type_name.Size = new System.Drawing.Size(335, 26);
            this.txt_transp_type_name.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(7, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(121, 18);
            this.label9.TabIndex = 24;
            this.label9.Text = "ზედნადების ტიპი";
            // 
            // cb_rs_wb_type
            // 
            this.cb_rs_wb_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_rs_wb_type.FormattingEnabled = true;
            this.cb_rs_wb_type.Location = new System.Drawing.Point(279, 21);
            this.cb_rs_wb_type.Name = "cb_rs_wb_type";
            this.cb_rs_wb_type.Size = new System.Drawing.Size(251, 21);
            this.cb_rs_wb_type.TabIndex = 23;
            // 
            // SendSoldZedToRS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 683);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cb_rs_wb_type);
            this.Controls.Add(this.txt_transp_type_name);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cb_rs_trans_type_id);
            this.Controls.Add(this.ck_trans_cost_payer);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dt_begin_date);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_car_number);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_transp_cost);
            this.Controls.Add(this.txt_driver_ident);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ck_driver_is_georgian);
            this.Controls.Add(this.txt_driver_name);
            this.Controls.Add(this.txt_end_address);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ck_buyer_is_georgian);
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
        private System.Windows.Forms.CheckBox ck_buyer_is_georgian;
        private System.Windows.Forms.TextBox txt_end_address;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ck_driver_is_georgian;
        private System.Windows.Forms.TextBox txt_driver_name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_driver_ident;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_transp_cost;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_car_number;
        private System.Windows.Forms.DateTimePicker dt_begin_date;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox ck_trans_cost_payer;
        private System.Windows.Forms.ComboBox cb_rs_trans_type_id;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_transp_type_name;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cb_rs_wb_type;
    }
}