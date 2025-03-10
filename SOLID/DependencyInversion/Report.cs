using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversion
{
    public class Report
    {
        //public MailSender MailSender { get; set; }

        private ISender sender;

        public Report(ISender sender)
        {
            this.sender = sender;
        }

        public void SendReport()
        {
            //MailSender mailSender = new MailSender();
            sender.Send();
        }
    }

    public interface ISender
    {
        void Send();
    }
    public class MailSender: ISender 
    {
        public void Send()
        {
            Console.WriteLine("Mail Gönderildi");
        }
    }

    public class WhatsAppSender : ISender
    {
        public void Send()
        {
            Console.WriteLine("WhatsApp Gönderildi");
        }
    }   


    public class TelegramSender : ISender
    {
        public void Send()
        {
            Console.WriteLine("Telegram Gönderildi");
        }
    }

}
