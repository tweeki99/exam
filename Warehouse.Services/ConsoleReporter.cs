using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Services.Abstract;

namespace Warehouse.Services
{
    public class ConsoleReporter : IReporter
    {
        public void SendMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
