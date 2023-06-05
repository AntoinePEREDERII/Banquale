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

        await Shell.Current.GoToAsync("//balance");
    }
    async void DisconnectionClicked(System.Object sender, System.EventArgs e)
    {
        await Shell.Current.GoToAsync("///connection");
    }

}