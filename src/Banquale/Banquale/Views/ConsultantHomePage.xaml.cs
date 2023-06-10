namespace Banquale.Views
{
    /// <summary>
    /// Page d'accueil du consultant.
    /// </summary>
    public partial class ConsultantHomePage : ContentPage
    {
        /// <summary>
        /// Initialise une nouvelle instance de la classe ConsultantHomePage.
        /// </summary>
        public ConsultantHomePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gère l'événement du bouton de déconnexion.
        /// </summary>
        async void DisconnectionClicked(System.Object sender, System.EventArgs e)
        {
            await Shell.Current.GoToAsync("///connection");
        }

        /// <summary>
        /// Gère l'événement du bouton d'identification du client.
        /// </summary>
        async void Id_Clicked(System.Object sender, System.EventArgs e)
        {
            await Shell.Current.Navigation.PushAsync(new ConsultantIdPage());
        }

        /// <summary>
        /// Gère l'événement du bouton de création de client.
        /// </summary>
        async void Create_Customer_Clicked(System.Object sender, System.EventArgs e)
        {
            await Shell.Current.Navigation.PushAsync(new CreateCustomerPage());
        }

        /// <summary>
        /// Gère l'événement du bouton de messagerie.
        /// </summary>
        async void Message_Clicked(System.Object sender, System.EventArgs e)
        {
            await Shell.Current.Navigation.PushAsync(new MessageListPage());
        }
    }
}
