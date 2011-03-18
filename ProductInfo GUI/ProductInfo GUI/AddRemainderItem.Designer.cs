namespace ProductInfo_UI
{
    partial class AddRemainderItem_Form
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
            this.lbl_wheretoaddrem = new System.Windows.Forms.Label();
            this.cmb_select_remainder = new System.Windows.Forms.ComboBox();
            this.lbl_remainder_chooser = new System.Windows.Forms.Label();
            this.capacity_txt = new System.Windows.Forms.TextBox();
            this.lbl_tevadoba = new System.Windows.Forms.Label();
            this.gpbox_sold_price = new System.Windows.Forms.GroupBox();
            this.piece_price_txt = new System.Windows.Forms.TextBox();
            this.pack_price_txt = new System.Windows.Forms.TextBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.rb_price_packs = new System.Windows.Forms.RadioButton();
            this.gpbox_sold_count = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.pack_count_txt = new System.Windows.Forms.TextBox();
            this.piece_count_txt = new System.Windows.Forms.TextBox();
            this.rb_count_type = new System.Windows.Forms.RadioButton();
            this.btn_add_soldrem = new System.Windows.Forms.Button();
            this.cb_addrem_store_id = new System.Windows.Forms.ComboBox();
            this.lbl_addrem_store_id = new System.Windows.Forms.Label();
            this.btn_add_prodname = new System.Windows.Forms.Button();
            this.gpbox_sold_price.SuspendLayout();
            this.gpbox_sold_count.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_wheretoaddrem
            // 
            this.lbl_wheretoaddrem.AutoSize = true;
            this.lbl_wheretoaddrem.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_wheretoaddrem.Location = new System.Drawing.Point(3, 3);
            this.lbl_wheretoaddrem.Name = "lbl_wheretoaddrem";
            this.lbl_wheretoaddrem.Size = new System.Drawing.Size(275, 36);
            this.lbl_wheretoaddrem.TabIndex = 0;
            this.lbl_wheretoaddrem.Text = "მომწოდებელი: არ არის მითითებული\r\nზედნადების ნომერი: 0145\r\n";
            // 
            // cmb_select_remainder
            // 
            this.cmb_select_remainder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_select_remainder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmb_select_remainder.FormattingEnabled = true;
            this.cmb_select_remainder.Location = new System.Drawing.Point(11, 79);
            this.cmb_select_remainder.Name = "cmb_select_remainder";
            this.cmb_select_remainder.Size = new System.Drawing.Size(280, 24);
            this.cmb_select_remainder.TabIndex = 5;
            this.cmb_select_remainder.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmb_select_remainder_Format);
            // 
            // lbl_remainder_chooser
            // 
            this.lbl_remainder_chooser.AutoSize = true;
            this.lbl_remainder_chooser.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_remainder_chooser.Location = new System.Drawing.Point(8, 52);
            this.lbl_remainder_chooser.Name = "lbl_remainder_chooser";
            this.lbl_remainder_chooser.Size = new System.Drawing.Size(88, 16);
            this.lbl_remainder_chooser.TabIndex = 6;
            this.lbl_remainder_chooser.Text = "დასახელება:";
            // 
            // capacity_txt
            // 
            this.capacity_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.capacity_txt.Location = new System.Drawing.Point(95, 160);
            this.capacity_txt.Name = "capacity_txt";
            this.capacity_txt.Size = new System.Drawing.Size(100, 22);
            this.capacity_txt.TabIndex = 12;
            this.capacity_txt.TextChanged += new System.EventHandler(this.capacity_txt_TextChanged);
            // 
            // lbl_tevadoba
            // 
            this.lbl_tevadoba.AutoSize = true;
            this.lbl_tevadoba.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_tevadoba.Location = new System.Drawing.Point(9, 162);
            this.lbl_tevadoba.Name = "lbl_tevadoba";
            this.lbl_tevadoba.Size = new System.Drawing.Size(70, 16);
            this.lbl_tevadoba.TabIndex = 14;
            this.lbl_tevadoba.Text = "ტევადობა";
            // 
            // gpbox_sold_price
            // 
            this.gpbox_sold_price.Controls.Add(this.piece_price_txt);
            this.gpbox_sold_price.Controls.Add(this.pack_price_txt);
            this.gpbox_sold_price.Controls.Add(this.radioButton3);
            this.gpbox_sold_price.Controls.Add(this.rb_price_packs);
            this.gpbox_sold_price.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gpbox_sold_price.ForeColor = System.Drawing.Color.Black;
            this.gpbox_sold_price.Location = new System.Drawing.Point(12, 300);
            this.gpbox_sold_price.Name = "gpbox_sold_price";
            this.gpbox_sold_price.Size = new System.Drawing.Size(206, 110);
            this.gpbox_sold_price.TabIndex = 13;
            this.gpbox_sold_price.TabStop = false;
            this.gpbox_sold_price.Text = "ფასი";
            // 
            // piece_price_txt
            // 
            this.piece_price_txt.Location = new System.Drawing.Point(92, 63);
            this.piece_price_txt.Name = "piece_price_txt";
            this.piece_price_txt.Size = new System.Drawing.Size(100, 23);
            this.piece_price_txt.TabIndex = 3;
            this.piece_price_txt.TextChanged += new System.EventHandler(this.piece_price_txt_TextChanged);
            // 
            // pack_price_txt
            // 
            this.pack_price_txt.Enabled = false;
            this.pack_price_txt.Location = new System.Drawing.Point(92, 33);
            this.pack_price_txt.Name = "pack_price_txt";
            this.pack_price_txt.Size = new System.Drawing.Size(100, 23);
            this.pack_price_txt.TabIndex = 3;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Checked = true;
            this.radioButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton3.Location = new System.Drawing.Point(8, 64);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(75, 20);
            this.radioButton3.TabIndex = 7;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "საცალო";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // rb_price_packs
            // 
            this.rb_price_packs.AutoSize = true;
            this.rb_price_packs.Enabled = false;
            this.rb_price_packs.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rb_price_packs.Location = new System.Drawing.Point(8, 34);
            this.rb_price_packs.Name = "rb_price_packs";
            this.rb_price_packs.Size = new System.Drawing.Size(66, 20);
            this.rb_price_packs.TabIndex = 7;
            this.rb_price_packs.Text = "ყუთის";
            this.rb_price_packs.UseVisualStyleBackColor = true;
            // 
            // gpbox_sold_count
            // 
            this.gpbox_sold_count.Controls.Add(this.radioButton2);
            this.gpbox_sold_count.Controls.Add(this.pack_count_txt);
            this.gpbox_sold_count.Controls.Add(this.piece_count_txt);
            this.gpbox_sold_count.Controls.Add(this.rb_count_type);
            this.gpbox_sold_count.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gpbox_sold_count.ForeColor = System.Drawing.Color.Black;
            this.gpbox_sold_count.Location = new System.Drawing.Point(11, 194);
            this.gpbox_sold_count.Name = "gpbox_sold_count";
            this.gpbox_sold_count.Size = new System.Drawing.Size(207, 100);
            this.gpbox_sold_count.TabIndex = 11;
            this.gpbox_sold_count.TabStop = false;
            this.gpbox_sold_count.Text = "რაოდენობა";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(9, 60);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(86, 20);
            this.radioButton2.TabIndex = 7;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "ცალობით";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // pack_count_txt
            // 
            this.pack_count_txt.Enabled = false;
            this.pack_count_txt.Location = new System.Drawing.Point(98, 28);
            this.pack_count_txt.Name = "pack_count_txt";
            this.pack_count_txt.Size = new System.Drawing.Size(95, 23);
            this.pack_count_txt.TabIndex = 2;
            // 
            // piece_count_txt
            // 
            this.piece_count_txt.Location = new System.Drawing.Point(98, 59);
            this.piece_count_txt.Name = "piece_count_txt";
            this.piece_count_txt.Size = new System.Drawing.Size(95, 23);
            this.piece_count_txt.TabIndex = 2;
            this.piece_count_txt.TextChanged += new System.EventHandler(this.piece_count_txt_TextChanged);
            // 
            // rb_count_type
            // 
            this.rb_count_type.AutoSize = true;
            this.rb_count_type.Enabled = false;
            this.rb_count_type.Location = new System.Drawing.Point(9, 29);
            this.rb_count_type.Name = "rb_count_type";
            this.rb_count_type.Size = new System.Drawing.Size(86, 20);
            this.rb_count_type.TabIndex = 7;
            this.rb_count_type.Text = "ყუთობით";
            this.rb_count_type.UseVisualStyleBackColor = true;
            // 
            // btn_add_soldrem
            // 
            this.btn_add_soldrem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_add_soldrem.Location = new System.Drawing.Point(12, 425);
            this.btn_add_soldrem.Name = "btn_add_soldrem";
            this.btn_add_soldrem.Size = new System.Drawing.Size(94, 28);
            this.btn_add_soldrem.TabIndex = 10;
            this.btn_add_soldrem.Text = "დამატება";
            this.btn_add_soldrem.UseVisualStyleBackColor = true;
            this.btn_add_soldrem.Click += new System.EventHandler(this.btn_add_soldrem_Click);
            // 
            // cb_addrem_store_id
            // 
            this.cb_addrem_store_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_addrem_store_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cb_addrem_store_id.FormattingEnabled = true;
            this.cb_addrem_store_id.Items.AddRange(new object[] {
            "მონიშნეთ საწყობი",
            "პირველი",
            "მეორე"});
            this.cb_addrem_store_id.Location = new System.Drawing.Point(95, 118);
            this.cb_addrem_store_id.Name = "cb_addrem_store_id";
            this.cb_addrem_store_id.Size = new System.Drawing.Size(144, 24);
            this.cb_addrem_store_id.TabIndex = 16;
            // 
            // lbl_addrem_store_id
            // 
            this.lbl_addrem_store_id.AutoSize = true;
            this.lbl_addrem_store_id.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbl_addrem_store_id.Location = new System.Drawing.Point(11, 121);
            this.lbl_addrem_store_id.Name = "lbl_addrem_store_id";
            this.lbl_addrem_store_id.Size = new System.Drawing.Size(64, 16);
            this.lbl_addrem_store_id.TabIndex = 15;
            this.lbl_addrem_store_id.Text = "საწყობი:";
            // 
            // btn_add_prodname
            // 
            this.btn_add_prodname.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_add_prodname.Image = global::ProductInfo_UI.Properties.Resources.item_add_21x21;
            this.btn_add_prodname.Location = new System.Drawing.Point(297, 81);
            this.btn_add_prodname.Name = "btn_add_prodname";
            this.btn_add_prodname.Size = new System.Drawing.Size(21, 21);
            this.btn_add_prodname.TabIndex = 17;
            this.btn_add_prodname.UseVisualStyleBackColor = true;
            this.btn_add_prodname.Click += new System.EventHandler(this.btn_add_prodname_Click);
            // 
            // AddRemainderItem_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 516);
            this.Controls.Add(this.btn_add_prodname);
            this.Controls.Add(this.cb_addrem_store_id);
            this.Controls.Add(this.lbl_addrem_store_id);
            this.Controls.Add(this.capacity_txt);
            this.Controls.Add(this.lbl_tevadoba);
            this.Controls.Add(this.gpbox_sold_price);
            this.Controls.Add(this.gpbox_sold_count);
            this.Controls.Add(this.btn_add_soldrem);
            this.Controls.Add(this.lbl_remainder_chooser);
            this.Controls.Add(this.cmb_select_remainder);
            this.Controls.Add(this.lbl_wheretoaddrem);
            this.Name = "AddRemainderItem_Form";
            this.Text = "ზედნადებში პროდუქტის დამატება";
            this.Load += new System.EventHandler(this.AddRemainderItem_Form_Load);
            this.gpbox_sold_price.ResumeLayout(false);
            this.gpbox_sold_price.PerformLayout();
            this.gpbox_sold_count.ResumeLayout(false);
            this.gpbox_sold_count.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_wheretoaddrem;
        private System.Windows.Forms.ComboBox cmb_select_remainder;
        private System.Windows.Forms.Label lbl_remainder_chooser;
        private System.Windows.Forms.TextBox capacity_txt;
        private System.Windows.Forms.Label lbl_tevadoba;
        private System.Windows.Forms.GroupBox gpbox_sold_price;
        private System.Windows.Forms.TextBox piece_price_txt;
        private System.Windows.Forms.TextBox pack_price_txt;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton rb_price_packs;
        private System.Windows.Forms.GroupBox gpbox_sold_count;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.TextBox pack_count_txt;
        private System.Windows.Forms.TextBox piece_count_txt;
        private System.Windows.Forms.RadioButton rb_count_type;
        private System.Windows.Forms.Button btn_add_soldrem;
        private System.Windows.Forms.ComboBox cb_addrem_store_id;
        private System.Windows.Forms.Label lbl_addrem_store_id;
        private System.Windows.Forms.Button btn_add_prodname;
    }
}