namespace FMS.SQLSERVER_Queries
{

    class CloudConnection
    {        
        //string StrConn = "Server=mssql-17471-0.cloudclusters.net,17471;Initial Catalog=FMS;Persist Security Info=False;User ID=7ooda74;Password=Mahmoud@2021;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=true;Connection Timeout=20;";
       string StrConn = "Data Source=DESKTOP-6LU3BQE;Initial Catalog=FMS;Integrated Security=True";         
        public string StartConnection
        {
            get
            {
                return StrConn;
            }

              
        }
    }
}
