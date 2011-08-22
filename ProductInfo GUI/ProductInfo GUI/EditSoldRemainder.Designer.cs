namespace ProductInfo_UI
{
    partial class EditSoldRemainder_Form
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
            this.attributes_lbl = new System.Windows.Forms.Label();
            this.pack_count_txt = new System.Windows.Forms.TextBox();
            this.pack_price_txt = new System.Windows.Forms.TextBox();
            this.btn_update_soldrem = new System.Windows.Forms.Button();
            this.piece_price_txt = new System.Windows.Forms.TextBox();
            this.piece_count_txt = new System.Windows.Forms.TextBox();
            this.rb_count_type = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.rb_price_packs = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.gpbox_sold_count = new System.Windows.Forms.GroupBox();
            this.gpbox_sold_price = new System.Windows.Forms.GroupBox();
            this.lbl_tevadoba = new System.Windows.Forms.Label();
            this.capacity_txt = new System.Windows.Forms.TextBox();
            this.gpbox_rem_sell_price = new System.Windows.Forms.GroupBox();
            this.rem_sell_price_piece_txt = new System.Windows.Forms.TextBox();
            this.rem_sell_price_pack_txt = new System.Windows.Forms.TextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.rb_rem_sell_price_packs = new System.Windows.Forms.RadioButton();
            this.gpbox_sold_count.SuspendLayout();
            this.gpbox_sold_price.SuspendLayout();
            this.gpbox_rem_sell_price.SuspendLayout();
            this.SuspendLayout();
            // 
            // attributes_lbl
            // 
            this.attributes_lbl.AutoSize = true;
            this.attributes_lbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.attributes_lbl.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.attributes_lbl.Location = new System.Drawing.Point(0, 0);
            this.attributes_lbl.Name = "attributes_lbl";
            this.attributes_lbl.Size = new System.Drawing.Size(274, 64);
            this.attributes_lbl.TabIndex = 1;
            this.attributes_lbl.Text = "გაყიდვის დრო: 08/08/08 45:45:45 PM\r\nზედნადების ნომერი: 0145\r\nმყიდველი: უცნობია\r\nჩ" +
                "ეკით";
            // 
            // pack_count_txt
            // 
            this.pack_count_txt.Enabled = false;
            this.pack_count_txt.Location = new System.Drawing.Point(98, 28);
            this.pack_count_txt.Name = "pack_count_txt";
            this.pack_count_txt.Size = new System.Drawing.Size(95, 23);
            this.pack_count_txt.TabIndex = 2;
            // 
            // pack_price_txt
            // 
            this.pack_price_txt.Enabled = false;
            this.pack_price_txt.Location = new System.Drawing.Point(92, 33);
            this.pack_price_txt.Name = "pack_price_txt";
            this.pack_price_txt.Size = new System.Drawing.Size(100, 23);
            this.pack_price_txt.TabIndex = 3;
            // 
            // btn_update_soldrem
            // 
            this.btn_update_soldrem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_update_soldrem.Location = new System.Drawing.Point(12, 465);
            this.btn_update_soldrem.Name = "btn_update_soldrem";
            this.btn_update_soldrem.Size = new System.Drawing.Size(101, 28);
            this.btn_update_soldrem.TabIndex = 6;
            this.btn_update_soldrem.Text = "განახლება";
            this.btn_update_soldrem.UseVisualStyleBackColor = true;
            this.btn_update_soldrem.Click += new System.EventHandler(this.btn_update_soldrem_Click);
            // 
            // piece_price_txt
            // 
            this.piece_price_txt.Location = new System.Drawing.Point(92, 63);
            this.piece_price_txt.Name = "piece_price_txt";
            this.piece_price_txt.Size = new System.Drawing.Size(100, 23);
            this.piece_price_txt.TabIndex = 3;
            // 
            // piece_count_txt
            // 
            this.piece_count_txt.Location = new System.Drawing.Point(98, 59);
            this.piece_count_txt.Name = "piece_count_txt";
            this.piece_count_txt.Size = new System.Drawing.Size(95, 23);
            this.piece_count_txt.TabIndex = 2;
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
            // gpbox_sold_count
            // 
            this.gpbox_sold_count.Controls.Add(this.radioButton2);
            this.gpbox_sold_count.Controls.Add(this.pack_count_txt);
            this.gpbox_sold_count.Controls.Add(this.piece_count_txt);
            this.gpbox_sold_count.Controls.Add(this.rb_count_type);
            this.gpbox_sold_count.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gpbox_sold_count.ForeColor = System.Drawing.Color.Black;
            this.gpbox_sold_count.Location = new System.Drawing.Point(11, 74);
            this.gpbox_sold_count.Name = "gpbox_sold_count";
            this.gpbox_sold_count.Size = new System.Drawing.Size(207, 100);
            this.gpbox_sold_count.TabIndex = 8;
            this.gpbox_sold_count.TabStop = false;
            this.gpbox_sold_count.Text = "გაყიდული რაოდენობა";
            // 
            // gpbox_sold_price
            // 
            this.gpbox_sold_price.Controls.Add(this.piece_price_txt);
            this.gpbox_sold_price.Controls.Add(this.pack_price_txt);
            this.gpbox_sold_price.Controls.Add(this.radioButton3);
            this.gpbox_sold_price.Controls.Add(this.rb_price_packs);
            this.gpbox_sold_price.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gpbox_sold_price.ForeColor = System.Drawing.Color.Black;
            this.gpbox_sold_price.Location = new System.Drawing.Point(12, 180);
            this.gpbox_sold_price.Name = "gpbox_sold_price";
            this.gpbox_sold_price.Size = new System.Drawing.Size(206, 110);
            this.gpbox_sold_price.TabIndex = 8;
            this.gpbox_sold_price.TabStop = false;
            this.gpbox_sold_price.Text = "ფასი";
            // 
            // lbl_tevadoba
            // 
            this.lbl_tevadoba.AutoSize = true;
            this.lbl_tevadoba.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_tevadoba.Location = new System.Drawing.Point(17, 428);
            this.lbl_tevadoba.Name = "lbl_tevadoba";
            this.lbl_tevadoba.Size = new System.Drawing.Size(70, 16);
            this.lbl_tevadoba.TabIndex = 9;
            this.lbl_tevadoba.Text = "ტევადობა";
            // 
            // capacity_txt
            // 
            this.capacity_txt.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.capacity_txt.Location = new System.Drawing.Point(104, 425);
            this.capacity_txt.Name = "capacity_txt";
            this.capacity_txt.Size = new System.Drawing.Size(100, 23);
            this.capacity_txt.TabIndex = 8;
            // 
            // gpbox_rem_sell_price
            // 
            this.gpbox_rem_sell_price.Controls.Add(this.rem_sell_price_piece_txt);
            this.gpbox_rem_sell_price.Controls.Add(this.rem_sell_price_pack_txt);
            this.gpbox_rem_sell_price.Controls.Add(this.radioButton1);
            this.gpbox_rem_sell_price.Controls.Add(this.rb_rem_sell_price_packs);
            this.gpbox_rem_sell_price.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gpbox_rem_sell_price.ForeColor = System.Drawing.Color.Black;
            this.gpbox_rem_sell_price.Location = new System.Drawing.Point(12, 297);
            this.gpbox_rem_sell_price.Name = "gpbox_rem_sell_price";
            this.gpbox_rem_sell_price.Size = new System.Drawing.Size(206, 110);
            this.gpbox_rem_sell_price.TabIndex = 9;
            this.gpbox_rem_sell_price.TabStop = false;
            this.gpbox_rem_sell_price.Text = "გასაყიდი ფასი";
            // 
            // rem_sell_price_piece_txt
            // 
            this.rem_sell_price_piece_txt.Location = new System.Drawing.Point(92, 63);
            this.rem_sell_price_piece_txt.Name = "rem_sell_price_piece_txt";
            this.rem_sell_price_piece_txt.Size = new System.Drawing.Size(100, 23);
            this.rem_sell_price_piece_txt.TabIndex = 3;
            // 
            // rem_sell_price_pack_txt
            // 
            this.rem_sell_price_pack_txt.Enabled = false;
            this.rem_sell_price_pack_txt.Location = new System.Drawing.Point(92, 33);
            this.rem_sell_price_pack_txt.Name = "rem_sell_price_pack_txt";
            this.rem_sell_price_pack_txt.Size = new System.Drawing.Size(100, 23);
            this.rem_sell_price_pack_txt.TabIndex = 3;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton1.Location = new System.Drawing.Point(8, 64);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(75, 20);
            this.radioButton1.TabIndex = 7;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "საცალო";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // rb_rem_sell_price_packs
            // 
            this.rb_rem_sell_price_packs.AutoSize = true;
            this.rb_rem_sell_price_packs.Enabled = false;
            this.rb_rem_sell_price_packs.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rb_rem_sell_price_packs.Location = new System.Drawing.Point(8, 34);
            this.rb_rem_sell_price_packs.Name = "rb_rem_sell_price_packs";
            this.rb_rem_sell_price_packs.Size = new System.Drawing.Size(66, 20);
            this.rb_rem_sell_price_packs.TabIndex = 7;
            this.rb_rem_sell_price_packs.Text = "ყუთის";
            this.rb_rem_sell_price_packs.UseVisualStyleBackColor = true;
            // 
            // EditSoldRemainder_Form
            // 
            this.AcceptButton = this.btn_update_soldrem;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 512);
            this.Controls.Add(this.gpbox_rem_sell_price);
            this.Controls.Add(this.capacity_txt);
            this.Controls.Add(this.lbl_tevadoba);
            this.Controls.Add(this.gpbox_sold_price);
            this.Controls.Add(this.gpbox_sold_count);
            this.Controls.Add(this.btn_update_soldrem);
            this.Controls.Add(this.attributes_lbl);
            this.MaximizeBox = false;
            this.Name = "EditSoldRemainder_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "გაყიდული პროდუქტის შეცვლა";
            this.Load += new System.EventHandler(this.EditSoldRemainder_Form_Load);
            this.gpbox_sold_count.ResumeLayout(false);
            this.gpbox_sold_count.PerformLayout();
            this.gpbox_sold_price.ResumeLayout(false);
            this.gpbox_sold_price.PerformLayout();
            this.gpbox_rem_sell_price.ResumeLayout(false);
            this.gpbox_rem_sell_price.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label attributes_lbl;
        private System.Windows.Forms.TextBox pack_count_txt;
        private System.Windows.Forms.TextBox pack_price_txt;
        private System.Windows.Forms.Button btn_update_soldrem;
        private System.Windows.Forms.TextBox piece_price_txt;
        private System.Windows.Forms.TextBox piece_count_txt;
        private System.Windows.Forms.RadioButton rb_count_type;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton rb_price_packs;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.GroupBox gpbox_sold_count;
        private System.Windows.Forms.GroupBox gpbox_sold_price;
        private System.Windows.Forms.Label lbl_tevadoba;
        private System.Windows.Forms.TextBox capacity_txt;
        private System.Windows.Forms.GroupBox gpbox_rem_sell_price;
        private System.Windows.Forms.TextBox rem_sell_price_piece_txt;
        private System.Windows.Forms.TextBox rem_sell_price_pack_txt;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton rb_rem_sell_price_packs;
    }
}