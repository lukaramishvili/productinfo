using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Data;
using ProductInfo;
using System.Drawing.Printing;

namespace Data_Visualization
{
    public class BitmapGenerator
    {
        public static string GeoNumbers(decimal f)
        {
            string s = "";



            return s;
        }

        public static string add_zeros(string a)
        {
            if (a.Length == 1)
            {
                return ("0" + a);
            }
            else
            {
                return a;
            }
        }

        public static string[] GeorgianMonths = { "Dummy", "იანვარი", "თებერვალი", "მარტი", "აპრილი", "მაისი", "ივნისი", "ივლისი", "აგვისტო", "სექტემბერი", "ოქტომბერი", "ნოემბერი", "დეკემბერი" };

        public static Bitmap[] RenderDataTable(DataTable dt_arg, bool landscape_arg, bool rems_for_long_zed)
        {
            List<Bitmap> return_pages = new List<Bitmap>();

            int generated_page_count = 1;

            Bitmap A4 = null;
            Graphics g = null;
            int PageWidth = 1020;
            int PageHeight = 720;
            if (false == landscape_arg)
            {
                PageWidth = 720;
                PageHeight = 1020;
            }
            A4 = new Bitmap(PageWidth, PageHeight, System.Drawing.Imaging.PixelFormat.Format32bppRgb);

            g = Graphics.FromImage(A4);

            Font Sylfaen_fnt = new Font("Sylfaen", 12.0f, FontStyle.Regular, GraphicsUnit.Pixel);

            Font Arial_fnt = new Font("Arial", 12.0f, FontStyle.Regular, GraphicsUnit.Pixel);

            float defaultOffsetX = 12;
            float defaultOffsetY = 26;
            if (rems_for_long_zed)
            {
                defaultOffsetY = 100;
            }

            float offsetX = defaultOffsetX;
            float offsetY = defaultOffsetY;

            Pen rowPen = new Pen(Color.Black, 1.0f);


            g.Clear(Color.White);
            offsetX = defaultOffsetX;//default left padding 
            offsetY = defaultOffsetY;//default top padding
            ///            

            //draw background color (not neccessery)
            for (int i = 0; i < A4.Height; i++)
            {
                //SolidBrush b = new SolidBrush(Color.FromArgb(63, 200 - i * 200 / A4.Height, 200 - i * 200 / A4.Height, 200 - i * 200 / A4.Height));
                // g.FillRectangle(b, 0, i, A4.Width, 1);
            }

            //column width measuring code ---------------------------------------------------
            float[] colWidths = new float[dt_arg.Columns.Count];
            float[] maxColWidths = new float[dt_arg.Columns.Count];
            //draw columns
            int colI = 0;
            foreach (DataColumn nextCol in dt_arg.Columns)
            {
                int rowI = 1;
                foreach (DataRow dRow in dt_arg.Rows)
                {
                    colWidths[colI] = (g.MeasureString(dRow[nextCol].ToString(), Sylfaen_fnt).Width + rowI * colWidths[colI]) / (rowI + 1);
                    //
                    if (g.MeasureString(dRow[nextCol].ToString(), Sylfaen_fnt).Width > maxColWidths[colI])
                    {
                        maxColWidths[colI] = g.MeasureString(dRow[nextCol].ToString(), Sylfaen_fnt).Width;
                    }
                    //
                    rowI++;
                }

                //
                if (g.MeasureString(nextCol.ColumnName, Sylfaen_fnt).Width > maxColWidths[colI])
                {
                    maxColWidths[colI] = g.MeasureString(nextCol.ColumnName, Sylfaen_fnt).Width;
                }
                //

                colI++;
            }
            float WholeWidth = 0.0f;
            foreach (float nextColW in colWidths)
            {
                WholeWidth += nextColW;
            }//get whole width for all columns
            for (int it = 0; it < colWidths.Length; it++)
            {
                colWidths[it] *= (A4.Width - offsetX * 2) / WholeWidth;//offsetX*2 these are left and right page bounds
            }
            //TODO widths per page??
            //TODO if(max col&row width < calculatedwith, calculatedwidth = maxwidth)
            for (int ckI = 0; ckI < colWidths.Length; ckI++)
            {
                if (maxColWidths[ckI] < colWidths[ckI])
                {
                    colWidths[ckI] = maxColWidths[ckI];
                }
            }
            if (WholeWidth < A4.Width)
            {
                for (int ckI = 0; ckI < colWidths.Length; ckI++)
                {
                    //colWidths[ckI] = maxColWidths[ckI];
                }
            }
            //end column width measuring code -----------------------------------------------

            g.DrawString(DateTime.Now.ToString("dd.MM.yyyy HH:mm"), Sylfaen_fnt, Brushes.Black, 10, 6);

            int colDrawI = 0;
            foreach (DataColumn nextCol in dt_arg.Columns)
            {
                int fitStep = 0;
                Font fitFont = new Font(Sylfaen_fnt, FontStyle.Regular);
                string fitText = nextCol.ColumnName.ToString();
                while (g.MeasureString(fitText, fitFont).Width > colWidths[colDrawI] && 0.0f != colWidths[colDrawI])
                {
                    fitStep++;
                    if ((Sylfaen_fnt.Size - fitStep * 0.3f) < 6.0f)
                    {
                        if (fitText.Length < 2)
                        {
                            break;
                        }
                        else
                        {
                            fitText = fitText.Substring(0, fitText.Length - 1);
                        }
                    }
                    else
                    {
                        fitFont = new Font(Sylfaen_fnt.Name, Sylfaen_fnt.Size - fitStep * 0.3f, FontStyle.Regular, GraphicsUnit.Pixel);
                    }
                    //fitFont = new Font(Sylfaen_fnt, Sylfaen_fnt.Size - fitStep * 0.5f);
                }
                if (rems_for_long_zed)
                {
                    StringFormat col_center = new StringFormat();
                    col_center.Alignment = StringAlignment.Center;
                    g.DrawString(fitText, fitFont, Brushes.Black, offsetX + colWidths[colDrawI] / 2, offsetY, col_center);
                }
                else
                {
                    g.DrawString(fitText, fitFont, Brushes.Black, offsetX, offsetY, StringFormat.GenericDefault);
                }
                g.DrawLine(rowPen, offsetX, offsetY, offsetX, offsetY + Sylfaen_fnt.Height);
                g.DrawLine(rowPen, offsetX + colWidths[colDrawI], offsetY, offsetX + colWidths[colDrawI], offsetY + Sylfaen_fnt.Height);//right line
                if (rems_for_long_zed)
                {
                    g.DrawLine(rowPen, offsetX, offsetY, offsetX, offsetY + Sylfaen_fnt.Height * 4);
                    g.DrawLine(rowPen, offsetX + colWidths[colDrawI], offsetY, offsetX + colWidths[colDrawI], offsetY + Sylfaen_fnt.Height * 4);//right line
                }
                g.DrawLine(rowPen, offsetX, offsetY, offsetX + colWidths[colDrawI], offsetY);
                offsetX += colWidths[colDrawI];
                //offsetX += g.MeasureString(nextCol.ColumnName.ToString(), Sylfaen_fnt).Width+10;

                colDrawI++;
            }

            //next line from columns
            offsetX = defaultOffsetX;
            offsetY += Sylfaen_fnt.Height;
            if (rems_for_long_zed)
            {
                offsetY += Sylfaen_fnt.Height * 3;
            }

            //draw rows
            foreach (DataRow nextRow in dt_arg.Rows)
            {
                if (offsetY + Sylfaen_fnt.Height + 3 > A4.Height)
                {
                    return_pages.Add(new Bitmap(A4));
                    generated_page_count++;
                    g.Clear(Color.White);
                    offsetY = defaultOffsetY;


                    int colDrawI2 = 0;
                    foreach (DataColumn nextCol in dt_arg.Columns)
                    {
                        int fitStep = 0;
                        Font fitFont = new Font(Sylfaen_fnt, FontStyle.Regular);
                        string fitText = nextCol.ColumnName.ToString();
                        while (g.MeasureString(fitText, fitFont).Width > colWidths[colDrawI2])
                        {
                            fitStep++;
                            if ((Sylfaen_fnt.Size - fitStep * 0.3f) < 6.0f)
                            {
                                if (fitText.Length < 2)
                                {
                                    break;
                                }
                                else
                                {
                                    fitText = fitText.Substring(0, fitText.Length - 1);
                                }
                            }
                            else
                            {
                                fitFont = new Font(Sylfaen_fnt.Name, Sylfaen_fnt.Size - fitStep * 0.3f, FontStyle.Regular, GraphicsUnit.Pixel);
                            }
                            //fitFont = new Font(Sylfaen_fnt, Sylfaen_fnt.Size - fitStep * 0.5f);
                        }
                        g.DrawString(fitText, fitFont, Brushes.Black, offsetX, offsetY, StringFormat.GenericDefault);
                        g.DrawLine(rowPen, offsetX, offsetY, offsetX, offsetY + Sylfaen_fnt.Height);
                        g.DrawLine(rowPen, offsetX + colWidths[colDrawI2], offsetY, offsetX + colWidths[colDrawI2], offsetY + Sylfaen_fnt.Height);//right line
                        g.DrawLine(rowPen, offsetX, offsetY, offsetX + colWidths[colDrawI2], offsetY);
                        offsetX += colWidths[colDrawI2];
                        //offsetX += g.MeasureString(nextCol.ColumnName.ToString(), Sylfaen_fnt).Width+10;


                        colDrawI2++;
                    }
                    //next line from columns
                    offsetX = defaultOffsetX;
                    offsetY += Sylfaen_fnt.Height;
                }
                int rowDrawI = 0;
                foreach (DataColumn nextCol in dt_arg.Columns)
                {
                    int fitStep = 0;
                    Font fitFont = new Font(Sylfaen_fnt, FontStyle.Regular);
                    while (g.MeasureString(nextRow[nextCol].ToString(), fitFont).Width > colWidths[rowDrawI])
                    {
                        fitStep++;
                        fitFont = new Font(Sylfaen_fnt.Name, Sylfaen_fnt.Size - fitStep * 0.3f, FontStyle.Regular, GraphicsUnit.Pixel);
                        if (Math.Round(Sylfaen_fnt.Size - fitStep * 0.3f) < Math.Round(7.0f))
                        {
                            break;
                        }
                        //fitFont = new Font(Sylfaen_fnt, Sylfaen_fnt.Size - fitStep * 0.5f);
                    }
                    if (fitFont.Size >= 7.0f)
                    {
                        g.DrawString(nextRow[nextCol].ToString(), fitFont, Brushes.Black, offsetX, offsetY, StringFormat.GenericDefault);
                    }
                    else
                    {
                        if (rems_for_long_zed)
                        {
                            string str_to_split = nextRow[nextCol].ToString();
                            if (g.MeasureString(str_to_split.Substring(0, str_to_split.Length / 4) + "\n" + str_to_split.Substring(str_to_split.Length / 4, str_to_split.Length / 4) + "...", fitFont).Width < colWidths[rowDrawI])
                            {
                                g.DrawString(str_to_split.Substring(0, str_to_split.Length / 4) + "\n" + str_to_split.Substring(str_to_split.Length / 4, str_to_split.Length / 4) + "...", fitFont, Brushes.Black, offsetX, offsetY, StringFormat.GenericDefault);
                            }
                            else
                            {
                                g.DrawString(str_to_split.Substring(0, 30) + "\n" + str_to_split.Substring(30, 30) + "..", fitFont, Brushes.Black, offsetX, offsetY, StringFormat.GenericDefault);
                            }
                        }
                        else
                        {
                            g.DrawString("x", Sylfaen_fnt, Brushes.Gray, offsetX, offsetY, StringFormat.GenericDefault);
                        }
                    }
                    g.DrawLine(rowPen, offsetX, offsetY, offsetX, offsetY + Sylfaen_fnt.Height);//left line
                    g.DrawLine(rowPen, offsetX + colWidths[rowDrawI], offsetY, offsetX + colWidths[rowDrawI], offsetY + Sylfaen_fnt.Height);//right line
                    g.DrawLine(rowPen, offsetX, offsetY, offsetX + colWidths[rowDrawI], offsetY);//top line
                    g.DrawLine(rowPen, offsetX, offsetY + Sylfaen_fnt.Height, offsetX + colWidths[rowDrawI], offsetY + Sylfaen_fnt.Height);//bottom line
                    //offsetX += g.MeasureString(nextRow[nextCol].ToString(), Sylfaen_fnt).Width+10;
                    offsetX += colWidths[rowDrawI];

                    rowDrawI++;
                }
                //next line
                offsetX = defaultOffsetX;
                offsetY += Sylfaen_fnt.Height;

            }

            if (return_pages.ToArray().Length < generated_page_count)
            {
                return_pages.Add(A4);
            }
            return return_pages.ToArray();
        }

