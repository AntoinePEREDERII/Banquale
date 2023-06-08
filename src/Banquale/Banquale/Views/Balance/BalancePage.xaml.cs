using Model;

namespace Banquale.Views.Balance;


public partial class BalancePage : ContentPage
{
	public Manager Mgr => (App.Current as App).MyManager;

    public BalancePage()
	{
		InitializeComponent();
        BindingContext = Mgr.SelectedAccount;
    }

    public async void Balance_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.Navigation.PushAsync(new NewPage1());
    }

}
