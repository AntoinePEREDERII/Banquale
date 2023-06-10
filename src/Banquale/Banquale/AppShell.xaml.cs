using Banquale.Views;
using Banquale.Views.Category;
using Banquale.Views.Transfer;
using Model;

namespace Banquale
{
    /// <summary>
    /// Classe représentant la coquille de l'application.
    /// </summary>
    public partial class AppShell : Shell
    {
        /// <summary>
        /// Obtient le gestionnaire de l'application à partir de l'instance de l'application (Manager Mgr).
        /// </summary>
        public Manager Mgr => (App.Current as App).MyManager;

        /// <summary>
        /// Initialise une nouvelle instance de la classe AppShell.
        /// </summary>
        public AppShell()
        {
            InitializeComponent();
        }
    }
}
