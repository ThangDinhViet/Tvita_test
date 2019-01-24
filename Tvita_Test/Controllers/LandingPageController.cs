using Newtonsoft.Json.Linq;
using reCAPTCHA.MVC;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;
using Tvita.BAL.Implement;
using Tvita.Model.Table;

namespace Tvita_Test.Controllers
{
    public class LandingPageController : TvitaController
    {
        // GET: LandingPage
        public ActionResult Index()
        {
            return View();
        }

        private OrderLandingPageManager _orderLandingPageManager { get; set; }


        [HttpPost]
        public ActionResult AddOrder(FormCollection fc)
        {
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
            string body;
            using (var sr = new StreamReader(Server.MapPath("\\App_Data\\") + "Templates.txt"))
            {
                body = sr.ReadToEnd();
            }
            try
            {
                //var response = Request["g-recaptcha-response"];
                ////string secretKey = "6Lfew4oUAAAAAN8e-Yl0kelYTHDoBwGdOzZZ0q0q";
                //string secretKey = "6LeIxAcTAAAAAGG-vFI1TnRWxMZNFuojJ4WifJWe";
                //var client = new WebClient();
                //var result = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, response));
                //var obj = JObject.Parse(result);
                //var status = (bool)obj.SelectToken("success");
                //ViewBag.Message = status ? "Google reCaptcha validation success" : "Google reCaptcha validation failed";
                ////if (status == true)
                var contentID = "Image";
                var inlineLogo = new Attachment(Server.MapPath("\\Content\\images\\logos\\") + "log.png");
                inlineLogo.ContentId = contentID;
                inlineLogo.ContentDisposition.Inline = true;
                inlineLogo.ContentDisposition.DispositionType = DispositionTypeNames.Inline;

                var contentID1 = "Image1";
                var inlineLogo1 = new Attachment(Server.MapPath("\\Content\\images\\landingpage\\") + "image1.png");
                inlineLogo1.ContentId = contentID1;
                inlineLogo1.ContentDisposition.Inline = true;
                inlineLogo1.ContentDisposition.DispositionType = DispositionTypeNames.Inline;

                var contentID2 = "Image2";
                var inlineLogo2 = new Attachment(Server.MapPath("\\Content\\images\\landingpage\\") + "image2.png");
                inlineLogo2.ContentId = contentID2;
                inlineLogo2.ContentDisposition.Inline = true;
                inlineLogo2.ContentDisposition.DispositionType = DispositionTypeNames.Inline;

                var contentID3 = "Image3";
                var inlineLogo3 = new Attachment(Server.MapPath("\\Content\\images\\landingpage\\") + "image3.png");
                inlineLogo3.ContentId = contentID3;
                inlineLogo3.ContentDisposition.Inline = true;
                inlineLogo3.ContentDisposition.DispositionType = DispositionTypeNames.Inline;
                {
                    _orderLandingPageManager = new OrderLandingPageManager();
                    OrderLandingPageModel order = new OrderLandingPageModel();

                    order.Customer_Name = fc["name"].ToString();
                    order.Customer_PhoneNum = fc["phone"].ToString();
                    order.Customer_Address = fc["address"].ToString();
                    order.Customer_Note = fc["note"].ToString();
                    order.Customer_Email = fc["email"].ToString();
                    if (fc["check1"] == "true")
                        order.QuantityPro1 = Convert.ToInt16(fc["num1"]);
                    if (fc["check2"] == "true")
                        order.QuantityPro2 = Convert.ToInt16(fc["num2"]);
                    if (fc["check3"] == "true")
                        order.QuantityPro3 = Convert.ToInt16(fc["num3"]);
                    order.TotalPrice = Convert.ToInt32(fc["price"]);
                    order.Time_Delivery = DateTime.Parse(fc["datedeli"]);

                    var numOrder = _orderLandingPageManager.AddOrderLandingPage(order);
                    //send email
                    string from = ConfigurationManager.AppSettings["From"];
                    string subject = ConfigurationManager.AppSettings["Subject"];
                    MailMessage mail = new MailMessage(from, order.Customer_Email);
                    mail.Attachments.Add(inlineLogo);
                    mail.Attachments.Add(inlineLogo1);
                    mail.Attachments.Add(inlineLogo2);
                    mail.Attachments.Add(inlineLogo3);
                    string messageBody = string.Format(body, order.Customer_Name, order.Customer_PhoneNum, order.Customer_Address, order.Time_Delivery.Value.ToString("dd/MM/yyyy"), order.Customer_Note, order.TotalPrice.Value.ToString("#,###", cul.NumberFormat), order.QuantityPro1, order.QuantityPro2, order.QuantityPro3, numOrder, contentID, contentID1, contentID2, contentID3);
                    mail.Subject = subject;
                    mail.Body = messageBody;
                    mail.IsBodyHtml = true;
                    MailMessage mailEmployee = new MailMessage(from, ConfigurationManager.AppSettings["To"]);
                    mailEmployee.Subject = subject;
                    mailEmployee.Body = messageBody;
                    mailEmployee.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    NetworkCredential networkCredential = new NetworkCredential(from, "Tvita@1234");
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = networkCredential;
                    smtp.Port = 587;

                    smtp.Send(mail);


                    smtp.Send(mailEmployee);
                    ViewBag.Message = "Sent";


                    return Json(new { status = 1 });
                }
                //else
                //    return Json(new { status = ViewBag.Message });
            }
            catch (Exception ex)
            {
                return Json(new { status = 0 });
            }

        }
    }
}