using Banquale.Model;
namespace Banquale.Views.Transfer;

public partial class RequestPage : ContentPage
{
	public RequestPage()
	{
		InitializeComponent();
	}

    public async void Send_Clicked(Object sender, EventArgs e)
    {
        Account.DoRequest(Name, IBAN, Sum);
        await Shell.Current.GoToAsync("//balance");
    }

}
