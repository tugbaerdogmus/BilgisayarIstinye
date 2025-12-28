using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace BilgisayarIstinye.Controllers
{
    public class PageController : Controller
    {
        // GET: Page
        public ActionResult AboutUs()
        {
            return View();
        }
        public ActionResult ContactUs()
        {
            return View();
        }
        public ActionResult Services()
        {
            return View();
        }
        public ActionResult ServiceDetail(int id)
        {
            ViewBag.ServiceId = id;
            return View();
        }
        public ActionResult Projects()
        {
            return View();
        }
        public ActionResult ProjectDetail(int id)
        {
            ViewBag.ProjectId = id;
            return View();
        }
        public ActionResult Products()
        {
            return View();
        }
        public ActionResult ProductDetail(int id)
        {
            return View();
        }
        public ActionResult Blogs()
        {
            return View();
        }
        public ActionResult BlogDetail(int id)
        {
            ViewBag.BlogtId = id;
            return View();
        }
        #region mail gönderim
        Mail email = new Mail();
        [HttpGet]
        public ActionResult EMailSender()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EMailSender(string sendMailAdress, string subject, string body, string telefon, string fName, string lName, string select)
        {
            string deger = @"
<p>Sayın Chetah Media ekibi, '" + select + @"' ile ilgili talep bilgilerim aşağıda yer almaktadır. İyi çalışmalar.<br/> </p>
<p><strong>Talep Türü:</strong> " + select + @"</p>
<p><strong>Ad:</strong> " + fName + @"</p>
<p><strong>Soyad:</strong> " + lName + @"</p>
<p><strong>Email:</strong> " + sendMailAdress + @"</p>
<p><strong>Telefon:</strong> " + telefon + @"</p>
<p><strong>Konu:</strong> " + subject + @"</p>
<p><strong>Mesaj:</strong> " + body + @"</p>";

            email.MailSender(sendMailAdress, select, deger + body, subject);
            ViewBag.Kontrol = "Mail başarı ile gönderilmiştir";
            return Json(true);
        }
        #endregion

    }
    public class Mail
    {
        public class Contact
        {
            public string fName { get; set; }
            public string lName { get; set; }
            public string Email { get; set; }
            public string Subject { get; set; }
            public string Message { get; set; }
        }

        public void MailSender(string sendMailAdress, string subject, string comment, string baslik)
        {
            SmtpClient client = new SmtpClient();
            MailAddress from = new MailAddress(sendMailAdress, baslik); //göndericimail
            MailAddress to = new MailAddress("alicimail@gmail.com"); //alıcımail
            MailMessage msg = new MailMessage(from, to);

            msg.IsBodyHtml = true;
            msg.Subject = subject;
            msg.Body = comment;
            msg.To.Add("gondericimail@gmail.com");
            NetworkCredential info = new NetworkCredential("alicimail@gmail.com", "cete ntju kdvu ybtn");
            //NetworkCredential info = new NetworkCredential("cagliyantugba@gmail.com", "bwfg iyrk kdup wozg"); //tuenwebdemo şifre
            client.Port = 587;
            //client.Host = "mail.premiumkapak.com";
            client.Host = "smtp.gmail.com";

            client.EnableSsl = true;
            client.Credentials = info;
            client.Send(msg);



        }
    }
}