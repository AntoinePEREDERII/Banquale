using Model;
using Banquale.Stub;
using Banquale.DataContractPersistance;

namespace Banquale
{
    /// <summary>
    /// Classe principale de l'application Banquale.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Déclare et instencie le manager MyManager
        /// </summary>
        public Manager MyManager { get; private set; } = new Manager(new Stub.Stub() /*DataContractPersistance.DataContractPersXML()*/);

        /// <summary>
        /// Initialise une nouvelle instance de la classe App.
        /// </summary>
        public App()
        {
            // Charge les données
            MyManager.DataLoad();

            // Définit le mécanisme de persistance
            MyManager.Persistence = new DataContractPersistance.DataContractPersXML();

            // Enregistre les données
            MyManager.DataSave();

            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
