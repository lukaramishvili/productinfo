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
    public partial class MoneyTransfer_Form : Form
    {
        public MoneyTransfer_Form()
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

        Supplier[] all_suppliers = null;
        Buyer[] all_buyers = null;

        DataProvider.MoneyTransferType TransferMode = DataProvider.MoneyTransferType.Give;
        Type ClientType = typeof(Supplier);
        DataProvider.MoneyTransferPurpose TransferPurpose = DataProvider.MoneyTransferPurpose.SimpleTransfer;
        Type TargetType = null;
        string TargetIdentCode = null;

        private void MoneyTransfer_Form_Load(object sender, EventArgs e)
        {
            taking_txt.Enabled = false;
            rb_giving.Checked = true;

            all_suppliers = ProductInfo_Main_Form.conn.AllSuppliers();
            all_buyers = ProductInfo_Main_Form.conn.AllBuyers();
            client_chooser.Items.Clear();
            foreach (Supplier nextSupplier in all_suppliers)
            {
                client_chooser.Items.Add(nextSupplier.saxeli);
            }
            giving_txt.Focus();

            transfer_purpose_chooser.Format += delegate(object eEnumConvertSender, ListControlConvertEventArgs eEnumConvert)
            {
                //return properly formatted combobox item titles
                //eEnumConvert.Value = GetDescription<DataProvider.MoneyTransferPurpose>((DataProvider.MoneyTransferPurpose)eEnumConvert.Value);
                //eEnumConvert.Value = ((DataProvider.MoneyTransferPurpose)eEnumConvert.Value).ToString() + "";
                eEnumConvert.Value = Utilities.Internals.GetEnumValueDescription((DataProvider.MoneyTransferPurpose)eEnumConvert.Value);
            };

            transfer_purpose_chooser.Items.Clear();
            transfer_purpose_chooser.Items.Add(DataProvider.MoneyTransferPurpose.SimpleTransfer);
            transfer_purpose_chooser.Items.Add(DataProvider.MoneyTransferPurpose.PayFor);
            transfer_purpose_chooser.Items.Add(DataProvider.MoneyTransferPurpose.AddToCashBox);
            transfer_purpose_chooser.Items.Add(DataProvider.MoneyTransferPurpose.TakeFromCashBox);

            transfer_purpose_chooser.SelectedItem = DataProvider.MoneyTransferPurpose.SimpleTransfer;
        }

        public void LoadInterface(Type clienttype_arg, DataProvider.MoneyTransferType transfermode_arg, string client_ident_arg, int store_id_arg, DataProvider.MoneyTransferPurpose purpose_arg, Type targettype_arg, string target_ident_arg)
        {
            ClientType = clienttype_arg;
            TransferMode = transfermode_arg;

            TransferPurpose = purpose_arg;
            TargetType = targettype_arg;
            TargetIdentCode = target_ident_arg;

            transfer_purpose_chooser.SelectedItem = TransferPurpose;

            if (DataProvider.MoneyTransferPurpose.PayFor == TransferPurpose && null != targettype_arg && null != target_ident_arg)
            {
                if (typeof(ProductInfo.Zednadebi) == targettype_arg)
                {
                    target_type_chooser.SelectedItem = "ზედნადები";
                }
            }

            cb_mt_store_id.SelectedIndex = store_id_arg;

            if (typeof(Supplier) == clienttype_arg)
            {
                rb_supplier.Checked = true;

                taking_txt.Enabled = false;
                rb_giving.Checked = true;

                all_suppliers = ProductInfo_Main_Form.conn.AllSuppliers();
                all_buyers = ProductInfo_Main_Form.conn.AllBuyers();


                client_chooser.Items.Clear();
                foreach (Supplier nextSupplier in all_suppliers)
                {
                    client_chooser.Items.Add(nextSupplier.saxeli);
                }

                client_chooser.SelectedItem = (from s in all_suppliers
                                               where s.saidentifikacio_kodi == client_ident_arg
                                               select s.saxeli).ToArray()[0];
                giving_txt.Focus();
            }
            else if (typeof(Buyer) == clienttype_arg)
            {
                rb_buyer.Checked = true;

                taking_txt.Enabled = true;
                giving_txt.Enabled = false;
                rb_giving.Checked = false;
                rb_taking.Checked = true;

                all_suppliers = ProductInfo_Main_Form.conn.AllSuppliers();
                all_buyers = ProductInfo_Main_Form.conn.AllBuyers();


                client_chooser.Items.Clear();
                foreach (Buyer nextBuyer in all_buyers)
                {
                    client_chooser.Items.Add(nextBuyer.saxeli);
                }

                client_chooser.SelectedItem = (from b in all_buyers
                                               where b.saidentifikacio_kodi == client_ident_arg
                                               select b.saxeli).ToArray()[0];
                taking_txt.Focus();
            }
        }

        private void rb_supplier_CheckedChanged(object sender, EventArgs e)
        {
            if (true == rb_supplier.Checked)
            {
                this.ClientType = typeof(Supplier);
                client_chooser.Items.Clear();
                foreach (Supplier nextSupplier in all_suppliers)
                {
                    client_chooser.Items.Add(nextSupplier.saxeli);
                }
                rb_giving.Checked = true;
            }
        }

        private void rb_buyer_CheckedChanged(object sender, EventArgs e)
        {
            if (true == rb_buyer.Checked)
            {
                this.ClientType = typeof(Buyer);
                client_chooser.Items.Clear();
                foreach (Buyer nextBuyer in all_buyers)
                {
                    client_chooser.Items.Add(nextBuyer.saxeli);
                }
                rb_taking.Checked = true;
            }
        }

        private void rb_giving_CheckedChanged(object sender, EventArgs e)
        {
            if (true == rb_giving.Checked)
            {
                giving_txt.Enabled = true;
                taking_txt.Enabled = false;
                TransferMode = DataProvider.MoneyTransferType.Give;
            }
        }

        private void rb_taking_CheckedChanged(object sender, EventArgs e)
        {
            if (true == rb_taking.Checked)
            {
                giving_txt.Enabled = false;
                taking_txt.Enabled = true;
                TransferMode = DataProvider.MoneyTransferType.Take;
            }
        }

        private void transfer_submit_btn_Click(object sender, EventArgs e)
        {
            string procClientIdent = "";
            decimal procAmount = 0.0m;

            if (typeof(Supplier) == ClientType)
            {
                if (client_chooser.SelectedIndex >= 0 && client_chooser.SelectedIndex < all_suppliers.Length)
                {
                    procClientIdent = all_suppliers[client_chooser.SelectedIndex].saidentifikacio_kodi;
                }
                else
                {
                    MessageBox.Show("კლიენტი არ არის მითითებული!");
                    return;
                }
            }
            else if (typeof(Buyer) == ClientType)
            {
                if (client_chooser.SelectedIndex >= 0 && client_chooser.SelectedIndex < all_buyers.Length)
                {
                    procClientIdent = all_buyers[client_chooser.SelectedIndex].saidentifikacio_kodi;
                }
                else
                {
                    MessageBox.Show("კლიენტი არ არის მითითებული!");
                    return;
                }
            }

            if (DataProvider.MoneyTransferType.Give == TransferMode)
            {
                procAmount = ParseDecimal(giving_txt.Text);
            }
            else if (DataProvider.MoneyTransferType.Take == TransferMode)
            {
                procAmount = ParseDecimal(taking_txt.Text);
            }
            if (!(procAmount > 0))
            {
                MessageBox.Show("შეიყვანეთ თანხა!");
                return;
            }



            info transfmoney_info = ProductInfo_Main_Form.conn.TransferMoney(procClientIdent, TransferMode, DateTime.Now, procAmount, ClientType, TransferPurpose, cb_mt_store_id.SelectedIndex, TargetType, TargetIdentCode);
            MessageBox.Show(transfmoney_info.details, transfmoney_info.errcode.ToString());
            if (0 == transfmoney_info.errcode)
            {
                this.Close();
            }
        }

        private void transfer_purpose_chooser_SelectedIndexChanged(object sender, EventArgs e)
        {
            TransferPurpose = (DataProvider.MoneyTransferPurpose)transfer_purpose_chooser.SelectedItem;
            switch (TransferPurpose)
            {
                case DataProvider.MoneyTransferPurpose.SimpleTransfer:
                    this.Width = 286;
                    lbl_mt_target_type.Visible = false;
                    lbl_mt_target_ident.Visible = false;
                    break;
                case DataProvider.MoneyTransferPurpose.PayFor:
                    this.Width = 510;
                    lbl_mt_target_type.Visible = true;
                    lbl_mt_target_ident.Visible = true;

                    target_type_chooser.SelectedIndex = 0;

                    break;
                case DataProvider.MoneyTransferPurpose.AddToCashBox:
                    this.Width = 286;
                    lbl_mt_target_type.Visible = false;
                    lbl_mt_target_ident.Visible = false;

                    rb_taking.Checked = true;
                    taking_txt.Enabled = true;
                    giving_txt.Enabled = false;

                    break;
                case DataProvider.MoneyTransferPurpose.TakeFromCashBox:
                    this.Width = 286;
                    lbl_mt_target_type.Visible = false;
                    lbl_mt_target_ident.Visible = false;

                    rb_giving.Checked = true;
                    giving_txt.Enabled = true;
                    taking_txt.Enabled = false;
                    break;
            }

            /*if (DataProvider.MoneyTransferPurpose.AddToCashBox == TransferPurpose | DataProvider.MoneyTransferPurpose.TakeFromCashBox == TransferPurpose)
            {
                //client_chooser.Enabled = false;
            }
            else
            {
                //client_chooser.Enabled = true;
            }*/
        }

        private void PopulateTargetIdentList()
        {
            switch (target_type_chooser.SelectedItem.ToString())
            {
                case "ზედნადები":
                    MessageBox.Show("Populate Target Ident List items with ZednadebiListOfSupplier/Buyer");
                    break;
            }
        }

        private void target_type_chooser_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateTargetIdentList();
        }
    }
}
