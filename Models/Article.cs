using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSUDBack.Models
{
    internal class Article
    {
        public int id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public string year { get; set; }
        public string description { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }
        public int idFamily { get; set; }
    }
}
