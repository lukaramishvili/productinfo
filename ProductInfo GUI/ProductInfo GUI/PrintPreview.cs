using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Data_Visualization;
using ProductInfo;

namespace ProductInfo_UI
{
    public partial class PrintPreview_Form : Form
    {
        public PrintPreview_Form()
        {
            InitializeComponent();
        }

        public DataTable pages_data = new DataTable();
        public Bitmap[] pages = new List<Bitmap>().ToArray();
        public Bitmap[] OriginalPages = new List<Bitmap>().ToArray();
        public bool DirectBMPPrinting = false;

        public int pageOffset = 0;
        bool PrintInProgress = false;
        bool LandscapePrinting = true;

        bool PrintingZednadebi = false;
        string ZedBuyerIdent = "";
        int ZedRemainderCount = 0;

        public void DrawBitmaps(Bitmap[] bitmaps_arg, bool landscape_arg, bool is_zed_bmp, string buyer_ident, int zed_rem_count)
        {
            DirectBMPPrinting = true;
            this.pages = bitmaps_arg;

            ZedRemainderCount = zed_rem_count;

            //c@ copies references :|
            this.OriginalPages = new Bitmap[this.pages.Length];
            for (int i = 0; i < this.OriginalPages.Length; i++)
            {
                this.OriginalPages[i] = new Bitmap(this.pages[i].Width, this.pages[i].Height);
                Graphics origSurface = Graphics.FromImage(this.OriginalPages[i]);
                origSurface.DrawImage(this.pages[i], 0, 0);
            }

            LandscapePrinting = landscape_arg;
            if (LandscapePrinting)
            {
                rb_landscape.Checked = true;
            }
            else
            {
                rb_portrait.Checked = true;
            }
            for (int ix = 1; ix <= zed_rem_count; ix++)
            {
                if (ix > 23)
                {
                    ComboBox ex_p_up23 = new ComboBox();
                    ex_p_up23.Name = "ex_p" + ix.ToString();
                    string[] pack_types = { "ცალი", "კგ", "ყუთი", "ტომარა" };
                    ex_p_up23.Size = new System.Drawing.Size(47, 21);
                    ex_p_up23.Location = new Point(0, 0);
                    ex_p_up23.Items.AddRange(pack_types);
                    ex_p_up23.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                    ex_p_up23.FormattingEnabled = true;
                    this.preview_area.Controls.Add(ex_p_up23);
                }
                this.preview_area.Controls["ex_p" + ix.ToString()].Visible = true;
                ComboBox ex_p_next_ref = (ComboBox)this.preview_area.Controls["ex_p" + ix.ToString()];
                ex_p_next_ref.SelectedIndex = 0;
            }

            Graphics g = draw_area.CreateGraphics();//this.CreateGraphics();
            g.Clear(this.BackColor);
            pageOffset = 0;
            ChangePage(pageOffset);
            g.DrawImage(pages[pageOffset], 0, 0);//2, 30

            if (is_zed_bmp)
            {
                ZedBuyerIdent = buyer_ident;
                LoadExtraFields(buyer_ident);
                PrintingZednadebi = is_zed_bmp;
            }
        }

        private void LoadExtraFields(string buyer_ident)
        {
            string[] saved_vars = new string[5];
            for (int i = 1; i <= 5; i++)
            {
                try
                {
                    saved_vars[i - 1] = Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\zero\ProductInfo\1.0\Customers\" + buyer_ident, i.ToString(), "").ToString();
                    this.preview_area.Controls["ex" + i.ToString()].Text = saved_vars[i - 1];
                }
                catch (Exception)
                {
                }
                this.preview_area.Controls["ex" + i.ToString()].Visible = true;
            }
        }

        public void DrawZednadebi(SellOrder SO_arg, bool landscape_arg)
        {
            throw new NotImplementedException("This method is not implemented yet.");
        }

        public void DrawData(DataTable data_arg, bool landscape_arg)
        {
            DirectBMPPrinting = false;
            this.pages_data = data_arg;
            this.pages = BitmapGenerator.RenderDataTable(data_arg, landscape_arg, false);
            LandscapePrinting = landscape_arg;
            if (LandscapePrinting)
            {
                rb_landscape.Checked = true;
            }
            else
            {
                rb_portrait.Checked = true;
            }

            Graphics g = draw_area.CreateGraphics();//this.CreateGraphics();
            g.Clear(this.BackColor);
            pageOffset = 0;
            g.DrawImage(pages[pageOffset], 0, 0);//2, 30);
        }

