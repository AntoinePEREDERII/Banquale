using Model;

namespace Banquale.Views.Transfer
{
    /// <summary>
    /// Page d'affichage du RIB.
    /// </summary>
    public partial class RibPage : ContentPage
    {
        public Manager Mgr => (App.Current as App).MyManager;

        /// <summary>
        /// Initialise une nouvelle instance de la classe RibPage.
        /// </summary>
        public RibPage()
        {
            InitializeComponent();
            BindingContext = Mgr;
        }
    }
}
