using Model;
using Microsoft.Maui.Controls;

namespace Banquale.Views.Transfer;

public partial class RequestPage : ContentPage
{
    public Manager Mgr => (App.Current as App).MyManager;

    public RequestPage()
	{
		InitializeComponent();
    }

    public async void Send_Clicked(Object sender, EventArgs e)
    {
        Account.DoRequest(Name.Text, IBAN.Text, Sum.Text);
        await Shell.Current.GoToAsync("//balance");
    }
}
