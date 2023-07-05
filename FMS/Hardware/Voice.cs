using System;
using System.IO;
using System.Media;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FMS.Hardware
{
    public partial class Voice : Form
    {
        public Voice()
        {
            InitializeComponent();
        }



        private void recording_Click(object sender, EventArgs e)
        {

            Record.Recording();
            recording.Enabled = false;
            playRecording.Enabled = false;
            stopRecording.Enabled = true;

        }

        private void stopRecording_Click(object sender, EventArgs e)
        {
            Record.StopRecord();
            recording.Enabled = true;
            playRecording.Enabled = true;
            stopRecording.Enabled = false;

        }

        private void playRecording_Click(object sender, EventArgs e)
        {
            if (!File.Exists(Record.RecordPath))
            {
                MessageBox.Show("الملف غير موجود", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SoundPlayer soundPlayer = new SoundPlayer(Record.RecordPath);
            soundPlayer.Play();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
