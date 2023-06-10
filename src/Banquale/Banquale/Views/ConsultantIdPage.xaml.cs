using System.Diagnostics;
using Banquale.Views;
using Model;

namespace Banquale.Views
{
    /// <summary>
    /// Page d'identification du consultant.
    /// </summary>
    public partial class ConsultantIdPage : ContentPage
    {
        /// <summary>
        /// Obtient le gestionnaire de l'application à partir de l'instance de l'application.
        /// </summary>
        public Manager Mgr => (App.Current as App).MyManager;

        /// <summary>
        /// Initialise une nouvelle instance de la classe ConsultantIdPage.
        /// </summary>
        public ConsultantIdPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gère l'événement du bouton de connexion.
        /// </summary>
        public async void Connection_Clicked(Object sender, EventArgs e)
        {
            // Récupération de l'ID entré
            uint currentId = Convert.ToUInt32(ident.Text);

            // Validation de l'ID
            if (string.IsNullOrWhiteSpace(ident.Text))
            {
                await DisplayAlert("Erreur", "Il faut rentrer un ID", "OK");
                return;
            }

            if (currentId == 0)
            {
                await DisplayAlert("Erreur", "Ce compte est inaccessible", "OK");
                return;
            }

            // Recherche du client correspondant à l'ID
            Customer customer = Mgr.CustomersList.FirstOrDefault(u => u.Id == currentId);
            if (customer == null)
            {
                await DisplayAlert("Erreur", "L'ID entré est incorrect ou n'existe pas.", "OK");
                return;
            }

            // Sélection du client dans le gestionnaire
            Mgr.SelectedCustomer = customer;

            Debug.WriteLine(Mgr.IsConsultant);

            // Navigation vers la page de sélection du compte
            await Navigation.PushModalAsync(new SwitchAccountPage());
        }
    }
}
