using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProductInfo;
using Utilities;

namespace ProductInfo_UI
{
    public partial class AddRemainderItem_Form : Form
    {
        public AddRemainderItem_Form()
        {
            InitializeComponent();
        }

        public float ParseFloat(string arg)
        {
            return Utilities.Utilities.ParseFloat(arg);
        }

        public decimal ParseDecimal(string arg)
        {
            return Utilities.Utilities.ParseDecimal(arg);
        }

        public enum AddRemainderItemMode { BoughtZed, SoldZed, SellOrder }


        AddRemainderItemMode AddRemMode = AddRemainderItemMode.BoughtZed;

        Product[] all_prod_names = ProductInfo_Main_Form.conn.GetProductSuggestions("");
        Remainder[] all_valid_rems = ProductInfo_Main_Form.conn.GetValidRemainders(ProductInfo_Main_Form.ActiveStoreID, true);

        string ClientIdent = "";
        string ZedIdent = "";
        int SellOrderID = -1;

        decimal PackCapacity = 0.0m;
        decimal PieceCount = 0.0m;
        decimal PiecePrice = 0.0m;

        public void LoadProdNamesList()
        {
            cmb_select_remainder.Items.Clear();
            switch (AddRemMode)
            {
                case AddRemainderItemMode.BoughtZed:
                    foreach (Product p in all_prod_names)
                    {
                        cmb_select_remainder.Items.Add(p.barcode);
                    }
                    break;
                case AddRemainderItemMode.SoldZed:
                    foreach (Remainder r in all_valid_rems)
                    {
                        cmb_select_remainder.Items.Add(r.product_barcode);
                    }
                    break;
                case AddRemainderItemMode.SellOrder:
                    foreach (Remainder r in all_valid_rems)
                    {
                        cmb_select_remainder.Items.Add(r.product_barcode);
                    }
                    break;
            }
        }

        public void LoadBoughtZedInterface(string supplier_ident_arg, string zed_ident_arg)
        {
            AddRemMode = AddRemainderItemMode.BoughtZed;
            ClientIdent = supplier_ident_arg;
            ZedIdent = zed_ident_arg;

            LoadProdNamesList();
        }

        public void LoadSellOrderInterface(string buyer_ident_arg, string zed_ident_arg, int SellOrderID_arg)
        {
            AddRemMode = AddRemainderItemMode.SellOrder;
            ClientIdent = buyer_ident_arg;
            ZedIdent = zed_ident_arg;
            SellOrderID = SellOrderID_arg;

            capacity_txt.Enabled = false;

            LoadProdNamesList();
        }

        public void LoadSoldZedInterface(string buyer_ident_arg, string zed_ident_arg, int SellOrderID_arg)
        {
            AddRemMode = AddRemainderItemMode.SoldZed;
            ClientIdent = buyer_ident_arg;
            ZedIdent = zed_ident_arg;
            SellOrderID = SellOrderID_arg;

            capacity_txt.Enabled = false;

            LoadProdNamesList();
        }

        private void cmb_select_remainder_Format(object sender, ListControlConvertEventArgs e)
        {
            ComboBox cmb_target = (ComboBox)sender;
            e.Value = (from prod in all_prod_names where prod.barcode == e.Value.ToString() select prod.name).ToArray()[0];
        }

