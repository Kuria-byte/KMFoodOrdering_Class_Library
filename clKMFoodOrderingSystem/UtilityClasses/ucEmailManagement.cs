using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace clKMFoodOrderingSystem.UtilityClasses
{
  public class ucEmailManagement
    {

        public static void SendEmailOnSignup(string pEmail, string EmailMsg)
        {

            MailMessage msg = new MailMessage();

            msg.From = new MailAddress(Global.gFromEmail);
            msg.To.Add(pEmail);
            msg.Subject = "Registration Verification : KMFoodOrderingSystem.com";


            string strBody = EmailMsg;

            //"Please click the link to successfully verify your email and continue with the registration  "
            //            + "https://" + Global.gWebDomain + "/StudentLogIn.aspx?stid=" + ucEDOperation.EncryptString(Global.gEDKey, Convert.ToString(pID));

            msg.Body = strBody;
            msg.IsBodyHtml = true;
            //msg.Priority = MailPriority.High;


            using (SmtpClient client = new SmtpClient())
            {
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(Global.gFromEmail, Global.gFromEmailPassword);
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;

                client.Send(msg);
            }



        }


        public static void SendEmailToOnForgotPassword(string pEmail, string EmailMsg)
        {

            MailMessage msg = new MailMessage();

            msg.From = new MailAddress(Global.gFromEmail);
            msg.To.Add(pEmail);
            msg.Subject = "Chagne Password  : KMFoodOrderingSystem.com";

            string strBody = EmailMsg;
            msg.IsBodyHtml = true;
            msg.Body = strBody;
            //msg.Priority = MailPriority.High;


            using (SmtpClient client = new SmtpClient())
            {
                client.EnableSsl = true;
                client.UseDefaultCredentials = true;
                client.Credentials = new NetworkCredential(Global.gFromEmail, Global.gFromEmailPassword);
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;

                client.Send(msg);
            }



        }

    }
}
