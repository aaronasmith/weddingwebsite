using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WeddingWebsite.Controllers
{
    public class RSVPController : Controller
    {
        public ActionResult RSVP(string name, bool yesOrNo)
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
                        setComing = new SqlCommand(@"Update RSVP set Coming = @coming where name = @name");
                    }
                    else
                    {
                        setComing = new SqlCommand(@"Insert into RSVP values(@name, @coming)");
                    }
                }

                setComing.Connection = connection;
                setComing.Parameters.Add(new SqlParameter("coming", yesOrNo));
                setComing.Parameters.Add(new SqlParameter("name", name));
                setComing.ExecuteNonQuery();

                setComing.Dispose();

                return View("Thankyou");
            }
        }
    }
}
