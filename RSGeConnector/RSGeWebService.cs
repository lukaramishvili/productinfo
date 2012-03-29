using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RSGeConnector.RSGE;
using System.Xml;
using System.IO;
using ProductInfo;

namespace RSGeWebService
{
    public class RSGeConnection
    {
        public WayBillsSoapClient client = new WayBillsSoapClient();
        public string soap_user = "";
        public string soap_pass = "";

        /// <summary>
        /// This reference to DataProvider connection should be provided by main ProductInfo code.
        /// </summary>
        public DataProvider refconn;
        /// <summary>
        /// Connects to rs.ge waybills web service
        /// </summary>
        /// <param name="arg_ref_conn">sql server connection to productinfo</param>
        /// <param name="arg_username">usernamed used to first access rs.ge</param>
        /// <param name="arg_password">password used to first access rs.ge</param>
        public RSGeConnection(DataProvider arg_ref_conn, string arg_username, string arg_password)
        {
            refconn = arg_ref_conn;
            soap_user = arg_username;
            soap_pass = arg_password;
        }

        string zedtemplate = @"
            <WAYBILL>
<SUB_WAYBILLS></SUB_WAYBILLS>
<GOODS_LIST>
{GOODS_LIST}
</GOODS_LIST>
<ID>{ID}</ID>
<TYPE>{TYPE}</TYPE>
<BUYER_TIN>{BUYER_TIN}</BUYER_TIN>
<CHEK_BUYER_TIN>{CHEK_BUYER_TIN}</CHEK_BUYER_TIN>
<BUYER_NAME>{BUYER_NAME}</BUYER_NAME>
<START_ADDRESS>{START_ADDRESS}</START_ADDRESS>
<END_ADDRESS>{END_ADDRESS}</END_ADDRESS>
<DRIVER_TIN>{DRIVER_TIN}</DRIVER_TIN>
<CHEK_DRIVER_TIN>{CHEK_DRIVER_TIN}</CHEK_DRIVER_TIN>
<DRIVER_NAME>{DRIVER_NAME}</DRIVER_NAME>
<TRANSPORT_COAST>{TRANSPORT_COAST}</TRANSPORT_COAST>
<RECEPTION_INFO>{RECEPTION_INFO}</RECEPTION_INFO>
<RECEIVER_INFO>{RECEIVER_INFO}</RECEIVER_INFO>
{DELIVERY_DATE_TAG}
<STATUS>{STATUS}</STATUS>
<SELER_UN_ID>{SELLER_UN_ID}</SELER_UN_ID>
<PAR_ID>{PAR_ID}</PAR_ID>
<FULL_AMOUNT>{FULL_AMOUNT}</FULL_AMOUNT>
<CAR_NUMBER>{CAR_NUMBER}</CAR_NUMBER>
<WAYBILL_NUMBER>{WAYBILL_NUMBER}</WAYBILL_NUMBER>
<S_USER_ID>{S_USER_ID}</S_USER_ID>
<BEGIN_DATE>{BEGIN_DATE}</BEGIN_DATE>
<TRAN_COST_PAYER>{TRAN_COST_PAYER}</TRAN_COST_PAYER>
<TRANS_ID>{TRANS_ID}</TRANS_ID>
<TRANS_TXT>{TRANS_TXT}</TRANS_TXT>
<COMMENT>{COMMENT}</COMMENT>
</WAYBILL>
            ";

