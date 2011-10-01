using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Xml.Serialization;
using Utilities;

namespace ProductInfo
{
    //--


    /// <summary>
    /// XML-Exportable Product Class (this is a comment =)) )
    /// </summary>
    [XmlRootAttribute("Product")]
    public class Product
    {
        [XmlAttribute]
        public string barcode = null;
        [XmlAttribute]
        public string name = null;
        [XmlAttribute]
        public bool usesVAT = true;


        public Product()
        {
            this.barcode = "0";
            this.name = "nameless";
            this.usesVAT = true;
        }
        public Product(string barcode_arg, string name_arg, bool vat_arg)
        {
            this.barcode = barcode_arg;
            this.name = name_arg;
            this.usesVAT = vat_arg;
        }
    }

    /// <summary>
    /// XML-Exportable PurchaseOrder Class
    /// </summary>
    [XmlRootAttribute("PurchaseOrder")]
    public class PurchaseOrder
    {
        [XmlAttribute]
        public DateTime dro = new DateTime();
        [XmlAttribute]
        public Supplier supplier_client;
        [XmlAttribute]
        public Zednadebi BuyingZednadebi = null;
        [XmlAttribute]
        public AngarishFaqtura BuyingAF = null;
        [XmlArray]
        public Remainder[] IncomingRemainders = null;

        public PurchaseOrder()
        {
            this.dro = new DateTime();
            this.supplier_client = null;
            this.BuyingZednadebi = null;
            this.BuyingAF = null;
            this.IncomingRemainders = new List<Remainder>().ToArray();
        }
        public PurchaseOrder(DateTime dro_arg, Supplier supplier_arg, Zednadebi zednadebi_arg, Remainder[] buying_remainders_arg, AngarishFaqtura buying_af_arg)
        {
            this.dro = dro_arg;
            this.supplier_client = supplier_arg;
            this.BuyingZednadebi = zednadebi_arg;
            this.IncomingRemainders = buying_remainders_arg;

            if (null != buying_af_arg)
            {
                this.BuyingAF = buying_af_arg;
            }
        }
    }
    /// <summary>
    /// XML-Exportable SellOrder Class
    /// </summary>
    [XmlRootAttribute("SellOrder")]
    public class SellOrder
    {
        [XmlAttribute]
        public DateTime dro = new DateTime();
        [XmlAttribute]
        public bool using_check = true;
        [XmlAttribute]
        public DataProvider.PaymentType payment_method = DataProvider.PaymentType.Nagdi;
        [XmlAttribute]
        public Buyer buyer_client;
        [XmlAttribute]
        public Zednadebi SellingZednadebi = null;
        [XmlAttribute]
        public AngarishFaqtura SellingAF = null;
        [XmlArray]
        public Remainder[] OutgoingRemainders = null;

        public SellOrder()
        {
            this.dro = new DateTime();
            this.using_check = true;
            this.payment_method = DataProvider.PaymentType.Nagdi;
            this.buyer_client = null;
            this.SellingZednadebi = null;
            this.SellingAF = null;
            this.OutgoingRemainders = new List<Remainder>().ToArray();
        }

        public SellOrder(DateTime dro_arg, bool using_check_arg, DataProvider.PaymentType pay_method_arg, Buyer buyer_arg, Zednadebi zednadebi_arg, Remainder[] selling_rems_arg, AngarishFaqtura selling_af_arg)
        {
            this.dro = dro_arg;
            this.using_check = using_check_arg;
            this.payment_method = pay_method_arg;
            this.buyer_client = buyer_arg;
            this.OutgoingRemainders = selling_rems_arg;

            if (null != zednadebi_arg)
            {
                this.SellingZednadebi = zednadebi_arg;
            }
            if (null != selling_af_arg)
            {
                this.SellingAF = selling_af_arg;
            }

            if (false == using_check_arg)
            {
                this.SellingAF = null;
                this.SellingZednadebi = null;
            }
            if (null == buyer_arg)
            {
                this.payment_method = DataProvider.PaymentType.Nagdi;
            }
            else
            {
                if ("ხელზე" == buyer_arg.saidentifikacio_kodi | "" == buyer_arg.saidentifikacio_kodi)
                {
                    this.payment_method = DataProvider.PaymentType.Nagdi;
                }
            }

        }
    }
    //--

    [Serializable]
    public class Supplier
    {
        public string saidentifikacio_kodi;
        public string saxeli;
        public string address;

        public Supplier(string id_kode_arg, string name_arg, string address_arg)
        {
            saidentifikacio_kodi = id_kode_arg;
            saxeli = name_arg;
            address = address_arg;

        }
    }//Supplier Class

    [Serializable]
    public class Buyer
    {
        public string saidentifikacio_kodi;
        public string saxeli;
        public string address;

        public static Buyer xelze = new Buyer("ხელზე", "ხელზე", "ხელზე");

        public Buyer()
        {
            saidentifikacio_kodi = "0";
            saxeli = "no name";
            address = "nowhere";
        }
        public Buyer(string id_kode_arg, string name_arg, string address_arg)
        {
            saidentifikacio_kodi = id_kode_arg;
            saxeli = name_arg;
            address = address_arg;
        }
    }//Buyer Class

    [Serializable]
    public class AngarishFaqtura
    {
        public string af_nomeri;
        public string seria;
        public DateTime dro;


        public DataProvider.OperationType operation_type;
        public string supplier_saident;//
        public string buyer_saident;//romelime unda sheivsos marto, ARCERT SHEMTXVEVASHI ORIVE

        public AngarishFaqtura()
        {

        }
        public AngarishFaqtura(string seria_arg, string nomeri_arg, DateTime dro_arg, DataProvider.OperationType op_type_arg, string supplier_saident_arg)
        {
            this.seria = seria_arg;
            this.af_nomeri = nomeri_arg;
            this.dro = dro_arg;
            this.operation_type = op_type_arg;
            this.supplier_saident = supplier_saident_arg;

        }
    }//AngarishFaqtura Class

    [XmlRootAttribute("Zednadebi")]
    public class Zednadebi
    {
        public string zednadebis_nomeri = "0";
        public DateTime dro = new DateTime();
        public string af_seria = "0";
        public string af_saident = "0";//angarish-faqturis saidentifikacio kodi, sheidzleba iyos noli

        public List<Remainder> OrderedItemList = new List<Remainder>();

        public DataProvider.OperationType operation_type;
        public string supplier_saident;//
        public string buyer_saident;//romelime unda sheivsos marto, ARCERT SHEMTXVEVASHI ORIVE

        public DataProvider.PaymentType gadaxdis_metodi;


        public Zednadebi()
        {

        }
        public Zednadebi(string zed_nomeri_arg, DateTime dro_arg, string af_seria_arg, string af_ident_code_arg, DataProvider.OperationType oper_type_arg, string client_ident_code_arg, DataProvider.PaymentType payment_type_arg)
        {
            this.zednadebis_nomeri = zed_nomeri_arg;
            this.dro = dro_arg;
            this.af_seria = af_seria_arg;
            this.af_saident = af_ident_code_arg;

            this.operation_type = oper_type_arg;
            this.gadaxdis_metodi = payment_type_arg;

            if (DataProvider.OperationType.Buy == oper_type_arg)
            {
                this.supplier_saident = client_ident_code_arg;
            }
            else if (DataProvider.OperationType.Sell == oper_type_arg)
            {
                this.buyer_saident = client_ident_code_arg;
            }
        }

        public void AddRemainder(Remainder nextProd)
        {
            this.OrderedItemList.Add(nextProd);
        }
        public void AddRemainderArray(Remainder[] nextProdList)
        {
            this.OrderedItemList.AddRange(nextProdList);
        }

    }//Zednadebi Class

    [XmlRootAttribute("Remainder")]
    public class Remainder
    {
        [XmlAttribute]
        public string product_barcode = "";
        [XmlAttribute]
        public string supplier_ident = "";
        [XmlAttribute]
        public string zednadebis_nomeri = "";
        [XmlAttribute]
        public decimal initial_pieces = 0.0m;
        [XmlAttribute]
        public decimal pack_capacity = 0.0m;
        [XmlAttribute]
        public decimal remaining_pieces = 0.0m;
        [XmlAttribute]
        public decimal buy_price = 0.0m;
        [XmlAttribute]
        public decimal formal_buy_price = 0.0m;
        [XmlAttribute]
        public decimal sell_price = 0.0m;
        [XmlAttribute]
        public decimal formal_sell_price = 0.0m;
        [XmlAttribute]
        public int storehouse_id;//sacyobi

        public Remainder()
        {
        }

        public Remainder(string prod_barcode_arg, string supp_ident_arg, string zed_nomeri_arg, decimal initial_pieces_arg, decimal capacity_arg, decimal remaining_pieces_arg, decimal buy_price_arg, decimal formal_buy_price_arg, decimal sell_price_arg, decimal formal_sell_price_arg, int store_id_arg)
        {
            this.product_barcode = prod_barcode_arg;
            this.supplier_ident = supp_ident_arg;
            this.zednadebis_nomeri = zed_nomeri_arg;
            this.initial_pieces = initial_pieces_arg;
            this.pack_capacity = capacity_arg;
            this.remaining_pieces = remaining_pieces_arg;
            this.buy_price = buy_price_arg;
            this.formal_buy_price = formal_buy_price_arg;
            this.sell_price = sell_price_arg;
            this.formal_sell_price = formal_sell_price_arg;
            this.storehouse_id = store_id_arg;
        }
    }

    public class DataProvider
    {
        public enum MoneyType { Cash, Nisia };//es nisiaa da (savaraudod???) sabutebshi ver sheitan 
        public enum PaymentType { Nagdi, Unagdo, Konsignacia }//es sheidzleba bankidan gadaixados da 'MoneyType nisiasgan' gansxvavdeba. da kanonis mier agiarebuli formaa. 

        public enum OperationType { Buy, Sell };

        public enum MoneyTransferType { Give, Take };

        public enum MoneyTransferPurpose
        {
            [System.ComponentModel.Description("თანხის გადარიცხვა")]
            SimpleTransfer,
            [System.ComponentModel.Description("ვალის დაფარვა")]
            PayFor,
            [System.ComponentModel.Description("სალაროში შემოტანა")]
            AddToCashBox,
            [System.ComponentModel.Description("სალაროდან გატანა")]
            TakeFromCashBox
        };


        public static SqlConnection SqlLink = new SqlConnection("Data Source=ZERO\\MSSQLSERVER2008;Initial Catalog=productinfo_db;Integrated Security=True");

        /// <summary>
        /// user rights-is droebit chanacvleba. 
        /// </summary>
        public bool AllowSensitiveInformation = false;

        public info status = new info("საჭიროა სერვერთან დაკავშირება. ");


        public info Connect(string uname_arg, string pwd_arg)
        {
            if ("manager" == uname_arg && "123" == pwd_arg)
            {
                //this.permissionLevel=database user.permissionLevel
                this.status = new info("თქვენ გაიარეთ ავტორიზაცია. ", 0);
                this.AllowSensitiveInformation = true;
                return this.status;
            }
            else if ("user" == uname_arg && "123" == pwd_arg)
            {
                //this.permissionLevel=database user.permissionLevel
                this.status = new info("თქვენ გაიარეთ ავტორიზაცია. ", 0);
                this.AllowSensitiveInformation = false;
                return this.status;
            }
            else
            {
                this.status = new info("403 მომხმარებლის სახელი ან პაროლი არასწორია. ", 403);
                return this.status;
            }
        }

        public void Close()
        {
            SqlLink.Close();
        }

        public DataProvider()
        {
            if (File.Exists("connectionstring.conf"))
            {
                SqlLink.ConnectionString = File.ReadAllText("connectionstring.conf");
            }
            try
            {
                SqlLink.Open();
            }
            catch (SqlException)
            {
                //nothing to catch, moving to filesystem working mode. 
            }
            finally
            {
                if (SqlLink.State == ConnectionState.Open)
                {
                    this.status.details = "სერვერს წარმატებით დავუკავშირდით. ";
                    this.status.errcode = 0;
                }
                else
                {
                    this.status.details = "სერვერს ვერ ვუკავშირდებით. გადავდივართ დროებით ლოკალურ რეჟიმზე. ";
                    this.status.errcode = 404;
                }
            }
        }//

        public info AddProductName(Product prod_arg)
        {
            int resultCode = 0;

            SqlCommand addprod_sql = new SqlCommand("AddProduct", DataProvider.SqlLink);
            addprod_sql.CommandType = CommandType.StoredProcedure;
            SqlDataReader result = null;

            addprod_sql.Parameters.Add(new SqlParameter("@barcode", prod_arg.barcode));
            addprod_sql.Parameters.Add(new SqlParameter("@name", prod_arg.name));
            addprod_sql.Parameters.Add(new SqlParameter("@usesVAT", prod_arg.usesVAT));

            SqlParameter AddProdRetVal = new SqlParameter("@Return_Value", DbType.Int32);
            AddProdRetVal.Direction = ParameterDirection.ReturnValue;
            addprod_sql.Parameters.Add(AddProdRetVal);

            result = addprod_sql.ExecuteReader();
            while (result.Read())
            {
            }

            resultCode = Convert.ToInt32(AddProdRetVal.Value);


            result.Close();


            if (resultCode > 0)
            {
                //return new info("A similiar Product already exists", 183);
                return new info("ასეთი პროდუქტი უკვე არსებობს!", resultCode);
            }

            else
            {
                return new info("პროდუქტის დამატება წარმატებით დასრულდა!", 0);
            }
        }
        public info AddSupplier(Supplier supplier_arg)
        {
            info ret_info = info.niy();

            SqlCommand addsupplier_sql = new SqlCommand("AddSupplier", DataProvider.SqlLink);
            addsupplier_sql.CommandType = CommandType.StoredProcedure;

            addsupplier_sql.Parameters.Add(new SqlParameter("@id_code", supplier_arg.saidentifikacio_kodi));
            addsupplier_sql.Parameters.Add(new SqlParameter("@name", supplier_arg.saxeli));
            addsupplier_sql.Parameters.Add(new SqlParameter("@address", supplier_arg.address));

            SqlParameter AddSuppRetVal = new SqlParameter("@Return_Value", DbType.Int32);
            AddSuppRetVal.Direction = ParameterDirection.ReturnValue;
            addsupplier_sql.Parameters.Add(AddSuppRetVal);

            int result = addsupplier_sql.ExecuteNonQuery();

            ret_info.errcode = (int)AddSuppRetVal.Value;
            switch (ret_info.errcode)
            {
                case 0:
                    ret_info.details = "მომწოდებელი დაემატა!";
                    break;
                case 1:
                    ret_info.details = "გადაცემულია არასწორი არგუმენტები!";
                    break;
                case 183:
                    ret_info.details = "ასეთი მომწოდებელი უკვე არსებობს!";
                    break;
                case 404:
                    ret_info.details = "მომწოდებელი არ მოიძებნა!";
                    break;
            }
            return ret_info;
        }
        public info AddBuyer(Buyer buyer_arg)
        {
            info ret_info = info.niy();

            SqlCommand addbuyer_sql = new SqlCommand("AddBuyer", DataProvider.SqlLink);
            addbuyer_sql.CommandType = CommandType.StoredProcedure;

            addbuyer_sql.Parameters.Add(new SqlParameter("@id_code", buyer_arg.saidentifikacio_kodi));
            addbuyer_sql.Parameters.Add(new SqlParameter("@name", buyer_arg.saxeli));
            addbuyer_sql.Parameters.Add(new SqlParameter("@address", buyer_arg.address));

            SqlParameter AddBuyerRetVal = new SqlParameter("@Return_Value", DbType.Int32);
            AddBuyerRetVal.Direction = ParameterDirection.ReturnValue;
            addbuyer_sql.Parameters.Add(AddBuyerRetVal);

            int result = addbuyer_sql.ExecuteNonQuery();

            ret_info.errcode = (int)AddBuyerRetVal.Value;
            switch (ret_info.errcode)
            {
                case 0:
                    ret_info.details = "მყიდველი დაემატა!";
                    break;
                case 1:
                    ret_info.details = "გადაცემულია არასწორი არგუმენტები!";
                    break;
                case 183:
                    ret_info.details = "ასეთი მყიდველი უკვე არსებობს!";
                    break;
                case 404:
                    ret_info.details = "მყიდველი არ მოიძებნა!";
                    break;
            }
            return ret_info;
        }
        /*  */

