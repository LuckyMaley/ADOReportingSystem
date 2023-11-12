using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using Outlook = Microsoft.Office.Interop.Outlook;
using XLookupReportSystem.Models;
using System.Web;

namespace XLookupReportSystem.Controllers
{
    public class EmailController
    {
        public static bool EmailSendForgot(string user, string subjectPart, string bodyPart)
        {
            try
            {
                XLookupReportingDB db = new Models.XLookupReportingDB();
                // Create Outlook application
                Outlook.Application outlookApp = new Outlook.Application();

                // Create a new mail item
                Outlook.MailItem mailItem = outlookApp.CreateItem(Outlook.OlItemType.olMailItem) as Outlook.MailItem;

                // Set the properties of the mail item
                mailItem.Subject = subjectPart;
                mailItem.Body = bodyPart;
                Outlook.Recipients recipients = mailItem.Recipients;
                Outlook.Recipient recipient = recipients.Add(user);
                recipient.Resolve();
                //mailItem.To = user;

                // Send the email
                mailItem.Send();

                // Optional: Display a success message
               // return "Email sent successfully!";
               return true;
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                //return "Error sending email: " + ex.Message;
                return false;
            }
        }
    }
}