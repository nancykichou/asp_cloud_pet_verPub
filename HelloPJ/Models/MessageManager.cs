using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HelloPJ.Models
{
    public class MessageManager
    {
        private static readonly string connStr = dbString.getConnet();
        public void newMessage(Message mes,string place)
        {
            SqlConnection sqlConnection = new SqlConnection(connStr);
            SqlCommand sqlCommand = new SqlCommand(@"INSERT INTO message_"+place+"(user_id,account_name,message) " +
                                                    "VALUES("+mes.user_id+",N'"+mes.account_name+"',N'"+mes.message+"')");
            sqlCommand.Connection = sqlConnection;

            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public List<Message> getMessage(string place,int message_show)
        {
            List<Message> message_list = new List<Message>();

            SqlConnection sqlConnection = new SqlConnection(connStr);
            //SqlCommand sqlCommand = new SqlCommand(@"Select Top "+message_show+" * From message_"+place+" Order By message_id");
            SqlCommand sqlCommand = new SqlCommand(@"Select * From message_" + place + " Order By message_id");
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Message message = new Message
                    {
                        message_id = reader.GetInt32(reader.GetOrdinal("message_id")),
                        user_id = reader.GetInt32(reader.GetOrdinal("user_id")),
                        account_name = reader.GetString(reader.GetOrdinal("account_name")),
                        message = reader.GetString(reader.GetOrdinal("message")),
                    };
                    message_list.Add(message);
                }
            }
            sqlConnection.Close();
            return message_list;
        }
    }
}
