using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DacSan.Models;
using DacSan.Areas.Guest.Models;
using static DataLibrary.BusinessLogic.LoaiSPProcessor;
using static DataLibrary.BusinessLogic.ProductProcessor;
using static DataLibrary.BusinessLogic.OrderDetailProcessor;
using static DataLibrary.BusinessLogic.OrderProcessor;
using static DataLibrary.BusinessLogic.GuestProcessor;
using static DataLibrary.BusinessLogic.UsersProcessor;
using static DataLibrary.BusinessLogic.CartDetailProcessor;
using static DataLibrary.BusinessLogic.CartProcessor;
using DataLibrary.Models;
using DataLibrary.Models.NewFolder1;
using PagedList;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using System.Web.Services.Protocols;
using VNPAY_CS_ASPX;
using System.Configuration;
using VNPAY_CS_ASPX.Models;

namespace DacSan.Areas.Guest.Controllers
{
    public class CartController : Controller
    {
        Model1 db = new Model1();
        private static string Business = "";

        private static string apiuser = "";// Liên hệ kỹ thuật Bao Kim để lấy api user và pass
        private static string apipass = "";
        private static string merchantid = "";// id của site
        private static string securepass = "";// dùng để mã hóa tại hàm getHmacSHA1
        private static string url_complete = "http://cuahangbiaht01.chinh.vn/Guest/Cart/Complete";
        private static string BAOKIM_API_PAYMENT = "/payment/api/v4/";

