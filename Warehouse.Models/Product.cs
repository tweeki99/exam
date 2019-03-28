using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Manufacturer { get; set; }
        public string ManufactureCountry { get; set; }
        public DateTime DateOfManufacture { get; set; }
    }
}
