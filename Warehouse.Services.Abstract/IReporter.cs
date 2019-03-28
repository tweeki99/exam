using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Services.Abstract
{
    public interface IReporter
    {
        void SendMessage(string message);
    }
}
