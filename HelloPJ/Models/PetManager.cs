using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HelloPJ.Models
{
    public class PetManager
    {
        public enum type_change
        {
            cat = 1,
        }

        private readonly string connStr = dbString.getConnet();

        public List<Pet> UserPetsInfo(string user_id)
        {
            /*
            List<Pet> pet_list = new List<Pet>();

            SqlConnection sqlConnection = new SqlConnection(connStr);
            SqlCommand sqlCommand = new SqlCommand(@"Select * From pet_info Inner Join pet_status On pet_info.pet_id = pet_status.pet_id Where pet_info.user_id="+user_id+" And pet_info.pet_raising='t'");
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Pet pet = new Pet
                    {
                        pet_id = reader.GetInt32(reader.GetOrdinal("pet_id")),
                        pet_name = reader.GetString(reader.GetOrdinal("pet_name")),
                        pet_type = ((type_change)reader.GetInt32(reader.GetOrdinal("pet_type"))).ToString(),
                        pet_stamina = reader.GetInt32(reader.GetOrdinal("pet_stamina")),
                        pet_loyalty = reader.GetInt32(reader.GetOrdinal("pet_loyalty")),
                        pet_health = reader.GetInt32(reader.GetOrdinal("pet_health")),
                        pet_curiosity = reader.GetInt32(reader.GetOrdinal("pet_curiosity")),
                        pet_wild = reader.GetInt32(reader.GetOrdinal("pet_wild")),
                        now_sleep = reader.GetString(reader.GetOrdinal("now_sleep")),
                        now_feed = reader.GetString(reader.GetOrdinal("now_feed"))
                    };
                    pet_list.Add(pet);
                }
            }
            sqlConnection.Close();
            return pet_list;
            */
            List<Pet> pet_list = new List<Pet>();

            SqlConnection sqlConnection = new SqlConnection(connStr);
            SqlCommand sqlCommand = new SqlCommand(@"Select * From pet_info Where pet_info.user_id=" + user_id + " And pet_info.pet_raising='t'");
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string pet_id = reader.GetInt32(reader.GetOrdinal("pet_id")).ToString();
                    pet_list.Add(ServerManager.pet_dict[pet_id]);
                }
            }
            sqlConnection.Close();
            return pet_list;
        }
    }
}