        public static Bitmap[] RenderZednadebi(SellOrder SO_arg)
        {
            if (SO_arg.OutgoingRemainders.Length > 23)
            {
                return RenderLongZednadebi(SO_arg);
            }
            List<Bitmap> ret_bmps = new List<Bitmap>();
            Bitmap zed_form = new Bitmap(Image.FromFile("zednadebi_sample.tiff"), 720, 1020);//596, 842);

            Graphics g = Graphics.FromImage(zed_form);
            Font Sylfaen_fnt = new Font("Sylfaen", 12.0f, FontStyle.Regular, GraphicsUnit.Pixel);
            Font Sylfaen_fnt11 = new Font("Sylfaen", 11.0f, FontStyle.Regular, GraphicsUnit.Pixel);


            g.DrawString(SO_arg.SellingZednadebi.zednadebis_nomeri, Sylfaen_fnt, Brushes.Black, 417, 20);//218, 28);
            g.DrawString(SO_arg.SellingZednadebi.dro.Day.ToString() + "           " + GeorgianMonths[SO_arg.SellingZednadebi.dro.Month], Sylfaen_fnt11, Brushes.Black, 210, 56);//359, 32);
            g.DrawString(SO_arg.SellingZednadebi.dro.Year.ToString(), Sylfaen_fnt11, Brushes.Black, 424, 57);//454, 32);

            //g.DrawString(SO_arg.buyer_client.saidentifikacio_kodi, Sylfaen_fnt, Brushes.Black, 519, 69);//432, 57);
            for (int i = 0; i < SO_arg.buyer_client.saidentifikacio_kodi.Length; i++)
            {
                g.DrawString(SO_arg.buyer_client.saidentifikacio_kodi[i].ToString(), Sylfaen_fnt, Brushes.Black, 546 + 14 * i, 97);//432, 57);
            }

            g.DrawString(SO_arg.buyer_client.saxeli, Sylfaen_fnt, Brushes.Black, 397, 96);//301, 81);
            g.DrawString(SO_arg.buyer_client.address, Sylfaen_fnt11, Brushes.Black, 297, 190);//301, 106);

            //for (int i = 0; i < SO_arg.buyer_client.saidentifikacio_kodi.Length; i++)
            //{
            //g.DrawString(SO_arg.buyer_client.saidentifikacio_kodi[i].ToString(), Sylfaen_fnt, Brushes.Black, 530 + 17 * i, 166);//430, 138);
            //}

            //g.DrawString(SO_arg.buyer_client.saxeli, Sylfaen_fnt, Brushes.Black, 364, 195);//298, 162);
            //g.DrawString(SO_arg.buyer_client.address, Sylfaen_fnt, Brushes.Black, 364, 222);//299, 184);

            int rOffset = 0;
            decimal wholeSum = 0.0m;
            foreach (Remainder r in SO_arg.OutgoingRemainders)
            {
                //g.DrawString((rOffset + 1).ToString(), Sylfaen_fnt, Brushes.Black, 7, 384.0f + rOffset * 20.0f);//17, 348.0f + rOffset * 17);

                //////////////////////////////////////////////name
                Font prodname_font = new Font("Sylfaen", 12.0f, FontStyle.Regular, GraphicsUnit.Pixel);
                string prodname_to_print = r.product_barcode;
                if (g.MeasureString(r.product_barcode, Sylfaen_fnt).Width > 215)
                {
                    bool appropSize = false;
                    Font Sylfaen_fnt_prodname_test = new Font("Sylfaen", 11.0f, FontStyle.Regular, GraphicsUnit.Pixel);
                    for (float f = 11.0f; f > 6.0f; f--)
                    {
                        Sylfaen_fnt_prodname_test = new Font("Sylfaen", f, FontStyle.Regular, GraphicsUnit.Pixel);
                        if (g.MeasureString(r.product_barcode, Sylfaen_fnt_prodname_test).Width <= 215)
                        {
                            prodname_font = Sylfaen_fnt_prodname_test;
                            appropSize = true;
                            break;
                        }
                    }//for decremental smaller font sizes
                    //and if even shrinking fonts is not enough
                    if (!appropSize)
                    {
                        prodname_font = new Font("Sylfaen", 7.0f, FontStyle.Regular, GraphicsUnit.Pixel);
                        prodname_to_print = prodname_to_print.Substring(0, 60) + "\r\n" + prodname_to_print.Substring(60);
                    }
                }
                g.DrawString(prodname_to_print, prodname_font, Brushes.Black, 7, 384.0f + rOffset * 20.0f);//17, 348.0f + rOffset * 17);
                //////////////////////////////////////////////name

                //g.DrawString("ცალი", Sylfaen_fnt, Brushes.Black, 264, 384.0f + rOffset * 20.4f);//214, 348.0f + rOffset * 17);
                g.DrawString(r.initial_pieces.ToString("G4"), Sylfaen_fnt, Brushes.Black, 266, 384.0f + rOffset * 20.0f);//254, 348.0f + rOffset * 17);

                decimal erteuli_lari = (r.sell_price - r.sell_price % 1);
                decimal erteuli_tetri = Math.Round(((r.sell_price % 1) * 100), 0);
                if (100 == erteuli_tetri)
                {
                    erteuli_lari += 1;
                    erteuli_tetri = 0;
                }

                //g.DrawString(erteuli_lari.ToString(), Sylfaen_fnt, Brushes.Black, 405, 384.0f + rOffset * 20.4f);//329, 348.0f + rOffset * 17);
                //g.DrawString(add_zeros(erteuli_tetri.ToString()), Sylfaen_fnt, Brushes.Black, 457, 384.0f + rOffset * 20.0f);//372, 348.0f + rOffset * 17);
                g.DrawString(r.sell_price.ToString("F2"), Sylfaen_fnt, Brushes.Black, 310, 384.0f + rOffset * 20.0f);//372, 348.0f + 

                decimal tanxa_lari = ((r.sell_price * r.initial_pieces) - (r.sell_price * r.initial_pieces) % 1);
                decimal tanxa_tetri = Math.Round((((r.sell_price * r.initial_pieces) % 1) * 100), 0);
                if (100 == tanxa_tetri)
                {
                    tanxa_lari += 1;
                    tanxa_tetri = 0;
                }

                //g.DrawString((tanxa_lari).ToString(), Sylfaen_fnt, Brushes.Black, 518, 384.0f + rOffset * 20.0f);//423, 348.0f + rOffset * 17);
                //g.DrawString(add_zeros(tanxa_tetri.ToString()), Sylfaen_fnt, Brushes.Black, 576, 384.0f + rOffset * 20.0f);//471, 348.0f + rOffset * 17);
                g.DrawString((r.sell_price * r.initial_pieces).ToString("F2"), Sylfaen_fnt, Brushes.Black, 369, 384.0f + rOffset * 20.0f);//471, 348.0f + rOffset * 17);

                wholeSum += r.sell_price * r.initial_pieces;

                rOffset++;
            }

            //g.DrawString(wholeSum.ToString(), Sylfaen_fnt, Brushes.Black, 74, 644);

            decimal sum_lari = (wholeSum - wholeSum % 1);
            decimal sum_tetri = Math.Round(((wholeSum % 1) * 100), 0);
            if (100 == sum_tetri)
            {
                sum_lari += 1;
                sum_tetri = 0;
            }

            //g.DrawString(sum_lari.ToString(), Sylfaen_fnt, Brushes.Black, 520, 782);//421, 645);
            //g.DrawString(add_zeros(sum_tetri.ToString()), Sylfaen_fnt, Brushes.Black, 580, 782);//470, 645);
            g.DrawString(wholeSum.ToString("F2"), Sylfaen_fnt, Brushes.Black, 286, 855);//470, 645);

            g.DrawString(SO_arg.SellingZednadebi.dro.Day.ToString() + "          " + GeorgianMonths[SO_arg.SellingZednadebi.dro.Month] + ",    " + SO_arg.SellingZednadebi.dro.Year.ToString(), Sylfaen_fnt11, Brushes.Black, 368, 962);//117, 819);
            //g.DrawString(SO_arg.SellingZednadebi.dro.Year.ToString().Substring(2), Sylfaen_fnt11, Brushes.Black, 412, 964);//195, 820);

            // g.DrawString(SO_arg.SellingZednadebi.dro.Day.ToString() + " " + GeorgianMonths[SO_arg.SellingZednadebi.dro.Month], Sylfaen_fnt11, Brushes.Black, 482, 998);//388, 819);
            //g.DrawString(SO_arg.SellingZednadebi.dro.Year.ToString().Substring(2), Sylfaen_fnt11, Brushes.Black, 594, 999);//489, 820);


            //Bitmap zed_form_resized = new Bitmap(zed_form, 820, 1070);
            ret_bmps.Add(zed_form);
            return ret_bmps.ToArray();
        }

