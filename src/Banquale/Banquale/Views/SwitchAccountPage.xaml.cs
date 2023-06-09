using System.Diagnostics;
using Banquale.Views.Balance;
using Model;

namespace Banquale.Views;

public partial class SwitchAccountPage : ContentPage
{

    public Manager Mgr => (App.Current as App).MyManager;
    public SwitchAccountPage()
	{
		InitializeComponent();
        BindingContext = Mgr.SelectedCustomer;
	}

    public async void Transfer_Clicked(object sender, EventArgs e)
    {
        var selectedItem = (sender as Button)?.BindingContext as Account;

        if (selectedItem != null)
        {
            Mgr.SelectedAccount = selectedItem;
            if (Mgr.IsConsultant == true)
            {
                await Shell.Current.Navigation.PushAsync(new Balance.BalancePage());
            }
            else
            {
                await Shell.Current.GoToAsync("//balance");
                var balancePage = Shell.Current.CurrentPage as BalancePage;
                balancePage?.RefreshPage();
            }
        }
        
    }

    async void DisconnectionClicked(object sender, EventArgs e)
    {
        if(Mgr.IsConsultant == true)
        {
            await Shell.Current.Navigation.PopAsync();
        }
        else
        {
            await Shell.Current.GoToAsync("///connection");
        }
    }

}