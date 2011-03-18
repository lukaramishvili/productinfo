using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProductInfo;

namespace ProductInfo_UI
{
    public partial class AddProductList_Form : Form
    {
        public AddProductList_Form()
        {
            InitializeComponent();
        }

        private void AddProductList_Form_Load(object sender, EventArgs e)
        {
            vat_col.DefaultCellStyle.NullValue = true;
        }

        private void submit_list_btn_Click(object sender, EventArgs e)
        {
            
            List<Product> list_prods=new List<Product>(prodlist_data.Rows.Count);
            int validCount = 0;
            int invalidCount = 0;

            foreach (DataGridViewRow next_row in prodlist_data.Rows)
            {
                try
                {
                    string nextbarcode = (string)next_row.Cells["barcode_col"].Value;
                    string nextname = (string)next_row.Cells["name_col"].Value;
                    bool nextVAT = true;
                    if (null != next_row.Cells["vat_col"].Value)
                    {
                        nextVAT = (bool)next_row.Cells["vat_col"].Value;
                    }

                    if ("" != nextbarcode && "" != nextname && null != nextbarcode && null != nextname)
                    {
                        Product next_prod = new Product(nextbarcode, nextname, nextVAT);
                        list_prods.Add(next_prod);
                        validCount++;
                    }
                    else
                    {
                        //MessageBox.Show("ინფორმაცია არასრულადაა შეყვანილი, ამ ველს გამოვტოვებ. ");
                    }
                }
                catch (NullReferenceException)
                {
                    //MessageBox.Show("ინფორმაცია არასრულადაა შეყვანილი, გთხოვთ შეავსოთ ყევლა ველი. ");
                    invalidCount++;
                }
            }


            foreach (Product prod_item in list_prods)
            {
                ProductInfo_Main_Form.conn.AddProductName(prod_item);
            }
            MessageBox.Show(validCount.ToString()+" პროდუქტზე ინფორმაცია შევინახეთ, არასწორად იყო შევსებული "+invalidCount.ToString()+" პროდუქტის დასახელება.");
            if (0 == invalidCount)
            {
                prodlist_data.Rows.Clear();
            }
        }

        private void prodlist_data_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F8)
            {
                try
                {
                    int currentRowIndex = prodlist_data.CurrentRow.Index;
                    prodlist_data.ClearSelection();
                    prodlist_data.EndEdit();
                    prodlist_data.Rows[currentRowIndex].Cells["barcode_col"].Selected = true;
                }
                catch (NullReferenceException)
                {
                    prodlist_data.Rows.Add();
                }
            }
        }

        private void prodlist_data_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
