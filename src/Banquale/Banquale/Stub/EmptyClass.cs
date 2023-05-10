using System;
using Banquale.Model;

namespace Banquale.Stub
{
	public class Stub : IPersistanceManager
	{

        (List<Client>, List<Transactions>) IPersistanceManager.ChargeDonnee()
        {
            throw new NotImplementedException();
        }

        void IPersistanceManager.SauvegardeDonnee(List<Client> c, List<Transactions> t)
        {
            throw new NotImplementedException();
        }

    }

}

