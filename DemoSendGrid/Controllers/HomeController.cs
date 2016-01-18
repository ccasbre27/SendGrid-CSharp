using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using SendGrid;

namespace DemoSendGrid.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            sendEmail();
            return View();
        }

        private void sendEmail()
        {
            // Create the email object first, then add the properties.
            var myMessage = new SendGridMessage();

            // Add the message properties.
            myMessage.From = new MailAddress("myname@example.com");

            // Add multiple addresses to the To field.
            List<String> recipients = new List<String>
            {
                @"Bacon Ipsum <user@domain.com>",
                @"Lorem Ipsum <user@domain.com>"
            };

            myMessage.AddTo(recipients);

            myMessage.Subject = "Testing the SendGrid Library on Sir-Rover!";

            //Add the HTML and Text bodies
            myMessage.Html = "<p>Hello World from SendGrid!</p>";
            myMessage.Text = "Hello World!";


            // Create credentials, specifying your user name and password.
var credentials = new NetworkCredential("username", "password");

// Create an Web transport for sending email.
var transportWeb = new Web(credentials);

// Send the email, which returns an awaitable task.
transportWeb.DeliverAsync(myMessage);
        }

    }
}