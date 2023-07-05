using System;
using System.Media;
using System.Windows.Forms;

namespace FMS
{
    public partial class Splach : Form
    {
        System.IO.FileInfo FiletxtDate = new System.IO.FileInfo(Application.StartupPath + @"\$tn\&$FFRDGYYUDIHGFF3DDHHJH8JJHF.txt");

        public Splach()
        {
            InitializeComponent();
            string MusicPath = Application.StartupPath + @"\Media\Video Editor.wav";
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = MusicPath;
            player.Play();
            if (!FiletxtDate.Exists) // if file not found
            {
                FiletxtDate.Create();
            }
            if (!backgroundWorker.IsBusy)
                backgroundWorker.RunWorkerAsync();
        }


        private void Splach_Load(object sender, EventArgs e)
        {

        }

        private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            SetDate();
        }
        private void backgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.ToString(), "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                new MainMenu().Show();
                this.Hide();
                backgroundWorker.Dispose();
            }
        }
        private void SetDate()
        {
            Properties.Settings.Default.StartDate = ConnectionTimeOut.GetInternetDate();
            try
            {
                if (FiletxtDate.Exists)
                {
                    if (FiletxtDate.Length == 0)  // check if file of end date has date or not 
                    {
                        System.IO.File.WriteAllText(FiletxtDate.FullName, Properties.Settings.Default.StartDate.AddDays(30).ToString());
                        Properties.Settings.Default.EndDate = Properties.Settings.Default.StartDate.AddDays(30); // convert date from txt file into DateTime
                    }
                    Properties.Settings.Default.Save();
                }
            }
            catch (System.IO.IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


    }
}