        private void btn_add_soldrem_Click(object sender, EventArgs e)
        {
            if (0 == cb_addrem_store_id.SelectedIndex)
            {
                MessageBox.Show("გთხოვთ მონიშნოთ საწყობი!", "შეცდომა");
                return;
            }
            info addrem_res = info.niy();
            switch (AddRemMode)
            {
                case AddRemainderItemMode.BoughtZed:
                    if (ValidateAddRemFields())
                    {
                        Remainder RemToAdd = new Remainder(cmb_select_remainder.SelectedItem.ToString(), ClientIdent, ZedIdent, PieceCount, PackCapacity, PieceCount, PiecePrice, PiecePrice, 0.0m, 0.0m, cb_addrem_store_id.SelectedIndex);
                        addrem_res = ProductInfo_Main_Form.conn.sOpAddRemainder(RemToAdd);
                    }
                    else
                    {
                        addrem_res.errcode = 1;
                        addrem_res.details = "გთხოვთ შეავსოთ ყველა ველი!";
                    }
                    break;
                case AddRemainderItemMode.SoldZed:
                    if (ValidateAddRemFields())
                    {
                        Remainder RemToSell = new Remainder(cmb_select_remainder.SelectedItem.ToString(), ClientIdent, "", PieceCount, PackCapacity, PieceCount, 0.0m, 0.0m, PiecePrice, PiecePrice, cb_addrem_store_id.SelectedIndex);
                        addrem_res = ProductInfo_Main_Form.conn.sOpSellRemainder(RemToSell, SellOrderID);
                    }
                    else
                    {
                        addrem_res.errcode = 1;
                        addrem_res.details = "გთხოვთ შეავსოთ ყველა ველი!";
                    }
                    break;
                case AddRemainderItemMode.SellOrder:
                    if (ValidateAddRemFields())
                    {
                        Remainder RemToSell = new Remainder(cmb_select_remainder.SelectedItem.ToString(), ClientIdent, "", PieceCount, PackCapacity, PieceCount, 0.0m, 0.0m, PiecePrice, PiecePrice, cb_addrem_store_id.SelectedIndex);
                        addrem_res = ProductInfo_Main_Form.conn.sOpSellRemainder(RemToSell, SellOrderID);
                    }
                    else
                    {
                        addrem_res.errcode = 1;
                        addrem_res.details = "გთხოვთ შეავსოთ ყველა ველი!";
                    }
                    break;
            }
            MessageBox.Show(addrem_res.details, addrem_res.errcode.ToString());
            if (0 == addrem_res.errcode)
            {
                this.Close();
            }
        }

        private bool ValidateAddRemFields()
        {
            switch (this.AddRemMode)
            {
                case AddRemainderItemMode.BoughtZed:
                    if (0 <= cmb_select_remainder.SelectedIndex && PieceCount > 0 && PiecePrice > 0 && PackCapacity > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    break;
                case AddRemainderItemMode.SellOrder:
                case AddRemainderItemMode.SoldZed:
                    if (0 <= cmb_select_remainder.SelectedIndex && PieceCount > 0 && PiecePrice > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    break;
                default:
                    if (0 <= cmb_select_remainder.SelectedIndex && PieceCount > 0 && PiecePrice > 0 && PackCapacity > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
            }
            //
        }

        private void AddRemainderItem_Form_Load(object sender, EventArgs e)
        {
            cb_addrem_store_id.SelectedIndex = ProductInfo_Main_Form.ActiveStoreID;

            switch (this.AddRemMode)
            {
                case AddRemainderItemMode.BoughtZed:
                    btn_add_prodname.Visible = true;
                    break;
                case AddRemainderItemMode.SellOrder:
                case AddRemainderItemMode.SoldZed:
                    btn_add_prodname.Visible = false;
                    break;
            }
        }

        private void capacity_txt_TextChanged(object sender, EventArgs e)
        {
            PackCapacity = ParseDecimal(capacity_txt.Text);
        }

        private void piece_count_txt_TextChanged(object sender, EventArgs e)
        {
            PieceCount = ParseDecimal(piece_count_txt.Text);
        }

        private void piece_price_txt_TextChanged(object sender, EventArgs e)
        {
            PiecePrice = ParseDecimal(piece_price_txt.Text);
        }

        private void btn_add_prodname_Click(object sender, EventArgs e)
        {
            AddProduct_Form prod_add_frm = new AddProduct_Form();
            prod_add_frm.Show();
            prod_add_frm.FormClosed += delegate(object senderProdAddFrm, FormClosedEventArgs eProdAddFrm)
                {
                    all_prod_names = ProductInfo_Main_Form.conn.GetProductSuggestions("");
                    //all_valid_rems = ProductInfo_Main_Form.conn.GetValidRemainders(ProductInfo_Main_Form.ActiveStoreID, true);

                    LoadProdNamesList();
                };
        }


        //
    }
}
