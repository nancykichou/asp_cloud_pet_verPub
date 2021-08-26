using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HelloPJ.Models
{
    public class Message
    {
        public int message_id { get; set; }
        public int user_id { get; set; }
        public string account_name { get; set; }
        public string message { get; set; }
        public string message_time { get; set; }
    }
}
