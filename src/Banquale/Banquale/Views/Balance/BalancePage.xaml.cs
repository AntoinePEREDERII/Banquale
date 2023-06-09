using Android.Telephony;
using Model;

namespace Banquale.Views.Balance;


public partial class BalancePage : ContentPage
{
	public Manager Mgr => (App.Current as App).MyManager;

    //private BalanceView MybalanceView;
    public BalancePage()
	{
		InitializeComponent();
        BindingContext = Mgr.SelectedAccount;
        //MybalanceView = balanceViewContainer.FindByName<BalanceView>("balanceViewContainer");
    }

    public void RefreshPage()
    {
        BindingContext = Mgr.SelectedAccount;
        //MybalanceView.RefreshView();
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

}
