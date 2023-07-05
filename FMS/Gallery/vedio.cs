using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace FMS.Gallery
{
    class vedio
    {
        SQLSERVER_Queries.CloudConnection cloud = new SQLSERVER_Queries.CloudConnection();
        public void UploadVedio(SqlConnection connection, string PathVedio,Panel panelLoader)
        {
            FileStream stream = new FileStream(PathVedio, FileMode.Open, FileAccess.Read);
            byte[] bytes = new byte[stream.Length];
            int numBytesToRead = (int)stream.Length;
            int numBytesRead = 0;
            while (numBytesToRead > 0)
            {
                // Read may return anything from 0 to numBytesToRead. 
                int n = stream.Read(bytes, numBytesRead, numBytesToRead);

                // Break when the end of the file is reached. 
                if (n == 0)
                    break;

                numBytesRead += n;
                numBytesToRead -= n;
            }


            try
            {
                
                PathVedio = PathVedio.Substring(PathVedio.LastIndexOf("\\"));
                PathVedio = PathVedio.Remove(0, 1);
                connection = new SqlConnection(cloud.StartConnection);
                connection.Open();
                SqlCommand cmd = new SqlCommand("insert into VediosGallery(vedio_name,vedioContainer) values(@nam,@ved)", connection);
                cmd.Parameters.AddWithValue("@nam", PathVedio);
                cmd.Parameters.Add("@ved", System.Data.SqlDbType.VarBinary).Value = bytes;
                cmd.ExecuteNonQuery();
                panelLoader.Visible = false;
                MessageBox.Show("تم رفع الفيديو", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (SqlException ex)
            {


                if (ex.Number == 2627)
                {
                    MessageBox.Show("يوجد فيديو بنفس الاسم برجاء اختيار فيديو اخري", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {

                    if (ex.Message.Contains("A network-related or instance-specific error occurred while establishing a connection to SQL Server. The server was not found or was not accessible. Verify that the instance name is correct and that SQL Server is configured to allow remote connections. (provider: TCP Provider, error: 0 - No such host is known.)"))
                    {

                        MessageBox.Show("خطأ في الأتصال بالخادم برجاء التحقق من اتصالك بالأنترنت", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }


            }
        }
        public void DeleteVedio(SqlConnection connection,string VedioName)
        {
            try
            {             
                connection = new SqlConnection(cloud.StartConnection);
                connection.Open();
                SqlCommand cmd = new SqlCommand("delete from VediosGallery where vedio_name =@nam  ", connection);
                cmd.Parameters.AddWithValue("@nam", VedioName);
                cmd.ExecuteNonQuery();
                MessageBox.Show("تم حذف الفيديو", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {


                if (ex.Message.Contains("A network-related or instance-specific error occurred while establishing a connection to SQL Server. The server was not found or was not accessible. Verify that the instance name is correct and that SQL Server is configured to allow remote connections. (provider: TCP Provider, error: 0 - No such host is known.)"))
                {

                    MessageBox.Show("خطأ في الأتصال بالخادم برجاء التحقق من اتصالك بالأنترنت", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
        }
    }
}
