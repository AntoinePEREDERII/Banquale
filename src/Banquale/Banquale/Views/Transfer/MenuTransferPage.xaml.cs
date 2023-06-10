namespace Banquale.Views.Transfer
{
    /// <summary>
    /// Page de menu pour les transferts.
    /// </summary>
    public partial class MenuTransferPage : ContentPage
    {
        /// <summary>
        /// Initialise une nouvelle instance de la classe MenuTransferPage.
        /// </summary>
        public MenuTransferPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gère l'événement du bouton "RIB".
        /// </summary>
        public async void RIB_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PushAsync(new RibPage());
        }

        /// <summary>
        /// Gère l'événement du bouton "Demande".
        /// </summary>
        public async void Request_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PushAsync(new RequestPage());
        }

        /// <summary>
        /// Gère l'événement du bouton "Transfert".
        /// </summary>
        public async void Transfer_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PushAsync(new TransferPage());
        }
    }
}