        public static Bitmap[] RenderLongZednadebi(SellOrder SO_arg)
        {
            List<Bitmap> ret_bmps = new List<Bitmap>();
            Bitmap zed_form = new Bitmap(Image.FromFile("zednadebi_sample.tiff"), 720, 1020);//596, 842);
            List<Bitmap> danarti_bmps = new List<Bitmap>();

            Graphics g = Graphics.FromImage(zed_form);
            Font Sylfaen_fnt = new Font("Sylfaen", 12.0f, FontStyle.Regular, GraphicsUnit.Pixel);
            Font Sylfaen_fnt11 = new Font("Sylfaen", 11.0f, FontStyle.Regular, GraphicsUnit.Pixel);
            Font Sylfaen_fnt10 = new Font("Sylfaen", 10.0f, FontStyle.Regular, GraphicsUnit.Pixel);


            g.DrawString(SO_arg.SellingZednadebi.zednadebis_nomeri, Sylfaen_fnt, Brushes.Black, 262, 31);//218, 28);
            g.DrawString(SO_arg.SellingZednadebi.dro.Day.ToString() + "       " + GeorgianMonths[SO_arg.SellingZednadebi.dro.Month], Sylfaen_fnt11, Brushes.Black, 438, 34);//359, 32);
            g.DrawString(SO_arg.SellingZednadebi.dro.Year.ToString(), Sylfaen_fnt11, Brushes.Black, 554, 36);//454, 32);

            //g.DrawString(SO_arg.buyer_client.saidentifikacio_kodi, Sylfaen_fnt, Brushes.Black, 519, 69);//432, 57);
            for (int i = 0; i < SO_arg.buyer_client.saidentifikacio_kodi.Length; i++)
            {
                g.DrawString(SO_arg.buyer_client.saidentifikacio_kodi[i].ToString(), Sylfaen_fnt, Brushes.Black, 530 + 17 * i, 66);//432, 57);
            }

            g.DrawString(SO_arg.buyer_client.saxeli, Sylfaen_fnt, Brushes.Black, 364, 94);//301, 81);
            g.DrawString(SO_arg.buyer_client.address, Sylfaen_fnt11, Brushes.Black, 364, 126);//301, 106);

            for (int i = 0; i < SO_arg.buyer_client.saidentifikacio_kodi.Length; i++)
            {
                g.DrawString(SO_arg.buyer_client.saidentifikacio_kodi[i].ToString(), Sylfaen_fnt, Brushes.Black, 530 + 17 * i, 166);//430, 138);
            }

            g.DrawString(SO_arg.buyer_client.saxeli, Sylfaen_fnt, Brushes.Black, 364, 195);//298, 162);
            //g.DrawString(SO_arg.buyer_client.address, Sylfaen_fnt, Brushes.Black, 364, 222);//299, 184);

            int rOffset = 0;
            decimal wholeSum = 0.0m;

            DataTable out_rems_dt = new DataTable();
            out_rems_dt.Columns.Add("N.");
            out_rems_dt.Columns.Add("საქონლის (ტვირთის) \nდასახელება ან \nკონტეინერის ნომერი,\n მ.შ. დანართის მიხედვით");
            out_rems_dt.Columns.Add("ზომის \nერთეული");
            out_rems_dt.Columns.Add("რაოდენობა");
            out_rems_dt.Columns.Add("ერთეულის ფასი\nდღგ–ს და აქციზის \nჩათვლით\nლარი  | თეთრი\n\t");
            out_rems_dt.Columns.Add("თანხა\nლარი | თეთრი");
            out_rems_dt.Columns.Add("შეფუთ–\nვის\nსახე");
            out_rems_dt.Columns.Add("მასა\nბრუტო\nტონა");

            g.DrawString("ამ ზედნადების შესაბამისად \nმიეწოდება " + SO_arg.OutgoingRemainders.Length.ToString() + " \nდასახელების საქონელი \nდანართის მიხედვით", Sylfaen_fnt, Brushes.Black, 21, 384.0f);
            foreach (Remainder r in SO_arg.OutgoingRemainders)
            {
                DataRow nextRemRow = out_rems_dt.NewRow();
                nextRemRow[0] = rOffset + 1;
                nextRemRow[1] = r.product_barcode;
                nextRemRow[2] = "\t";
                nextRemRow[3] = r.initial_pieces.ToString() + "\t";
                //////////////////////////////////////////////name

                decimal erteuli_lari = (r.sell_price - r.sell_price % 1);
                decimal erteuli_tetri = Math.Round(((r.sell_price % 1) * 100), 0);
                if (100 == erteuli_tetri)
                {
                    erteuli_lari += 1;
                    erteuli_tetri = 0;
                }
                nextRemRow[4] = "         " + erteuli_lari.ToString() + "   |   " + add_zeros(erteuli_tetri.ToString());

                decimal tanxa_lari = ((r.sell_price * r.initial_pieces) - (r.sell_price * r.initial_pieces) % 1);
                decimal tanxa_tetri = Math.Round((((r.sell_price * r.initial_pieces) % 1) * 100), 0);
                if (100 == tanxa_tetri)
                {
                    tanxa_lari += 1;
                    tanxa_tetri = 0;
                }

                nextRemRow[5] = "      " + (tanxa_lari).ToString() + "   |   " + add_zeros(tanxa_tetri.ToString());

                nextRemRow[6] = "\t";
                nextRemRow[7] = "\t";

                //add row
                out_rems_dt.Rows.Add(nextRemRow);

                wholeSum += r.sell_price * r.initial_pieces;

                rOffset++;
            }
            danarti_bmps.AddRange(RenderDataTable(out_rems_dt, false, true));
            foreach (Bitmap nextDanBmp in danarti_bmps)
            {
                string danarti_zed_title = "# " + SO_arg.SellingZednadebi.zednadebis_nomeri;
                //Pen danartiPen=Pens.Black;
                using (Graphics nextDanG = Graphics.FromImage(nextDanBmp))
                {
                    nextDanG.DrawString(danarti_zed_title + "\t სასაქონლო ზედნადების დანართი", Sylfaen_fnt, Brushes.Black, 40, 20);
                    nextDanG.DrawLine(Pens.Black, 40, 20 + Sylfaen_fnt.Height, 40 + nextDanG.MeasureString(danarti_zed_title, Sylfaen_fnt).Width, 20 + Sylfaen_fnt.Height);

                    nextDanG.DrawRectangle(Pens.Black, new Rectangle(40, 50, 200, 16));
                    nextDanG.DrawLine(Pens.Black, 78, 50, 78, 66);
                    nextDanG.DrawLine(Pens.Black, 185, 50, 185, 66);
                    nextDanG.DrawString("   " + SO_arg.SellingZednadebi.dro.Day.ToString() + "         " + GeorgianMonths[SO_arg.SellingZednadebi.dro.Month] + "                " + SO_arg.SellingZednadebi.dro.Year.ToString(), Sylfaen_fnt, Brushes.Black, 40, 50);
                    nextDanG.DrawString("რიცხვი    თვე (სიტყვიერად)     წელიწადი", Sylfaen_fnt10, Brushes.Black, 40, 68);
                }
            }
            //g.DrawString(wholeSum.ToString(), Sylfaen_fnt, Brushes.Black, 74, 644);

            decimal sum_lari = (wholeSum - wholeSum % 1);
            decimal sum_tetri = Math.Round(((wholeSum % 1) * 100), 0);
            if (100 == sum_tetri)
            {
                sum_lari += 1;
                sum_tetri = 0;
            }

            //g.DrawString(sum_lari.ToString(), Sylfaen_fnt, Brushes.Black, 520, 782);//421, 645);
            //g.DrawString(add_zeros(sum_tetri.ToString()), Sylfaen_fnt, Brushes.Black, 580, 782);//470, 645);

            g.DrawString(SO_arg.SellingZednadebi.dro.Day.ToString() + " " + GeorgianMonths[SO_arg.SellingZednadebi.dro.Month], Sylfaen_fnt11, Brushes.Black, 159, 998);//117, 819);
            g.DrawString(SO_arg.SellingZednadebi.dro.Year.ToString().Substring(2), Sylfaen_fnt11, Brushes.Black, 238, 998);//195, 820);

            g.DrawString(SO_arg.SellingZednadebi.dro.Day.ToString() + " " + GeorgianMonths[SO_arg.SellingZednadebi.dro.Month], Sylfaen_fnt11, Brushes.Black, 482, 998);//388, 819);
            g.DrawString(SO_arg.SellingZednadebi.dro.Year.ToString().Substring(2), Sylfaen_fnt11, Brushes.Black, 594, 999);//489, 820);


            //Bitmap zed_form_resized = new Bitmap(zed_form, 820, 1070);
            ret_bmps.Add(zed_form);
            ret_bmps.AddRange(danarti_bmps);
            return ret_bmps.ToArray();
        }

