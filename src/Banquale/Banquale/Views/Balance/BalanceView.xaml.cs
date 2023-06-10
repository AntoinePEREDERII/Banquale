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
    }

    public void RefreshView()
    {
        BindingContext = Mgr.SelectedAccount;


    }
}
