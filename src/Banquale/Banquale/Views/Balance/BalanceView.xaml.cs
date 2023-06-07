using System.Diagnostics;
using Model;

namespace Banquale.Views.Balance;

public partial class BalanceView : ContentView
{

    public Manager Mgr => (App.Current as App).MyManager;

    public BalanceView()
	{
		InitializeComponent();
        BindingContext = Mgr.SelectedAccount;
    }

    public async void Transaction_Clicked(Object sender, EventArgs e)
    {
        var selectedItem = (sender as Grid)?.BindingContext as Transaction;

        if (selectedItem != null)
        {
            Mgr.SelectedTransaction = selectedItem;
            await Navigation.PushModalAsync(new TransactionsPage());
        }

        //if (string.IsNullOrWhiteSpace(idLabel.Text))
        //{
        //    //await DisplayAlert("Erreur", "Aucune transaction présente", "OK");
        //    Debug.WriteLine("Erreur1");
        //    return;
        //}

        //Transaction transaction = Mgr.SelectedAccount.TransactionsList.FirstOrDefault(u => u.Id == TransactionId);
        //if (transaction == null)
        //{
        //    Debug.WriteLine("Erreur2");
        //    //await DisplayAlert("Erreur", "La transaction n'éxiste pas !", "OK");
        //    return;
        //}

        //Mgr.SelectedTransaction = transaction;

        //Mgr.SelectedTransaction = Mgr.CustomersList[0].AccountsList[0].TransactionsList[0];


        //await Navigation.PushModalAsync(new TransactionsPage());
    }
}
