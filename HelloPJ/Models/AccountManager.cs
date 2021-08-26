using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HelloPJ.Models
{
    public class AccountManager
    {
        private static readonly string connStr = dbString.getConnet();
        public string newAccount(Account user)
        {
            SqlConnection sqlConnection = new SqlConnection(connStr);
            SqlCommand sqlCommand = new SqlCommand(@"Select * From account_info Where user_name='"+user.user_name+"'");
            sqlCommand.Connection = sqlConnection;
            
            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();
            System.Diagnostics.Debug.WriteLine(reader.HasRows.ToString());
            if (reader.HasRows)
            {
                System.Diagnostics.Debug.WriteLine("訊息：帳號重複");
                sqlConnection.Close();
                return "帳號重複!!";
            }
            else {
                reader.Close();
                try
                {
                    sqlCommand.CommandText = @"Insert Into account_info(user_name,user_passwd,account_name,spend_money) VALUES('"+user.user_name+"','"+user.user_passwd+"',N'"+user.account_name+"',0)";
                    sqlCommand.ExecuteNonQuery();
                }
                catch(Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("錯誤訊息：" + e.ToString());
                    sqlConnection.Close();
                    return "發生錯誤";
                }
            }
            sqlConnection.Close();
            return "帳號建立成功!!";
        }

        public string Login(Account user)
        {
            SqlConnection sqlConnection = new SqlConnection(connStr);
            SqlCommand sqlCommand = new SqlCommand(@"Select * From account_info Where user_name='"+ user.user_name + "' And user_passwd='"+ user.user_passwd + "'", sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                string user_id = reader["user_id"].ToString();
                sqlConnection.Close();
                //如果確認帳號密碼無誤，回傳使用者id
                return user_id;
            }
            sqlConnection.Close();
            return "0";
        }

        public string getName(int user_id)
        {
            string name = "";
            SqlConnection sqlConnection = new SqlConnection(connStr);
            SqlCommand sqlCommand = new SqlCommand(@"Select * From account_info Where user_id=" + user_id, sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                name = reader["account_name"].ToString();
            }
            sqlConnection.Close();
            return name;
        }

        public int getMoney(string user_id)
        {
            int money = 0;
            SqlConnection sqlConnection = new SqlConnection(connStr);
            SqlCommand sqlCommand = new SqlCommand(@"Select * From account_info Where user_id=" + user_id, sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                money = Convert.ToInt32(reader["spend_money"]);
            }
            sqlConnection.Close();
            return money;
        }

        public void add_login_info(string user_id)
        {
            string strHostName = System.Net.Dns.GetHostName();
            string clientIPAddress = System.Net.Dns.GetHostAddresses(strHostName).GetValue(0).ToString();
            string user = @strHostName + ":" + clientIPAddress;
            /*
            SqlConnection sqlConnection = new SqlConnection(connStr);
            SqlCommand sqlCommand = new SqlCommand(@"Insert Into login_info(HostName,HostAddress,user_id) Values(N'" + strHostName + "',N'" + clientIPAddress + "'," +user_id + ")", sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            */
            //System.Diagnostics.Debug.WriteLine("登入新增成功："+user);
            ServerManager.login_dict.Add(user, user_id);
        }

        public string get_login_info()
        {
            string user_id = "";
            string strHostName = System.Net.Dns.GetHostName();
            string clientIPAddress = System.Net.Dns.GetHostAddresses(strHostName).GetValue(0).ToString();
            /*
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connStr);
                SqlCommand sqlCommand = new SqlCommand(@"Select * From login_info Where HostName='" + strHostName + "' And HostAddress='" + clientIPAddress + "'", sqlConnection);
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    user_id = reader["user_id"].ToString();
                    reader.Close();
                    sqlCommand.CommandText = @"Update account_info Set last_login = getDate() where user_id =" + user_id;
                    sqlCommand.ExecuteNonQuery();
                }
                sqlConnection.Close();
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine("錯誤訊息：" + e.ToString());
            }
            */
            string user = @strHostName + ":" + clientIPAddress;
            if(ServerManager.login_dict.ContainsKey(user))
                user_id = ServerManager.login_dict[user];
            //System.Diagnostics.Debug.WriteLine("確認到使用者：" + user);
            return user_id;
        }

        public void delete_login_info()
        {
            string strHostName = System.Net.Dns.GetHostName();
            string clientIPAddress = System.Net.Dns.GetHostAddresses(strHostName).GetValue(0).ToString();
            /*
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connStr);
                SqlCommand sqlCommand = new SqlCommand(@"DELETE FROM login_info Where HostName = '"+strHostName+"' And HostAddress='"+clientIPAddress+"'", sqlConnection);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch
            {

            }*/
            string user = @strHostName + ":" + clientIPAddress;
            //System.Diagnostics.Debug.WriteLine("使用者登出：" + user);
            ServerManager.login_dict.Remove(user);
        }
    }
}
