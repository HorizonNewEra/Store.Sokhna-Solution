using Store.Sokhna.PL.Models;
using System.Net;
using System.Net.Mail;

namespace Store.Sokhna.PL.HelperClasses
{
	public static class EmailSettings
	{
		public static void SendEmailTo(EmailSend email)
		{
			var client = new SmtpClient("smtp.gmail.com", 587);
			client.EnableSsl=true;
			client.Credentials = new NetworkCredential("horizon.newera1@gmail.com", "wvkyfytxupohzxwi");
			client.Send("horizon.newera1@gmail.com", email.To, email.Title, email.Body);
		}
	} 
}
