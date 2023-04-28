using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banquale.Model
{
    class Transactions
    {
        public int Type { get; private set; }

        public int Somme { get; private set; }

        public Compte CompteImplique { get; private set; }

        public string Categorie { get; private set; }

        private Transactions( int type, int somme, Compte compteImplique, string categorie) { 
            Type = type;
            Somme = somme;
            CompteImplique = compteImplique;
            Categorie = categorie;
        }
    }
}
