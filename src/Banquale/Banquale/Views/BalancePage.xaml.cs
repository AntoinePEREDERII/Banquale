using Model;

namespace Banquale.Views;


public partial class BalancePage : ContentPage
{
	public Manager Mgr => (App.Current as App).MyManager;

    public BalancePage()
	{
		InitializeComponent();
        BindingContext = Mgr.SelectedAccount;
        //BindingContext = new Account(999, "Tatouille", "FR76 9161 9581 6296 8415 2361 004");
    }


    public async void Transactions_Clicked(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        Mgr.SelectedTransaction = Mgr.SelectedAccount.TransactionsList[0];
        //Mgr.SelectedTransaction = Mgr.PropertyChanged;
        await Shell.Current.Navigation.PushAsync(new TransactionsPage());
    }

    public async void Balance_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.Navigation.PushAsync(new NewPage1());
    }

    public async void Transaction_Clicked(Object sender, EventArgs e)
    {
        uint TransactionId = Convert.ToUInt32(idLabel.Text);

        if (string.IsNullOrWhiteSpace(idLabel.Text))
        {
            await DisplayAlert("Erreur", "aucune transaction présente", "OK");
            return;
        }

        Transaction transaction = Mgr.SelectedAccount.TransactionsList.FirstOrDefault(u => u.Id == TransactionId);
        if (transaction == null)
        {
            await DisplayAlert("Erreur", "La transaction n'éxiste pas !", "OK");
            return;
        }

        Mgr.SelectedTransaction = transaction;


        await Navigation.PushModalAsync(new TransactionsPage());
    }

}
