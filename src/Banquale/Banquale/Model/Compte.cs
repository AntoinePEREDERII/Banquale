using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Banquale.Model
{
    class Compte
    {
        public int Solde { get; set; }

        public string Nom { get; set;}

        public string IBAN { get; set; }

        public List<Transactions> CompteList { get; set; }
    }
}
