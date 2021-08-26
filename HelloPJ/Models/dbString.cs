using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloPJ.Models
{
    public static class dbString
    {
        private static string connectionString = "Data Source = (localdb)\\MSSQLLocalDB;Initial Catalog =  HelloPJ_db ; Persist Security Info=True;User ID = nancywu; Password=123456; Trusted_Connection=True";
        //private static string connectionString = "Data Source=hellopjdbserver.database.windows.net;Initial Catalog=HelloPJ_db;User ID=hellopj;Password=Nyan_Nyan;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static string getConnet()
        {
            return connectionString;
        }

    }
}
