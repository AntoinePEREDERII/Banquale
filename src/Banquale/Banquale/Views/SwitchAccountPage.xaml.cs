using System.Diagnostics;
using Banquale.Views.Balance;
using Model;

namespace Banquale.Views
{
    /// <summary>
    /// Page permettant de basculer entre les comptes.
    /// </summary>
    public partial class SwitchAccountPage : ContentPage
    {
        /// <summary>
        /// Obtient le gestionnaire de l'application à partir de l'instance de l'application (Manager Mgr).
        /// </summary>
        public Manager Mgr => (App.Current as App).MyManager;

        /// <summary>
        /// Initialise une nouvelle instance de la classe SwitchAccountPage.
        /// </summary>
        public SwitchAccountPage()
        {
            InitializeComponent();

            // Lie le contexte de liaison au client sélectionné dans le Manager
            BindingContext = Mgr.SelectedCustomer;
        }

        /// <summary>
        /// Méthode appelée lorsque la page apparaît.
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();

            RefreshData();
        }

        /// <summary>
        /// Gère l'événement du bouton de transfert.
        /// </summary>
        public async void Transfer_Clicked(object sender, EventArgs e)
        {
            var selectedItem = (sender as Button)?.BindingContext as Account;

            if (selectedItem != null)
            {
                Mgr.SelectedAccount = selectedItem;
                if (Mgr.IsConsultant)
                {
                    await Shell.Current.Navigation.PushAsync(new Balance.BalancePage());
                }
                else
                {
                    await Shell.Current.GoToAsync("//balance");
                    var balancePage = Shell.Current.CurrentPage as BalancePage;
                    balancePage?.RefreshPage();
                }
            }
        }

        /// <summary>
        /// Gère l'événement du bouton de déconnexion.
        /// </summary>
        async void DisconnectionClicked(object sender, EventArgs e)
        {
            if (Mgr.IsConsultant)
            {
                await Shell.Current.Navigation.PopAsync();
            }
            else
            {
                await Shell.Current.GoToAsync("///connection");
            }
        }

        /// <summary>
        /// Rafraîchit les données de la page.
        /// </summary>
        private void RefreshData()
        {
            BindingContext = Mgr.SelectedCustomer;
        }
    }
}
