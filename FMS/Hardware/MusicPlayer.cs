using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WMPLib;

namespace FMS.Hardware
{
    public partial class MusicPlayer : Form
    {
        WindowsMediaPlayer mediaPlayer = new WindowsMediaPlayer();
        TagLib.File file;
        MemoryStream memoryStream = new MemoryStream();
        private const int APPCOMMAND_VOLUME_MUTE = 0x80000;
        private const int WM_APPCOMMAND = 0x319;

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg,
            IntPtr wParam, IntPtr lParam);

        private void Mute()
        {
            SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle,
                (IntPtr)APPCOMMAND_VOLUME_MUTE);
        }

        public MusicPlayer()
        {
            InitializeComponent();
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            if (pause.Checked)
            {

                mediaPlayer.controls.play();
            }
            else
            {
                mediaPlayer.controls.pause();

            }

        }

        private void openMusic_Click(object sender, EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                mediaPlayer.currentPlaylist.clear();
               
                mediaPlayer.newPlaylist("Mixed", "");
                foreach (string fn in openFile.FileNames)
                {
                    mediaPlayer.currentPlaylist.appendItem(mediaPlayer.newMedia(fn));
                }
                mediaPlayer.controls.play();
                pause.Checked = true;
                file = TagLib.File.Create(openFile.FileName);
                var firstImg = file.Tag.Pictures.FirstOrDefault();
                if (firstImg != null)
                {
                    byte[] pData = firstImg.Data.Data;
                    memoryStream.Write(pData, 0, Convert.ToInt32(pData.Length));
                    var bm = new Bitmap(memoryStream, false);
                    if(bm != null)
                    {
                        coverImagesMusic.Image = null;
                        coverImagesMusic.Image = bm;

                    }
                    else
                    {
                        coverImagesMusic.Image = null;

                    }
                }


            }
        }

        private void nextMusic_Click(object sender, EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            mediaPlayer.controls.next();
        }

        private void PreviousMusic_Click(object sender, EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            mediaPlayer.controls.previous();

        }

     
     

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Mute();
        }

        private void MusicPlayer_FormClosing(object sender, FormClosingEventArgs e)
        {
            mediaPlayer.currentPlaylist.clear();

        }

    }
}
