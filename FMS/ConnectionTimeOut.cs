using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace FMS
{
    static internal class ConnectionTimeOut
    {
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int conn, int val);  //Connection State
        public static async void CheckConenction(Guna.UI2.WinForms.Guna2GradientPanel panel4, Guna.UI2.WinForms.Guna2GradientPanel panel2, Panel panel1, NotifyIcon connection, BackgroundWorker worker)
        {
            //while (true)
            //{
            //    await Task.Delay(1000);
            //    int Out;
            //    if (InternetGetConnectedState(out Out, 0) == true)
            //    {
            //        panel1.Enabled = true;
            //        panel4.Enabled = true;
            //        panel2.Enabled = true;

            //    }
            //    else
            //    {
            //        panel1.Enabled = false;
            //        panel4.Enabled = false;
            //        panel2.Enabled = false;

            //        connection.ShowBalloonTip(500, "Connection State",
            //            "Connection Failed Please Check Your Connection !!",
            //            ToolTipIcon.Error);
            //        connection.Dispose();
            //        worker.Dispose();

            //    }
            //}

        }
        public static async void CheckConenction(Guna.UI2.WinForms.Guna2GradientPanel panel2, Panel panel1, NotifyIcon connection, BackgroundWorker worker)
        {

            //while (true)
            //{
            //    await Task.Delay(1000);
            //    int Out;
            //    if (InternetGetConnectedState(out Out, 0) == true)
            //    {
            //        panel1.Enabled = true;
            //        panel2.Enabled = true;

            //    }
            //    else
            //    {
            //        panel1.Enabled = false;
            //        panel2.Enabled = false;

            //        connection.ShowBalloonTip(500, "Connection State",
            //                              "Connection Failed Please Check Your Connection ",
            //                              ToolTipIcon.Error);
            //        connection.Dispose();
            //        worker.Dispose();
            //    }
            //}

        }
        public static async void CheckConenction(Panel panel2, Panel panel1, NotifyIcon connection, BackgroundWorker worker)
        {
            //while (true)
            //{
            //    await Task.Delay(1000);
            //    int Out;
            //    if (InternetGetConnectedState(out Out, 0) == true)
            //    {
            //        panel1.Enabled = true;
            //        panel2.Enabled = true;

            //    }
            //    else
            //    {
            //        panel1.Enabled = false;
            //        panel2.Enabled = false;

            //        connection.ShowBalloonTip(500, "Connection State",
            //                              "Connection Failed Please Check Your Connection ",
            //                              ToolTipIcon.Error);
            //        connection.Dispose();
            //        worker.Dispose();
            //    }
            //}

        }

        public static async void MainMenuConnection(Panel panel1, Guna.UI2.WinForms.Guna2GradientPanel profile, MenuStrip menuStrip, BackgroundWorker worker, NotifyIcon connection)
        {
            while (true)
            {
                await Task.Delay(1000);
                int Out;
                if (InternetGetConnectedState(out Out, 0) == true)
                {
                    panel1.Enabled = true;
                    menuStrip.Enabled = true;
                    profile.Enabled = true;
                }
                else
                {
                    panel1.Enabled = false;
                    menuStrip.Enabled = false;
                    profile.Enabled = false;

                    connection.ShowBalloonTip(500, "حالــة الإتصال",
                                          "تم قطع الإتصال بالإنترنت",
                                          ToolTipIcon.Error);
                    connection.Dispose();
                    worker.Dispose();
                }
            }

        }

        public static DateTime GetInternetDate()
        {
            DateTime dateTime = DateTime.MinValue;
            int Out;
            if (InternetGetConnectedState(out Out, 0) == true)
            {
                System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create("http://www.microsoft.com");
                request.Method = "GET";
                request.Accept = "text/html, application/xhtml+xml, */*";
                request.UserAgent = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.1; Trident/6.0)";
                request.ContentType = "application/x-www-form-urlencoded";
                request.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.NoCacheNoStore);
                System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string todaysDates = response.Headers["date"];
                    dateTime = DateTime.ParseExact(todaysDates, "ddd, dd MMM yyyy HH:mm:ss 'GMT'",
                    System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat, System.Globalization.DateTimeStyles.AssumeUniversal);
                }

            }
            return dateTime;
        }

    }
}
