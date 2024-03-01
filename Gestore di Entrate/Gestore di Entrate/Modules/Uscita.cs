using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestore_di_Entrate.Modules
{
    class Uscita : ITransaction
    {
        private double value;
        private string name;
        private string mese;

        public double Value { get { return value; } set { this.value = value; } }
        public string Name { get { return name; } set { name = value; } }

        public string Mese { get { return mese; } set { mese = value; } }
    }
}
