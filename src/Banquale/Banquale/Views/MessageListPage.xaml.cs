using System.Diagnostics;
using System.Runtime.Serialization.DataContracts;
using Model;

namespace Banquale.Views
{
    /// <summary>
    /// Page affichant la liste des messages.
    /// </summary>
    public partial class MessageListPage : ContentPage
    {
        /// <summary>
        /// Obtient le gestionnaire de l'application à partir de l'instance de l'application.
        /// </summary>
        public Manager Mgr => (App.Current as App).MyManager;

        /// <summary>
        /// Initialise une nouvelle instance de la classe MessageListPage.
        /// </summary>
        public MessageListPage()
        {
            // Affiche le sujet du premier message dans les logs de débogage
            Debug.WriteLine(Mgr.Consultant.MessagesList[0].Subject);

            // Lie le contexte de liaison au gestionnaire
            BindingContext = Mgr;

            InitializeComponent();
        }
    }
}