        public static Bitmap AddZedDetails(Bitmap zed_bmp, string[] details)
        {
            Bitmap ret_bmp = zed_bmp;

            Font Sylfaen_fnt11 = new Font("Sylfaen", 11.0f, FontStyle.Regular, GraphicsUnit.Pixel);
            PointF[] locs = {
                            new PointF(29, 233),
                            new PointF(547, 233),
                            new PointF(40, 891),
                            new PointF(407, 891),
                            new PointF(354, 855),
                            };

            Graphics g = Graphics.FromImage(ret_bmp);
            for (int i = 0; i < details.Length; i++)
            {
                g.DrawString(details[i], Sylfaen_fnt11, Brushes.Black, locs[i]);
            }

            return ret_bmp;
        }

        public static Bitmap AddZedCountTypes(Bitmap zed_bmp, string[] countTypes)
        {
            Bitmap ret_bmp = zed_bmp;

            Font Sylfaen_fnt11 = new Font("Sylfaen", 11.0f, FontStyle.Regular, GraphicsUnit.Pixel);
            PointF loc = new PointF(228, 384.0f);

            Graphics g = Graphics.FromImage(ret_bmp);
            for (int i = 0; i < countTypes.Length; i++)
            {
                g.DrawString(countTypes[i], Sylfaen_fnt11, Brushes.Black, loc.X, loc.Y + i * 20.0f);
            }

            return ret_bmp;
        }

