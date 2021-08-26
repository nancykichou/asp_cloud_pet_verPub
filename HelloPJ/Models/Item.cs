using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloPJ.Models
{
    public class Item
    {
        public int id { get; set; }
        public int item_id { get; set; }
        public string item_name { get; set; }
        public int item_price { get; set; }
        public string item_pic { get; set; }
        public string item_type { get; set; }
        public int item_quantity { get; set; }
        public string item_used { get; set; }
        public string position_top { get; set; }
        public string position_left { get; set; }
    }
}
