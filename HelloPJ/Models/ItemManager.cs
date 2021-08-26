using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HelloPJ.Models
{
    public class ItemManager
    {
        private static readonly string connStr = dbString.getConnet();
        public List<Item> StoreShowItem(string type)
        {
            List<Item> item_list = new List<Item>();

            SqlConnection sqlConnection = new SqlConnection(connStr);
            SqlCommand sqlCommand = new SqlCommand(@"Select * From item_list Where item_type='"+type+"'");
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Item item = new Item
                    {
                        item_id = reader.GetInt32(reader.GetOrdinal("item_id")),
                        item_name = reader.GetString(reader.GetOrdinal("item_name")),
                        item_price = reader.GetInt32(reader.GetOrdinal("item_price")),
                        item_pic = reader.GetString(reader.GetOrdinal("item_pic")),
                        item_type = reader.GetString(reader.GetOrdinal("item_type")),
                    };
                    item_list.Add(item);
                }
            }
            sqlConnection.Close();
            return item_list;
        }
        public int StoreBuyItem(string user_id,string item_id,int num)
        {
            int price = 0;
            string item_type = "";
            int return_num = 0;
            SqlConnection sqlConnection = new SqlConnection(connStr);
            SqlCommand sqlCommand = new SqlCommand(@"Select * From item_list Where item_id=" + item_id);
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            
            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                price = reader.GetInt32(reader.GetOrdinal("item_price"));
                item_type = reader.GetString(reader.GetOrdinal("item_type"));
            }
            reader.Close();

            sqlCommand.CommandText = @"Update account_info Set spend_money = spend_money+" + price * num + " Where user_id=" + user_id;
            sqlCommand.ExecuteNonQuery();

            if (item_id == "102")
                num *= 50;

            switch (item_type)
            {
                case "food":
                    sqlCommand.CommandText = @"Select * From user_item Where user_id=" + user_id + " And item_id=" + item_id;
                    reader = sqlCommand.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Close();
                        sqlCommand.CommandText = @"Update user_item Set item_quantity = item_quantity+" + num + " Where user_id=" + user_id + " And item_id=" + item_id;
                        sqlCommand.ExecuteNonQuery();
                    }
                    else
                    {
                        reader.Close();
                        sqlCommand.CommandText = @"Insert Into user_item(user_id,item_id,item_quantity) Values('" + user_id + "','" + item_id + "'," + num + ")";
                        sqlCommand.ExecuteNonQuery();
                    }
                    return_num = 1;
                    break;
                case "toy":
                    sqlCommand.CommandText = @"Select * From user_item Where user_id=" + user_id + " And item_id=" + item_id;
                    reader = sqlCommand.ExecuteReader();
                    if (reader.HasRows)
                    {
                        return_num = 86;
                    }
                    else
                    {
                        reader.Close();
                        sqlCommand.CommandText = @"Insert Into user_item(user_id,item_id,item_quantity) Values('" + user_id + "','" + item_id + "'," + num + ")";
                        sqlCommand.ExecuteNonQuery();
                        return_num = 2;
                    }
                    break;
                case "furniture":
                    sqlCommand.CommandText = @"Insert Into user_item(user_id,item_id,item_quantity,item_used,position_top,position_left) Values('" + user_id + "','" + item_id + "'," + num + ",'f',160,375)";
                    sqlCommand.ExecuteNonQuery();
                    return_num = 3;
                    break;
            }
            sqlConnection.Close();
            return return_num;
        }

        public bool PetCheck(string user_id)
        {
            SqlConnection sqlConnection = new SqlConnection(connStr);
            SqlCommand sqlCommand = new SqlCommand(@"Select * From pet_info Where user_id = "+user_id);
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                sqlConnection.Close();
                return true;
            }
            else
            {
                sqlConnection.Close();
                return false;
            }
        }

        public int StoreGetPet(string user_id, string pet_name,int pet_type)
        {
            int pet_id = 0;
            SqlConnection sqlConnection = new SqlConnection(connStr);
            SqlCommand sqlCommand = new SqlCommand(@"Insert Into pet_info(user_id,pet_name,pet_type,pet_now,pet_now_num,pet_raising,position_top,position_left) Values('" + user_id + "',N'" + pet_name + "'," + pet_type + ",'stand',1,'t',160,375)");
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();

            sqlCommand.CommandText = @"Select Top 1 * From pet_info Where user_id = "+user_id+" Order by pet_id desc";
            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                pet_id = reader.GetInt32(reader.GetOrdinal("pet_id"));
            }
            sqlConnection.Close();
            return pet_id;
        }
        public List<Item> UserItemGet(string user_id,string type)
        {
            List<Item> item_list = new List<Item>();

            SqlConnection sqlConnection = new SqlConnection(connStr);
            SqlCommand sqlCommand = new SqlCommand(@"Select * From item_list Inner Join user_item On item_list.item_id = user_item.item_id Where user_item.user_id=" + user_id + " And user_item.item_quantity>0 And item_type='" + type + "'");
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Item item = new Item
                    {
                        id = reader.GetInt32(reader.GetOrdinal("id")),
                        item_id = reader.GetInt32(reader.GetOrdinal("item_id")),
                        item_name = reader.GetString(reader.GetOrdinal("item_name")),
                        item_quantity = reader.GetInt32(reader.GetOrdinal("item_quantity")),
                        item_pic = reader.GetString(reader.GetOrdinal("item_pic")),
                        item_type = reader.GetString(reader.GetOrdinal("item_type")),
                    };
                    if(type == "furniture")
                    {
                        item.item_used = reader.GetString(reader.GetOrdinal("item_used"));
                        item.position_top = reader.GetInt32(reader.GetOrdinal("position_top")) + "px";
                        item.position_left = reader.GetInt32(reader.GetOrdinal("position_left"))+ "px";
                    }
                    item_list.Add(item);
                }
            }
            sqlConnection.Close();
            return item_list;
        }
        public void UserItemUse(string user_id, string item_id)
        {
            SqlConnection sqlConnection = new SqlConnection(connStr);
            SqlCommand sqlCommand = new SqlCommand(@"Update user_item Set item_quantity = item_quantity-1 Where user_id=" + Convert.ToInt32(user_id) + " And id=" + Convert.ToInt32(item_id));
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public void Set_Furniture(string user_id, int item_id)
        {
            string used = "";
            SqlConnection sqlConnection = new SqlConnection(connStr);
            SqlCommand sqlCommand = new SqlCommand(@"Select * From user_item Where id = "+item_id);
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                used = reader["item_used"].ToString();
            }
            reader.Close();
            if (used == "f")
            {
                sqlCommand.CommandText = @"Update user_item Set item_used = 't' Where user_id=" + Convert.ToInt32(user_id) + " And id=" + item_id;
                sqlCommand.ExecuteNonQuery();
            }
            else
            {
                sqlCommand.CommandText = @"Update user_item Set item_used = 'f' Where user_id=" + Convert.ToInt32(user_id) + " And id=" + item_id;
                sqlCommand.ExecuteNonQuery();
            }
            sqlConnection.Close();
        }
        public void Set_Furniture(string id, string position_top, string position_left)
        {
            bool move = true;
            int top = Convert.ToInt32(position_top.Remove(position_top.Length - 2));
            int left = Convert.ToInt32(position_left.Remove(position_left.Length - 2));
            if (top / 3 + left / 2 < 75)
                move = false;
            if (top > 265 || top < -5)
                move = false;
            if (left > 680 || left < 0)
                move = false;
            if (top > 225 && left < 0)
                move = false;
            if (move)
            {
                SqlConnection sqlConnection = new SqlConnection(connStr);
                SqlCommand sqlCommand = new SqlCommand(@"Update user_item Set position_top = " + top + " , position_left = " + left + " Where id = " + id);
                sqlCommand.Connection = sqlConnection;
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }
    }
}