        public info AddPurchaseOrder(PurchaseOrder p_order_arg)
        {
            info return_info = info.niy();

            SqlTransaction safe_pur_trans = SqlLink.BeginTransaction("AddPurchase_trans");

            SqlCommand AddPurchaseName_sql = new SqlCommand("AddPurchaseOrder", SqlLink, safe_pur_trans);
            AddPurchaseName_sql.CommandType = CommandType.StoredProcedure;
            AddPurchaseName_sql.Parameters.Add(new SqlParameter("@purchase_time", p_order_arg.dro));
            AddPurchaseName_sql.Parameters.Add(new SqlParameter("@supplier_ident_code", p_order_arg.supplier_client.saidentifikacio_kodi));
            AddPurchaseName_sql.Parameters.Add(new SqlParameter("@zed_ident", p_order_arg.BuyingZednadebi.zednadebis_nomeri));

            SqlParameter AddPurchRetVal = new SqlParameter("@Return_Value", DbType.Int32);
            AddPurchRetVal.Direction = ParameterDirection.ReturnValue;
            AddPurchaseName_sql.Parameters.Add(AddPurchRetVal);

            SqlDataReader pur_rdr = AddPurchaseName_sql.ExecuteReader();
            while (pur_rdr.Read())
            {
            }
            pur_rdr.Close();
            //err check
            if ((Int32)AddPurchRetVal.Value > 0)
            {
                pur_rdr.Close();
                safe_pur_trans.Rollback();
                return_info = new info(AddPurchRetVal.Value.ToString() + " error adding purchase name", Int32.Parse(AddPurchRetVal.Value.ToString()));
                return return_info;
            }
            return_info = new info(AddPurchRetVal.Value.ToString() + " result adding purchase name", Int32.Parse(AddPurchRetVal.Value.ToString()));




            if (null != p_order_arg.BuyingAF)
            {

                SqlCommand addAF_sql = new SqlCommand("AddAngarishFaqtura", SqlLink, safe_pur_trans);
                addAF_sql.CommandType = CommandType.StoredProcedure;
                addAF_sql.Parameters.Add(new SqlParameter("@nomeri", p_order_arg.BuyingAF.af_nomeri));
                addAF_sql.Parameters.Add(new SqlParameter("@seria", p_order_arg.BuyingAF.seria));
                addAF_sql.Parameters.Add(new SqlParameter("@dro", p_order_arg.BuyingAF.dro));
                addAF_sql.Parameters.Add(new SqlParameter("@operation", p_order_arg.BuyingAF.operation_type.ToString()));
                addAF_sql.Parameters.Add(new SqlParameter("@client_ident", p_order_arg.BuyingAF.supplier_saident));

                SqlParameter addAFRetVal = new SqlParameter("@Return_Value", DbType.Int32);
                addAFRetVal.Direction = ParameterDirection.ReturnValue;
                addAF_sql.Parameters.Add(addAFRetVal);

                SqlDataReader addAF_rdr = addAF_sql.ExecuteReader();
                while (addAF_rdr.Read())
                {
                }
                addAF_rdr.Close();
                if ((Int32)addAFRetVal.Value > 0 && (Int32)addAFRetVal.Value != 183)
                {
                    addAF_rdr.Close();
                    safe_pur_trans.Rollback();
                    return_info = new info(addAFRetVal.Value.ToString() + " error adding angarish/faqtura", Int32.Parse(addAFRetVal.Value.ToString()));
                    return return_info;
                }
                return_info = new info(addAFRetVal.Value.ToString() + " result adding angarish/faqtura", Int32.Parse(addAFRetVal.Value.ToString()));


            }

            SqlCommand addZed_sql = new SqlCommand("AddZednadebi", SqlLink, safe_pur_trans);
            addZed_sql.CommandType = CommandType.StoredProcedure;
            addZed_sql.Parameters.Add(new SqlParameter("@id_code", p_order_arg.BuyingZednadebi.zednadebis_nomeri));
            addZed_sql.Parameters.Add(new SqlParameter("@dro", p_order_arg.BuyingZednadebi.dro));
            addZed_sql.Parameters.Add(new SqlParameter("@operation", p_order_arg.BuyingZednadebi.operation_type.ToString()));
            addZed_sql.Parameters.Add(new SqlParameter("@client_id", p_order_arg.BuyingZednadebi.supplier_saident));
            addZed_sql.Parameters.Add(new SqlParameter("@af_seria", p_order_arg.BuyingZednadebi.af_seria));
            addZed_sql.Parameters.Add(new SqlParameter("@af_nomeri", p_order_arg.BuyingZednadebi.af_saident));
            addZed_sql.Parameters.Add(new SqlParameter("@pay_method", p_order_arg.BuyingZednadebi.gadaxdis_metodi.ToString()));

            SqlParameter addZedRetVal = new SqlParameter("@Return_Value", DbType.Int32);
            addZedRetVal.Direction = ParameterDirection.ReturnValue;
            addZed_sql.Parameters.Add(addZedRetVal);

            SqlDataReader addzed_rdr = addZed_sql.ExecuteReader();
            while (addzed_rdr.Read())
            {
            }
            addzed_rdr.Close();
            //check for errors
            if ((Int32)addZedRetVal.Value > 0)
            {
                addzed_rdr.Close();
                safe_pur_trans.Rollback();
                return_info = new info(addZedRetVal.Value.ToString() + " error adding zednadebi", Int32.Parse(addZedRetVal.Value.ToString()));
                return return_info;
            }
            return_info = new info(addZedRetVal.Value.ToString() + " result adding zednadebi", Int32.Parse(addZedRetVal.Value.ToString()));


            foreach (Remainder addRem in p_order_arg.IncomingRemainders)
            {
                //DONT USE HERE AddRemainder() UNLESS THE TRANSACTION PART IS INCLUDED
                SqlCommand addRemSql = new SqlCommand("AddRemainder", SqlLink, safe_pur_trans);
                addRemSql.CommandType = CommandType.StoredProcedure;
                addRemSql.Parameters.Add(new SqlParameter("@barcode", addRem.product_barcode));
                addRemSql.Parameters.Add(new SqlParameter("@supplier_ident", addRem.supplier_ident));
                addRemSql.Parameters.Add(new SqlParameter("@zed_nomeri", addRem.zednadebis_nomeri));
                addRemSql.Parameters.Add(new SqlParameter("@initial_pieces", addRem.initial_pieces));
                addRemSql.Parameters.Add(new SqlParameter("@remaining_pieces", addRem.remaining_pieces));
                addRemSql.Parameters.Add(new SqlParameter("@capacity", addRem.pack_capacity));
                addRemSql.Parameters.Add(new SqlParameter("@buy_price", addRem.buy_price));
                addRemSql.Parameters.Add(new SqlParameter("@sell_price", addRem.sell_price));
                addRemSql.Parameters.Add(new SqlParameter("@store_id", addRem.storehouse_id));

                SqlParameter addrem_retval = new SqlParameter("@Return_Value", DbType.Int32);
                addrem_retval.Direction = ParameterDirection.ReturnValue;
                addRemSql.Parameters.Add(addrem_retval);

                SqlDataReader addrem_rdr = addRemSql.ExecuteReader();
                while (addrem_rdr.Read())
                {
                }
                addrem_rdr.Close();
                if ((Int32)addrem_retval.Value > 0)
                {
                    addrem_rdr.Close();
                    safe_pur_trans.Rollback();
                    return_info = new info(addrem_retval.Value.ToString() + " error adding remainder", Int32.Parse(addrem_retval.Value.ToString()));
                    return return_info;
                }
                return_info = new info(addrem_retval.Value.ToString() + " result adding remainder", Int32.Parse(addrem_retval.Value.ToString()));



            }

            //
            safe_pur_trans.Commit();
            ////
            return return_info;
        }

        public info AddSellOrder(SellOrder s_order_arg, out int SellOrderInsertID_out_arg)
        {
            info return_info = info.niy();

            SqlTransaction safe_sell_trans = SqlLink.BeginTransaction("AddSellOrder_trans");

            int SellOrderInsertID = 0;

            SqlCommand AddSellName_sql = new SqlCommand("AddSellOrder", SqlLink, safe_sell_trans);
            AddSellName_sql.CommandType = CommandType.StoredProcedure;
            AddSellName_sql.Parameters.Add(new SqlParameter("@sell_time", s_order_arg.dro));
            AddSellName_sql.Parameters.Add(new SqlParameter("@buyer_ident_code", s_order_arg.buyer_client.saidentifikacio_kodi));

            if (null != s_order_arg.SellingZednadebi)
            {
                AddSellName_sql.Parameters.Add(new SqlParameter("@zed_ident", s_order_arg.SellingZednadebi.zednadebis_nomeri));
            }
            else
            {
                AddSellName_sql.Parameters.Add(new SqlParameter("@zed_ident", ""));
            }
            AddSellName_sql.Parameters.Add(new SqlParameter("@selling_with_check", s_order_arg.using_check));

            SqlParameter AddSOInsertIdPar = new SqlParameter("@Insert_Id", DbType.Int32);
            AddSOInsertIdPar.Direction = ParameterDirection.Output;
            AddSellName_sql.Parameters.Add(AddSOInsertIdPar);
            AddSellName_sql.Parameters.Add(new SqlParameter("@payment_method", s_order_arg.payment_method.ToString()));

            SqlParameter AddSellRetVal = new SqlParameter("@Return_Value", DbType.Int32);
            AddSellRetVal.Direction = ParameterDirection.ReturnValue;
            AddSellName_sql.Parameters.Add(AddSellRetVal);

            SqlDataReader addsel_rdr = AddSellName_sql.ExecuteReader();
            while (addsel_rdr.Read())
            {
            }
            SellOrderInsertID = (Int32)AddSOInsertIdPar.Value;
            SellOrderInsertID_out_arg = SellOrderInsertID;
            if ((Int32)AddSellRetVal.Value > 0)
            {
                addsel_rdr.Close();
                safe_sell_trans.Rollback();
                return_info = new info(AddSellRetVal.Value.ToString() + " error adding SellOrder name", Int32.Parse(AddSellRetVal.Value.ToString()));
                return return_info;
            }
            return_info = new info(AddSellRetVal.Value.ToString() + " result adding SellOrder name", Int32.Parse(AddSellRetVal.Value.ToString()));


            addsel_rdr.Close();

            if (null != s_order_arg.SellingAF)
            {

                SqlCommand addAF_sql = new SqlCommand("AddAngarishFaqtura", SqlLink, safe_sell_trans);
                addAF_sql.CommandType = CommandType.StoredProcedure;
                addAF_sql.Parameters.Add(new SqlParameter("@nomeri", s_order_arg.SellingAF.af_nomeri));
                addAF_sql.Parameters.Add(new SqlParameter("@seria", s_order_arg.SellingAF.seria));
                addAF_sql.Parameters.Add(new SqlParameter("@dro", s_order_arg.SellingAF.dro));
                addAF_sql.Parameters.Add(new SqlParameter("@operation", s_order_arg.SellingAF.operation_type.ToString()));
                addAF_sql.Parameters.Add(new SqlParameter("@client_ident", s_order_arg.SellingAF.supplier_saident));

                SqlParameter addAFRetVal = new SqlParameter("@Return_Value", DbType.Int32);
                addAFRetVal.Direction = ParameterDirection.ReturnValue;
                addAF_sql.Parameters.Add(addAFRetVal);

                SqlDataReader addAF_rdr = addAF_sql.ExecuteReader();
                while (addAF_rdr.Read())
                {
                }
                //check for errors
                if ((Int32)addAFRetVal.Value > 0 && (Int32)addAFRetVal.Value != 183)//on error 183 we continue. (=af is already added. )
                {
                    addAF_rdr.Close();
                    safe_sell_trans.Rollback();
                    return_info = new info(addAFRetVal.Value.ToString() + " error adding angarish/faqtura", Int32.Parse(addAFRetVal.Value.ToString()));
                    return return_info;
                }
                return_info = new info(addAFRetVal.Value.ToString() + " result adding angarish/faqtura", Int32.Parse(addAFRetVal.Value.ToString()));


                addAF_rdr.Close();
            }

            if (null != s_order_arg.SellingZednadebi)
            {
                SqlCommand addZed_sql = new SqlCommand("AddZednadebi", SqlLink, safe_sell_trans);
                addZed_sql.CommandType = CommandType.StoredProcedure;
                addZed_sql.Parameters.Add(new SqlParameter("@id_code", s_order_arg.SellingZednadebi.zednadebis_nomeri));
                addZed_sql.Parameters.Add(new SqlParameter("@dro", s_order_arg.SellingZednadebi.dro));
                addZed_sql.Parameters.Add(new SqlParameter("@operation", s_order_arg.SellingZednadebi.operation_type.ToString()));
                addZed_sql.Parameters.Add(new SqlParameter("@client_id", s_order_arg.SellingZednadebi.buyer_saident));
                addZed_sql.Parameters.Add(new SqlParameter("@af_seria", s_order_arg.SellingZednadebi.af_seria));
                addZed_sql.Parameters.Add(new SqlParameter("@af_nomeri", s_order_arg.SellingZednadebi.af_saident));
                addZed_sql.Parameters.Add(new SqlParameter("@pay_method", s_order_arg.SellingZednadebi.gadaxdis_metodi.ToString()));

                SqlParameter addZedRetVal = new SqlParameter("@Return_Value", DbType.Int32);
                addZedRetVal.Direction = ParameterDirection.ReturnValue;
                addZed_sql.Parameters.Add(addZedRetVal);

                SqlDataReader addzed_rdr = addZed_sql.ExecuteReader();
                while (addzed_rdr.Read())
                {
                }
                //check for errors
                if ((Int32)addZedRetVal.Value > 0)
                {
                    addzed_rdr.Close();
                    safe_sell_trans.Rollback();
                    return_info = new info(addZedRetVal.Value.ToString() + " error adding zednadebi", Int32.Parse(addZedRetVal.Value.ToString()));
                    return return_info;
                }
                return_info = new info(addZedRetVal.Value.ToString() + " result adding zednadebi", Int32.Parse(addZedRetVal.Value.ToString()));


                addzed_rdr.Close();
            }

            foreach (Remainder sellRem in s_order_arg.OutgoingRemainders)
            {
                if (0.0m >= sellRem.sell_price | 0.0m >= sellRem.initial_pieces)
                {
                    safe_sell_trans.Rollback();
                    return_info = new info("გადაცემულია არასწორი პარამეტრები", 1);
                    return return_info;
                }
                //TODO
                SqlCommand sellRemSql = new SqlCommand("SellRemainder", SqlLink, safe_sell_trans);
                sellRemSql.CommandType = CommandType.StoredProcedure;
                sellRemSql.Parameters.Add(new SqlParameter("@barcode", sellRem.product_barcode));
                sellRemSql.Parameters.Add(new SqlParameter("@storeID", sellRem.storehouse_id));
                sellRemSql.Parameters.Add(new SqlParameter("@selling_count", sellRem.initial_pieces));
                sellRemSql.Parameters.Add(new SqlParameter("@piece_price", sellRem.sell_price));
                sellRemSql.Parameters.Add(new SqlParameter("@SellOrderID", AddSOInsertIdPar.Value));

                SqlParameter sellrem_retval = new SqlParameter("@Return_Value", DbType.Int32);
                sellrem_retval.Direction = ParameterDirection.ReturnValue;
                sellRemSql.Parameters.Add(sellrem_retval);

                SqlDataReader sellrem_rdr = sellRemSql.ExecuteReader();
                while (sellrem_rdr.Read())
                {
                }
                sellrem_rdr.Close();
                if ((Int32)sellrem_retval.Value > 0)
                {
                    safe_sell_trans.Rollback();
                    return_info = new info(sellrem_retval.Value.ToString() + " error adding remainder", Int32.Parse(sellrem_retval.Value.ToString()));
                    return return_info;
                }
                return_info = new info(sellrem_retval.Value.ToString() + " result adding remainder", Int32.Parse(sellrem_retval.Value.ToString()));
                sellrem_rdr.Close();
                //end TODO foreach, the rest is done in this function
            }

            //
            safe_sell_trans.Commit();
            ////
            return return_info;
        }