        public static void PrintPOSCheck(SellOrder SO_arg, decimal cash_handled, decimal cash_change, Product[] AllProductsKeyValue)
        {
            PrintDocument printPOS_doc = new PrintDocument();
            printPOS_doc.DefaultPageSettings = printPOS_doc.PrinterSettings.DefaultPageSettings;
            printPOS_doc.DefaultPageSettings.Landscape = false;
            //
            //-Bitmap CheckToPrint_bmp = new Bitmap(270, 130 + 40 * SO_arg.OutgoingRemainders.Length);
            //Graphics DedaMovutynatMartoblivatAmIsedacMartoblivatDedamotynulPOSChecksIsePOSCheckIseArJgersRogorcBozSexKitxvisNishaniTanDzalianDidiKitxvisNishaniAiIsetiRomGagaocebsTavisiSididitKitxvisNishani;
            //the variable is declared but its value is never used:: LetsUseItNowAndForever
            //-Graphics g = Graphics.FromImage(CheckToPrint_bmp);
            //
            try
            {
                //print to default printer
                printPOS_doc.PrintPage += new PrintPageEventHandler(delegate(object sender, PrintPageEventArgs e)
                {
                    Font Sylfaen_11 = new Font("Sylfaen", 11.0f, FontStyle.Regular, GraphicsUnit.Pixel);
                    Font Sylfaen_16 = new Font("Sylfaen", 16.0f, FontStyle.Regular, GraphicsUnit.Pixel);
                    Font Sylfaen_20 = new Font("Sylfaen", 20.0f, FontStyle.Regular, GraphicsUnit.Pixel);
                    //
                    e.Graphics.DrawString("სუპერმარკეტი ეკოლარი", Sylfaen_20, Brushes.Black, new PointF(16.0f, 11.0f));
                    e.Graphics.DrawLine(Pens.Black, new Point(5, 50), new Point(260, 50));

                    float Offset = 60.0f;
                    foreach (Remainder nR in SO_arg.OutgoingRemainders)
                    {
                        string nRProdName = (from Product p in AllProductsKeyValue
                                             where p.barcode == nR.product_barcode
                                             select p.name).ToArray()[0];
                        //TODO: draw product name
                        e.Graphics.DrawString((nRProdName ?? nR.product_barcode), Sylfaen_11, Brushes.Black, new PointF(5, Offset + 4));
                        //draw raodenoba
                        e.Graphics.DrawString(Math.Round(nR.sell_price, 2).ToString() + "*" + Math.Round(nR.initial_pieces, 2).ToString() + "ც", Sylfaen_11, Brushes.Black, new PointF(5, Offset + 20));
                        //draw sum price
                        string SumPrice = "=" + Math.Round((nR.initial_pieces * nR.sell_price), 2).ToString();
                        e.Graphics.DrawString(SumPrice, Sylfaen_11, Brushes.Black, new PointF(270 - 12 - e.Graphics.MeasureString(SumPrice, Sylfaen_11).Width, Offset + 20));
                        //draw separator line
                        e.Graphics.DrawLine(Pens.Black, new PointF(5, Offset + 39), new PointF(260, Offset + 39));
                        //
                        Offset += 40.0f;
                    }
                    //
                    e.Graphics.DrawString("ჯამი: " + Math.Round(SO_arg.OutgoingRemainders.Sum(w => w.initial_pieces * w.sell_price), 2).ToString(), Sylfaen_11, Brushes.Black, new PointF(5, Offset + 4));
                    Offset += 20;
                    e.Graphics.DrawString("ნაღდი ფული: " + Math.Round(cash_handled, 2).ToString(), Sylfaen_11, Brushes.Black, new PointF(5, Offset + 4));
                    Offset += 20;
                    e.Graphics.DrawString("ხურდა: " + Math.Round(cash_change, 2).ToString(), Sylfaen_11, Brushes.Black, new PointF(5, Offset + 4));
                    Offset += 20;
                    //
                    e.Graphics.DrawLine(Pens.Black, new PointF(5, Offset + 11), new PointF(260, Offset + 11));
                    e.Graphics.DrawString("გმადლობთ მობრძანებისთვის.", Sylfaen_16, Brushes.Black, new PointF(5.0f, Offset + 20));
                    e.Graphics.DrawString("კიდევ გვეწვიეთ", Sylfaen_16, Brushes.Black, new PointF(71.0f, Offset + 40));
                    //draw line at the bottom to ensure enough space is left for reading the last line
                    e.Graphics.DrawLine(Pens.Black, new PointF(109, Offset + 70), new PointF(152, Offset + 70));

                    //
                    e.HasMorePages = false;
                });
                printPOS_doc.Print();
            }
            catch (InvalidPrinterException)
            {
                //printer is not defined or connected
            }
        }

        static void printPOS_doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            throw new NotImplementedException();
        }


        //
    }
}
