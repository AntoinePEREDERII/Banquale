using System.Diagnostics;
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
        Mgr.SelectedAccount = Mgr.SelectedCustomer.AccountsList[0]; // 0 � changer
        if(Mgr.IsConsultant == true)
        {
            await Shell.Current.Navigation.PushAsync(new Balance.BalancePage());
        }
        else
        {
            await Shell.Current.GoToAsync("//balance");
        }
    }

    async void DisconnectionClicked(object sender, EventArgs e)
    {
        if(Mgr.IsConsultant == true)
        {
            //await Shell.Current.GoToAsync(;
            Debug.WriteLine("Hello");
        }
        else
        {
            await Shell.Current.GoToAsync("///connection");
        }
    }

}