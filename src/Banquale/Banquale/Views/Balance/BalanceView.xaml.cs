using Banquale.Model;
using Banquale.Views.Category;
namespace Banquale.Views.Balance;

public partial class BalanceView : ContentView
{

    public Manager Mgr => (App.Current as App).MyManager;

    public BalanceView()
	{
		InitializeComponent();
        BindingContext = Mgr;
    }

    public async void Transaction_Clicked(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        await Shell.Current.Navigation.PushAsync(new TransactionsPage());
    }
}
