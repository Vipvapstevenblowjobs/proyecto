using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CurrentMailer
    {
        public static class Mails
        {
            public static DateTime today { get; set; }
            public static int CurrentMail { get; set; }
            public static int MailsSent { get; set; }
            public static int MailsSentTotal { get; set; }
            
        }
    }
}
