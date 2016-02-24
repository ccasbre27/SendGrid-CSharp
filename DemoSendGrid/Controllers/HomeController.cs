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

        private async void sendEmail()
		{
			// Creamos el objeto de tipo Email
			SendGridMessage myMessage = new SendGridMessage();
		
			// Se agrega el remitente del email
			myMessage.From = new MailAddress("myname@example.com");
		
			// Se crea una lista con los destinarios
			List<String> recipients = new List<String>
			{
				@"Bacon Ipsum <user@domain.com>",
				@"Lorem Ipsum <user@domain.com>"
			};
			
			// se agregan los destinarios
			myMessage.AddTo(recipients);
			
			// se agrega el tema del email
			myMessage.Subject = "Testing the SendGrid Library on Sir-Rover!";
		
			// Se agrega el contenido del mensaje, cabe destacar que se puede hacer mediante texto o html
			myMessage.Html = "<p>Hello World from SendGrid!</p>";
			//myMessage.Text = "Hello World!";
		
		
			// Creamos las credenciales de nuestro servicio, enviamos :
			// 1 - el nombre de usuario que copiamos de azure
			// 2 - clave que ingresamos cuando se creo el servicio
			var credentials = new NetworkCredential("username", "password");
		
			// Creamos Web transport para enviar el email
			var transportWeb = new Web(credentials);
			
			// enviamos el email, nótese que es una tarea asíncrona por lo que utilizamos el await
			await transportWeb.DeliverAsync(myMessage);
		
		}
}
