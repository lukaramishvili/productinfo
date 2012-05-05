using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RSGeConnector.RSGE;
using System.Xml;
using System.IO;
using ProductInfo;
using Utilities;

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

        public static Dictionary<int, string> initWbErrorDict()
        {
            Dictionary<int, string> dictretval = new Dictionary<int, string>();
            dictretval[-1001] = "ზედნადების ტიპი არასწორია";
            dictretval[-1028] = "წაშლილ ზედნადებში ვერ დაარედაქტირებთ და ვერც წაშლით";
            dictretval[-1002] = "ტრანსპორტირების ტიპი არასწორია";
            dictretval[-1014] = "მძღოლი არ მოიძებნა;  chek_driver_tin=1 ";
            dictretval[-1015] = "reception_info დიდია";
            dictretval[-1016] = "receiver_info დიდია";
            dictretval[-1017] = "delivery_date მეტია მინდინარე თარიღზე";
            dictretval[-1003] = "buyer_name აუცილებელია chek_buyer_tin=0";
            dictretval[-1018] = "delivery_date ნაკლებია begin_date თარიღზე";
            dictretval[-1004] = "მყიდველი აუცილებელია ყოველთვის გარდა შიდაგადაზიდვისას";
            dictretval[-1019] = "სტატუსი არასწორია";
            dictretval[-1020] = "შეუნახავს ვერ წაშლი";
            dictretval[-1021] = "შეუნახავს ვერ გააუქმებ";
            dictretval[-1022] = "გამყიდველი ლიკვიდირებულია";
            dictretval[-1005] = "მყიდვევლი არ მოიძებნა თუ   chek_buyer_tin=1";
            dictretval[-1006] = "მყიდვევლი ლიკვიდირებულია ან კოდი გაუქმებულია";
            dictretval[-1007] = "start_address დიდია";
            dictretval[-1023] = "ქვეზედნადებისთვის მშობელი აუცილებელია";
            dictretval[-1008] = "driver_tin დიდია";
            dictretval[-1027] = "დასრულებულის რედაქტირებას ვე გააკეთებთ";
            dictretval[-1009] = "start_address აუცილებელია";
            dictretval[-1010] = "end_address დიდია";
            dictretval[-1029] = "გაუქმებულს ზედნადებში ვერ დაარედაქტირებთ და ვერც წაშლით";
            dictretval[-1030] = "მშობელ ზედნადებს ვე გააუქმებთ თუ ქვე ზედნადები აქვს";
            dictretval[-1011] = "end_address აუცილებელია თუ ტრანსპორტირებაა";
            dictretval[-1024] = "მშობელი არ მოიძებნა ან მშობელი აქტივირებული არ არის";
            dictretval[-1025] = "ქვე ზედნადები მარტო დისტრიბუციაზე იწერება";
            dictretval[-1026] = "მანქანია ნომერი არასწორია";
            dictretval[-1012] = "მძღოლი აუცილებელია ტრანსპორტირების ტიპის ყველა ზედნადებზე";
            dictretval[-1013] = "მძღოლის სახელი აუცილებელია  chek_buyer_tin=0  ტრანსპორტირების ტიპის ყველა ზედნადებზე";
            dictretval[-2003] = "unit_id არასწორია";
            dictretval[-2004] = "unit_txt აუცილებელია როცა unit_id = 99";
            dictretval[-2005] = "რაოდენობა 0-ზე მედი უნდა";
            dictretval[-2006] = "ქონების სტატუსი არასწორია";
            dictretval[-2007] = "price არის აუცილებელი გარდა შიდაგადაზიდვის ";
            dictretval[-2008] = "აქციზის ID არქასწორია";
            dictretval[-2002] = "vat_type არასწორია";
            dictretval[-2001] = "w_name დიდია";
            dictretval[-3006] = "ანგარიშფაქტურა და ზედნადები სხვადასხვა გადამხდელზეა გამოწერილი";
            dictretval[-3004] = "გამყიდველი არ არის დღგს გადამხდელი";
            dictretval[-3005] = "მყიდველი არ არის გადამხელი ან რეგისრირებული არ არის დეკლარირებაში";
            dictretval[-3003] = "ზედნადები არ არის დახურული";
            dictretval[-3002] = "გამყიდველი არ არის დეცლარირებაში რეგისტრირებული";
            dictretval[-3001] = "ზედნადები არ მოიძებნა";
            dictretval[-1034] = "აქტივაციის თარიღი  ნაკლებია შექმნის თარიღზე";
            dictretval[-2] = "ზოგადი შეცდომა (არამთელი რიცხვებს გამყოფად წერტილი უნდა ქონდეთ)";
            dictretval[-1036] = "ტრანსპორტირების გარეშე  შემთხვევაში დაწყების და დარულების ადგილი უნდა ემთხვეოდეს";
            dictretval[-1031] = "გადაგზავნილს ვერ წაშლით";
            dictretval[-1032] = "ქვე ზედდებულს ძირითადად ვერ გახდი";
            dictretval[-1033] = "გამოწერილ ზედნადებს ქვე ზედნადებად ვერ გადააკეთებ";
            dictretval[-1035] = "შიდაგადაზიდვის დროს მყიდველის საიდენტიფიკაციო კოდი ცარიელი ან გამყიდველის კოდი უნდა იყოს მითითებული";
            dictretval[-1] = "გაურკვეველი შეცდომა (გადაამოწმეთ თარიღების ფორმატი)";
            dictretval[-100] = "სერვისის მომხმარებელი ან პაროლი არასწორია";
            dictretval[-101] = "გამომწერის un_id განსხვავდება XML-ში მითითებული seler_un_id -ის გან ";
            dictretval[-1037] = "თუ ტრანსპორტირების ტიპი არის სხვა მიუთითეთ TRANS_TXT";
            dictretval[-2009] = "მშობელ ზედნადებში არ არის შესაბამისი საქონელი";
            dictretval[-102] = "შეცდომა მოხდა XML-ის პარსირებისას ან SELLER_UN_ID ტეგი არ გაქვთ";
            return dictretval;
        }

        public static Dictionary<int, string> wbErrorDict = initWbErrorDict();

        public static string GetWBError(int nError)
        {
            if (wbErrorDict.ContainsKey(nError))
            {
                return wbErrorDict[nError].ToString();
            }
            else
            {
                return nError.ToString();
            }
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
            ret = ret.Replace("{QUANTITY}", Utilities.Utilities.StringFromDecimal(Math.Round(arg_rem.initial_pieces,3)));
            ret = ret.Replace("{PRICE}", Utilities.Utilities.StringFromDecimal(Math.Round(arg_rem.sell_price,3)));
            ret = ret.Replace("{STATUS}", arg_status.ToString());
            ret = ret.Replace("{AMOUNT}", Utilities.Utilities.StringFromDecimal(Math.Round((arg_rem.sell_price * arg_rem.initial_pieces),3)));
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
        public XmlElement PrepareZednadebi(Zednadebi arg_zed,
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
            sxmlzed = sxmlzed.Replace("{TRANSPORT_COAST}", Utilities.Utilities.StringFromDecimal(Math.Round(arg_transport_coast,3)));
            sxmlzed = sxmlzed.Replace("{RECEPTION_INFO}", arg_reception_info.ToString());
            sxmlzed = sxmlzed.Replace("{RECEIVER_INFO}", arg_receiver_info.ToString());
            string delivery_date_tag = "<DELIVERY_DATE/>";
            switch (arg_status)
            {
                case 0:
                case 1:
                    if (DataProvider.OperationType.SellTransporting == arg_type)
                    {
                        delivery_date_tag
                            = "<DELIVERY_DATE>" + arg_delivery_date.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss"
                                , culture) + "</DELIVERY_DATE>";
                    }
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
            sxmlzed = sxmlzed.Replace("{FULL_AMOUNT}", Utilities.Utilities.StringFromDecimal(Math.Round(dRemsFullAmount)));
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
            return (XmlElement)waybill;
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
            return PrepareZednadebi(arg_zed,
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

        public Zednadebi LoadWaybill(int Waybill_ID)
        {
            XmlElement xmlZedFromRS
                = client.get_waybill(soap_user, soap_pass, Waybill_ID);
            //TODO: .SelectSingleNode("/ID"), ("GOODS_LIST") etc
            return null;
        }

        public info AddInvoiceForZednadebi(int Waybill_ID, out int outInvoiceID)
        {
            int retErrorCode;
            string sErrorMessage = "ოპერაცია არ დაწყებულა!";
            int RSGESaveInvoice = client.save_invoice(soap_user, soap_pass, Waybill_ID, 0, out outInvoiceID);
            switch (RSGESaveInvoice)
            {
                case 1:
                    //success; return
                    retErrorCode = 0;
                    sErrorMessage = "ოპერაცია წარმატებით დასრულდა!";
                    break;
                case -1:
                    retErrorCode = -1;
                    sErrorMessage = "მოხდა შეცდომა. ოპერაცია ვერ განხორციელდა!";
                    break;
                case -101:
                    //sxvisi zednadebia
                    retErrorCode = -101;
                    sErrorMessage = "ზედნადები ამ კოდით ეკუთვნის სხვას!";
                    break;
                case -100:
                    //momxmarebeli/paroli arascoria
                    retErrorCode = -100;
                    sErrorMessage = "მომხმარებლის სახელი/პაროლი არასწორია!";
                    break;
                default:
                    if (wbErrorDict.ContainsKey(RSGESaveInvoice))
                    {
                        retErrorCode = 0;
                        sErrorMessage = wbErrorDict[RSGESaveInvoice];
                    }
                    else
                    {
                        //unknown error
                        retErrorCode = -1;
                        sErrorMessage = "უცნობი შეცდომა. ოპერაცია ვერ განხორციელდა!";
                    }
                    break;
            }
            return new info(sErrorMessage, retErrorCode);
        }

        public int GetSoldZednadebiWaybillID(string sZedIdent, out int WaybillID)
        {
            XmlElement xmlWaybill = client.get_waybills(soap_user, soap_pass, null, null, null
                , null, null, null, null, null, null, null, null, null, sZedIdent, null, null, null, null);
            WaybillID = (null == xmlWaybill.SelectSingleNode("/WAYBILL/ID"))
                ? -1
                : Utilities.Utilities.ParseInt(xmlWaybill.SelectSingleNode("/WAYBILL/ID").InnerText);
            if (WaybillID > 0)
            {
                return 0;
            }
            else
            {
                return 404;
            }
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
