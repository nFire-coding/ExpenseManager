using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestore_di_Entrate.Modules
{
    interface ITransaction
    {
        string Name { get; set; }
        double Value { get; set; }
        
        Mesi Mese { get; set; }
    }
}
