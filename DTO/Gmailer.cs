using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Web.Hosting;

namespace DTO
{
    public class GMailer
    {
        public static string GmailUsername { get; set; } 
        public static string GmailPassword { get; set; } 
        public static string[] Gmails { get; set; } =  { "udi.jdb@gmail.com", "udi.jdbp@gmail.com", "areaUDI.cecyt9JDBP@gmail.com","unidad.de.informatica.Cecyt9@gmail.com","udi.cecyt9.cursosipn@gmail.com"};
        public static string[] GmailPasswords { get; set; } = { "ydmq yril jprr pstz", "cjji lhww kqrq nxcx", "lpsi quvt ozds deaz", "gdjz ujye nqiu izbq", "rsxf vknr lavu tukg" };
        //Password for vichtorr77 "ppeh eaig vtwi jwog"
        //Password for udi.jdb@gmail.com ydmq "yril jprr pstz"
        public static string GmailHost { get; set; }
        public static int GmailPort { get; set; }
        public static bool GmailSSL { get; set; }

        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsHtml { get; set; }

        static GMailer()
        {
            GmailHost = "smtp.gmail.com";
            GmailPort = 587; // Gmail can use ports 25, 465 & 587; but must be 25 for medium trust environment.
            GmailSSL = true;
        }

        public bool Send()
        {
            bool toomuchMails = false;
            try
            {
                SmtpClient smtp = new SmtpClient();
                smtp.Host = GmailHost;
                smtp.Port = GmailPort;
                smtp.EnableSsl = GmailSSL;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                if (CurrentMailer.Mails.MailsSentTotal == 0)
                {
                    if (!File.Exists(HostingEnvironment.MapPath("/Areas/Admin/Content/GmailStatus/Gmail.bin")))
                    {
                        FileStream fs = new FileStream(HostingEnvironment.MapPath("/Areas/Admin/Content/GmailStatus/Gmail.bin"), FileMode.OpenOrCreate);
                        BinaryWriter bw = new BinaryWriter(fs);

                        //Date Mails started being sent
                        bw.Write(DateTime.Now.Year);
                        bw.Write(DateTime.Now.Month);
                        bw.Write(DateTime.Now.Day);
                        bw.Write(DateTime.Now.Hour);
                        bw.Write(DateTime.Now.Minute);
                        bw.Write(DateTime.Now.Second);
                        //CurrentMail
                        bw.Write(0);
                        //MailsSent
                        bw.Write(0);
                        //MailsSentToday (Total)
                        bw.Write(0);

                        fs.Close();

                        CurrentMailer.Mails.today = DateTime.Now;
                        CurrentMailer.Mails.CurrentMail = 0;
                        CurrentMailer.Mails.MailsSent = 1;
                        CurrentMailer.Mails.MailsSentTotal = 1;
                    }
                    else
                    {
                        FileStream fs = new FileStream(HostingEnvironment.MapPath("/Areas/Admin/Content/GmailStatus/Gmail.bin"), FileMode.Open);

                        BinaryReader br = new BinaryReader(fs);
                        BinaryWriter bw = new BinaryWriter(fs);

                        CurrentMailer.Mails.today = new DateTime(br.ReadInt32(),br.ReadInt32(),br.ReadInt32(),br.ReadInt32(),br.ReadInt32(),br.ReadInt32());
                        CurrentMailer.Mails.CurrentMail = br.ReadInt32();
                        CurrentMailer.Mails.MailsSent = br.ReadInt32();
                        CurrentMailer.Mails.MailsSentTotal = br.ReadInt32();
                        if ((DateTime.Now - CurrentMailer.Mails.today).TotalHours>24)
                        {
                            //Date Mails started being sent
                            bw.Write(DateTime.Now.Year);
                            bw.Write(DateTime.Now.Month);
                            bw.Write(DateTime.Now.Day);
                            bw.Write(DateTime.Now.Hour);
                            bw.Write(DateTime.Now.Minute);
                            bw.Write(DateTime.Now.Second);
                            //CurrentMail
                            bw.Write(0);
                            //MailsSent
                            bw.Write(0);
                            //MailsSentToday (Total)
                            bw.Write(0);

                            fs.Close();

                            CurrentMailer.Mails.today = DateTime.Now;
                            CurrentMailer.Mails.CurrentMail = 0;
                            CurrentMailer.Mails.MailsSent = 1;
                            CurrentMailer.Mails.MailsSentTotal = 1;
                            
                        }
                        else
                        {
                            if (CurrentMailer.Mails.MailsSent >= 450)
                            {
                                if (CurrentMailer.Mails.CurrentMail < Gmails.Count()-1)
                                {
                                    CurrentMailer.Mails.CurrentMail++;
                                    CurrentMailer.Mails.MailsSent = 0;
                                }
                                else
                                {
                                    toomuchMails = true;
                                }
                            }
                            if (!toomuchMails)
                            {
                                CurrentMailer.Mails.MailsSentTotal++;
                                CurrentMailer.Mails.MailsSent++;
                                
                            }
                        }
                        br.Close();
                        fs.Close();
                    }

                }
                else
                {
                    if (CurrentMailer.Mails.MailsSent >= 450)
                    {
                        if (CurrentMailer.Mails.CurrentMail < Gmails.Count()-1)
                        {
                            CurrentMailer.Mails.CurrentMail++;
                            CurrentMailer.Mails.MailsSent = 0;
                        }
                        else
                        {
                            toomuchMails = true;
                        }
                    }
                    if (!toomuchMails)
                    {
                        CurrentMailer.Mails.MailsSentTotal++;
                        CurrentMailer.Mails.MailsSent++;
                        
                    } 
                }

                FileStream ffs = new FileStream(HostingEnvironment.MapPath("/Areas/Admin/Content/GmailStatus/Gmail.bin"), FileMode.OpenOrCreate);
                BinaryWriter bwf = new BinaryWriter(ffs);

                //Date Mails started being sent
                bwf.Write(CurrentMailer.Mails.today.Year);
                bwf.Write(CurrentMailer.Mails.today.Month);
                bwf.Write(CurrentMailer.Mails.today.Day);
                bwf.Write(CurrentMailer.Mails.today.Hour);
                bwf.Write(CurrentMailer.Mails.today.Minute);
                bwf.Write(CurrentMailer.Mails.today.Second);

                //CurrentMail
                bwf.Write(CurrentMailer.Mails.CurrentMail);
                //MailsSent
                bwf.Write(CurrentMailer.Mails.MailsSent);
                //MailsSentToday (Total)
                bwf.Write(CurrentMailer.Mails.MailsSentTotal);

                ffs.Close();
                bwf.Close();

                Debug.WriteLine(CurrentMailer.Mails.MailsSentTotal + " " + CurrentMailer.Mails.MailsSent + " " + CurrentMailer.Mails.CurrentMail);

                if (!toomuchMails)
                {
                    GmailUsername = Gmails[CurrentMailer.Mails.CurrentMail];
                    GmailPassword = GmailPasswords[CurrentMailer.Mails.CurrentMail];

                    smtp.Credentials = new NetworkCredential(GmailUsername, GmailPassword);

                    using (var message = new MailMessage(GmailUsername, ToEmail))
                    {
                        message.Subject = Subject;
                        message.Body = Body;
                        message.IsBodyHtml = IsHtml;
                        smtp.Send(message);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return toomuchMails;
        }
    }
}
