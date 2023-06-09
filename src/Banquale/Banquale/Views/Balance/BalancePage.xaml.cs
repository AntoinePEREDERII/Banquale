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
<<<<<<< HEAD
=======

>>>>>>> 55ea5ef38724b058c90869c8f83110399f1104d6
}
