using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloPJ.Models
{
    public class Pet
    {
        public int pet_id { get; set; }
        public string pet_name { get; set; }
        public string pet_type { get; set; }
        public string pet_now { get; set; }
        public int pet_now_num { get; set; }
        public string position_top { get; set; }
        public string position_left { get; set; }
        public int pet_stamina { get; set; }
        public int pet_loyalty { get; set; }
        public int pet_health { get; set; }
        public int pet_curiosity { get; set; }
        public int pet_wild { get; set; }
        public string now_sleep { get; set; }
        public string now_feed { get; set; }
        public string pet_pic
        {
            get
            {
                return pet_type + "_" + pet_now + "_" + pet_now_num + ".png";
            }
        }
    }
}
