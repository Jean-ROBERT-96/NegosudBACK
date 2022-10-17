using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSUDBack.Models
{
    internal class PurchaseOrder
    {
        public int id { get; set; }
        public string date { get; set; }
        public int idVendor { get; set; }
    }
}
