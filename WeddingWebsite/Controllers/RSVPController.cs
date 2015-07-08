using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mail;
using System.Web.Mvc;

namespace WeddingWebsite.Controllers
{
    public class RSVPController : Controller
    {
        public ActionResult RSVP(string name, bool yesOrNo = false, bool plusOne = false)
        {
            using (var connection = new SqlConnection("Server=198.71.226.6;User Id=website;Password=Evbx496%;"))
            {
                connection.Open();

                SqlCommand setComing;
                using (var cmd = new SqlCommand(@"Select Count(1) from RSVP where name = @name", connection))
                {
                    cmd.Parameters.Add(new SqlParameter("name", name));
                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                    {
                        setComing = new SqlCommand(@"Update RSVP set Coming = @coming, PlusOne = @plusOne where name = @name");
                    }
                    else
                    {
                        setComing = new SqlCommand(@"Insert into RSVP values(@name, @coming, @plusOne)");
                    }
                }

                setComing.Connection = connection;
                setComing.Parameters.Add(new SqlParameter("coming", yesOrNo));
                setComing.Parameters.Add(new SqlParameter("name", name));
                setComing.Parameters.Add(new SqlParameter("plusOne", plusOne));
                setComing.ExecuteNonQuery();

                setComing.Dispose();

                if (yesOrNo)
                {
                    ViewBag.Result = "Yay! Get ready to party!";
                    if (plusOne)
                        ViewBag.Result = "Yay! You and your date better be ready to party!";
                }
                else
                {
                    ViewBag.Result = "Boo! We're sad you can't make it.";
                }

                const string SERVER = "relay-hosting.secureserver.net";
                MailMessage oMail = new System.Web.Mail.MailMessage();
                oMail.From = "wedding@thebooksmiths.com";
                oMail.To = "book2gs@gmail.com";
                oMail.Subject = string.Format("Response from {0}", name);
                if(yesOrNo){                    
                    oMail.Body = string.Format("{0} is coming!", name);
                        if(plusOne)
                            oMail.Body += string.Format("\r\nWith a guest!");
                }
                else{
                    oMail.Body = string.Format("{0} isn't coming.  :-(");
                }
                SmtpMail.SmtpServer = SERVER;
                SmtpMail.Send(oMail);
                oMail = null;	// free up resources

                return View("Thankyou");
            }
        }
    }
}
