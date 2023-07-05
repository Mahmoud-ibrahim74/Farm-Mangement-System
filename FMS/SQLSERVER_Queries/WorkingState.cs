using System.Data.SqlClient;

namespace FMS.SQLSERVER_Queries
{
    class WorkingState
    {
        SQLSERVER_Queries.CloudConnection cloud = new SQLSERVER_Queries.CloudConnection();
        public string GoodsState(Guna.UI2.WinForms.Guna2ComboBox product)
        {
            string getAmount = "0";
            try
            {

                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd = new SqlCommand("use fms\n " +
                    "select dbo.GoodsState(@pro); ", cn);
                cmd.Parameters.AddWithValue("@pro", product.SelectedItem.ToString());
                getAmount =  cmd.ExecuteScalar().ToString();
                cn.Close();
            }
            catch (SqlException )
            {
               
            }

            return getAmount;

        }

        public string AnimalState(Guna.UI2.WinForms.Guna2ComboBox animalName)
        {
            string getNumbers = "0";
            try
            {

                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd = new SqlCommand("use [FMS]\n " +
                    "select dbo.AnimalState(@pro); ", cn);
                cmd.Parameters.AddWithValue("@pro", animalName.SelectedItem.ToString());
                getNumbers = cmd.ExecuteScalar().ToString();
                cn.Close();
            }
            catch (SqlException )
            {

            }

            return getNumbers;

        }

        public string MedicineState(Guna.UI2.WinForms.Guna2ComboBox medcine, Guna.UI2.WinForms.Guna2ComboBox Anavar)
        {
            string getNumbers = "0";
            try
            {

                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd = new SqlCommand("use [FMS]\n " +
                    " select dbo.MedicineState(@med,@an); ", cn);
                cmd.Parameters.AddWithValue("@med", medcine.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@an", Anavar.SelectedItem.ToString());

                getNumbers = cmd.ExecuteScalar().ToString();
                cn.Close();
            }
            catch (SqlException)
            {

            }

            return getNumbers;

        }


    }
}
