using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;

namespace HelloPJ.Models
{
    public enum type_change
    {
        cat = 1,
    }

    public static class ServerManager
    {
        private static bool _server_status = false;
        public static bool server_status
        {
            get
            {
                return _server_status;
            }
            set
            {
                _server_status = value;
            }
        }
        private static readonly string connStr = dbString.getConnet();
        private static Random rand = new Random();
        private static Dictionary<string, Pet> _pet_dict = new Dictionary<string, Pet>();
        public static Dictionary<string, Pet> pet_dict
        {
            get
            {
                return _pet_dict;
            }
        }
        private static Dictionary<string, string> _login_dict = new Dictionary<string, string>();
        public static Dictionary<string,string> login_dict
        {
            get
            {
                return _login_dict;
            }
        }


        public static void Start_Pet()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connStr);
                SqlCommand sqlCommand = new SqlCommand(@"Select * From pet_info Where pet_raising = 't'");
                sqlCommand.Connection = sqlConnection;
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string pet_id = Convert.ToInt32(reader["pet_id"]).ToString();
                        Pet pp = Get_Pet_Status(pet_id);
                        _pet_dict.Add(pet_id, pp);
                        Thread newThread = new Thread(ServerManager.Home_Pet);
                        newThread.Start(pet_id);
                    }
                }
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("錯誤訊息：" + e.ToString());
            }
        }

        public static Pet Get_Pet_Status(string pet_id)
        {
            Pet pet = new Pet();
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connStr);
                SqlCommand sqlCommand = new SqlCommand(@"Select * From pet_info Where pet_id = " + Convert.ToInt32(pet_id));
                sqlCommand.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                reader.Read();
                pet.pet_id = reader.GetInt32(reader.GetOrdinal("pet_id"));
                pet.pet_name = reader.GetString(reader.GetOrdinal("pet_name"));
                pet.pet_type = ((type_change)reader.GetInt32(reader.GetOrdinal("pet_type"))).ToString();
                pet.pet_now = reader.GetString(reader.GetOrdinal("pet_now"));
                pet.pet_now_num = reader.GetInt32(reader.GetOrdinal("pet_now_num"));
                pet.position_top = reader.GetInt32(reader.GetOrdinal("position_top")) + "px";
                pet.position_left = reader.GetInt32(reader.GetOrdinal("position_left")) + "px";
                sqlConnection.Close();
            }
            catch
            {

            }
            return pet;
        }

        public static void New_Pet(object pet_id)
        {
            Pet pp = Get_Pet_Status(pet_id.ToString());
            _pet_dict.Add(pet_id.ToString(), pp);
            Thread newThread = new Thread(ServerManager.Home_Pet);
            newThread.Start(pet_id);
        }

        public static void Home_Pet(object pet_id)
        {
            /*while (true)
            {
                try
                {
                    SqlConnection sqlConnection = new SqlConnection(connStr);
                    SqlCommand sqlCommand = new SqlCommand(@"Select * From pet_info Where pet_id = " + Convert.ToInt32(pet_id));
                    sqlCommand.Connection = sqlConnection;
                    sqlConnection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        string now = reader.GetString(reader.GetOrdinal("pet_now"));
                        reader.Close();
                        if (now == "stand")
                        {
                            break;
                        }
                    }
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("錯誤訊息：" + e.ToString());
                }
                Thread.Sleep(120 * 1000);
            }*/
            pet_dict[pet_id.ToString()].pet_now = "stand";
            pet_dict[pet_id.ToString()].pet_now_num = 1;
            Thread.Sleep(rand.Next(3000, 5000));
            switch (2/*rand.Next(1, 4)*/)
            {
                case 1:
                    Home_Pet(pet_id);
                    break;
                case 2:
                    Pet_Walk(pet_id);
                    break;
                case 3:
                    Pet_Sleep(pet_id);
                    break;
            }
        }

        public static void Pet_Walk(object pet_id)
        {
            int top = Convert.ToInt32(pet_dict[pet_id.ToString()].position_top.Remove(pet_dict[pet_id.ToString()].position_top.Length - 2));
            int left = Convert.ToInt32(pet_dict[pet_id.ToString()].position_left.Remove(pet_dict[pet_id.ToString()].position_left.Length - 2));
            int walk;
            int x;
            int y;
            int walk_t;
            int walk_l;
            bool move;
            do
            {
                move = true;
                walk = rand.Next(5, 16);
                x = rand.Next(-10, 11);
                y = rand.Next(-5, 6);

                walk_t = top + y * walk;
                walk_l = left + x * walk;

                if (walk_t / 3 + walk_l / 2 < 99)
                    move = false;
                if (walk_t > 320 || walk_t < 35)
                    move = false;
                if (walk_l > 755 || walk_l < 0)
                    move = false;
            } while (!move);
            string horizontal;
            if (x > 0)
            {
                horizontal = "walkr";
            }
            else
            {
                horizontal = "walkl";
            }
            pet_dict[pet_id.ToString()].pet_now = horizontal;
            for (int i = 0; i < walk; i++)
            {
                pet_dict[pet_id.ToString()].pet_now_num = i % 2 + 1;
                pet_dict[pet_id.ToString()].position_top = top + y + "px";
                pet_dict[pet_id.ToString()].position_left = left + x + "px";
                top = Convert.ToInt32(pet_dict[pet_id.ToString()].position_top.Remove(pet_dict[pet_id.ToString()].position_top.Length - 2));
                left = Convert.ToInt32(pet_dict[pet_id.ToString()].position_left.Remove(pet_dict[pet_id.ToString()].position_left.Length - 2));
                Thread.Sleep(1000);
            }
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connStr);
                SqlCommand sqlCommand = new SqlCommand(@"Select * From pet_info Where pet_id = " + Convert.ToInt32(pet_id));
                sqlCommand.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    string now = reader.GetString(reader.GetOrdinal("pet_now"));
                    reader.Close();
                    if (now == "stand")
                    {
                        sqlCommand.CommandText = @"Update pet_info Set position_top = " + top + " , position_left = " + left + " Where pet_id = " + Convert.ToInt32(pet_id);
                        sqlCommand.ExecuteNonQuery();
                        sqlConnection.Close();
                    }
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("錯誤訊息：" + e.ToString());
            }
            Home_Pet(pet_id);
        }

        public static void Pet_Sleep(object pet_id)
        {
            pet_dict[pet_id.ToString()].pet_now = "sleep";
            int sleep_time = rand.Next(1, 6) * 30;
            for (int i = 0; i < 15; i++)
            {
                pet_dict[pet_id.ToString()].pet_now_num = i % 4 + 1;
                Thread.Sleep(1000);
            }
            Home_Pet(pet_id);
        }
    }
}