        public void ChangePage(int page_id)
        {
            if (page_id >= 0 && page_id < pages.Length)
            {
                pageOffset = page_id;
                Graphics g = draw_area.CreateGraphics();//this.CreateGraphics();
                g.Clear(this.BackColor);
                g.DrawImage(pages[pageOffset], 0, 0);//2, 30);
            }

            if (ZedRemainderCount > 23)
            {
                if (page_id > 0)
                {
                    foreach (Control c in preview_area.Controls)
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(c.Name, @"ex\d+"))
                        {
                            c.Hide();
                        }
                        for (int ix = 1; ix <= ZedRemainderCount; ix++)
                        {
                            this.preview_area.Controls["ex_p" + ix.ToString()].Visible = true;
                        }
                    }
                }
                else
                {
                    foreach (Control c in preview_area.Controls)
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(c.Name, @"ex\d+"))
                        {
                            c.Show();
                        }
                        for (int ix = 1; ix <= ZedRemainderCount; ix++)
                        {
                            this.preview_area.Controls["ex_p" + ix.ToString()].Visible = false;
                        }
                    }
                }
            }
            else
            {
                for (int ix = 1; ix <= ZedRemainderCount; ix++)
                {
                    this.preview_area.Controls["ex_p" + ix.ToString()].Visible = true;
                }
            }
        }

        private void PrintPreview_Form_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= 5; i++)
            {
                this.preview_area.Controls["ex" + i.ToString()].Visible = false;
            }
        }



        private void prev_btn_Click(object sender, EventArgs e)
        {
            ChangePage(pageOffset - 1);
        }

        private void next_btn_Click(object sender, EventArgs e)
        {
            ChangePage(pageOffset + 1);
        }

        private void print_btn_Click(object sender, EventArgs e)
        {
            if (PrintingZednadebi)
            {
                List<string> detail_strings = new List<string>();
                List<string> piece_count_strings = new List<string>();
                for (int i = 1; i <= 5; i++)
                {
                    detail_strings.Add(this.preview_area.Controls["ex" + i.ToString()].Text);
                }
                for (int j = 1; j <= 23; j++)
                {
                    piece_count_strings.Add(this.preview_area.Controls["ex_p" + j.ToString()].Text);
                }

                //C# assigns reference :|:|:|
                //reset image
                pages[0] = new Bitmap(pages[0].Width, pages[0].Height);
                Graphics origSurface = Graphics.FromImage(this.pages[0]);
                origSurface.DrawImage(this.OriginalPages[0], 0, 0);
                //
                pages[0] = BitmapGenerator.AddZedDetails(pages[0], detail_strings.ToArray());
                pages[0] = BitmapGenerator.AddZedCountTypes(pages[0], piece_count_strings.ToArray());
            }
            //
            if (DialogResult.OK == print_dlg.ShowDialog())
            {
                ChangePage(0);
                PrintInProgress = true;
                print_doc.PrinterSettings = print_dlg.PrinterSettings;
                print_doc.Print();
            }
        }

        private void print_doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.HasMorePages = true;

            e.Graphics.DrawImage(pages[pageOffset], e.PageBounds.Left, e.PageBounds.Top);

            if ((pageOffset + 1) >= pages.Length)
            {
                PrintInProgress = false;
                e.HasMorePages = false;
            }
            else
            {
                ChangePage(pageOffset + 1);
            }
        }

        private void PrintPreview_Form_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics
            //draw_area.CreateGraphics().DrawImage(pages[pageOffset], 2, 30);
        }

        private void print_doc_QueryPageSettings(object sender, QueryPageSettingsEventArgs e)
        {
            e.PageSettings.Landscape = LandscapePrinting;
        }

        private void rb_landscape_CheckedChanged(object sender, EventArgs e)
        {
            LandscapePrinting = true;
        }

        private void rb_portrait_CheckedChanged(object sender, EventArgs e)
        {
            LandscapePrinting = false;
        }

        private void draw_area_Paint(object sender, PaintEventArgs e)
        {
            if (pages.Length > 0)
            {
                e.Graphics.DrawImage(pages[pageOffset], 0, 0);//2, 30);
            }
        }

        private void PrintPreview_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            //sul i+1 cvladia, mara bolo cvladi, anu sul ghirebuleba sityvierad, ar unda daimaxsovros da amito imaxsovrebs marto i raodenobas
            for (int i = 1; i <= 4; i++)
            {
                try
                {
                    Microsoft.Win32.Registry.SetValue(@"HKEY_CURRENT_USER\Software\zero\ProductInfo\1.0\Customers\" + ZedBuyerIdent, i.ToString(), this.preview_area.Controls["ex" + i.ToString()].Text);
                }
                catch (Exception)
                {
                }
            }
        }







    }
}
