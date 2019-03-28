using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Models
{
    //public delegate void SendMessageDelegate(string message);

    public class Warehous
    {
        //public event SendMessageDelegate ReportEvent;

        public List<Product> AllProducts { get; set; }


        //ReportEvent?.Invoke($"Товар добавлен");
    }
}