        string remtemplate = @"
<GOODS>
<ID>{REM_ID}</ID>
<W_NAME>{REM_NAME}</W_NAME>
<UNIT_ID>{UNIT_ID}</UNIT_ID>
<UNIT_TXT>{UNIT_TXT}</UNIT_TXT>
<QUANTITY>{QUANTITY}</QUANTITY>
<PRICE>{PRICE}</PRICE>
<STATUS>{STATUS}</STATUS>
<AMOUNT>{AMOUNT}</AMOUNT>
<BAR_CODE>{BAR_CODE}</BAR_CODE>
<A_ID>{A_ID}</A_ID>
<VAT_TYPE>{VAT_TYPE}</VAT_TYPE>
</GOODS>
";
        /// <summary>
        /// Prepares XML string &lt;goods&gt; for a remainder.
        /// </summary>
        /// <param name="rem">ნაშთი (QUANTITY=rem.initial_pieces, PRICE=rem.sell_price, AMOUNT=QT*PRICE, BAR_CODE)</param>
        /// <param name="prod">პროდუქტი (REM_NAME და VAT_TYPE)</param>
        /// <param name="rem_id">REM_ID - 0 თუ ემატება, და rs.ge-ს მხარეს ID ჩასწორების დროს.</param>
        /// <param name="unit_id">ერთეულის ID (?)</param>
        /// <param name="unit_txt">ერთეულის სახელი როცა UNIT_ID=99("სხვა")</param>
        /// <param name="status">გადაეცით 1. თუ გადაეცემა –1, ეს საქონელი წაიშლება.</param>
        /// <param name="a_id">აქციზის ID ან თუ აქციზური არ არის, 0.</param>
        /// <returns></returns>
        public string PrepareRemainder(
            Remainder arg_rem,
            Product arg_prod,
            int arg_rem_id,
            int arg_unit_id,
            string arg_unit_txt,
            int arg_status,
            int arg_a_id)
        {
            string ret = remtemplate;
            ret = ret.Replace("{REM_ID}", arg_rem_id.ToString());
            ret = ret.Replace("{REM_NAME}", arg_prod.name);
            ret = ret.Replace("{UNIT_ID}", arg_unit_id.ToString());
            ret = ret.Replace("{UNIT_TXT}", arg_unit_txt.ToString());
            ret = ret.Replace("{QUANTITY}", arg_rem.initial_pieces.ToString());
            ret = ret.Replace("{PRICE}", arg_rem.sell_price.ToString());
            ret = ret.Replace("{STATUS}", arg_status.ToString());
            ret = ret.Replace("{AMOUNT}", (arg_rem.sell_price * arg_rem.initial_pieces).ToString());
            ret = ret.Replace("{BAR_CODE}", arg_rem.product_barcode);
            ret = ret.Replace("{A_ID}", arg_a_id.ToString());
            ret = ret.Replace("{VAT_TYPE}", (arg_prod.usesVAT ? 0 : 2).ToString());
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg_zed"></param>
        /// <param name="arg_id"></param>
        /// <param name="arg_type"></param>
        /// <param name="arg_buyer"></param>
        /// <param name="arg_chek_buyer_tin"></param>
        /// <param name="arg_start_address"></param>
        /// <param name="arg_end_address"></param>
        /// <param name="arg_driver_tin"></param>
        /// <param name="arg_chek_driver_tin"></param>
        /// <param name="arg_driver_name"></param>
        /// <param name="arg_transport_coast"></param>
        /// <param name="arg_reception_info"></param>
        /// <param name="arg_receiver_info"></param>
        /// <param name="arg_delivery_date"></param>
        /// <param name="arg_status"></param>
        /// <param name="arg_seller_un_id">unicaluri nomeri mag. LTD-s saxelmcifo saregistracio nomeri (chek_service_user => un_id)</param>
        /// <param name="arg_par_id"></param>
        /// <param name="arg_car_number"></param>
        /// <param name="arg_s_user_id">qve-momxmareblis ID (chek_service_user => s_user_id)</param>
        /// <param name="arg_begin_date"></param>
        /// <param name="arg_tran_cost_payer"></param>
        /// <param name="arg_trans_id"></param>
        /// <param name="arg_trans_txt"></param>
        /// <param name="arg_comment"></param>
        /// <returns></returns>
        public XmlNode PrepareZednadebi(Zednadebi arg_zed,
            int arg_id,
            DataProvider.OperationType arg_type,
            Buyer arg_buyer,
            int arg_chek_buyer_tin,
            string arg_start_address,
            string arg_end_address,
            string arg_driver_tin,
            int arg_chek_driver_tin,
            string arg_driver_name,
            decimal arg_transport_coast,
            string arg_reception_info,
            string arg_receiver_info,
            DateTime arg_delivery_date,
            int arg_status,
            int arg_seller_un_id,
            int arg_par_id,
            string arg_car_number,
            int arg_s_user_id,
            DateTime arg_begin_date,
            int arg_tran_cost_payer,
            int arg_trans_id,
            string arg_trans_txt,
            string arg_comment
            )
        {
            string sxmlzed = zedtemplate;
            string sxmlrems = "";//all zed remainders as <GOODS> entities
            decimal dRemsFullAmount = 0.0m;//remainders total cost for FULL_AMOUNT
            foreach (Remainder nrem in arg_zed.OrderedItemList)
            {
                dRemsFullAmount += nrem.initial_pieces * nrem.sell_price;
                sxmlrems += PrepareRemainder(nrem,
                    refconn.GetProductByBarCode(nrem.product_barcode),
                    //TODO: WHAT'S HERE?
                    0,
                    1,
                    "idk",
                    1,
                    0);
            }
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
            sxmlzed = sxmlzed.Replace("{GOODS_LIST}", sxmlrems);
            //
            sxmlzed = sxmlzed.Replace("{ID}", arg_id.ToString());
            sxmlzed = sxmlzed.Replace("{TYPE}", ((int)arg_type).ToString());
            sxmlzed = sxmlzed.Replace("{BUYER_TIN}", arg_buyer.saidentifikacio_kodi);
            sxmlzed = sxmlzed.Replace("{CHEK_BUYER_TIN}", arg_chek_buyer_tin.ToString());
            sxmlzed = sxmlzed.Replace("{BUYER_NAME}", arg_buyer.saxeli);
            sxmlzed = sxmlzed.Replace("{START_ADDRESS}", arg_start_address.ToString());
            sxmlzed = sxmlzed.Replace("{END_ADDRESS}", arg_end_address.ToString());
            sxmlzed = sxmlzed.Replace("{DRIVER_TIN}", arg_driver_tin.ToString());
            sxmlzed = sxmlzed.Replace("{CHEK_DRIVER_TIN}", arg_chek_driver_tin.ToString());
            sxmlzed = sxmlzed.Replace("{DRIVER_NAME}", arg_driver_name.ToString());
            sxmlzed = sxmlzed.Replace("{TRANSPORT_COAST}", arg_transport_coast.ToString());
            sxmlzed = sxmlzed.Replace("{RECEPTION_INFO}", arg_reception_info.ToString());
            sxmlzed = sxmlzed.Replace("{RECEIVER_INFO}", arg_receiver_info.ToString());
            string delivery_date_tag = "<DELIVERY_DATE/>";
            switch (arg_status)
            {
                case 0:
                case 1:
                    break;
                case 2:
                    delivery_date_tag
                        = "<DELIVERY_DATE>" + arg_delivery_date.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss"
                            , culture) + "</DELIVERY_DATE>";
                    break;
            }
            sxmlzed = sxmlzed.Replace("{DELIVERY_DATE_TAG}", delivery_date_tag);
            sxmlzed = sxmlzed.Replace("{STATUS}", arg_status.ToString());
            sxmlzed = sxmlzed.Replace("{SELLER_UN_ID}", arg_seller_un_id.ToString());
            sxmlzed = sxmlzed.Replace("{PAR_ID}", arg_par_id.ToString());
            sxmlzed = sxmlzed.Replace("{FULL_AMOUNT}", dRemsFullAmount.ToString());
            sxmlzed = sxmlzed.Replace("{CAR_NUMBER}", arg_car_number.ToString());
            sxmlzed = sxmlzed.Replace("{WAYBILL_NUMBER}", arg_zed.zednadebis_nomeri);
            sxmlzed = sxmlzed.Replace("{S_USER_ID}", arg_s_user_id.ToString());
            sxmlzed = sxmlzed.Replace("{BEGIN_DATE}", arg_begin_date.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss", culture));
            sxmlzed = sxmlzed.Replace("{TRAN_COST_PAYER}", arg_tran_cost_payer.ToString());
            sxmlzed = sxmlzed.Replace("{TRANS_ID}", arg_trans_id.ToString());
            sxmlzed = sxmlzed.Replace("{TRANS_TXT}", arg_trans_txt.ToString());
            sxmlzed = sxmlzed.Replace("{COMMENT}", arg_comment.ToString());
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(sxmlzed);
            XmlNode waybill = doc.SelectSingleNode("/WAYBILL");
            return waybill;
        }

        public XmlElement PrepareSoldZednadebiEasy(Zednadebi arg_zed,
            int arg_id,
            Buyer arg_buyer,
            string arg_start_address,
            DateTime arg_delivery_date,
            int arg_seller_un_id,
            int arg_s_user_id
            )
        {
            return (XmlElement)PrepareZednadebi(arg_zed,
                arg_id,
                arg_zed.operation_type,
                arg_buyer,
                1,
                arg_start_address,
                arg_buyer.address,
                "",
                1,
                "",
                0,
                "",
                "",
                arg_delivery_date,
                1,
                arg_seller_un_id,
                0,
                "",
                arg_s_user_id,
                arg_zed.dro,
                2,
                167,
                "",
                ""
            );
        }

        public XmlElement SaveWaybill(XmlElement arg_wb)
        {
            return client.save_waybill(soap_user, soap_pass, arg_wb);
        }

        //

        public int GetSellerUnId()
        {
            int SellerUnId;
            int SUserId;
            client.chek_service_user
                (soap_user, soap_pass, out SellerUnId, out SUserId);
            return SellerUnId;
        }

        public int GetSUserId()
        {
            int SellerUnId;
            int SUserId;
            client.chek_service_user
                (soap_user, soap_pass, out SellerUnId, out SUserId);
            return SUserId;
        }
    }
}
