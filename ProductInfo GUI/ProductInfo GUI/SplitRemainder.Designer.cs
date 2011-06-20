namespace ProductInfo_UI
{
    partial class SplitRemainder_Form
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
            this.lbl_rem_info = new System.Windows.Forms.Label();
            this.txt_store1_count = new System.Windows.Forms.TextBox();
            this.txt_store2_count = new System.Windows.Forms.TextBox();
            this.lbl_store1 = new System.Windows.Forms.Label();
            this.lbl_store2 = new System.Windows.Forms.Label();
            this.submit_btn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_select_remainder = new System.Windows.Forms.ComboBox();
            this.cb_target_store_id = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lbl_rem_info
            // 
            this.lbl_rem_info.AutoSize = true;
            this.lbl_rem_info.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_rem_info.Location = new System.Drawing.Point(3, 61);
            this.lbl_rem_info.Name = "lbl_rem_info";
            this.lbl_rem_info.Size = new System.Drawing.Size(147, 48);
            this.lbl_rem_info.TabIndex = 0;
            this.lbl_rem_info.Text = "პროდუქტი: მარილი\r\nსულ საცალო: 200 ც.\r\nღირებულება: 200 ლ.\r\n";
            // 
            // txt_store1_count
            // 
            this.txt_store1_count.Enabled = false;
            this.txt_store1_count.Location = new System.Drawing.Point(6, 147);
            this.txt_store1_count.Name = "txt_store1_count";
            this.txt_store1_count.Size = new System.Drawing.Size(100, 20);
            this.txt_store1_count.TabIndex = 0;
            this.txt_store1_count.Text = "0";
            // 
            // txt_store2_count
            // 
            this.txt_store2_count.Location = new System.Drawing.Point(6, 212);
            this.txt_store2_count.Name = "txt_store2_count";
            this.txt_store2_count.Size = new System.Drawing.Size(100, 20);
            this.txt_store2_count.TabIndex = 1;
            this.txt_store2_count.Text = "0";
            this.txt_store2_count.TextChanged += new System.EventHandler(this.txt_store2_count_TextChanged);
            // 
            // lbl_store1
            // 
            this.lbl_store1.AutoSize = true;
            this.lbl_store1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_store1.Location = new System.Drawing.Point(3, 125);
            this.lbl_store1.Name = "lbl_store1";
            this.lbl_store1.Size = new System.Drawing.Size(234, 16);
            this.lbl_store1.TabIndex = 0;
            this.lbl_store1.Text = "საწყობ 1–ში არსებული რაოდენობა";
            // 
            // lbl_store2
            // 
            this.lbl_store2.AutoSize = true;
            this.lbl_store2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_store2.Location = new System.Drawing.Point(3, 186);
            this.lbl_store2.Name = "lbl_store2";
            this.lbl_store2.Size = new System.Drawing.Size(183, 16);
            this.lbl_store2.TabIndex = 0;
            this.lbl_store2.Text = "საწყობ                           –ში";
            // 
            // submit_btn
            // 
            this.submit_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submit_btn.Location = new System.Drawing.Point(6, 249);
            this.submit_btn.Name = "submit_btn";
            this.submit_btn.Size = new System.Drawing.Size(88, 29);
            this.submit_btn.TabIndex = 2;
            this.submit_btn.Text = "გადატანა";
            this.submit_btn.UseVisualStyleBackColor = true;
            this.submit_btn.Click += new System.EventHandler(this.submit_btn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "ნაშთი:";
            // 
            // cmb_select_remainder
            // 
            this.cmb_select_remainder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_select_remainder.FormattingEnabled = true;
            this.cmb_select_remainder.Location = new System.Drawing.Point(6, 29);
            this.cmb_select_remainder.Name = "cmb_select_remainder";
            this.cmb_select_remainder.Size = new System.Drawing.Size(228, 21);
            this.cmb_select_remainder.TabIndex = 4;
            this.cmb_select_remainder.SelectedIndexChanged += new System.EventHandler(this.cmb_select_remainder_SelectedIndexChanged);
            // 
            // cb_target_store_id
            // 
            this.cb_target_store_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_target_store_id.FormattingEnabled = true;
            this.cb_target_store_id.Location = new System.Drawing.Point(59, 186);
            this.cb_target_store_id.Name = "cb_target_store_id";
            this.cb_target_store_id.Size = new System.Drawing.Size(93, 21);
            this.cb_target_store_id.TabIndex = 5;
            this.cb_target_store_id.SelectedIndexChanged += new System.EventHandler(this.cb_target_store_id_SelectedIndexChanged);
            // 
            // SplitRemainder_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 295);
            this.Controls.Add(this.cb_target_store_id);
            this.Controls.Add(this.cmb_select_remainder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.submit_btn);
            this.Controls.Add(this.txt_store2_count);
            this.Controls.Add(this.txt_store1_count);
            this.Controls.Add(this.lbl_store2);
            this.Controls.Add(this.lbl_store1);
            this.Controls.Add(this.lbl_rem_info);
            this.Name = "SplitRemainder_Form";
            this.Text = "ნაშთების განაწილება";
            this.Load += new System.EventHandler(this.SplitRemainder_Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_rem_info;
        private System.Windows.Forms.TextBox txt_store1_count;
        private System.Windows.Forms.TextBox txt_store2_count;
        private System.Windows.Forms.Label lbl_store1;
        private System.Windows.Forms.Label lbl_store2;
        private System.Windows.Forms.Button submit_btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_select_remainder;
        private System.Windows.Forms.ComboBox cb_target_store_id;
    }
}