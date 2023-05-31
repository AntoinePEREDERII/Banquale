using Banquale.Model;

namespace Banquale.Views.Balance;


public partial class BalancePage : ContentPage
{
	public Manager Mgr => (App.Current as App).MyManager;

    public BalancePage()
	{
		InitializeComponent();
        BindingContext = Mgr.SelectedAccount;
        //BindingContext = new Account(999, "Tatouille", "FR76 9161 9581 6296 8415 2361 004");
    }


    public async void Transaction_Clicked(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        Mgr.SelectedTransaction = Mgr.SelectedAccount.TransactionsList[0];
        await Shell.Current.Navigation.PushAsync(new TransactionsPage());
    }
    public async void Balance_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.Navigation.PushAsync(new NewPage1());
    }

}
