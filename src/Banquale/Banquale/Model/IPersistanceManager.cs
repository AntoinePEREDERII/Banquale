using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banquale.Model
{
    public interface IPersistanceManager
    {
        public (List<Client>, List<Transactions>) ChargeDonnee();

        void SauvegardeDonnee(List<Client> c, List<Transactions> t /*, List<Compte> c2*/);
    }
}
