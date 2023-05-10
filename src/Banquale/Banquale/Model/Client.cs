﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Banquale.Model
{
    //[DataFrameworks]
    public class Client: Personne
    {
        //[DataMember]
        public List<Compte> ListeComptes { get; private set; }


        public Client(string nom, string prenom, string mdp) : base(nom, prenom, mdp)
        {}


    }

}
