using System.Diagnostics;
using Model;

namespace Banquale.Views.Balance
{
    /// <summary>
    /// Vue pour afficher les différentes transactions d'un compte.
    /// </summary>
    public partial class BalanceView : ContentView
    {
        public Manager Mgr => (App.Current as App).MyManager;

        /// <summary>
        /// Constructeur de la vue BalanceView.
        /// </summary>
        public BalanceView()
        {
            InitializeComponent();
            BindingContext = Mgr.SelectedAccount;
        }

        /// <summary>
        /// Gère l'événement de clic sur une transaction.
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

        /// <summary>
        /// Rafraîchit la vue.
        /// </summary>
        public void RefreshView()
        {
            BindingContext = Mgr.SelectedAccount;
        }
    }
}
