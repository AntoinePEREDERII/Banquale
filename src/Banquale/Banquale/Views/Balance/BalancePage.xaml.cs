using Android.Telephony;
using Model;

namespace Banquale.Views.Balance
{
    /// <summary>
    /// Page de balance.
    /// </summary>
    public partial class BalancePage : ContentPage
    {
        public Manager Mgr => (App.Current as App).MyManager;

        /// <summary>
        /// Constructeur de la page BalancePage.
        /// </summary>
        public BalancePage()
        {
            InitializeComponent();
            BindingContext = Mgr.SelectedAccount;
        }

        /// <summary>
        /// Actualise la page.
        /// </summary>
        public void RefreshPage()
        {
            BindingContext = Mgr.SelectedAccount;
        }

        /// <summary>
        /// Gère le clic sur une transaction.
        /// </summary>
        public async void Transaction_Clicked(Object sender, EventArgs e)
        {
            var selectedItem = (sender as Grid)?.BindingContext as Transaction;

            if (selectedItem != null)
            {
                Mgr.SelectedTransaction = selectedItem;
                await Navigation.PushModalAsync(new TransactionsPage());
            }
        }
    }
}
