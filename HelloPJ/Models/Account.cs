using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelloPJ.Models
{
    public class Account
    {
        public int user_id { get; set; }
        [DisplayName("帳號")]
        public string user_name { get; set; }
        [DisplayName("密碼")]
        public string user_passwd { get; set; }
        [DisplayName("名稱")]
        public string account_name { get; set; }
    }
}
