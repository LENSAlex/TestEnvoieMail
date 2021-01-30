using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;



//using mail
using System.Net;
using System.Net.Mail;

namespace TestEnvoieMail
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });


        public void mailSender()
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("soignantsniriotia@gmail.com", "testtest25."),
                EnableSsl = true,
            };

            smtpClient.Send("alex.lens2000@gmail.com", "recipient", "subject", "body");
        }


        public void CreateTestMessage2()
        {
            string to = "soignantsniriotia@gmail.com";
            string from = "alex.lens2000@gmail.com";
            MailMessage message = new MailMessage(from, to);
            message.Subject = "Using the new SMTP client.";
            message.Body = @"Using this new feature, you can send an email message from an application very easily.";
            SmtpClient client = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("soignantsniriotia@gmail.com", "testtest25."),
                EnableSsl = true,
            };
            // Credentials are necessary if the server requires the client
            // to authenticate before it will send email on the client's behalf.
            client.UseDefaultCredentials = true;

            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateTestMessage2(): {0}",
                    ex.ToString());
            }
        }

        public static void SendMail(string[] adresses, string subject, string message)
        {
            try
            {
                MailMessage mail = new MailMessage();
                //ajouter les destinataires
                foreach (string adress in adresses)
                {
                    mail.To.Add(adress);
                }

                mail.Subject = subject;
                mail.Body = message;
                //définir l'expéditeur
                mail.From = new MailAddress("no-replay@mon-site.fr", "Webmaster & News");
                //définir les paramètres smtp pour l'envoi
                SmtpClient smtpServer = new SmtpClient
                {
                    Host = "smtp.mon-site.fr",
                    Port = 587,
                    EnableSsl = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("moi@mon-site.fr", "mot-de-passe")
                };
                //envoi du mail
                smtpServer.Send(mail);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public void test3()
        {
            MailMessage msg = new MailMessage("soignantsniriotia@gmail.com", "alex.lens2000@gmail.com", "challah ca marche", "icnha");
            msg.IsBodyHtml = true;
            SmtpClient sc = new SmtpClient("smtp.gmail.com", 587);
            sc.UseDefaultCredentials = false;
            NetworkCredential cre = new NetworkCredential("soignantsniriotia@gmail.com", "testtest25.");//your mail password
            sc.Credentials = cre;
            sc.EnableSsl = true;
            sc.UseDefaultCredentials = true;
            sc.Send(msg);
            //MessageBox.Show("Mail Send");
        }

        public void test4()
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("soignantsniriotia@gmail.com");
                mail.To.Add("alex.lens2000@gmail.com");
                mail.Subject = "Hello World";
                mail.Body = "<h1>Hello</h1>";
                mail.IsBodyHtml = true;
                //mail.Attachments.Add(new Attachment("C:\\file.zip"));

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("soignantsniriotia@gmail.com", "testtest25.");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }
    }
}
