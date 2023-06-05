using Model;
namespace Banquale.Views.Transfer;

public partial class TransferPage : ContentPage
{
    public Manager Mgr => (App.Current as App).MyManager;
    public TransferPage()
	{
		InitializeComponent();
	}

    public async void Send_Clicked(Object sender, EventArgs e)
    {
        Account.DoTransactions(Name.Text, IBAN.Text, Sum.Text);
        await Shell.Current.GoToAsync("//balance");
    }

}