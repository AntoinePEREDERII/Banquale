/// \file
/// \brief Définition de l'interface IPersistenceManager.
/// \author Votre nom

using System;
using System.Collections.Generic;

namespace Model
{
    /// <summary>
    /// Interface pour la gestion de la persistance des données.
    /// </summary>
    public interface IPersistenceManager
    {
        /// <summary>
        /// Charge les données depuis une source de persistance.
        /// </summary>
        /// <returns>Un tuple contenant la liste des clients et le consultant.</returns>
        (List<Customer>, Consultant) DataLoad();

        /// <summary>
        /// Enregistre les données dans une source de persistance.
        /// </summary>
        /// <param name="cu">La liste des clients à enregistrer.</param>
        /// <param name="co">Le consultant à enregistrer.</param>
        void DataSave(List<Customer> cu, Consultant co);
    }
}