        public info SellRemainders(Remainder[] RemainderSellList_arg)
        {
            //wont implement
            return info.niy();
        }

        public Remainder[] FilterByStore(int store_id)
        {
            List<Remainder> PerStoreRemainders = new List<Remainder>();
            SqlCommand filter_store_sql = new SqlCommand("RemaindersInStoreID", DataProvider.SqlLink);
            filter_store_sql.CommandType = CommandType.StoredProcedure;
            SqlDataReader ResultSet = null;

            filter_store_sql.Parameters.Add(new SqlParameter("@StoreID", store_id));

            ResultSet = filter_store_sql.ExecuteReader();

            while (ResultSet.Read())
            {
                Remainder nextRem = new Remainder();
                nextRem.product_barcode = (string)ResultSet["product_barcode"];
                nextRem.zednadebis_nomeri = (string)ResultSet["supplier_ident"];
                nextRem.zednadebis_nomeri = (string)ResultSet["zednadebis_nomeri"];
                nextRem.initial_pieces = (decimal)ResultSet["initial_pieces"];
                nextRem.pack_capacity = (decimal)ResultSet["pack_capacity"];
                nextRem.remaining_pieces = (decimal)ResultSet["remaining_pieces"];
                nextRem.buy_price = (decimal)ResultSet["buy_price"];
                nextRem.formal_buy_price = (decimal)ResultSet["formal_buy_price"];
                nextRem.sell_price = (decimal)ResultSet["sell_price"];
                nextRem.formal_sell_price = (decimal)ResultSet["formal_sell_price"];
                nextRem.storehouse_id = (int)ResultSet["storehouse_id"];

                PerStoreRemainders.Add(nextRem);
            }

            ResultSet.Close();

            return PerStoreRemainders.ToArray();
        }//FilterByStore

        public Product GetProductByBarCode(string barcode_arg)
        {
            Product bycode_prod = new Product();

            SqlCommand prodbybarcode_cmd = new SqlCommand("GetProductByBarCode", DataProvider.SqlLink);
            prodbybarcode_cmd.CommandType = CommandType.StoredProcedure;
            prodbybarcode_cmd.Parameters.Add(new SqlParameter("@barcode_par", barcode_arg));

            SqlDataReader rs = prodbybarcode_cmd.ExecuteReader();

            while (rs.Read())
            {
                bycode_prod.barcode = (string)rs["barcode"];
                bycode_prod.name = (string)rs["name"];
                bycode_prod.usesVAT = Convert.ToBoolean(rs["uses_vat"]);
            }

            rs.Close();

            return bycode_prod;
        }

        public Product[] GetProductSuggestions(string hintname_arg)
        {
            List<Product> prod_suggestions = new List<Product>();

            SqlCommand prodsuggestions_cmd = new SqlCommand("GetProductSuggestions", DataProvider.SqlLink);
            prodsuggestions_cmd.CommandType = CommandType.StoredProcedure;
            prodsuggestions_cmd.Parameters.Add(new SqlParameter("@hintnname_arg", hintname_arg));

            SqlDataReader rs = prodsuggestions_cmd.ExecuteReader();

            while (rs.Read())
            {
                Product prod_alt = new Product();
                prod_alt.barcode = (string)rs["barcode"];
                prod_alt.name = (string)rs["name"];
                prod_alt.usesVAT = Convert.ToBoolean(rs["uses_vat"]);

                prod_suggestions.Add(prod_alt);
            }

            rs.Close();

            return prod_suggestions.ToArray();
        }

        public DataTable GetRemaindersByProductName(int store_id, DateTime from_time, DateTime to_time)
        {
            DataTable prodrems_dt = new DataTable();
            prodrems_dt.Columns.Add("შტრიხ–კოდი");
            prodrems_dt.Columns.Add("დასახელება");
            prodrems_dt.Columns.Add("ტევადობა");
            prodrems_dt.Columns.Add("საწყისი ჯამ. საცალო რაოდ.");
            prodrems_dt.Columns.Add("საწყისი ღირებულება");
            prodrems_dt.Columns.Add("დარჩენილია");
            prodrems_dt.Columns.Add("საცალო ფასი");
            prodrems_dt.Columns.Add("დარჩენილის ღირებულება");
            prodrems_dt.Columns.Add("ღირ. დღგ–ს გარეშე");

            SqlCommand byprodrems_sql = new SqlCommand("GetRemaindersByProductName", DataProvider.SqlLink);
            byprodrems_sql.CommandType = CommandType.StoredProcedure;

            byprodrems_sql.Parameters.Add(new SqlParameter("@StoreID", store_id));
            byprodrems_sql.Parameters.Add(new SqlParameter("@FromTime", from_time));
            byprodrems_sql.Parameters.Add(new SqlParameter("@ToTime", to_time));

            SqlDataReader prodrems_rs = byprodrems_sql.ExecuteReader();

            while (prodrems_rs.Read())
            {
                DataRow newRec = prodrems_dt.NewRow();
                newRec["შტრიხ–კოდი"] = prodrems_rs["product_barcode"];
                newRec["დასახელება"] = prodrems_rs["product_name"];

                newRec["ტევადობა"] = prodrems_rs["rem_capacity"];
                try { newRec["ტევადობა"] = Math.Round(Utilities.Utilities.ParseDecimal(prodrems_rs["rem_capacity"].ToString()), 4, MidpointRounding.AwayFromZero); }
                catch (Exception) { }

                newRec["საწყისი ჯამ. საცალო რაოდ."] = prodrems_rs["initial_pieces"];
                newRec["საწყისი ღირებულება"] = prodrems_rs["sum_initial_cost"];

                newRec["დარჩენილია"] = prodrems_rs["remaining_pieces"];

                newRec["საცალო ფასი"] = prodrems_rs["piece_price"].ToString();
                newRec["დარჩენილის ღირებულება"] = prodrems_rs["whole_remaining_sum"].ToString();
                newRec["ღირ. დღგ–ს გარეშე"] = prodrems_rs["whole_remaining_sum_withoutVAT"].ToString();


                try { newRec["საცალო ფასი"] = Math.Round(Utilities.Utilities.ParseDecimal(prodrems_rs["piece_price"].ToString()), 4, MidpointRounding.AwayFromZero); }
                catch (Exception) { }
                try { newRec["დარჩენილის ღირებულება"] = Math.Round(Utilities.Utilities.ParseDecimal(prodrems_rs["whole_remaining_sum"].ToString()), 4, MidpointRounding.AwayFromZero); }
                catch (Exception) { }
                try { newRec["ღირ. დღგ–ს გარეშე"] = Math.Round(Utilities.Utilities.ParseDecimal(prodrems_rs["whole_remaining_sum_withoutVAT"].ToString()), 4, MidpointRounding.AwayFromZero); }
                catch (Exception) { }


                prodrems_dt.Rows.Add(newRec);
            }

            prodrems_rs.Close();

            return prodrems_dt;
        }

        public DataTable GetSoldRemaindersByProductName(int store_id, DateTime since_arg, DateTime until_arg)
        {
            DataTable sold_prodrems_dt = new DataTable();
            sold_prodrems_dt.Columns.Add("შტრიხ–კოდი");
            sold_prodrems_dt.Columns.Add("დასახელება");
            sold_prodrems_dt.Columns.Add("რაოდენობა (ცალობით)");
            sold_prodrems_dt.Columns.Add("საშუალო ფასი");
            sold_prodrems_dt.Columns.Add("საშუალო ღირებულება");
            sold_prodrems_dt.Columns.Add("საშ. ღირ.დღგ–ს გარეშე");

            SqlCommand byprod_soldrems_sql = new SqlCommand("GetSoldRemaindersByProductName", DataProvider.SqlLink);
            byprod_soldrems_sql.CommandType = CommandType.StoredProcedure;

            byprod_soldrems_sql.Parameters.Add(new SqlParameter("@StoreID", store_id));
            byprod_soldrems_sql.Parameters.Add(new SqlParameter("@Since", since_arg));
            byprod_soldrems_sql.Parameters.Add(new SqlParameter("@Until", until_arg));

            SqlDataReader prod_soldrems_rs = byprod_soldrems_sql.ExecuteReader();

            while (prod_soldrems_rs.Read())
            {
                DataRow newRec = sold_prodrems_dt.NewRow();
                for (int i = 0; i < prod_soldrems_rs.FieldCount; i++)
                {
                    newRec[i] = prod_soldrems_rs[i];
                    if ((2 == i | 3 == i | 4 == i | 5 == i) && "" != prod_soldrems_rs[i].ToString())
                    {
                        newRec[i] = Math.Round(Utilities.Utilities.ParseDecimal(prod_soldrems_rs[i].ToString()), 4, MidpointRounding.AwayFromZero);
                    }
                }
                sold_prodrems_dt.Rows.Add(newRec);
            }

            prod_soldrems_rs.Close();

            return sold_prodrems_dt;
        }

        public Remainder[] FilterRemainders(string filter_arg)
        {
            List<Remainder> filteredVal = new List<Remainder>();
            SqlCommand rem_textfilter = new SqlCommand("FilterRemainders", DataProvider.SqlLink);
            rem_textfilter.CommandType = CommandType.StoredProcedure;
            rem_textfilter.Parameters.Add(new SqlParameter("@FilterString", filter_arg));

            SqlDataReader rs = rem_textfilter.ExecuteReader();

            while (rs.Read())
            {
                Remainder nextRem = new Remainder((string)rs["product_barcode"], (string)rs["supplier_ident"], (string)rs["zednadebis_nomeri"], (decimal)rs["initial_pieces"], (decimal)rs["pack_capacity"], (decimal)rs["remaining_pieces"], (decimal)rs["buy_price"], (decimal)rs["formal_buy_price"], (decimal)rs["sell_price"], (decimal)rs["formal_sell_price"], (int)rs["storehouse_id"]);
                filteredVal.Add(nextRem);
            }

            rs.Close();

            return filteredVal.ToArray();
        }

        public DataTable Sold_Rem_Statistics(int storeid_arg, DateTime since_arg, DateTime until_arg)
        {
            DataTable sold_ret_dt = new DataTable();
            sold_ret_dt.Columns.Add("id");
            sold_ret_dt.Columns.Add("თარიღი");
            sold_ret_dt.Columns.Add("სალაროს N.");
            sold_ret_dt.Columns.Add("მყიდველი");
            sold_ret_dt.Columns.Add("საწყობის N.");
            sold_ret_dt.Columns.Add("ზედნადების ნომერი");
            sold_ret_dt.Columns.Add("ჩეკით");
            sold_ret_dt.Columns.Add("ღირებულება");
            sold_ret_dt.Columns.Add("ღირებულება დღგ–ს გარეშე");
            sold_ret_dt.Columns.Add("გასაყიდი ფასი");
            sold_ret_dt.Columns.Add("აღებული თანხა");
            sold_ret_dt.Columns.Add("მოგება");
            sold_ret_dt.Columns.Add("ფასთა სხვაობა დღგ–ს გარეშე");

            SqlCommand filter_orders_sql = new SqlCommand("Sold_Rem_Statistics", DataProvider.SqlLink);
            filter_orders_sql.CommandType = CommandType.StoredProcedure;

            filter_orders_sql.Parameters.Add(new SqlParameter("@StoreID", storeid_arg));
            filter_orders_sql.Parameters.Add(new SqlParameter("@since_date", since_arg));
            filter_orders_sql.Parameters.Add(new SqlParameter("@until_date", until_arg));

            SqlDataReader ResultSet = filter_orders_sql.ExecuteReader();

            while (ResultSet.Read())
            {
                DataRow nextSold = sold_ret_dt.NewRow();
                for (int i = 0; i < ResultSet.FieldCount; i++)
                {
                    nextSold[i] = ResultSet[i];
                    if ((6 == i | 7 == i | 8 == i | 9 == i | 10 == i | 11 == i | 12 == i) && "" != ResultSet[i].ToString())
                    {
                        nextSold[i] = Math.Round(Utilities.Utilities.ParseDecimal(ResultSet[i].ToString()), 4, MidpointRounding.AwayFromZero);
                    }
                }

                sold_ret_dt.Rows.Add(nextSold);
            }

            ResultSet.Close();

            return sold_ret_dt;
        }//NavachriByDate

        public Supplier[] AllSuppliers()
        {
            List<Supplier> all_suppliers_list = new List<Supplier>();

            SqlCommand all_suppliers_sql = new SqlCommand("SELECT * FROM dbo.suppliers ORDER BY name ASC", DataProvider.SqlLink);
            SqlDataReader all_suppliers_res = all_suppliers_sql.ExecuteReader();

            while (all_suppliers_res.Read())
            {
                Supplier nextSupplier = new Supplier((string)all_suppliers_res["id_code"], (string)all_suppliers_res["name"], (string)all_suppliers_res["address"]);
                all_suppliers_list.Add(nextSupplier);
            }

            all_suppliers_res.Close();

            return all_suppliers_list.ToArray();
        }//AllSuppliers

