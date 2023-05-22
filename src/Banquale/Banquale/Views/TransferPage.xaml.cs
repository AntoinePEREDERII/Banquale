using Banquale.Model;
namespace Banquale.Views;

public partial class TransferPage : ContentPage
{
	public TransferPage()
	{
		InitializeComponent();
	}

    public async void Send_Clicked(Object sender, EventArgs e)
    {
        Account.DoTransactions(Name, IBAN, Sum);
        await Shell.Current.GoToAsync("//balance");
    }

}