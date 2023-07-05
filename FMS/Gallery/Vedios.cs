using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
namespace FMS.Gallery
{
    public partial class Vedios : Form
    {
        string MediaFolderPath = Directory.GetCurrentDirectory() + @"\Media";
        string VedioURL = "";
        string BackGroundName = "";
        List<string> VediosDbName = new List<string>(); 
        SqlConnection connection;
        SQLSERVER_Queries.CloudConnection cloud = new SQLSERVER_Queries.CloudConnection();
        DataSet ds = new DataSet();
        public Vedios()
        {
            InitializeComponent();
            
        }


        private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            string ProcessName = (string)e.Argument;
            vedio ved = new vedio();
            if(ProcessName == "DownloadVedios")
            {
                ds.Clear();
                WindowsMediaPlayer.currentPlaylist.clear();
                string[] getFileNames = Directory.GetFiles(MediaFolderPath);

                for (int i = 0; i < getFileNames.Length; i++)
                {
                    if(!getFileNames[i].Contains("Video Editor.wav"))
                    {
                        File.Delete(getFileNames[i]);
                    }
                }
                try
                {
                    connection = new SqlConnection(cloud.StartConnection);
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("select vedio_name,vedioContainer from VediosGallery", connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    BackGroundName = "LoadVedios";

                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else if(ProcessName == "vedioUpload")
            {
                ved.UploadVedio(connection, VedioURL, panelLoader);
                VedioURL = null;
            }


        }


        private void backgroundWorker_RunWorkerCompleted(object senders, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (BackGroundName == "LoadVedios")
            {            
                if (ds.Tables.Count == 1) // if table is exist
                {
                    if (ds.Tables[0].Rows.Count > 0) // if rows is exist
                    {
                        WindowsMediaPlayer.newPlaylist("Farm_Vedios", MediaFolderPath);
                        int count = 0;
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            string VedioNameFormat = MediaFolderPath + @"\vedio_" + (i + 1).ToString() + ".mp4";
                            count = i+1;
                            byte[] getVedio = (byte[])ds.Tables[0].Rows[i]["vedioContainer"];
                            VediosDbName.Add((string)ds.Tables[0].Rows[i]["vedio_name"]);
                            File.WriteAllBytes(VedioNameFormat, getVedio);
                            WindowsMediaPlayer.currentPlaylist.appendItem(WindowsMediaPlayer.newMedia(VedioNameFormat));                         
                        }
                        vedioCounter.Text = count.ToString() + " Vedios";
                    }
                    connection.Close();
                    panelLoader.Visible = false;
                }
            }
        }

        private void cheque_display_Click(object sender, EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            if (!backgroundWorker.IsBusy)
            {
                panelLoader.Visible = true;
                backgroundWorker.RunWorkerAsync("DownloadVedios");
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            if (string.IsNullOrEmpty(VedioURL))
            {
                MessageBox.Show("برجاء سحب الفيديو اولا", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (!backgroundWorker.IsBusy)
                {
                    panelLoader.Visible = true;
                    backgroundWorker.RunWorkerAsync("vedioUpload");
                }
            }

        }


        private void guna2Button2_Click(object sender, EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            if (VediosDbName.Count < 1)
            {
                MessageBox.Show("برجاء تنزيل الفيدوهات اولا", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(Convert.ToInt32(NumericUpDown.Value) > VediosDbName.Count)
            {
                MessageBox.Show("برجاء ادخال رقم فيديو اقل من عدد الفيديوهات المتاح", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                if (MessageBox.Show(NumericUpDown.Value.ToString() + " هل تريد حذف الفيديو رقم ", "تحذير", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    Gallery.vedio vedio = new vedio();
                    vedio.DeleteVedio(connection, VediosDbName[Convert.ToInt32(NumericUpDown.Value) - 1]);
                }
            }
        }



        private void Vedios_DragDrop(object sender, DragEventArgs e)
        {

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                WindowsMediaPlayer.URL = file;
                VedioURL = file;
            }
        }

        private void Vedios_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void Vedios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F1)
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
            }
            else if (e.KeyData == Keys.F2)
            {
                this.FormBorderStyle = FormBorderStyle.Fixed3D;
                this.WindowState = FormWindowState.Normal;

            }
        }
    }
}
