namespace ProductInfo_UI
{
    partial class PrintPreview_Form
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
            this.print_dlg = new System.Windows.Forms.PrintDialog();
            this.print_doc = new System.Drawing.Printing.PrintDocument();
            this.prev_btn = new System.Windows.Forms.Button();
            this.next_btn = new System.Windows.Forms.Button();
            this.print_btn = new System.Windows.Forms.Button();
            this.rb_portrait = new System.Windows.Forms.RadioButton();
            this.rb_landscape = new System.Windows.Forms.RadioButton();
            this.ex1 = new System.Windows.Forms.TextBox();
            this.ex2 = new System.Windows.Forms.TextBox();
            this.ex5 = new System.Windows.Forms.TextBox();
            this.ex_p1 = new System.Windows.Forms.ComboBox();
            this.ex_p2 = new System.Windows.Forms.ComboBox();
            this.ex_p3 = new System.Windows.Forms.ComboBox();
            this.ex_p4 = new System.Windows.Forms.ComboBox();
            this.ex_p5 = new System.Windows.Forms.ComboBox();
            this.ex_p6 = new System.Windows.Forms.ComboBox();
            this.ex_p7 = new System.Windows.Forms.ComboBox();
            this.ex_p8 = new System.Windows.Forms.ComboBox();
            this.ex_p9 = new System.Windows.Forms.ComboBox();
            this.ex_p10 = new System.Windows.Forms.ComboBox();
            this.ex_p11 = new System.Windows.Forms.ComboBox();
            this.ex_p12 = new System.Windows.Forms.ComboBox();
            this.ex_p13 = new System.Windows.Forms.ComboBox();
            this.ex_p14 = new System.Windows.Forms.ComboBox();
            this.ex_p15 = new System.Windows.Forms.ComboBox();
            this.ex_p16 = new System.Windows.Forms.ComboBox();
            this.ex_p17 = new System.Windows.Forms.ComboBox();
            this.ex_p18 = new System.Windows.Forms.ComboBox();
            this.preview_area = new System.Windows.Forms.Panel();
            this.ex4 = new System.Windows.Forms.TextBox();
            this.ex3 = new System.Windows.Forms.TextBox();
            this.ex_p23 = new System.Windows.Forms.ComboBox();
            this.ex_p22 = new System.Windows.Forms.ComboBox();
            this.ex_p21 = new System.Windows.Forms.ComboBox();
            this.ex_p20 = new System.Windows.Forms.ComboBox();
            this.ex_p19 = new System.Windows.Forms.ComboBox();
            this.draw_area = new System.Windows.Forms.PictureBox();
            this.preview_area.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.draw_area)).BeginInit();
            this.SuspendLayout();
            // 
            // print_dlg
            // 
            this.print_dlg.AllowCurrentPage = true;
            this.print_dlg.AllowSelection = true;
            this.print_dlg.AllowSomePages = true;
            this.print_dlg.Document = this.print_doc;
            this.print_dlg.UseEXDialog = true;
            // 
            // print_doc
            // 
            this.print_doc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.print_doc_PrintPage);
            this.print_doc.QueryPageSettings += new System.Drawing.Printing.QueryPageSettingsEventHandler(this.print_doc_QueryPageSettings);
            // 
            // prev_btn
            // 
            this.prev_btn.Location = new System.Drawing.Point(4, 1);
            this.prev_btn.Name = "prev_btn";
            this.prev_btn.Size = new System.Drawing.Size(99, 23);
            this.prev_btn.TabIndex = 4;
            this.prev_btn.Text = "წინა გვერდი";
            this.prev_btn.UseVisualStyleBackColor = true;
            this.prev_btn.Click += new System.EventHandler(this.prev_btn_Click);
            // 
            // next_btn
            // 
            this.next_btn.Location = new System.Drawing.Point(113, 1);
            this.next_btn.Name = "next_btn";
            this.next_btn.Size = new System.Drawing.Size(99, 23);
            this.next_btn.TabIndex = 3;
            this.next_btn.Text = "შემდეგი გვერდი";
            this.next_btn.UseVisualStyleBackColor = true;
            this.next_btn.Click += new System.EventHandler(this.next_btn_Click);
            // 
            // print_btn
            // 
            this.print_btn.Location = new System.Drawing.Point(223, 1);
            this.print_btn.Name = "print_btn";
            this.print_btn.Size = new System.Drawing.Size(75, 23);
            this.print_btn.TabIndex = 5;
            this.print_btn.Text = "დაბეჭდვა";
            this.print_btn.UseVisualStyleBackColor = true;
            this.print_btn.Click += new System.EventHandler(this.print_btn_Click);
            // 
            // rb_portrait
            // 
            this.rb_portrait.AutoSize = true;
            this.rb_portrait.Location = new System.Drawing.Point(320, 4);
            this.rb_portrait.Name = "rb_portrait";
            this.rb_portrait.Size = new System.Drawing.Size(73, 17);
            this.rb_portrait.TabIndex = 7;
            this.rb_portrait.Text = "პორტრეტი";
            this.rb_portrait.UseVisualStyleBackColor = true;
            this.rb_portrait.CheckedChanged += new System.EventHandler(this.rb_portrait_CheckedChanged);
            // 
            // rb_landscape
            // 
            this.rb_landscape.AutoSize = true;
            this.rb_landscape.Checked = true;
            this.rb_landscape.Location = new System.Drawing.Point(410, 4);
            this.rb_landscape.Name = "rb_landscape";
            this.rb_landscape.Size = new System.Drawing.Size(81, 17);
            this.rb_landscape.TabIndex = 6;
            this.rb_landscape.TabStop = true;
            this.rb_landscape.Text = "ლანდშაფტი";
            this.rb_landscape.UseVisualStyleBackColor = true;
            this.rb_landscape.CheckedChanged += new System.EventHandler(this.rb_landscape_CheckedChanged);
            // 
            // ex1
            // 
            this.ex1.Location = new System.Drawing.Point(25, 262);
            this.ex1.Name = "ex1";
            this.ex1.Size = new System.Drawing.Size(307, 20);
            this.ex1.TabIndex = 10;
            // 
            // ex2
            // 
            this.ex2.Location = new System.Drawing.Point(544, 261);
            this.ex2.Name = "ex2";
            this.ex2.Size = new System.Drawing.Size(164, 20);
            this.ex2.TabIndex = 12;
            // 
            // ex5
            // 
            this.ex5.Location = new System.Drawing.Point(350, 883);
            this.ex5.Name = "ex5";
            this.ex5.Size = new System.Drawing.Size(356, 20);
            this.ex5.TabIndex = 22;
            // 
            // ex_p1
            // 
            this.ex_p1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ex_p1.FormattingEnabled = true;
            this.ex_p1.Items.AddRange(new object[] {
            "ცალი",
            "კგ",
            "ყუთი",
            "ტომარა"});
            this.ex_p1.Location = new System.Drawing.Point(221, 412);
            this.ex_p1.Name = "ex_p1";
            this.ex_p1.Size = new System.Drawing.Size(43, 21);
            this.ex_p1.TabIndex = 25;
            this.ex_p1.Visible = false;
            // 
            // ex_p2
            // 
            this.ex_p2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ex_p2.FormattingEnabled = true;
            this.ex_p2.Items.AddRange(new object[] {
            "ცალი",
            "კგ",
            "ყუთი",
            "ტომარა"});
            this.ex_p2.Location = new System.Drawing.Point(221, 432);
            this.ex_p2.Name = "ex_p2";
            this.ex_p2.Size = new System.Drawing.Size(43, 21);
            this.ex_p2.TabIndex = 26;
            this.ex_p2.Visible = false;
            // 
            // ex_p3
            // 
            this.ex_p3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ex_p3.FormattingEnabled = true;
            this.ex_p3.Items.AddRange(new object[] {
            "ცალი",
            "კგ",
            "ყუთი",
            "ტომარა"});
            this.ex_p3.Location = new System.Drawing.Point(221, 452);
            this.ex_p3.Name = "ex_p3";
            this.ex_p3.Size = new System.Drawing.Size(43, 21);
            this.ex_p3.TabIndex = 26;
            this.ex_p3.Visible = false;
            // 
            // ex_p4
            // 
            this.ex_p4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ex_p4.FormattingEnabled = true;
            this.ex_p4.Items.AddRange(new object[] {
            "ცალი",
            "კგ",
            "ყუთი",
            "ტომარა"});
            this.ex_p4.Location = new System.Drawing.Point(221, 472);
            this.ex_p4.Name = "ex_p4";
            this.ex_p4.Size = new System.Drawing.Size(43, 21);
            this.ex_p4.TabIndex = 26;
            this.ex_p4.Visible = false;
            // 
            // ex_p5
            // 
            this.ex_p5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ex_p5.FormattingEnabled = true;
            this.ex_p5.Items.AddRange(new object[] {
            "ცალი",
            "კგ",
            "ყუთი",
            "ტომარა"});
            this.ex_p5.Location = new System.Drawing.Point(221, 492);
            this.ex_p5.Name = "ex_p5";
            this.ex_p5.Size = new System.Drawing.Size(43, 21);
            this.ex_p5.TabIndex = 26;
            this.ex_p5.Visible = false;
            // 
            // ex_p6
            // 
            this.ex_p6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ex_p6.FormattingEnabled = true;
            this.ex_p6.Items.AddRange(new object[] {
            "ცალი",
            "კგ",
            "ყუთი",
            "ტომარა"});
            this.ex_p6.Location = new System.Drawing.Point(221, 512);
            this.ex_p6.Name = "ex_p6";
            this.ex_p6.Size = new System.Drawing.Size(43, 21);
            this.ex_p6.TabIndex = 26;
            this.ex_p6.Visible = false;
            // 
            // ex_p7
            // 
            this.ex_p7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ex_p7.FormattingEnabled = true;
            this.ex_p7.Items.AddRange(new object[] {
            "ცალი",
            "კგ",
            "ყუთი",
            "ტომარა"});
            this.ex_p7.Location = new System.Drawing.Point(221, 532);
            this.ex_p7.Name = "ex_p7";
            this.ex_p7.Size = new System.Drawing.Size(43, 21);
            this.ex_p7.TabIndex = 26;
            this.ex_p7.Visible = false;
            // 
            // ex_p8
            // 
            this.ex_p8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ex_p8.FormattingEnabled = true;
            this.ex_p8.Items.AddRange(new object[] {
            "ცალი",
            "კგ",
            "ყუთი",
            "ტომარა"});
            this.ex_p8.Location = new System.Drawing.Point(221, 552);
            this.ex_p8.Name = "ex_p8";
            this.ex_p8.Size = new System.Drawing.Size(43, 21);
            this.ex_p8.TabIndex = 26;
            this.ex_p8.Visible = false;
            // 
            // ex_p9
            // 
            this.ex_p9.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ex_p9.FormattingEnabled = true;
            this.ex_p9.Items.AddRange(new object[] {
            "ცალი",
            "კგ",
            "ყუთი",
            "ტომარა"});
            this.ex_p9.Location = new System.Drawing.Point(221, 572);
            this.ex_p9.Name = "ex_p9";
            this.ex_p9.Size = new System.Drawing.Size(43, 21);
            this.ex_p9.TabIndex = 26;
            this.ex_p9.Visible = false;
            // 
            // ex_p10
            // 
            this.ex_p10.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ex_p10.FormattingEnabled = true;
            this.ex_p10.Items.AddRange(new object[] {
            "ცალი",
            "კგ",
            "ყუთი",
            "ტომარა"});
            this.ex_p10.Location = new System.Drawing.Point(221, 592);
            this.ex_p10.Name = "ex_p10";
            this.ex_p10.Size = new System.Drawing.Size(43, 21);
            this.ex_p10.TabIndex = 26;
            this.ex_p10.Visible = false;
            // 
            // ex_p11
            // 
            this.ex_p11.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ex_p11.FormattingEnabled = true;
            this.ex_p11.Items.AddRange(new object[] {
            "ცალი",
            "კგ",
            "ყუთი",
            "ტომარა"});
            this.ex_p11.Location = new System.Drawing.Point(221, 612);
            this.ex_p11.Name = "ex_p11";
            this.ex_p11.Size = new System.Drawing.Size(43, 21);
            this.ex_p11.TabIndex = 26;
            this.ex_p11.Visible = false;
            // 
            // ex_p12
            // 
            this.ex_p12.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ex_p12.FormattingEnabled = true;
            this.ex_p12.Items.AddRange(new object[] {
            "ცალი",
            "კგ",
            "ყუთი",
            "ტომარა"});
            this.ex_p12.Location = new System.Drawing.Point(221, 632);
            this.ex_p12.Name = "ex_p12";
            this.ex_p12.Size = new System.Drawing.Size(43, 21);
            this.ex_p12.TabIndex = 26;
            this.ex_p12.Visible = false;
            // 
            // ex_p13
            // 
            this.ex_p13.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ex_p13.FormattingEnabled = true;
            this.ex_p13.Items.AddRange(new object[] {
            "ცალი",
            "კგ",
            "ყუთი",
            "ტომარა"});
            this.ex_p13.Location = new System.Drawing.Point(221, 652);
            this.ex_p13.Name = "ex_p13";
            this.ex_p13.Size = new System.Drawing.Size(43, 21);
            this.ex_p13.TabIndex = 28;
            this.ex_p13.Visible = false;
            // 
            // ex_p14
            // 
            this.ex_p14.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ex_p14.FormattingEnabled = true;
            this.ex_p14.Items.AddRange(new object[] {
            "ცალი",
            "კგ",
            "ყუთი",
            "ტომარა"});
            this.ex_p14.Location = new System.Drawing.Point(221, 672);
            this.ex_p14.Name = "ex_p14";
            this.ex_p14.Size = new System.Drawing.Size(43, 21);
            this.ex_p14.TabIndex = 27;
            this.ex_p14.Visible = false;
            // 
            // ex_p15
            // 
            this.ex_p15.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ex_p15.FormattingEnabled = true;
            this.ex_p15.Items.AddRange(new object[] {
            "ცალი",
            "კგ",
            "ყუთი",
            "ტომარა"});
            this.ex_p15.Location = new System.Drawing.Point(221, 692);
            this.ex_p15.Name = "ex_p15";
            this.ex_p15.Size = new System.Drawing.Size(43, 21);
            this.ex_p15.TabIndex = 30;
            this.ex_p15.Visible = false;
            // 
            // ex_p16
            // 
            this.ex_p16.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ex_p16.FormattingEnabled = true;
            this.ex_p16.Items.AddRange(new object[] {
            "ცალი",
            "კგ",
            "ყუთი",
            "ტომარა"});
            this.ex_p16.Location = new System.Drawing.Point(221, 712);
            this.ex_p16.Name = "ex_p16";
            this.ex_p16.Size = new System.Drawing.Size(43, 21);
            this.ex_p16.TabIndex = 29;
            this.ex_p16.Visible = false;
            // 
            // ex_p17
            // 
            this.ex_p17.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ex_p17.FormattingEnabled = true;
            this.ex_p17.Items.AddRange(new object[] {
            "ცალი",
            "კგ",
            "ყუთი",
            "ტომარა"});
            this.ex_p17.Location = new System.Drawing.Point(221, 732);
            this.ex_p17.Name = "ex_p17";
            this.ex_p17.Size = new System.Drawing.Size(43, 21);
            this.ex_p17.TabIndex = 32;
            this.ex_p17.Visible = false;
            // 
            // ex_p18
            // 
            this.ex_p18.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ex_p18.FormattingEnabled = true;
            this.ex_p18.Items.AddRange(new object[] {
            "ცალი",
            "კგ",
            "ყუთი",
            "ტომარა"});
            this.ex_p18.Location = new System.Drawing.Point(221, 752);
            this.ex_p18.Name = "ex_p18";
            this.ex_p18.Size = new System.Drawing.Size(43, 21);
            this.ex_p18.TabIndex = 31;
            this.ex_p18.Visible = false;
            // 
            // preview_area
            // 
            this.preview_area.AutoScroll = true;
            this.preview_area.Controls.Add(this.ex4);
            this.preview_area.Controls.Add(this.ex3);
            this.preview_area.Controls.Add(this.ex_p23);
            this.preview_area.Controls.Add(this.ex_p22);
            this.preview_area.Controls.Add(this.ex_p21);
            this.preview_area.Controls.Add(this.ex_p20);
            this.preview_area.Controls.Add(this.ex_p19);
            this.preview_area.Controls.Add(this.ex_p18);
            this.preview_area.Controls.Add(this.ex_p17);
            this.preview_area.Controls.Add(this.ex_p16);
            this.preview_area.Controls.Add(this.ex_p15);
            this.preview_area.Controls.Add(this.ex_p14);
            this.preview_area.Controls.Add(this.ex_p13);
            this.preview_area.Controls.Add(this.ex_p12);
            this.preview_area.Controls.Add(this.ex_p11);
            this.preview_area.Controls.Add(this.ex_p10);
            this.preview_area.Controls.Add(this.ex_p9);
            this.preview_area.Controls.Add(this.ex_p8);
            this.preview_area.Controls.Add(this.ex_p7);
            this.preview_area.Controls.Add(this.ex_p6);
            this.preview_area.Controls.Add(this.ex_p5);
            this.preview_area.Controls.Add(this.ex_p4);
            this.preview_area.Controls.Add(this.ex_p3);
            this.preview_area.Controls.Add(this.ex_p2);
            this.preview_area.Controls.Add(this.ex_p1);
            this.preview_area.Controls.Add(this.ex5);
            this.preview_area.Controls.Add(this.ex2);
            this.preview_area.Controls.Add(this.ex1);
            this.preview_area.Controls.Add(this.rb_landscape);
            this.preview_area.Controls.Add(this.rb_portrait);
            this.preview_area.Controls.Add(this.print_btn);
            this.preview_area.Controls.Add(this.next_btn);
            this.preview_area.Controls.Add(this.prev_btn);
            this.preview_area.Controls.Add(this.draw_area);
            this.preview_area.Dock = System.Windows.Forms.DockStyle.Fill;
            this.preview_area.Location = new System.Drawing.Point(0, 0);
            this.preview_area.Name = "preview_area";
            this.preview_area.Size = new System.Drawing.Size(1042, 686);
            this.preview_area.TabIndex = 3;
            // 
            // ex4
            // 
            this.ex4.Location = new System.Drawing.Point(403, 919);
            this.ex4.Name = "ex4";
            this.ex4.Size = new System.Drawing.Size(303, 20);
            this.ex4.TabIndex = 39;
            // 
            // ex3
            // 
            this.ex3.Location = new System.Drawing.Point(36, 919);
            this.ex3.Name = "ex3";
            this.ex3.Size = new System.Drawing.Size(310, 20);
            this.ex3.TabIndex = 38;
            // 
            // ex_p23
            // 
            this.ex_p23.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ex_p23.FormattingEnabled = true;
            this.ex_p23.Items.AddRange(new object[] {
            "ცალი",
            "კგ",
            "ყუთი",
            "ტომარა"});
            this.ex_p23.Location = new System.Drawing.Point(221, 852);
            this.ex_p23.Name = "ex_p23";
            this.ex_p23.Size = new System.Drawing.Size(43, 21);
            this.ex_p23.TabIndex = 36;
            this.ex_p23.Visible = false;
            // 
            // ex_p22
            // 
            this.ex_p22.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ex_p22.FormattingEnabled = true;
            this.ex_p22.Items.AddRange(new object[] {
            "ცალი",
            "კგ",
            "ყუთი",
            "ტომარა"});
            this.ex_p22.Location = new System.Drawing.Point(221, 832);
            this.ex_p22.Name = "ex_p22";
            this.ex_p22.Size = new System.Drawing.Size(43, 21);
            this.ex_p22.TabIndex = 37;
            this.ex_p22.Visible = false;
            // 
            // ex_p21
            // 
            this.ex_p21.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ex_p21.FormattingEnabled = true;
            this.ex_p21.Items.AddRange(new object[] {
            "ცალი",
            "კგ",
            "ყუთი",
            "ტომარა"});
            this.ex_p21.Location = new System.Drawing.Point(221, 812);
            this.ex_p21.Name = "ex_p21";
            this.ex_p21.Size = new System.Drawing.Size(43, 21);
            this.ex_p21.TabIndex = 34;
            this.ex_p21.Visible = false;
            // 
            // ex_p20
            // 
            this.ex_p20.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ex_p20.FormattingEnabled = true;
            this.ex_p20.Items.AddRange(new object[] {
            "ცალი",
            "კგ",
            "ყუთი",
            "ტომარა"});
            this.ex_p20.Location = new System.Drawing.Point(221, 792);
            this.ex_p20.Name = "ex_p20";
            this.ex_p20.Size = new System.Drawing.Size(43, 21);
            this.ex_p20.TabIndex = 35;
            this.ex_p20.Visible = false;
            // 
            // ex_p19
            // 
            this.ex_p19.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ex_p19.FormattingEnabled = true;
            this.ex_p19.Items.AddRange(new object[] {
            "ცალი",
            "კგ",
            "ყუთი",
            "ტომარა"});
            this.ex_p19.Location = new System.Drawing.Point(221, 772);
            this.ex_p19.Name = "ex_p19";
            this.ex_p19.Size = new System.Drawing.Size(43, 21);
            this.ex_p19.TabIndex = 33;
            this.ex_p19.Visible = false;
            // 
            // draw_area
            // 
            this.draw_area.Location = new System.Drawing.Point(0, 30);
            this.draw_area.Name = "draw_area";
            this.draw_area.Size = new System.Drawing.Size(1020, 1051);
            this.draw_area.TabIndex = 0;
            this.draw_area.TabStop = false;
            this.draw_area.Paint += new System.Windows.Forms.PaintEventHandler(this.draw_area_Paint);
            // 
            // PrintPreview_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 686);
            this.Controls.Add(this.preview_area);
            this.MinimumSize = new System.Drawing.Size(1050, 720);
            this.Name = "PrintPreview_Form";
            this.Text = "Print Preview";
            this.Load += new System.EventHandler(this.PrintPreview_Form_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PrintPreview_Form_Paint);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PrintPreview_Form_FormClosing);
            this.preview_area.ResumeLayout(false);
            this.preview_area.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.draw_area)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PrintDialog print_dlg;
        private System.Drawing.Printing.PrintDocument print_doc;
        private System.Windows.Forms.Button prev_btn;
        private System.Windows.Forms.Button next_btn;
        private System.Windows.Forms.Button print_btn;
        private System.Windows.Forms.RadioButton rb_portrait;
        private System.Windows.Forms.RadioButton rb_landscape;
        private System.Windows.Forms.TextBox ex1;
        private System.Windows.Forms.TextBox ex2;
        private System.Windows.Forms.TextBox ex5;
        private System.Windows.Forms.ComboBox ex_p1;
        private System.Windows.Forms.ComboBox ex_p2;
        private System.Windows.Forms.ComboBox ex_p3;
        private System.Windows.Forms.ComboBox ex_p4;
        private System.Windows.Forms.ComboBox ex_p5;
        private System.Windows.Forms.ComboBox ex_p6;
        private System.Windows.Forms.ComboBox ex_p7;
        private System.Windows.Forms.ComboBox ex_p8;
        private System.Windows.Forms.ComboBox ex_p9;
        private System.Windows.Forms.ComboBox ex_p10;
        private System.Windows.Forms.ComboBox ex_p11;
        private System.Windows.Forms.ComboBox ex_p12;
        private System.Windows.Forms.ComboBox ex_p13;
        private System.Windows.Forms.ComboBox ex_p14;
        private System.Windows.Forms.ComboBox ex_p15;
        private System.Windows.Forms.ComboBox ex_p16;
        private System.Windows.Forms.ComboBox ex_p17;
        private System.Windows.Forms.ComboBox ex_p18;
        private System.Windows.Forms.Panel preview_area;
        private System.Windows.Forms.PictureBox draw_area;
        private System.Windows.Forms.ComboBox ex_p23;
        private System.Windows.Forms.ComboBox ex_p22;
        private System.Windows.Forms.ComboBox ex_p21;
        private System.Windows.Forms.ComboBox ex_p20;
        private System.Windows.Forms.ComboBox ex_p19;
        private System.Windows.Forms.TextBox ex4;
        private System.Windows.Forms.TextBox ex3;
    }
}