        public Buyer[] AllBuyers()
        {
            List<Buyer> all_buyers_list = new List<Buyer>();

            SqlCommand all_buyers_sql = new SqlCommand("SELECT * FROM dbo.buyers ORDER BY name ASC", DataProvider.SqlLink);
            SqlDataReader all_buyers_res = all_buyers_sql.ExecuteReader();

            while (all_buyers_res.Read())
            {
                Buyer nextBuyer = new Buyer((string)all_buyers_res["id_code"], (string)all_buyers_res["name"], (string)all_buyers_res["address"]);
                all_buyers_list.Add(nextBuyer);
            }

            all_buyers_res.Close();

            return all_buyers_list.ToArray();
        }//AllBuyers

        public DataTable Bought_AF_Statistics()
        {
            DataTable bought_af_ret_dt = new DataTable();
            bought_af_ret_dt.Columns.Add("შემომტანის საიდენტ.");
            bought_af_ret_dt.Columns.Add("შემომტანის სახელი");
            bought_af_ret_dt.Columns.Add("სერია");
            bought_af_ret_dt.Columns.Add("საიდენტ. კოდი");
            bought_af_ret_dt.Columns.Add("თარიღი");
            bought_af_ret_dt.Columns.Add("ოპერაცია");
            bought_af_ret_dt.Columns.Add("ზედნად. რაოდენობა");
            bought_af_ret_dt.Columns.Add("საერთო ღირებულება");
            bought_af_ret_dt.Columns.Add("საერთო ღირ. დღგ–ს გარეშე");
            bought_af_ret_dt.Columns.Add("დღგ–ს თანხა");

            SqlCommand bought_af_statistics_sql = new SqlCommand("Bought_AF_Statistics", SqlLink);
            bought_af_statistics_sql.CommandType = CommandType.StoredProcedure;
            SqlDataReader bought_af_res = bought_af_statistics_sql.ExecuteReader();
            while (bought_af_res.Read())
            {
                DataRow nextRow = bought_af_ret_dt.NewRow();
                for (int i = 0; i < bought_af_res.FieldCount; i++)
                {
                    nextRow[i] = bought_af_res[i];
                    if ((7 == i | 8 == i | 9 == i) && "" != bought_af_res[i].ToString())
                    {
                        nextRow[i] = Math.Round(Utilities.Utilities.ParseDecimal(bought_af_res[i].ToString()), 4, MidpointRounding.AwayFromZero);
                    }
                }
                bought_af_ret_dt.Rows.Add(nextRow);
            }
            bought_af_res.Close();

            return bought_af_ret_dt;
        }

        public DataTable Sold_AF_Statistics()
        {
            DataTable sold_af_ret_dt = new DataTable();
            sold_af_ret_dt.Columns.Add("მყიდველის სახელი");
            sold_af_ret_dt.Columns.Add("სერია");
            sold_af_ret_dt.Columns.Add("საიდენტ. კოდი");
            sold_af_ret_dt.Columns.Add("თარიღი");
            sold_af_ret_dt.Columns.Add("ოპერაცია");
            sold_af_ret_dt.Columns.Add("ზედნად. რაოდენობა");
            sold_af_ret_dt.Columns.Add("საერთო ღირებულება");
            sold_af_ret_dt.Columns.Add("საერთო ღირ. დღგ–ს გარეშე");

            SqlCommand sold_af_statistics_sql = new SqlCommand("Sold_AF_Statistics", SqlLink);
            sold_af_statistics_sql.CommandType = CommandType.StoredProcedure;
            SqlDataReader sold_af_res = sold_af_statistics_sql.ExecuteReader();
            while (sold_af_res.Read())
            {
                DataRow nextRow = sold_af_ret_dt.NewRow();
                for (int i = 0; i < sold_af_res.FieldCount; i++)
                {
                    nextRow[i] = sold_af_res[i];
                    if ((6 == i | 7 == i) && "" != sold_af_res[i].ToString())
                    {
                        nextRow[i] = Math.Round(Utilities.Utilities.ParseDecimal(sold_af_res[i].ToString()), 4, MidpointRounding.AwayFromZero);
                    }
                }
                sold_af_ret_dt.Rows.Add(nextRow);
            }
            sold_af_res.Close();

            return sold_af_ret_dt;
        }

        public DataTable Bought_Zed_Statistics(DateTime since_arg, DateTime until_arg)
        {
            DataTable zeds_dt = new DataTable();
            zeds_dt.Columns.Add("საიდენტ. კოდი");
            zeds_dt.Columns.Add("თარიღი");
            zeds_dt.Columns.Add("მომწოდებელი");
            zeds_dt.Columns.Add("ა/ფ სერია");
            zeds_dt.Columns.Add("ა/ფ ნომერი");
            zeds_dt.Columns.Add("ღირ.");
            zeds_dt.Columns.Add("ღირ. დღგ–ს გარეშე");

            SqlCommand zeds_statistics_sql = new SqlCommand("Bought_Zed_Statistics", SqlLink);
            zeds_statistics_sql.CommandType = CommandType.StoredProcedure;

            zeds_statistics_sql.Parameters.Add(new SqlParameter("@since_date", since_arg));
            zeds_statistics_sql.Parameters.Add(new SqlParameter("@until_date", until_arg));

            SqlDataReader zeds_rdr = zeds_statistics_sql.ExecuteReader();
            while (zeds_rdr.Read())
            {
                DataRow nextZedRow = zeds_dt.NewRow();
                for (int i = 0; i < zeds_rdr.FieldCount; i++)
                {
                    nextZedRow[i] = zeds_rdr[i];
                    if ((5 == i | 6 == i) && "" != zeds_rdr[i].ToString())
                    {
                        nextZedRow[i] = Math.Round(Utilities.Utilities.ParseDecimal(zeds_rdr[i].ToString()), 4, MidpointRounding.AwayFromZero);
                    }
                }
                zeds_dt.Rows.Add(nextZedRow);
            }
            zeds_rdr.Close();

            return zeds_dt;
        }

        public DataTable Sold_Zed_Statistics(DateTime since_arg, DateTime until_arg)
        {
            DataTable sold_zeds_dt = new DataTable();
            sold_zeds_dt.Columns.Add("საიდენტ. კოდი");
            sold_zeds_dt.Columns.Add("თარიღი");
            sold_zeds_dt.Columns.Add("მყიდველი");
            sold_zeds_dt.Columns.Add("ა/ფ სერია");
            sold_zeds_dt.Columns.Add("ა/ფ ნომერი");
            sold_zeds_dt.Columns.Add("თვითღირ");
            sold_zeds_dt.Columns.Add("თვითღირ. დღგ–ს გარეშე");
            sold_zeds_dt.Columns.Add("აღ. თანხა");
            sold_zeds_dt.Columns.Add("ზედ. ღირ.");
            sold_zeds_dt.Columns.Add("მოგება");
            sold_zeds_dt.Columns.Add("მოგება დღგ–ს გარეშე");
            sold_zeds_dt.Columns.Add("დღგ");
            sold_zeds_dt.Columns.Add("ზედ.ღირ. დღგ–ს გარეშე");

            SqlCommand sold_zeds_statistics_sql = new SqlCommand("Sold_Zed_Statistics", SqlLink);
            sold_zeds_statistics_sql.CommandType = CommandType.StoredProcedure;

            sold_zeds_statistics_sql.Parameters.Add(new SqlParameter("@since_date", since_arg));
            sold_zeds_statistics_sql.Parameters.Add(new SqlParameter("@until_date", until_arg));

            SqlDataReader sold_zeds_rdr = sold_zeds_statistics_sql.ExecuteReader();
            while (sold_zeds_rdr.Read())
            {
                DataRow nextZedRow = sold_zeds_dt.NewRow();
                for (int i = 0; i < sold_zeds_rdr.FieldCount; i++)
                {
                    nextZedRow[i] = sold_zeds_rdr[i];
                    if ((5 == i | 6 == i | 7 == i | 8 == i | 9 == i | 10 == i | 11 == i | 12 == i) && "" != sold_zeds_rdr[i].ToString())
                    {
                        nextZedRow[i] = Math.Round(Utilities.Utilities.ParseDecimal(sold_zeds_rdr[i].ToString()), 4, MidpointRounding.AwayFromZero);
                    }
                }
                sold_zeds_dt.Rows.Add(nextZedRow);
            }
            sold_zeds_rdr.Close();

            return sold_zeds_dt;
        }

