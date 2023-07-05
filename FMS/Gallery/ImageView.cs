using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
namespace FMS.Gallery
{
    public partial class ImageView : Form
    {
        private List<Image> LoadedImages { get; set; }
        string ImageKey = "";
        List<KeyValuePair<string, Image>> LoadedImagesWithValues = new List<KeyValuePair<string, Image>>();
        public ImageView()
        {
            InitializeComponent();
            LoadedImages = new List<Image>();
        }
        private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            string ProcessName = (string)e.Argument;

            if (ProcessName == "uploadImages")
            {
                for (int i = 0; i < LoadedImages.Count; i++)
                {
                    try
                    {
                        SqlConnection connection = new SqlConnection(new SQLSERVER_Queries.CloudConnection().StartConnection);
                        connection.Open();
                        MemoryStream ms = new MemoryStream();
                        LoadedImages[i].Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        byte[] img = ms.GetBuffer();
                        SqlCommand cmd = new SqlCommand("insert into Gallery(imageContainer) values(@img)", connection);
                        cmd.Parameters.AddWithValue("@img", img);
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        int precentage = (i + 1) * 100 / LoadedImages.Count;
                        backgroundWorker.ReportProgress(precentage);
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }

            }
            else if (ProcessName == "DownLoadImages")
            {
                DownloadImageDb();
            }
            else if (ProcessName == "deleteImageDb")
            {
                DeleteImageBd();
            }
        }
        public void DownloadImageDb()
        {
            try
            {
                SqlConnection connection = new SqlConnection(new SQLSERVER_Queries.CloudConnection().StartConnection);
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT pic_index,imageContainer from Gallery", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int i = 0;
                    MemoryStream ms = new MemoryStream((byte[])reader["imageContainer"]);
                    Bitmap bitmap = new Bitmap(ms);
                    LoadedImages.Add(bitmap);
                    LoadedImagesWithValues.Add(new KeyValuePair<string, Image>(reader["pic_index"].ToString(), bitmap));
                    i++;
                }
                connection.Close();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void backgroundWorker_RunWorkerCompleted(object senders, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {

            if (LoadedImages.Count > 0)
            {
                Thread thread = new Thread(LoadImageForm);
                thread.Start();
            }


            Upload.Enabled = true;
            UploadServer.Enabled = true;
            panelLoader.Visible = false;
        }

        private void LoadImageForm()
        {
            // intializing image list
            ImageList images = new ImageList();
            images.ImageSize = new Size(130, 130);

            foreach (var img in LoadedImages)
            {
                images.Images.Add(img);
            }

            // Setting our List View With ImageList
            imageList.LargeImageList = images;

            for (int i = 0; i < LoadedImages.Count; i++)
            {
                imageList.Items.Add(new ListViewItem($"{i}", i));
                imageCounter.Text = $"{i + 1} Photos";
            }

        }
        private void LoadImageFromFolader()
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (LoadedImages.Count > 0)
                {
                    LoadedImages.Clear();
                    imageList.LargeImageList.Images.Clear();
                    imageList.Items.Clear();
                }

                foreach (var ImgLocations in openFileDialog.FileNames)
                {
                    var FolderImage = Image.FromFile(ImgLocations);
                    LoadedImages.Add(FolderImage);
                }
            }
        }

        private void imageList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (imageList.SelectedIndices.Count > 0)
            {
                int SelectImage = imageList.SelectedIndices[0];
                SelectedImage.Image = LoadedImages[SelectImage];
                var getKey = LoadedImagesWithValues.Find(a => a.Value == LoadedImages[SelectImage]); // get key of image
                ImageKey = getKey.Key;
            }
        }


        private void Upload_Click(object sender, EventArgs e)
        {
            LoadImageFromFolader();
            if (LoadedImages.Count > 0)
            {
                Thread thread = new Thread(LoadImageForm);
                thread.Start();
            }


        }

        private void imageList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (!string.IsNullOrEmpty(ImageKey))
                {
                    if (MessageBox.Show($" ({imageList.SelectedIndices[0]})  تأكيد حذف الصورة ", "تحذير", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        if (!backgroundWorker.IsBusy)
                        {
                            backgroundWorker.RunWorkerAsync("deleteImageDb");
                        }
                    }
                }
            }
        }
        public void DeleteImageBd()
        {
            SqlConnection connection = new SqlConnection(new SQLSERVER_Queries.CloudConnection().StartConnection);
            connection.Open();
            SqlCommand cmd = new SqlCommand("delete from Gallery where pic_index = @index", connection);
            cmd.Parameters.AddWithValue("@index", ImageKey);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        private void UploadServer_Click(object sender, EventArgs e)
        {
            if (imageList.Items.Count < 1)
            {
                MessageBox.Show("برجاء رفع صور من الجهاز اولا", "حطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!backgroundWorker.IsBusy)
            {
                UploadServer.Enabled = false;
                Upload.Enabled = false;
                panelLoader.Visible = true;
                ProgressIndicator.Visible = false;
                CircleProgressBar.Visible = true;
                txt_loader.Text = ".......  جاري الرفع";
                CircleProgressBar.Percentage = 0;
                backgroundWorker.RunWorkerAsync("uploadImages");
            }
        }


        private void backgroundWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            CircleProgressBar.Percentage = e.ProgressPercentage;
        }

        private void CloseWorker_Click(object sender, EventArgs e)
        {
            panelLoader.Visible = false;
            Upload.Visible = true;
            UploadServer.Visible = true;
            backgroundWorker.CancelAsync();
        }

        private void downlodServer_Click(object sender, EventArgs e)
        {
            if (LoadedImages.Count > 0)
            {
                LoadedImages.Clear();
                imageList.LargeImageList.Images.Clear();
                imageList.Items.Clear();
            }
            if (!backgroundWorker.IsBusy)
            {
                panelLoader.Visible = true;
                ProgressIndicator.Visible = true;
                CircleProgressBar.Visible = false;
                txt_loader.Text = ".......  جاري التنزيل";
                backgroundWorker.RunWorkerAsync("DownLoadImages");

            }
        }
    }
}
