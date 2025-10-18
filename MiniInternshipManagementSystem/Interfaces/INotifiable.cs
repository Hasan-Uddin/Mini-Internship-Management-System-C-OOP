using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniInternshipManagementSystem.Interfaces
{
    internal interface INotifiable
    {
        void Notify(string message);
    }
}