        public DataTable Rem_Statistics(int store_id, DateTime from_time, DateTime to_time)
        {
            DataTable rems_dt = new DataTable();
            rems_dt.Columns.Add("შტრიხ–კოდი");//product_barcode
            rems_dt.Columns.Add("დასახელება");//product_name
            rems_dt.Columns.Add("მომწოდებელი");
            rems_dt.Columns.Add("ტევ.");
            rems_dt.Columns.Add("საწყ.N");
            rems_dt.Columns.Add("დარჩენილია");
            rems_dt.Columns.Add("საც. ფასი");
            rems_dt.Columns.Add("გასაყიდი ფასი");
            rems_dt.Columns.Add("ჯამ. გასაყიდი ფასი");
            rems_dt.Columns.Add("საწყ. ღირ");
            rems_dt.Columns.Add("დარჩ. ღირ.");
            rems_dt.Columns.Add("დარჩ. ღირ. დღგ–ს გარეშე");

            SqlCommand rem_statistics_sql = new SqlCommand("Rem_Statistics", SqlLink);
            rem_statistics_sql.CommandType = CommandType.StoredProcedure;

            rem_statistics_sql.Parameters.Add(new SqlParameter("@StoreID", store_id));
            rem_statistics_sql.Parameters.Add(new SqlParameter("@FromTime", from_time));
            rem_statistics_sql.Parameters.Add(new SqlParameter("@ToTime", to_time));

            SqlDataReader rems_rdr = rem_statistics_sql.ExecuteReader();
            while (rems_rdr.Read())
            {
                DataRow nextRemRow = rems_dt.NewRow();
                for (int i = 0; i < rems_rdr.FieldCount; i++)
                {
                    nextRemRow[i] = rems_rdr[i];
                    if ((3 == i | 6 == i | 7 == i | 8 == i | 9 == i) && "" != rems_rdr[i].ToString())
                    {
                        try
                        {
                            nextRemRow[i] = Utilities.Utilities.ParseDecimal(Math.Round(Utilities.Utilities.ParseDecimal(rems_rdr[i].ToString()), 4, MidpointRounding.AwayFromZero).ToString("G18"));
                        }
                        catch (FormatException)
                        {
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
                rems_dt.Rows.Add(nextRemRow);
            }
            rems_rdr.Close();

            return rems_dt;
        }

        public info UpdateProduct(string barcode_arg, string newname_arg, int newVATvalue_arg)
        {
            info ret_info = info.niy();

            SqlCommand updprod_sql = new SqlCommand("UpdateProduct", SqlLink);
            updprod_sql.CommandType = CommandType.StoredProcedure;

            updprod_sql.Parameters.Add(new SqlParameter("@barcode", barcode_arg));
            updprod_sql.Parameters.Add(new SqlParameter("@newname", newname_arg));
            updprod_sql.Parameters.Add(new SqlParameter("@newVATvalue", newVATvalue_arg));

            SqlParameter updprod_ret = new SqlParameter("@Return_Value", DbType.Int32);
            updprod_ret.Direction = ParameterDirection.ReturnValue;
            updprod_sql.Parameters.Add(updprod_ret);

            SqlDataReader updprod_rdr = updprod_sql.ExecuteReader();
            while (updprod_rdr.Read())
            {
            }
            updprod_rdr.Close();

            ret_info.errcode = (int)updprod_ret.Value;

            return ret_info;
        }


        public Remainder[] GetValidRemainders(int StoreID_arg, bool usingCheck)
        {
            List<Remainder> validrems_ret = new List<Remainder>();

            SqlCommand getvalidrems_sql = new SqlCommand("GetValidRemainders", SqlLink);
            getvalidrems_sql.CommandType = CommandType.StoredProcedure;

            getvalidrems_sql.Parameters.Add(new SqlParameter("@StoreID", StoreID_arg));
            getvalidrems_sql.Parameters.Add(new SqlParameter("@usingCheck", usingCheck));


            SqlDataReader validrems_rdr = getvalidrems_sql.ExecuteReader();
            while (validrems_rdr.Read())
            {
                Remainder nextRem = new Remainder();
                nextRem.product_barcode = validrems_rdr["product_barcode"].ToString();
                nextRem.supplier_ident = validrems_rdr["supplier_ident"].ToString();
                nextRem.zednadebis_nomeri = validrems_rdr["zednadebis_nomeri"].ToString();
                nextRem.initial_pieces = Utilities.Utilities.ParseDecimal(validrems_rdr["initial_pieces"].ToString());
                nextRem.pack_capacity = Utilities.Utilities.ParseDecimal(validrems_rdr["pack_capacity"].ToString());
                nextRem.remaining_pieces = Utilities.Utilities.ParseDecimal(validrems_rdr["remaining_pieces"].ToString());
                nextRem.buy_price = Utilities.Utilities.ParseDecimal(validrems_rdr["buy_price"].ToString());
                if ("" != validrems_rdr["formal_buy_price"].ToString())
                {
                    nextRem.formal_buy_price = Utilities.Utilities.ParseDecimal(validrems_rdr["formal_buy_price"].ToString());
                }
                if ("" != validrems_rdr["sell_price"].ToString())
                {
                    nextRem.sell_price = Utilities.Utilities.ParseDecimal(validrems_rdr["sell_price"].ToString());
                }
                if ("" != validrems_rdr["formal_sell_price"].ToString())
                {
                    nextRem.formal_sell_price = Utilities.Utilities.ParseDecimal(validrems_rdr["formal_sell_price"].ToString());
                }

                nextRem.storehouse_id = Int32.Parse(validrems_rdr["storehouse_id"].ToString());

                validrems_ret.Add(nextRem);
            }
            validrems_rdr.Close();

            return validrems_ret.ToArray();
        }

        public DataTable Agcera_Statistics(int StoreID)
        {
            DataTable agcera_ret = new DataTable();
            agcera_ret.Columns.Add("შტრიხ–კოდი");
            agcera_ret.Columns.Add("დასახელება");
            agcera_ret.Columns.Add("საწყობი");
            agcera_ret.Columns.Add("შემომტანი");
            agcera_ret.Columns.Add("ზედდ. საიდენტ.");
            agcera_ret.Columns.Add("ზედ. თარიღი");
            agcera_ret.Columns.Add("ა/ფ სერია");
            agcera_ret.Columns.Add("ა/ფ ნომერი");
            agcera_ret.Columns.Add("ა/ფ თარიღი");
            agcera_ret.Columns.Add("დარჩენილია");
            agcera_ret.Columns.Add("ფასი დღგ–ს გარეშე");
            agcera_ret.Columns.Add("ფასი დღგ–ს ჩათვლით");

            SqlCommand agcera_Sql = new SqlCommand("Agcera_Statistics", SqlLink);
            agcera_Sql.CommandType = CommandType.StoredProcedure;
            agcera_Sql.Parameters.Add(new SqlParameter("@StoreID", StoreID));

            SqlDataReader agcera_rdr = agcera_Sql.ExecuteReader();
            while (agcera_rdr.Read())
            {
                DataRow newRow = agcera_ret.NewRow();
                for (int i = 0; i < agcera_rdr.FieldCount; i++)
                {
                    newRow[i] = agcera_rdr[i];
                    if ((9 == i | 10 == i | 11 == i) && "" != agcera_rdr[i].ToString())
                    {
                        newRow[i] = Math.Round(Utilities.Utilities.ParseDecimal(agcera_rdr[i].ToString()), 4, MidpointRounding.AwayFromZero);
                    }
                }
                agcera_ret.Rows.Add(newRow);
            }
            agcera_rdr.Close();

            return agcera_ret;
        }

        public DataTable Supplier_Fin_Statistics()
        {
            DataTable supp_fin_dt = new DataTable();
            supp_fin_dt.Columns.Add("მომწოდებლის სახელი");
            supp_fin_dt.Columns.Add("საიდენტიფიკაციო კოდი");
            supp_fin_dt.Columns.Add("მისამართი");
            supp_fin_dt.Columns.Add("მოსაცემი აქვს");
            supp_fin_dt.Columns.Add("მისაცემი გვაქვს");

            SqlCommand SuppFin_Sql = new SqlCommand("Supplier_Fin_Statistics", SqlLink);
            SuppFin_Sql.CommandType = CommandType.StoredProcedure;

            SqlDataReader suppfin_rdr = SuppFin_Sql.ExecuteReader();

            while (suppfin_rdr.Read())
            {
                DataRow newRow = supp_fin_dt.NewRow();
                for (int i = 0; i < suppfin_rdr.FieldCount; i++)
                {
                    newRow[i] = suppfin_rdr[i];
                    if ((3 == i | 4 == i) && "" != suppfin_rdr[i].ToString() && "-" != suppfin_rdr[i].ToString())
                    {
                        newRow[i] = Math.Round(Utilities.Utilities.ParseDecimal(suppfin_rdr[i].ToString()), 4, MidpointRounding.AwayFromZero);
                    }
                }
                supp_fin_dt.Rows.Add(newRow);
            }

            suppfin_rdr.Close();

            return supp_fin_dt;
        }

        public DataTable Buyer_Fin_Statistics()
        {
            DataTable buyer_fin_dt = new DataTable();
            buyer_fin_dt.Columns.Add("მყიდველის სახელი");
            buyer_fin_dt.Columns.Add("საიდენტიფიკაციო კოდი");
            buyer_fin_dt.Columns.Add("მისამართი");
            buyer_fin_dt.Columns.Add("მოსაცემი აქვს");
            buyer_fin_dt.Columns.Add("მისაცემი გვაქვს");

            SqlCommand BuyerFin_Sql = new SqlCommand("Buyer_Fin_Statistics", SqlLink);
            BuyerFin_Sql.CommandType = CommandType.StoredProcedure;

            SqlDataReader buyerfin_rdr = BuyerFin_Sql.ExecuteReader();

            while (buyerfin_rdr.Read())
            {
                DataRow newRow = buyer_fin_dt.NewRow();
                for (int i = 0; i < buyerfin_rdr.FieldCount; i++)
                {
                    newRow[i] = buyerfin_rdr[i];
                    if ((3 == i | 4 == i) && "" != buyerfin_rdr[i].ToString() && "-" != buyerfin_rdr[i].ToString())
                    {
                        newRow[i] = Math.Round(Utilities.Utilities.ParseDecimal(buyerfin_rdr[i].ToString()), 4, MidpointRounding.AwayFromZero);
                    }
                }
                buyer_fin_dt.Rows.Add(newRow);
            }

            buyerfin_rdr.Close();

            return buyer_fin_dt;
        }

        public info TransferMoney(string ClientID_arg, MoneyTransferType transferType_arg, DateTime dro_arg, decimal amount_arg, Type clientType_arg, DataProvider.MoneyTransferPurpose purpose_arg, int store_id_arg, Type targetType_arg, string target_ident_arg, int cashbox_id_arg, int cashier_id_arg)
        {
            info ret_info = info.niy();

            if ("" == ClientID_arg | null == transferType_arg | null == dro_arg | 0.0m >= amount_arg | null == clientType_arg)
            {
                return new info("გადაცემულია არასწორი პარამეტრები", 1);
            }

            SqlCommand TransferMoneySql = new SqlCommand("TransferMoney", SqlLink);
            TransferMoneySql.CommandType = CommandType.StoredProcedure;
            TransferMoneySql.Parameters.Add(new SqlParameter("@Client_Ident", ClientID_arg));
            TransferMoneySql.Parameters.Add(new SqlParameter("@transfer_type", transferType_arg.ToString()));
            TransferMoneySql.Parameters.Add(new SqlParameter("@dro", dro_arg));
            TransferMoneySql.Parameters.Add(new SqlParameter("@amount", amount_arg));
            TransferMoneySql.Parameters.Add(new SqlParameter("@client_type", clientType_arg.ToString()));
            TransferMoneySql.Parameters.Add(new SqlParameter("@purpose", purpose_arg.ToString()));
            TransferMoneySql.Parameters.Add(new SqlParameter("@store_id", store_id_arg));
            TransferMoneySql.Parameters.Add(new SqlParameter("@target_type", (null != targetType_arg) ? targetType_arg.ToString() : null));
            TransferMoneySql.Parameters.Add(new SqlParameter("@target_ident", (null != target_ident_arg) ? target_ident_arg.ToString() : null));
            TransferMoneySql.Parameters.Add(new SqlParameter("@cashbox_id", cashbox_id_arg));
            TransferMoneySql.Parameters.Add(new SqlParameter("@cashier_id", cashier_id_arg));

            SqlParameter TransfMonRetVal = new SqlParameter("@Return_Value", DbType.Int32);
            TransfMonRetVal.Direction = ParameterDirection.ReturnValue;
            TransferMoneySql.Parameters.Add(TransfMonRetVal);

            SqlDataReader TransfMoney_rdr = TransferMoneySql.ExecuteReader();
            while (TransfMoney_rdr.Read())
            {
            }
            int ReturnCode = (Int32)TransfMonRetVal.Value;

            TransfMoney_rdr.Close();

            ret_info.errcode = ReturnCode;
            if (0 == ReturnCode)
            {
                ret_info.details = "ფულადი ოპერაცია წარმატებით დასრულდა!";
            }
            else
            {
                ret_info.details = "მოხდა შეცდომა. ოპერაცია ვერ განხორციელდა!";
            }

            return ret_info;
        }


        public info EditSupplier(Supplier updatingSupplier)
        {
            info ret_info = info.niy();

            int update_res = 0;

            if ("" == updatingSupplier.saidentifikacio_kodi | "" == updatingSupplier.saxeli | "" == updatingSupplier.address)
            {
                return new info("არასაკმარისი ინფორმაციაა მოწოდებული!", 301);
            }

            SqlCommand UpdateSupplierSql = new SqlCommand("UpdateSupplier", SqlLink);
            UpdateSupplierSql.CommandType = CommandType.StoredProcedure;
            UpdateSupplierSql.Parameters.Add(new SqlParameter("@supp_ident", updatingSupplier.saidentifikacio_kodi));
            UpdateSupplierSql.Parameters.Add(new SqlParameter("@supp_name", updatingSupplier.saxeli));
            UpdateSupplierSql.Parameters.Add(new SqlParameter("@supp_addr", updatingSupplier.address));

            SqlParameter UpdSRetVal = new SqlParameter("@Return_Value", DbType.Int32);
            UpdSRetVal.Direction = ParameterDirection.ReturnValue;
            UpdateSupplierSql.Parameters.Add(UpdSRetVal);

            SqlDataReader UpdateSupp_rdr = UpdateSupplierSql.ExecuteReader();

            while (UpdateSupp_rdr.Read())
            {
            }
            UpdateSupp_rdr.Close();

            update_res = Convert.ToInt32(UpdSRetVal.Value);

            ret_info.errcode = update_res;
            if (0 == update_res)
            {
                ret_info.details = "მომწოდებელი შეიცვალა!";
            }

            return ret_info;

        }

        public DataTable SellOrderDetails(int SellOrderID_arg)
        {
            DataTable SOdetails_ret_dt = new DataTable();
            SOdetails_ret_dt.Columns.Add("id");
            SOdetails_ret_dt.Columns.Add("შტრიხ–კოდი");
            SOdetails_ret_dt.Columns.Add("დასახელება");
            SOdetails_ret_dt.Columns.Add("რაოდენობა");
            SOdetails_ret_dt.Columns.Add("საცალო ღირებულება");
            SOdetails_ret_dt.Columns.Add("ღირებულება");
            SOdetails_ret_dt.Columns.Add("საცალო ფასი");
            SOdetails_ret_dt.Columns.Add("საერთო ფასი");
            SOdetails_ret_dt.Columns.Add("მოგება");
            SOdetails_ret_dt.Columns.Add("ღირებულება (დღგ–ს გარეშე)");
            SOdetails_ret_dt.Columns.Add("საწყობის N.");

            SqlCommand SOdetails_Sql = new SqlCommand("SellOrder_Details", SqlLink);
            SOdetails_Sql.CommandType = CommandType.StoredProcedure;

            SOdetails_Sql.Parameters.Add(new SqlParameter("@SellOrderID", SellOrderID_arg));

            SqlDataReader SOdet_rdr = SOdetails_Sql.ExecuteReader();

            while (SOdet_rdr.Read())
            {
                DataRow newRow = SOdetails_ret_dt.NewRow();
                for (int i = 0; i < SOdet_rdr.FieldCount; i++)
                {
                    newRow[i] = SOdet_rdr[i];
                    if ((4 == i | 5 == i | 6 == i | 7 == i | 8 == i | 9 == i | 10 == i) && "" != SOdet_rdr[i].ToString())
                    {
                        newRow[i] = Math.Round(Utilities.Utilities.ParseDecimal(SOdet_rdr[i].ToString()), 4, MidpointRounding.AwayFromZero);
                    }
                }
                SOdetails_ret_dt.Rows.Add(newRow);
            }

            SOdet_rdr.Close();

            return SOdetails_ret_dt;
        }

        public DataTable SoldZedDetails(string buyer_ident_arg, string zed_id_arg)
        {
            DataTable SoldZed_ret_dt = new DataTable();
            SoldZed_ret_dt.Columns.Add("id");
            SoldZed_ret_dt.Columns.Add("შტრიხ–კოდი");
            SoldZed_ret_dt.Columns.Add("დასახელება");
            SoldZed_ret_dt.Columns.Add("რაოდენობა");
            SoldZed_ret_dt.Columns.Add("საცალო ღირებულება");
            SoldZed_ret_dt.Columns.Add("ღირებულება");
            SoldZed_ret_dt.Columns.Add("საცალო ფასი");
            SoldZed_ret_dt.Columns.Add("საერთო ფასი");
            SoldZed_ret_dt.Columns.Add("მოგება");
            SoldZed_ret_dt.Columns.Add("ღირებულება (დღგ–ს გარეშე)");
            SoldZed_ret_dt.Columns.Add("საწყობის N.");

            SqlCommand SoldZed_Sql = new SqlCommand("SoldZedDetails", SqlLink);
            SoldZed_Sql.CommandType = CommandType.StoredProcedure;

            SoldZed_Sql.Parameters.Add(new SqlParameter("@buyer_ident", buyer_ident_arg));
            SoldZed_Sql.Parameters.Add(new SqlParameter("@zed_ident", zed_id_arg));

            SqlDataReader SoldZed_rdr = SoldZed_Sql.ExecuteReader();

            while (SoldZed_rdr.Read())
            {
                DataRow newRow = SoldZed_ret_dt.NewRow();
                for (int i = 0; i < SoldZed_rdr.FieldCount; i++)
                {
                    newRow[i] = SoldZed_rdr[i];
                    if ((4 == i | 5 == i | 6 == i | 7 == i | 8 == i | 9 == i) && "" != SoldZed_rdr[i].ToString())
                    {
                        newRow[i] = Math.Round(Utilities.Utilities.ParseDecimal(SoldZed_rdr[i].ToString()), 4, MidpointRounding.AwayFromZero);
                    }
                }
                SoldZed_ret_dt.Rows.Add(newRow);
            }

            SoldZed_rdr.Close();

            return SoldZed_ret_dt;
        }

        public DataTable BoughtZedDetails(string supplier_ident_arg, string zed_id_arg)
        {
            DataTable BoughtZed_ret_dt = new DataTable();
            BoughtZed_ret_dt.Columns.Add("id");
            BoughtZed_ret_dt.Columns.Add("შტრიხ–კოდი");
            BoughtZed_ret_dt.Columns.Add("დასახელება");
            BoughtZed_ret_dt.Columns.Add("რაოდენობა");
            BoughtZed_ret_dt.Columns.Add("საცალო ღირებულება");
            BoughtZed_ret_dt.Columns.Add("ღირებულება");
            BoughtZed_ret_dt.Columns.Add("საცალო ფასი");
            BoughtZed_ret_dt.Columns.Add("საერთო ფასი");
            BoughtZed_ret_dt.Columns.Add("მოგება");
            BoughtZed_ret_dt.Columns.Add("ღირებულება (დღგ–ს გარეშე)");
            BoughtZed_ret_dt.Columns.Add("საწყობის N.");

            SqlCommand BoughtZed_Sql = new SqlCommand("BoughtZedDetails", SqlLink);
            BoughtZed_Sql.CommandType = CommandType.StoredProcedure;

            BoughtZed_Sql.Parameters.Add(new SqlParameter("@supplier_ident", supplier_ident_arg));
            BoughtZed_Sql.Parameters.Add(new SqlParameter("@zed_ident", zed_id_arg));

            SqlDataReader BoughtZed_rdr = BoughtZed_Sql.ExecuteReader();

            while (BoughtZed_rdr.Read())
            {
                DataRow newRow = BoughtZed_ret_dt.NewRow();
                for (int i = 0; i < BoughtZed_rdr.FieldCount; i++)
                {
                    newRow[i] = BoughtZed_rdr[i];
                    if ((4 == i | 5 == i | 9 == i) && "" != BoughtZed_rdr[i].ToString())
                    {
                        newRow[i] = Math.Round(Utilities.Utilities.ParseDecimal(BoughtZed_rdr[i].ToString()), 4, MidpointRounding.AwayFromZero);
                    }
                }
                BoughtZed_ret_dt.Rows.Add(newRow);
            }

            BoughtZed_rdr.Close();

            return BoughtZed_ret_dt;
        }

        public SellOrder GetSellOrderByZedCode(string zedcode_arg)
        {
            SellOrder SO_ret = new SellOrder();
            SO_ret.SellingZednadebi = new Zednadebi();
            SO_ret.buyer_client = new Buyer();
            List<Remainder> SO_rems = new List<Remainder>();

            DataTable ZedRems_dt = new DataTable();
            ZedRems_dt.Columns.Add("შტრიხ–კოდი");
            ZedRems_dt.Columns.Add("დასახელება");
            ZedRems_dt.Columns.Add("რაოდენობა");
            ZedRems_dt.Columns.Add("საცალო ფასი");
            ZedRems_dt.Columns.Add("აღებული თანხა");

            SqlCommand SObyZedCode_Sql = new SqlCommand("GetSellOrderByZedCode", SqlLink);
            SObyZedCode_Sql.CommandType = CommandType.StoredProcedure;

            SqlParameter zed_ident_par = new SqlParameter("@zed_ident", SqlDbType.NVarChar, 4000);
            zed_ident_par.Direction = ParameterDirection.InputOutput;
            zed_ident_par.Value = zedcode_arg;
            SqlParameter zed_tarigi_par = new SqlParameter("@zed_tarigi", SqlDbType.DateTime);
            zed_tarigi_par.Direction = ParameterDirection.Output;
            SqlParameter buyer_ident_par = new SqlParameter("@buyer_ident", SqlDbType.NVarChar, 4000);
            buyer_ident_par.Direction = ParameterDirection.Output;
            SqlParameter buyer_name_par = new SqlParameter("@buyer_name", SqlDbType.NVarChar, 4000);
            buyer_name_par.Direction = ParameterDirection.Output;
            SqlParameter buyer_address_par = new SqlParameter("@buyer_address", SqlDbType.NVarChar, 4000);
            buyer_address_par.Direction = ParameterDirection.Output;
            SqlParameter zed_sum_par = new SqlParameter("@zed_sum", DbType.Decimal);
            zed_sum_par.Direction = ParameterDirection.Output;

            SObyZedCode_Sql.Parameters.Add(zed_ident_par);
            SObyZedCode_Sql.Parameters.Add(zed_tarigi_par);
            SObyZedCode_Sql.Parameters.Add(buyer_ident_par);
            SObyZedCode_Sql.Parameters.Add(buyer_name_par);
            SObyZedCode_Sql.Parameters.Add(buyer_address_par);
            SObyZedCode_Sql.Parameters.Add(zed_sum_par);

            SqlDataReader SObyZedCode_rdr = SObyZedCode_Sql.ExecuteReader();

            while (SObyZedCode_rdr.Read())
            {
                Remainder nextRem = new Remainder();
                nextRem.product_barcode = SObyZedCode_rdr["product_barcode"].ToString();
                nextRem.initial_pieces = Utilities.Utilities.ParseDecimal(Utilities.Utilities.ParseDecimal(SObyZedCode_rdr["piece_count"].ToString()).ToString("G18"));
                nextRem.sell_price = Utilities.Utilities.ParseDecimal(Utilities.Utilities.ParseDecimal(SObyZedCode_rdr["piece_price"].ToString()).ToString("G18"));
                SO_rems.Add(nextRem);
            }
            SObyZedCode_rdr.Close();

            SO_ret.SellingZednadebi.zednadebis_nomeri = zed_ident_par.Value.ToString();
            SO_ret.SellingZednadebi.dro = DateTime.Parse(zed_tarigi_par.Value.ToString());
            SO_ret.SellingZednadebi.buyer_saident = buyer_ident_par.Value.ToString();
            SO_ret.buyer_client.saidentifikacio_kodi = buyer_ident_par.Value.ToString();
            SO_ret.buyer_client.saxeli = buyer_name_par.Value.ToString();
            SO_ret.buyer_client.address = buyer_address_par.Value.ToString();


            SO_ret.OutgoingRemainders = SO_rems.ToArray();

            return SO_ret;
        }

        public info RemoveProduct(string p_barcode_arg)
        {
            info ret_info = new info();

            SqlCommand RemProdCmd = new SqlCommand("RemoveProduct", SqlLink);
            RemProdCmd.CommandType = CommandType.StoredProcedure;

            RemProdCmd.Parameters.Add(new SqlParameter("@p_barcode", p_barcode_arg));

            int res = RemProdCmd.ExecuteNonQuery();

            // if (res > 0)//as SqlDataReader res.RecordsAffected
            // {
            ret_info.errcode = 0;
            //     ret_info.details = "წაიშალა იმავე შტრიხ–კოდის მქონე " + res.ToString() + " პროდუქტი. ";
            ret_info.details = "ოპერაცია წარმატებით დასრულდა. ";
            // }
            //else
            //{
            //    ret_info.errcode = 1;
            //    ret_info.details = "ამ შტრიხ–კოდის მქონე პროდუქტი ვერ მოიძებნა. ";
            //}

            return ret_info;
        }

        public string MaxZedIdent()
        {
            string ret_str = "";

            SqlCommand MaxZedIdent_Cmd = new SqlCommand("MaxZedIdent", SqlLink);
            MaxZedIdent_Cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader MaxZedIdent_rdr = MaxZedIdent_Cmd.ExecuteReader();

            while (MaxZedIdent_rdr.Read())
            {
                ret_str = MaxZedIdent_rdr["MaxZedIdentCode"].ToString();
            }

            MaxZedIdent_rdr.Close();

            return ret_str;
        }

        public string NextZedIdent(int StoreID_arg)
        {
            string ret_str = "";

            SqlCommand NextZedIdent_Cmd = new SqlCommand("NextZedIdent", SqlLink);
            NextZedIdent_Cmd.CommandType = CommandType.StoredProcedure;

            NextZedIdent_Cmd.Parameters.Add(new SqlParameter("@StoreID", StoreID_arg));

            SqlDataReader NextZedIdent_rdr = NextZedIdent_Cmd.ExecuteReader();

            while (NextZedIdent_rdr.Read())
            {
                ret_str = NextZedIdent_rdr["NextZedIdentCode"].ToString();
            }

            NextZedIdent_rdr.Close();

            return ret_str;
        }

        public DataTable SoldRemainderByID(int soldremid_arg)
        {
            DataTable SoldRemByID_ret_dt = new DataTable();
            SoldRemByID_ret_dt.Columns.Add("საცალო რ–ბა");
            SoldRemByID_ret_dt.Columns.Add("საცალო ფასი");
            SoldRemByID_ret_dt.Columns.Add("ტევადობა");
            SoldRemByID_ret_dt.Columns.Add("მყიდველი");
            SoldRemByID_ret_dt.Columns.Add("ოპერაციის დრო");
            SoldRemByID_ret_dt.Columns.Add("ჩეკით");
            SoldRemByID_ret_dt.Columns.Add("ზედ. ნომერი");

            SqlCommand SoldRemByID_Sql = new SqlCommand("SoldRemainderByID", SqlLink);
            SoldRemByID_Sql.CommandType = CommandType.StoredProcedure;

            SoldRemByID_Sql.Parameters.Add(new SqlParameter("@SoldRemID", soldremid_arg));

            SqlDataReader SoldRemByID_rdr = SoldRemByID_Sql.ExecuteReader();

            while (SoldRemByID_rdr.Read())
            {
                DataRow newRow = SoldRemByID_ret_dt.NewRow();
                for (int i = 0; i < SoldRemByID_rdr.FieldCount; i++)
                {
                    newRow[i] = SoldRemByID_rdr[i];
                }
                SoldRemByID_ret_dt.Rows.Add(newRow);
            }

            SoldRemByID_rdr.Close();

            return SoldRemByID_ret_dt;
        }

        public info UpdateSoldRemainder(int soldrem_id, decimal piece_count_arg, decimal piece_price_arg)
        {
            info ret_info = info.niy();

            SqlCommand updsoldrem_sql = new SqlCommand("UpdateSoldRemainder", SqlLink);
            updsoldrem_sql.CommandType = CommandType.StoredProcedure;

            updsoldrem_sql.Parameters.Add(new SqlParameter("@SoldRemID", soldrem_id));
            updsoldrem_sql.Parameters.Add(new SqlParameter("@piece_count_arg", piece_count_arg));
            updsoldrem_sql.Parameters.Add(new SqlParameter("@piece_price_arg", piece_price_arg));

            SqlParameter updsoldrem_ret = new SqlParameter("@Return_Value", DbType.Int32);
            updsoldrem_ret.Direction = ParameterDirection.ReturnValue;
            updsoldrem_sql.Parameters.Add(updsoldrem_ret);

            SqlDataReader updsoldrem_rdr = updsoldrem_sql.ExecuteReader();
            while (updsoldrem_rdr.Read())
            {
            }
            updsoldrem_rdr.Close();

            ret_info.errcode = (int)updsoldrem_ret.Value;
            switch (ret_info.errcode)
            {
                case 0:
                    ret_info.details = "ოპერაცია წარმატებით დასრულდა!";
                    break;
                case 1:
                    ret_info.details = "არასწორი არგუმენტებია გადაცემული!";
                    break;
                case 404:
                    ret_info.details = "ნაშთი არ მოიძებნა!";
                    break;
            }

            return ret_info;
        }

        public DataTable RemainderByID(int soldremid_arg)
        {
            DataTable RemByID_ret_dt = new DataTable();
            RemByID_ret_dt.Columns.Add("საცალო რ–ბა");
            RemByID_ret_dt.Columns.Add("საცალო ფასი");
            RemByID_ret_dt.Columns.Add("საცალო გასაყიდი ფასი");
            RemByID_ret_dt.Columns.Add("ტევადობა");
            RemByID_ret_dt.Columns.Add("შემომტანი");
            RemByID_ret_dt.Columns.Add("ზედ. თარიღი");
            RemByID_ret_dt.Columns.Add("ზედ. ნომერი");

            SqlCommand RemByID_Sql = new SqlCommand("RemainderByID", SqlLink);
            RemByID_Sql.CommandType = CommandType.StoredProcedure;

            RemByID_Sql.Parameters.Add(new SqlParameter("@RemID", soldremid_arg));

            SqlDataReader RemByID_rdr = RemByID_Sql.ExecuteReader();

            while (RemByID_rdr.Read())
            {
                DataRow newRow = RemByID_ret_dt.NewRow();
                for (int i = 0; i < RemByID_rdr.FieldCount; i++)
                {
                    newRow[i] = RemByID_rdr[i];
                }
                RemByID_ret_dt.Rows.Add(newRow);
            }

            RemByID_rdr.Close();

            return RemByID_ret_dt;
        }

        public info UpdateRemainder(int rem_id, decimal piece_count_arg, decimal piece_price_arg, decimal capacity_arg, decimal piece_sell_price_arg)
        {
            info ret_info = info.niy();

            SqlCommand updrem_sql = new SqlCommand("UpdateRemainder", SqlLink);
            updrem_sql.CommandType = CommandType.StoredProcedure;

            updrem_sql.Parameters.Add(new SqlParameter("@RemID", rem_id));
            updrem_sql.Parameters.Add(new SqlParameter("@piece_count_arg", piece_count_arg));
            updrem_sql.Parameters.Add(new SqlParameter("@piece_price_arg", piece_price_arg));
            updrem_sql.Parameters.Add(new SqlParameter("@capacity_arg", capacity_arg));
            updrem_sql.Parameters.Add(new SqlParameter("@piece_sell_price_arg", piece_sell_price_arg));

            SqlParameter updrem_ret = new SqlParameter("@Return_Value", DbType.Int32);
            updrem_ret.Direction = ParameterDirection.ReturnValue;
            updrem_sql.Parameters.Add(updrem_ret);

            SqlDataReader updrem_rdr = updrem_sql.ExecuteReader();
            while (updrem_rdr.Read())
            {
            }
            updrem_rdr.Close();

            ret_info.errcode = (int)updrem_ret.Value;
            switch (ret_info.errcode)
            {
                case 0:
                    ret_info.details = "ოპერაცია წარმატებით დასრულდა!";
                    break;
                case 1:
                    ret_info.details = "არასწორი არგუმენტებია გადაცემული!";
                    break;
                case 404:
                    ret_info.details = "ნაშთი არ მოიძებნა!";
                    break;
            }

            return ret_info;
        }

        public info UpdateZednadebi(string zed_ident_arg, string operation_type_arg, string client_ident_arg, DateTime zed_tarigi_arg, string af_seria_arg, string af_nomeri_arg, DateTime af_tarigi_arg)
        {
            info ret_info = info.niy();

            SqlCommand updzed_sql = new SqlCommand("UpdateZednadebi", SqlLink);
            updzed_sql.CommandType = CommandType.StoredProcedure;

            updzed_sql.Parameters.Add(new SqlParameter("@zed_ident", zed_ident_arg));
            updzed_sql.Parameters.Add(new SqlParameter("@operation_type", operation_type_arg));
            updzed_sql.Parameters.Add(new SqlParameter("@client_ident", client_ident_arg));
            updzed_sql.Parameters.Add(new SqlParameter("@tarigi", zed_tarigi_arg));
            updzed_sql.Parameters.Add(new SqlParameter("@af_seria", af_seria_arg));
            updzed_sql.Parameters.Add(new SqlParameter("@af_nomeri", af_nomeri_arg));
            updzed_sql.Parameters.Add(new SqlParameter("@af_date", af_tarigi_arg));

            SqlParameter updprod_ret = new SqlParameter("@Return_Value", DbType.Int32);
            updprod_ret.Direction = ParameterDirection.ReturnValue;
            updzed_sql.Parameters.Add(updprod_ret);

            SqlDataReader updprod_rdr = updzed_sql.ExecuteReader();
            while (updprod_rdr.Read())
            {
            }
            updprod_rdr.Close();

            ret_info.errcode = (int)updprod_ret.Value;


            switch (ret_info.errcode)
            {
                case 404:
                    ret_info.details = "მონაცემები არ ემთხვევა!";
                    break;
                case 1:
                    ret_info.details = "პარამეტრები არასწორია!";
                    break;
                case 0:
                    ret_info.details = "ოპერაცია წარმატებით დასრულდა!";
                    break;
            }

            return ret_info;
        }

        public DataTable SingleZedDetails(string zed_ident, string oper_type, string client_ident)
        {
            DataTable rems_dt = new DataTable();
            rems_dt.Columns.Add("id");//product_barcode
            rems_dt.Columns.Add("საიდენტ. კოდი");//product_name
            rems_dt.Columns.Add("დრო");
            rems_dt.Columns.Add("ოპერაცია");
            rems_dt.Columns.Add("კლიენტის საიდენტ. კოდი");
            rems_dt.Columns.Add("ა/ფ სერია");
            rems_dt.Columns.Add("ა/ფ ნომერი");
            rems_dt.Columns.Add("გადახდის მეთოდი");
            rems_dt.Columns.Add("ა/ფ id");
            rems_dt.Columns.Add("ა/ფ-ს ნომერი");
            rems_dt.Columns.Add("ა/ფ-ს სერია");
            rems_dt.Columns.Add("ა/ფ-ს დრო");
            rems_dt.Columns.Add("ა/ფ-ს ოპერაცია");
            rems_dt.Columns.Add("ა/ფ-ს კლიენტის საიდენტ. კოდი");

            SqlCommand rem_statistics_sql = new SqlCommand("SingleZedDetails", SqlLink);
            rem_statistics_sql.CommandType = CommandType.StoredProcedure;

            rem_statistics_sql.Parameters.Add(new SqlParameter("@zed_ident", zed_ident));
            rem_statistics_sql.Parameters.Add(new SqlParameter("@oper_type", oper_type));
            rem_statistics_sql.Parameters.Add(new SqlParameter("@client_ident", client_ident));

            SqlDataReader rems_rdr = rem_statistics_sql.ExecuteReader();
            while (rems_rdr.Read())
            {
                DataRow nextRemRow = rems_dt.NewRow();
                for (int i = 0; i < rems_rdr.FieldCount; i++)
                {
                    nextRemRow[i] = rems_rdr[i];
                }
                rems_dt.Rows.Add(nextRemRow);
            }
            rems_rdr.Close();

            return rems_dt;
        }

        public DataTable SplittableRemainders(string p_barcode_arg)
        {
            DataTable splitrems_list_dt = new DataTable();
            splitrems_list_dt.Columns.Add("id");
            splitrems_list_dt.Columns.Add("შტრიხ–კოდი");
            splitrems_list_dt.Columns.Add("მომწოდებლის საიდენტ. კოდი");
            splitrems_list_dt.Columns.Add("ზედ. საიდენტ. კოდი");
            splitrems_list_dt.Columns.Add("საწყისი რ–ბა");
            splitrems_list_dt.Columns.Add("დარჩენილი რ–ბა");
            splitrems_list_dt.Columns.Add("ტევადობა");
            splitrems_list_dt.Columns.Add("საცალო ღირ–ბა");
            splitrems_list_dt.Columns.Add("formal_buy_price");
            splitrems_list_dt.Columns.Add("sell_price");
            splitrems_list_dt.Columns.Add("formal_sell_price");
            splitrems_list_dt.Columns.Add("საწყობის N.");
            splitrems_list_dt.Columns.Add("ზედ. თარიღი");

            SqlCommand SplittableRems_Sql = new SqlCommand("SplittableRemainders", SqlLink);
            SplittableRems_Sql.CommandType = CommandType.StoredProcedure;

            SplittableRems_Sql.Parameters.Add(new SqlParameter("@p_barcode", p_barcode_arg));

            SqlDataReader SplittableRems_rdr = SplittableRems_Sql.ExecuteReader();

            while (SplittableRems_rdr.Read())
            {
                DataRow newRow = splitrems_list_dt.NewRow();
                for (int i = 0; i < SplittableRems_rdr.FieldCount; i++)
                {
                    newRow[i] = SplittableRems_rdr[i];
                    /*if ((5 == i | 6 == i | 7 == i | 8 == i | 9 == i | 10 == i) && "" != SplittableRems_rdr[i].ToString())
                    {
                        newRow[i] = Math.Round(Utilities.Utilities.ParseDecimal(SplittableRems_rdr[i].ToString()), 4, MidpointRounding.AwayFromZero);
                    }*/
                }
                splitrems_list_dt.Rows.Add(newRow);
            }

            SplittableRems_rdr.Close();

            return splitrems_list_dt;
        }

        public info SplitRemainder(int rem_id_arg, int to_storeid_arg, decimal piece_count_arg)
        {
            info ret_info = info.niy();

            SqlCommand splitrem_sql = new SqlCommand("SplitRemainder", SqlLink);
            splitrem_sql.CommandType = CommandType.StoredProcedure;

            splitrem_sql.Parameters.Add(new SqlParameter("@Rem_ID", rem_id_arg));
            splitrem_sql.Parameters.Add(new SqlParameter("@ToStoreID", to_storeid_arg));
            splitrem_sql.Parameters.Add(new SqlParameter("@PieceCount", piece_count_arg));

            SqlParameter splitrem_ret = new SqlParameter("@Return_Value", DbType.Int32);
            splitrem_ret.Direction = ParameterDirection.ReturnValue;
            splitrem_sql.Parameters.Add(splitrem_ret);

            SqlDataReader splitrem_rdr = splitrem_sql.ExecuteReader();
            while (splitrem_rdr.Read())
            {
            }
            splitrem_rdr.Close();

            ret_info.errcode = (int)splitrem_ret.Value;


            switch (ret_info.errcode)
            {
                case 404:
                    ret_info.details = "ნაშთი ვერ მოიძებნა!";
                    break;
                case 1:
                    ret_info.details = "პარამეტრები არასწორია!";
                    break;
                case 0:
                    ret_info.details = "ოპერაცია წარმატებით დასრულდა!";
                    break;
            }

            return ret_info;
        }

        public DataTable MoneyTransferStatistics(int StoreID_arg, DateTime since_arg, DateTime until_arg)
        {
            DataTable mttransf_rems_dt = new DataTable();
            mttransf_rems_dt.Columns.Add("id");
            mttransf_rems_dt.Columns.Add("კლიენტის ტიპი");
            mttransf_rems_dt.Columns.Add("კლიენტის სახელი");
            mttransf_rems_dt.Columns.Add("ოპერაციის ტიპი");
            mttransf_rems_dt.Columns.Add("ოპერაციის თარიღი");
            mttransf_rems_dt.Columns.Add("რაოდენობა");
            mttransf_rems_dt.Columns.Add("დანიშნულება");
            mttransf_rems_dt.Columns.Add("საწყობის N.");
            mttransf_rems_dt.Columns.Add("დანიშნ. დოკუმენტის ტიპი");
            mttransf_rems_dt.Columns.Add("დანიშნ. დოკუმენტის იდენტ. კოდი");
            mttransf_rems_dt.Columns.Add("სალაროს N.");
            mttransf_rems_dt.Columns.Add("მოლარის N.");

            SqlCommand mttransf_sql = new SqlCommand("MoneyTransferStatistics", DataProvider.SqlLink);
            mttransf_sql.CommandType = CommandType.StoredProcedure;

            mttransf_sql.Parameters.Add(new SqlParameter("@StoreID", StoreID_arg));
            mttransf_sql.Parameters.Add(new SqlParameter("@Since", since_arg));
            mttransf_sql.Parameters.Add(new SqlParameter("@Until", until_arg));

            SqlDataReader mttransf_rs = mttransf_sql.ExecuteReader();

            while (mttransf_rs.Read())
            {
                DataRow newRec = mttransf_rems_dt.NewRow();
                for (int i = 0; i < mttransf_rs.FieldCount; i++)
                {
                    newRec[i] = mttransf_rs[i];
                    if ((5 == i) && "" != mttransf_rs[i].ToString())
                    {
                        newRec[i] = Math.Round(Utilities.Utilities.ParseDecimal(mttransf_rs[i].ToString()), 4, MidpointRounding.AwayFromZero);
                    }
                }
                mttransf_rems_dt.Rows.Add(newRec);
            }

            mttransf_rs.Close();

            return mttransf_rems_dt;
        }

        public info RemoveRemainder(int rem_id_arg)
        {
            info ret_info = new info();

            SqlCommand RemRemainderCmd = new SqlCommand("RemoveRemainder", SqlLink);
            RemRemainderCmd.CommandType = CommandType.StoredProcedure;

            RemRemainderCmd.Parameters.Add(new SqlParameter("@Rem_ID", rem_id_arg));

            SqlParameter rmrem_ret = new SqlParameter("@Return_Value", DbType.Int32);
            rmrem_ret.Direction = ParameterDirection.ReturnValue;
            RemRemainderCmd.Parameters.Add(rmrem_ret);

            int res = RemRemainderCmd.ExecuteNonQuery();

            // if (res > 0)//as SqlDataReader res.RecordsAffected
            // {
            ret_info.errcode = (int)rmrem_ret.Value;

            switch (ret_info.errcode)
            {
                case 404:
                    ret_info.details = "ნაშთი ვერ მოიძებნა!";
                    break;
                case 2:
                    ret_info.details = "ამ ნაშთის გაყიდვა უკვე მოხდა. წაშლა შეუძლებელია!";
                    break;
                case 1:
                    ret_info.details = "პარამეტრები არასწორია!";
                    break;
                case 0:
                    ret_info.details = "ოპერაცია წარმატებით დასრულდა!";
                    break;
            }

            return ret_info;
        }

        public info RemoveSoldRemainder(int soldrem_id_arg)
        {
            info ret_info = new info();

            SqlCommand RemSoldRemainderCmd = new SqlCommand("RemoveSoldRemainder", SqlLink);
            RemSoldRemainderCmd.CommandType = CommandType.StoredProcedure;

            RemSoldRemainderCmd.Parameters.Add(new SqlParameter("@SoldRem_ID", soldrem_id_arg));

            SqlParameter rmsoldrem_ret = new SqlParameter("@Return_Value", DbType.Int32);
            rmsoldrem_ret.Direction = ParameterDirection.ReturnValue;
            RemSoldRemainderCmd.Parameters.Add(rmsoldrem_ret);

            int res = RemSoldRemainderCmd.ExecuteNonQuery();

            // if (res > 0)//as SqlDataReader res.RecordsAffected
            // {
            ret_info.errcode = (int)rmsoldrem_ret.Value;

            switch (ret_info.errcode)
            {
                case 404:
                    ret_info.details = "გაყიდული პროდუქტი ვერ მოიძებნა!";
                    break;
                case 2:
                    ret_info.details = "ამ ნაშთის გაყიდვა უკვე მოხდა. წაშლა შეუძლებელია!";
                    break;
                case 1:
                    ret_info.details = "პარამეტრები არასწორია!";
                    break;
                case 0:
                    ret_info.details = "ოპერაცია წარმატებით დასრულდა!";
                    break;
            }

            return ret_info;
        }

        public info RemoveZednadebi(string zed_ident_arg, string oper_type_arg, string client_ident_arg)
        {
            info ret_info = new info();

            SqlCommand RmZedCmd = new SqlCommand("RemoveZednadebi", SqlLink);
            RmZedCmd.CommandType = CommandType.StoredProcedure;

            RmZedCmd.Parameters.Add(new SqlParameter("@zed_ident", zed_ident_arg));
            RmZedCmd.Parameters.Add(new SqlParameter("@oper_type", oper_type_arg));
            RmZedCmd.Parameters.Add(new SqlParameter("@client_ident", client_ident_arg));

            SqlParameter rmzed_ret = new SqlParameter("@Return_Value", DbType.Int32);
            rmzed_ret.Direction = ParameterDirection.ReturnValue;
            RmZedCmd.Parameters.Add(rmzed_ret);

            int res = RmZedCmd.ExecuteNonQuery();

            ret_info.errcode = (int)rmzed_ret.Value;

            switch (ret_info.errcode)
            {
                case 404:
                    ret_info.details = "ზედნადები ვერ მოიძებნა!";
                    break;
                case 2:
                    ret_info.details = "ამ ზედნადებით შემოტანილი პროდუქციის გაყიდვა უკვე მოხდა. წაშლა შეუძლებელია!";
                    break;
                case 1:
                    ret_info.details = "პარამეტრები არასწორია!";
                    break;
                case 0:
                    ret_info.details = "ოპერაცია წარმატებით დასრულდა!";
                    break;
            }

            return ret_info;
        }

        public DataTable StoreSummary(int store_id_arg)
        {
            DataTable store_sum_dt = new DataTable();
            store_sum_dt.Columns.Add("ნაღდი ფული");

            SqlCommand store_sum_sql = new SqlCommand("StoreSummary", DataProvider.SqlLink);
            store_sum_sql.CommandType = CommandType.StoredProcedure;
            store_sum_sql.Parameters.Add(new SqlParameter("@StoreID", store_id_arg));

            //store_sum_sql.Parameters.Add(new SqlParameter("@Since", since_arg));
            //store_sum_sql.Parameters.Add(new SqlParameter("@Until", until_arg));

            SqlDataReader store_sum_rs = store_sum_sql.ExecuteReader();

            while (store_sum_rs.Read())
            {
                DataRow newRec = store_sum_dt.NewRow();
                for (int i = 0; i < store_sum_rs.FieldCount; i++)
                {
                    newRec[i] = store_sum_rs[i];
                    if ((0 == i) && "" != store_sum_rs[i].ToString())
                    {
                        newRec[i] = Math.Round(Utilities.Utilities.ParseDecimal(store_sum_rs[i].ToString()), 4, MidpointRounding.AwayFromZero);
                    }
                }
                store_sum_dt.Rows.Add(newRec);
            }

            store_sum_rs.Close();

            return store_sum_dt;
        }

        public int SoldZedRemCount(string zed_ident_arg, bool count_only_distinct_barcodes)
        {
            SellOrder so_byZed = GetSellOrderByZedCode(zed_ident_arg);

            if (count_only_distinct_barcodes)
            {
                string[] z_dist_rows = (from Remainder zrem in so_byZed.OutgoingRemainders
                                        select zrem.product_barcode).Distinct().ToArray();
                return z_dist_rows.Length;
            }
            else
            {
                return so_byZed.OutgoingRemainders.Length;
            }

        }

        public info RemoveMoneyTransfer(int mt_id_arg)
        {
            info ret_info = info.niy();

            SqlCommand RemMoneyTransferCmd = new SqlCommand("RemoveMoneyTransfer", SqlLink);
            RemMoneyTransferCmd.CommandType = CommandType.StoredProcedure;

            RemMoneyTransferCmd.Parameters.Add(new SqlParameter("@mt_id", mt_id_arg));

            int res = RemMoneyTransferCmd.ExecuteNonQuery();

            ret_info.errcode = res;
            switch (ret_info.errcode)
            {
                case 0:
                    ret_info.details = "ფულადი ოპერაცია გაუქმებულია!";
                    break;
                case 1:
                    ret_info.details = "გადაცემულია არასწორი არგუმენტები!";
                    break;
                case 404:
                    ret_info.details = "ოპერაცია არ მოიძებნა!";
                    break;
            }

            return ret_info;
        }



        public info EditBuyer(Buyer updatingBuyer)
        {
            info ret_info = info.niy();

            int update_res = 0;

            if ("" == updatingBuyer.saidentifikacio_kodi | "" == updatingBuyer.saxeli | "" == updatingBuyer.address)
            {
                return new info("არასაკმარისი ინფორმაციაა მოწოდებული!", 301);
            }

            SqlCommand UpdateBuyerSql = new SqlCommand("UpdateBuyer", SqlLink);
            UpdateBuyerSql.CommandType = CommandType.StoredProcedure;
            UpdateBuyerSql.Parameters.Add(new SqlParameter("@buyer_ident", updatingBuyer.saidentifikacio_kodi));
            UpdateBuyerSql.Parameters.Add(new SqlParameter("@buyer_name", updatingBuyer.saxeli));
            UpdateBuyerSql.Parameters.Add(new SqlParameter("@buyer_addr", updatingBuyer.address));

            SqlParameter UpdBRetVal = new SqlParameter("@Return_Value", DbType.Int32);
            UpdBRetVal.Direction = ParameterDirection.ReturnValue;
            UpdateBuyerSql.Parameters.Add(UpdBRetVal);

            SqlDataReader UpdateBuyer_rdr = UpdateBuyerSql.ExecuteReader();

            while (UpdateBuyer_rdr.Read())
            {
            }
            UpdateBuyer_rdr.Close();

            update_res = Convert.ToInt32(UpdBRetVal.Value);

            ret_info.errcode = update_res;
            if (0 == update_res)
            {
                ret_info.details = "მყიდველი შეიცვალა!";
            }

            return ret_info;

        }
        /// <summary>
        /// single-operation(non-transactional) add Remainder
        /// 
        /// </summary>
        /// <param name="addRem_arg"></param>
        /// <returns></returns>
        public info sOpAddRemainder(Remainder add_rem_arg)
        {
            info ret_info = info.niy();
            SqlCommand addRemSql = new SqlCommand("AddRemainder", SqlLink);
            addRemSql.CommandType = CommandType.StoredProcedure;
            addRemSql.Parameters.Add(new SqlParameter("@barcode", add_rem_arg.product_barcode));
            addRemSql.Parameters.Add(new SqlParameter("@supplier_ident", add_rem_arg.supplier_ident));
            addRemSql.Parameters.Add(new SqlParameter("@zed_nomeri", add_rem_arg.zednadebis_nomeri));
            addRemSql.Parameters.Add(new SqlParameter("@initial_pieces", add_rem_arg.initial_pieces));
            addRemSql.Parameters.Add(new SqlParameter("@remaining_pieces", add_rem_arg.remaining_pieces));
            addRemSql.Parameters.Add(new SqlParameter("@capacity", add_rem_arg.pack_capacity));
            addRemSql.Parameters.Add(new SqlParameter("@buy_price", add_rem_arg.buy_price));
            addRemSql.Parameters.Add(new SqlParameter("@sell_price", add_rem_arg.sell_price));
            addRemSql.Parameters.Add(new SqlParameter("@store_id", add_rem_arg.storehouse_id));

            SqlParameter addrem_retval = new SqlParameter("@Return_Value", DbType.Int32);
            addrem_retval.Direction = ParameterDirection.ReturnValue;
            addRemSql.Parameters.Add(addrem_retval);

            SqlDataReader addrem_rdr = addRemSql.ExecuteReader();
            while (addrem_rdr.Read())
            {
            }
            addrem_rdr.Close();

            ret_info.errcode = (Int32)addrem_retval.Value;
            switch (ret_info.errcode)
            {
                case 0:
                    ret_info.details = "ნაშთი დამატებულია!";
                    break;
                case 1:
                    ret_info.details = "გადაცემულია არასწორი არგუმენტები!";
                    break;
                case 183:
                    ret_info.details = "ასეთი ნაშთი უკვე არსებობს!";
                    break;
                case 404:
                    ret_info.details = "ნაშთი არ მოიძებნა!";
                    break;
            }

            return ret_info;
        }

        /// <summary>
        /// single-operation(non-transactional sell remainder)
        /// </summary>
        /// <param name="sell_rem_arg"></param>
        /// <returns></returns>
        public info sOpSellRemainder(Remainder sell_rem_arg, int SellOrderID_arg)
        {
            info ret_info = info.niy();
            SqlCommand sellRemSql = new SqlCommand("SellRemainder", SqlLink);
            sellRemSql.CommandType = CommandType.StoredProcedure;
            sellRemSql.Parameters.Add(new SqlParameter("@barcode", sell_rem_arg.product_barcode));
            sellRemSql.Parameters.Add(new SqlParameter("@storeID", sell_rem_arg.storehouse_id));
            sellRemSql.Parameters.Add(new SqlParameter("@selling_count", sell_rem_arg.initial_pieces));
            sellRemSql.Parameters.Add(new SqlParameter("@piece_price", sell_rem_arg.sell_price));
            sellRemSql.Parameters.Add(new SqlParameter("@SellOrderID", SellOrderID_arg));

            SqlParameter sellrem_retval = new SqlParameter("@Return_Value", DbType.Int32);
            sellrem_retval.Direction = ParameterDirection.ReturnValue;
            sellRemSql.Parameters.Add(sellrem_retval);

            SqlDataReader sellrem_rdr = sellRemSql.ExecuteReader();
            while (sellrem_rdr.Read())
            {
            }
            sellrem_rdr.Close();

            ret_info.errcode = (Int32)sellrem_retval.Value;
            switch (ret_info.errcode)
            {
                case 0:
                    ret_info.details = "ნაშთი გაყიდულია!";
                    break;
                case 1:
                    ret_info.details = "გადაცემულია არასწორი არგუმენტები!";
                    break;
                case 183:
                    ret_info.details = "ასეთი ნაშთი უკვე გაიყიდა!";
                    break;
                case 404:
                    ret_info.details = "ნაშთი არ მოიძებნა!";
                    break;
                case 10022:
                    ret_info.details = "პროდუქტი მითითებულზე გვიანდელი თარიღითაა შემოტანილი!";
                    break;
            }

            return ret_info;
            //
        }

        public int SellOrderIDByZedCode(string buyer_ident_arg, string zed_ident_arg)
        {
            info ret_info = info.niy();
            int RetSellOrderID = -1;

            SqlCommand SObyZedCode_Sql = new SqlCommand("SellOrderIDByZedCode", SqlLink);
            SObyZedCode_Sql.CommandType = CommandType.StoredProcedure;

            SObyZedCode_Sql.Parameters.Add(new SqlParameter("@buyer_ident", buyer_ident_arg));
            SObyZedCode_Sql.Parameters.Add(new SqlParameter("@zed_ident", zed_ident_arg));

            SqlParameter SOByZedCode_retval = new SqlParameter("@Return_Value", DbType.Int32);
            SOByZedCode_retval.Direction = ParameterDirection.ReturnValue;
            SObyZedCode_Sql.Parameters.Add(SOByZedCode_retval);

            SqlDataReader SObyZedCode_rdr = SObyZedCode_Sql.ExecuteReader();

            while (SObyZedCode_rdr.Read())
            {
                RetSellOrderID = (int)SObyZedCode_rdr[0];
            }
            SObyZedCode_rdr.Close();

            ret_info.errcode = (Int32)SOByZedCode_retval.Value;
            switch (ret_info.errcode)
            {
                case 0:
                    ret_info.details = "გაყიდვა წარმატებით მოიძებნა!";
                    break;
                case 1:
                    ret_info.details = "გადაცემულია არასწორი არგუმენტები!";
                    break;
                case 183:
                    ret_info.details = "ზუსტი ჩანაწერი ვერ მოიძებნა!";
                    break;
                case 404:
                    ret_info.details = "გაყიდვა არ მოიძებნა!";
                    break;
            }

            //return ret_info;
            return RetSellOrderID;
        }

        public DataTable Bought_AF_Standard_List()
        {
            DataTable bought_af_ret_dt = new DataTable();
            bought_af_ret_dt.Columns.Add("seriesNumber");
            bought_af_ret_dt.Columns.Add("invoiceNumber");
            bought_af_ret_dt.Columns.Add("invoiceIssueDate");
            bought_af_ret_dt.Columns.Add("pairedIdentificationNumber");
            bought_af_ret_dt.Columns.Add("invoiceAmount");

            SqlCommand bought_af_statistics_sql = new SqlCommand("Bought_AF_Standard_List", SqlLink);
            bought_af_statistics_sql.CommandType = CommandType.StoredProcedure;
            SqlDataReader bought_af_res = bought_af_statistics_sql.ExecuteReader();
            while (bought_af_res.Read())
            {
                DataRow nextRow = bought_af_ret_dt.NewRow();
                for (int i = 0; i < bought_af_res.FieldCount; i++)
                {
                    nextRow[i] = bought_af_res[i];
                    if ((4 == i) && "" != bought_af_res[i].ToString())
                    {
                        nextRow[i] = Math.Round(Utilities.Utilities.ParseDecimal(bought_af_res[i].ToString()), 2, MidpointRounding.AwayFromZero);
                    }
                }
                bought_af_ret_dt.Rows.Add(nextRow);
            }
            bought_af_res.Close();

            return bought_af_ret_dt;
        }

        public DataTable Gasavali(int SellOrderID_arg)
        {
            DataTable gasavali_ret_dt = new DataTable();
            gasavali_ret_dt.Columns.Add("დასახელება");
            gasavali_ret_dt.Columns.Add("ყუთების რ–ბა");
            gasavali_ret_dt.Columns.Add("ყუთის ფასი");
            gasavali_ret_dt.Columns.Add("საცალო რ–ბა");
            gasavali_ret_dt.Columns.Add("საცალო ფასი");
            gasavali_ret_dt.Columns.Add("ჯამური ფასი");

            SqlCommand gasavali_sql = new SqlCommand("Gasavali", SqlLink);
            gasavali_sql.CommandType = CommandType.StoredProcedure;

            gasavali_sql.Parameters.Add(new SqlParameter("@SellOrderID", SellOrderID_arg));

            SqlDataReader gasavali_res = gasavali_sql.ExecuteReader();
            while (gasavali_res.Read())
            {
                DataRow nextRow = gasavali_ret_dt.NewRow();
                for (int i = 0; i < gasavali_res.FieldCount; i++)
                {
                    nextRow[i] = gasavali_res[i];
                    if ((1 == i | 2 == i | 3 == i | 4 == i | 5 == i) && "" != gasavali_res[i].ToString())
                    {
                        nextRow[i] = Math.Round(Utilities.Utilities.ParseDecimal(gasavali_res[i].ToString()), 2, MidpointRounding.AwayFromZero);
                    }
                }
                gasavali_ret_dt.Rows.Add(nextRow);
            }
            gasavali_res.Close();

            return gasavali_ret_dt;
        }

        public DataTable AllStores()
        {
            DataTable AllStores_ret = new DataTable();
            AllStores_ret.Columns.AddRange(new DataColumn[]{
                  new DataColumn("id",typeof(int))
                , new DataColumn("Name",typeof(string))
                , new DataColumn("ParentID",typeof(int))
                , new DataColumn("Address",typeof(string))
                , new DataColumn("ResponsibleUserID",typeof(int))
                , new DataColumn("HasOwnStorageSpace",typeof(bool))
                , new DataColumn("CanSell",typeof(bool))
            });

            //there should always be a root (id=0) store

            //TODO: Get from db, this code is a placeholder
            /*
            DataRow store0 = AllStores_ret.NewRow();
            store0.ItemArray = new object[] { 0, "ყველა", -1, "Address Line 1", 0, 0, 0 };
            DataRow store1 = AllStores_ret.NewRow();
            store1.ItemArray = new object[] { 1, "პირველი", 0, "Store 1 Address", 0, 1, 1 };
            DataRow store2 = AllStores_ret.NewRow();
            store2.ItemArray = new object[] { 2, "მეორე", 0, "Store 2 Address", 0, 1, 1 };
            
            AllStores_ret.Rows.Add(store0);
            AllStores_ret.Rows.Add(store1);
            AllStores_ret.Rows.Add(store2);
            */
            //end placeholder code

            SqlCommand AllStores_sql = new SqlCommand("SELECT * FROM dbo.stores", SqlLink);
            AllStores_sql.CommandType = CommandType.Text;

            SqlDataReader AllStores_res = AllStores_sql.ExecuteReader();
            while (AllStores_res.Read())
            {
                DataRow nextRow = AllStores_ret.NewRow();
                for (int i = 0; i < AllStores_res.FieldCount; i++)
                {
                    nextRow[i] = AllStores_res[i];
                }
                AllStores_ret.Rows.Add(nextRow);
            }
            AllStores_res.Close();

            return AllStores_ret;
        }

        public DataTable CashBoxSummary(int cashbox_id_arg)
        {
            DataTable cashbox_sum_dt = new DataTable();
            cashbox_sum_dt.Columns.Add("ნაღდი ფული");

            SqlCommand cashbox_sum_sql = new SqlCommand("CashBoxSummary", DataProvider.SqlLink);
            cashbox_sum_sql.CommandType = CommandType.StoredProcedure;
            cashbox_sum_sql.Parameters.Add(new SqlParameter("@CashBoxID", cashbox_id_arg));

            //store_sum_sql.Parameters.Add(new SqlParameter("@Since", since_arg));
            //store_sum_sql.Parameters.Add(new SqlParameter("@Until", until_arg));

            SqlDataReader cashbox_sum_rs = cashbox_sum_sql.ExecuteReader();

            while (cashbox_sum_rs.Read())
            {
                DataRow newRec = cashbox_sum_dt.NewRow();
                for (int i = 0; i < cashbox_sum_rs.FieldCount; i++)
                {
                    newRec[i] = cashbox_sum_rs[i];
                    if ((0 == i) && "" != cashbox_sum_rs[i].ToString())
                    {
                        newRec[i] = Math.Round(Utilities.Utilities.ParseDecimal(cashbox_sum_rs[i].ToString()), 4, MidpointRounding.AwayFromZero);
                    }
                }
                cashbox_sum_dt.Rows.Add(newRec);
            }

            cashbox_sum_rs.Close();

            return cashbox_sum_dt;
        }

        public info RemoveSellOrder(int SO_id_arg)
        {
            info ret_info = new info();

            SqlCommand RemSellOrderCmd = new SqlCommand("RemoveSellOrder", SqlLink);
            RemSellOrderCmd.CommandType = CommandType.StoredProcedure;

            RemSellOrderCmd.Parameters.Add(new SqlParameter("@SellOrderID", SO_id_arg));

            SqlParameter rmSO_ret = new SqlParameter("@Return_Value", DbType.Int32);
            rmSO_ret.Direction = ParameterDirection.ReturnValue;
            RemSellOrderCmd.Parameters.Add(rmSO_ret);

            int res = RemSellOrderCmd.ExecuteNonQuery();

            // if (res > 0)//as SqlDataReader res.RecordsAffected
            // {
            ret_info.errcode = (int)rmSO_ret.Value;

            switch (ret_info.errcode)
            {
                case 404:
                    ret_info.details = "გაყიდვა ვერ მოიძებნა!";
                    break;
                case 2:
                    ret_info.details = "გაყიდვა უკვე წაიშალა!";//??
                    break;
                case 1:
                    ret_info.details = "პარამეტრები არასწორია!";
                    break;
                case 0:
                    ret_info.details = "ოპერაცია წარმატებით დასრულდა!";
                    break;
            }

            return ret_info;
        }

        public DataTable CashBoxStatistics()
        {
            DataTable CashBoxBalance_ret = new DataTable();
            CashBoxBalance_ret.Columns.AddRange(new DataColumn[]{
                  new DataColumn("id",typeof(int))
                , new DataColumn("Balance",typeof(decimal))
            });

            SqlCommand CashBoxBalance_sql = new SqlCommand("CashBoxStatistics", SqlLink);
            CashBoxBalance_sql.CommandType = CommandType.StoredProcedure;

            SqlDataReader CashBoxBalance_res = CashBoxBalance_sql.ExecuteReader();
            while (CashBoxBalance_res.Read())
            {
                DataRow nextRow = CashBoxBalance_ret.NewRow();
                for (int i = 0; i < CashBoxBalance_res.FieldCount; i++)
                {
                    nextRow[i] = CashBoxBalance_res[i];
                }
                CashBoxBalance_ret.Rows.Add(nextRow);
            }
            CashBoxBalance_res.Close();

            return CashBoxBalance_ret;
        }

    } //DataProvider Class




}