        private void __construct()
        {
            ViewBag.Title = "Trang Người dùng";
            try
            {
                if (Session["UserID"] != null)
                {
                    ViewBag.UserID = Session["UserID"];
                    ViewBag.UserName = Session["UserName"];
                    ViewBag.UserRole = Session["UserRole"];
                    var user = LoadOneUser((int)Session["UserID"]);
                    ViewData["user"] = user;
                    List<ItemModel> list = new List<ItemModel>();
                    var listCart = LoadCartDetailByCartID((int)Session["CartID"]);
                    foreach (CartDetailModel cd in listCart)
                    {
                        var product = LoadOneProduct(cd.SanPhamID);
                        if (product != null)
                        {
                            ItemModel item = new ItemModel() { SL = cd.SL, NgayThem = cd.NgayThem, Product = new DacSan.Models.ProductModel(product) };
                            list.Add(item);
                        }
                    }
                    Session["cart"] = list;
                }

                List<tbl_TinTuc> listtintuc = db.tbl_TinTuc.ToList();
                ViewData["listTinTuc"] = listtintuc;

                var loaisp = LoadLoaiSP(12);
                ViewData["loaisp"] = loaisp;
                foreach (LoaiSPModel loai in (IEnumerable<LoaiSPModel>)ViewData["loaisp"])
                {
                    var listsp = LoadProductByCate(loai.LoaiSPID, 6);
                    ViewData[loai.LoaiSPID.ToString()] = listsp;
                }
                if (Session["cart"] != null)
                {
                    ViewData["NumCart"] = ((List<ItemModel>)Session["cart"]).Count;
                }
                else
                {
                    ViewData["NumCart"] = 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private void __LoadCart()
        {
            if (Session["UserID"] != null)
            {
                var check = LoadOneCartByUser((int)Session["UserID"]);
                int GioHangID;
                if (check == null)
                {
                    GioHangID = CreateCart((int)Session["UserID"]);
                }
                else
                {
                    GioHangID = check.GioHangID;
                }
                RemoveAllCartDetail(GioHangID);
                if (Session["cart"] != null)
                {
                    List<ItemModel> cart = (List<ItemModel>)Session["cart"];
                    foreach (ItemModel item in cart)
                    {
                        CreateCartDetail(item.Product.ProductID, item.SL, item.Product.DonGia, GioHangID, item.NgayThem);
                    }
                }
            }
        }
        // GET: Guest/Cart
        public ActionResult Index(int id = -1)
        {
            if (id != -1)
            {
                int sl = 1;
                if (Session["cart"] == null)
                {
                    List<ItemModel> cart = new List<ItemModel>();
                    var sp = new DacSan.Models.ProductModel(LoadOneProduct(id));
                    ItemModel item = new ItemModel() { Product = sp, SL = sl, NgayThem = DateTime.Now };
                    cart.Add(item);
                    Session["cart"] = cart;
                }
                else
                {
                    List<ItemModel> cart = (List<ItemModel>)Session["cart"];
                    int index = isExist(id);
                    if (index != -1)
                    {
                        cart[index].SL += sl;
                    }
                    else
                    {
                        var sp = new DacSan.Models.ProductModel(LoadOneProduct(id));
                        ItemModel item = new ItemModel() { Product = sp, SL = sl, NgayThem = DateTime.Now };
                        cart.Add(item);
                    }
                    Session["cart"] = cart;
                }
                __LoadCart();
            }
            __construct();
            return View();
        }

        public ActionResult InfoGuest()
        {
            __construct();
            if (Session["cart"] == null || ((List<ItemModel>)Session["cart"]).Count == 0)
            {
                TempData["Error"] = "Không có sản phẩm nào";
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult PayByMomo()
        {
            try
            {
                return Redirect(this.Payment(Session["totalAmount"].ToString(), "Thanh toan hoa don " + Session["HoTen"].ToString()));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                TempData["Error"] = "Mua thật bại, Mất kết nối cơ sở dữ liệu";
                return RedirectToAction("Index");
            }
        }

        public ActionResult PayByVNPay()
        {
            try
            {
                return Redirect(Page_Load());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                TempData["Error"] = "Mua thật bại, Mất kết nối cơ sở dữ liệu";
                return RedirectToAction("Index");
            }
        }
        public string Page_Load()
        {
            //Get Config Info
            string vnp_Returnurl = ConfigurationManager.AppSettings["vnp_Returnurl"]; //URL nhan ket qua tra ve 
            string vnp_Url = ConfigurationManager.AppSettings["vnp_Url"]; //URL thanh toan cua VNPAY 
            string vnp_TmnCode = ConfigurationManager.AppSettings["vnp_TmnCode"]; //Ma website
            string vnp_HashSecret = ConfigurationManager.AppSettings["vnp_HashSecret"]; //Chuoi bi mat

            //Get payment input
            OrderInfo order = new OrderInfo();
            //Save order to db
            order.OrderId = DateTime.Now.Ticks;
            order.Amount = Convert.ToDecimal(Session["totalAmount"].ToString());
            order.OrderDescription = "Thanh toán bằng VNPay";
            order.CreatedDate = DateTime.Now;

            //Build URL for VNPAY
            VnPayLibrary vnpay = new VnPayLibrary();

            vnpay.AddRequestData("vnp_Version", "2.0.0");
            vnpay.AddRequestData("vnp_Command", "pay");
            vnpay.AddRequestData("vnp_TmnCode", vnp_TmnCode);

            string locale = "vn";//"en"
            if (!string.IsNullOrEmpty(locale))
            {
                vnpay.AddRequestData("vnp_Locale", locale);
            }
            else
            {
                vnpay.AddRequestData("vnp_Locale", "vn");
            }

            vnpay.AddRequestData("vnp_CurrCode", "VND");
            vnpay.AddRequestData("vnp_TxnRef", order.OrderId.ToString());
            vnpay.AddRequestData("vnp_OrderInfo", order.OrderDescription);
            vnpay.AddRequestData("vnp_OrderType", "insurance"); //default value: other
            vnpay.AddRequestData("vnp_Amount", (order.Amount * 100).ToString());
            vnpay.AddRequestData("vnp_ReturnUrl", vnp_Returnurl);
            vnpay.AddRequestData("vnp_IpAddr", GetIpAddress());
            vnpay.AddRequestData("vnp_CreateDate", order.CreatedDate.ToString("yyyyMMddHHmmss"));
            //if (bank.SelectedItem != null && !string.IsNullOrEmpty(bank.SelectedItem.Value))
            //{
            //    vnpay.AddRequestData("vnp_BankCode", bank.SelectedItem.Value);
            //}
            string paymentUrl = vnpay.CreateRequestUrl(vnp_Url, vnp_HashSecret);

            return paymentUrl;
        }
        public ActionResult PayByBaoKim()
        {
            try
            {
                return Redirect("https://www.baokim.vn/payment/?oid=101872033&checksum=17ef0ed7ea051e61b8d9f81e75d8bdce359f49cd");
                //return Redirect(this.Payment(Session["totalAmount"].ToString(), "Thanh toan hoa don " + Session["HoTen"].ToString()));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                TempData["Error"] = "Mua thật bại, Mất kết nối cơ sở dữ liệu";
                return RedirectToAction("Index");
            }
        }
        public string PaymentBaoKim()
        {
            string totalAmount = Session["totalAmount"].ToString();
            string currency = "VND";
            string serect_key = "a18ff78e7a9e44f38de372e093d87ca1";
            string serect_pass = "9623ac03057e433f95d86cf4f3bef5cc";
            JObject param = new JObject
            {
                {"merchant_id", "" },
                {"order_id", "DH01" },
                {"business", "chinhhi102@gmail.com" },
                {"total_amount",  totalAmount},
                {"shipping_fee", "0" },
                {"tax_fee", "0" },
                {"order_description", "order_description" },
                {"url_success", url_complete },
                {"url_cancel", url_complete },
                {"url_detail", "" },
                {"payer_name", "KH" },
                {"payer_email", "KH@gmail.com" },
                {"payer_phone", "01231243" },
                {"shipping_address", "06 Tran Van On" },
                {"currency", currency }
            }; 

            //param.Add("checksum", new HMACSHA1( param.ToString(), Encoding.UTF8.GetBytes("a18ff78e7a9e44f38de372e093d87ca1")));

            //Kiểm tra  biến $redirect_url xem có '?' không, nếu không có thì bổ sung vào
            string bkUrl = "http://sandbox.baokim.vn";
            string redirect_url = bkUrl + BAOKIM_API_PAYMENT;

            string url_params = "";
            foreach (var x in param)
            {
                if(url_params == "")
                {
                    url_params += x.Key + "=" + Server.UrlEncode(x.Value.ToString());
                }
                else
                {
                    url_params += "&" + x.Key + "=" + Server.UrlEncode(x.Value.ToString());
                }
            }
            return redirect_url + url_params;
        }

        public string GetIpAddress()
        {
            string ipAddress;
            try
            {
                ipAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(ipAddress) || (ipAddress.ToLower() == "unknown"))
                    ipAddress = Request.ServerVariables["REMOTE_ADDR"];
            }
            catch (Exception ex)
            {
                ipAddress = "Invalid IP:" + ex.Message;
            }

            return ipAddress;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InfoGuest(InfoGuestModel info)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int KhachHangID;
                    int loai;
                    if (Session["UserID"] == null)
                    {
                        loai = 1;
                        KhachHangID = CreateGuest(info.HoTen, info.Email, info.SDT, info.SoNha, info.Duong, info.Xa, info.Tinh, info.huyen);
                    }
                    else
                    {
                        loai = 2;
                        KhachHangID = (int)Session["UserID"];
                    }
                    var DonHangID = CreateOrder(KhachHangID, loai, 1);
                    int totalAmount = 0;
                    foreach (ItemModel item in (List<ItemModel>)Session["cart"])
                    {
                        CreateOrderDetail(item.Product.ProductID, item.SL, item.Product.DonGia, DonHangID, DateTime.Now);
                        totalAmount += (int)item.Product.DonGia * (int)item.SL;
                    }
                    Session["totalAmount"] = totalAmount;
                    Session["HoTen"] = info.HoTen;
                    return RedirectToAction("InfoPay", "Cart");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    TempData["Error"] = "Mua thật bại, Mất kết nối cơ sở dữ liệu";
                    return RedirectToAction("Index");
                }

            }
            else
            {
                return View();
            }
        }
        public string Payment(string amount, string orderInfo)
        {
            //request params need to request to MoMo system
            string endpoint = "https://test-payment.momo.vn/gw_payment/transactionProcessor";
            string partnerCode = "MOMOR9DA20200930";
            string accessKey = "4n1OdJYj90WS1HCB";
            string serectkey = "aKQrLwlhgTDow9vRxOrxHtR3YHG65nuK";
            //string orderInfo = "Chinh";
            string returnUrl = url_complete;
            string notifyurl = url_complete;

            //string amount = "1000";
            string orderid = Guid.NewGuid().ToString();
            string requestId = Guid.NewGuid().ToString();
            string extraData = "";

            //Before sign HMAC SHA256 signature
            string rawHash = "partnerCode=" +
                partnerCode + "&accessKey=" +
                accessKey + "&requestId=" +
                requestId + "&amount=" +
                amount + "&orderId=" +
                orderid + "&orderInfo=" +
                orderInfo + "&returnUrl=" +
                returnUrl + "&notifyUrl=" +
                notifyurl + "&extraData=" +
                extraData;

            MoMo.MoMoSecurity crypto = new MoMo.MoMoSecurity();
            //sign signature SHA256
            string signature = crypto.signSHA256(rawHash, serectkey);

            //build body json request
            JObject message = new JObject
            {
                { "partnerCode", partnerCode },
                { "accessKey", accessKey },
                { "requestId", requestId },
                { "amount", amount },
                { "orderId", orderid },
                { "orderInfo", orderInfo },
                { "returnUrl", returnUrl },
                { "notifyUrl", notifyurl },
                { "extraData", extraData },
                { "requestType", "captureMoMoWallet" },
                { "signature", signature }

            };
            string responseFromMomo = MoMo.PaymentRequest.sendPaymentRequest(endpoint, message.ToString());

            Console.WriteLine(responseFromMomo);

            JObject jmessage = JObject.Parse(responseFromMomo);

            Console.WriteLine(jmessage.GetValue("payUrl").ToString());

            if (jmessage.GetValue("payUrl") == null)
                return "/";

            return jmessage.GetValue("payUrl").ToString();

            // jmessage.GetValue("payUrl").ToString()


        }
        public ActionResult InfoPay()
        {
            __construct();
            if (Session["cart"] == null || ((List<ItemModel>)Session["cart"]).Count == 0)
            {
                TempData["Error"] = "Không có sản phẩm nào";
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Complete()
        {
            __construct();
            //if (Session["cart"] == null || ((List<ItemModel>)Session["cart"]).Count == 0)
            //{
            //    TempData["Error"] = "Không có sản phẩm nào";
            //    return RedirectToAction("Index");
            //}   

            if (Request.Params["errorCode"] != null && Request.Params["errorCode"].ToString() != "0")
            {
                TempData["Error"] = "Thanh toán không thành công !";
            }
            else
            {
                Session["cart"] = null;
                __LoadCart();
                __construct();
            }
            return View();
        }

        public ActionResult Remove(int id)
        {
            List<ItemModel> cart = (List<ItemModel>)Session["cart"];
            int index = isExist(id);
            cart.RemoveAt(index);
            Session["cart"] = cart;
            __construct();
            return RedirectToAction("Index");
        }

        public static bool VerifyFile(byte[] key, String sourceFile)
        {
            bool err = false;
            // Initialize the keyed hash object.
            using (HMACSHA256 hmac = new HMACSHA256(key))
            {
                // Create an array to hold the keyed hash value read from the file.
                byte[] storedHash = new byte[hmac.HashSize / 8];
                // Create a FileStream for the source file.
                using (FileStream inStream = new FileStream(sourceFile, FileMode.Open))
                {
                    // Read in the storedHash.
                    inStream.Read(storedHash, 0, storedHash.Length);
                    // Compute the hash of the remaining contents of the file.
                    // The stream is properly positioned at the beginning of the content,
                    // immediately after the stored hash value.
                    byte[] computedHash = hmac.ComputeHash(inStream);
                    // compare the computed hash with the stored value

                    for (int i = 0; i < storedHash.Length; i++)
                    {
                        if (computedHash[i] != storedHash[i])
                        {
                            err = true;
                        }
                    }
                }
            }
            if (err)
            {
                Console.WriteLine("Hash values differ! Signed file has been tampered with!");
                return false;
            }
            else
            {
                Console.WriteLine("Hash values agree -- no tampering occurred.");
                return true;
            }
        } //end VerifyFile
        private int isExist(int id)
        {
            List<ItemModel> cart = (List<ItemModel>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].Product.ProductID.Equals(id))
                    return i;
            return -1;
        }
    }
}