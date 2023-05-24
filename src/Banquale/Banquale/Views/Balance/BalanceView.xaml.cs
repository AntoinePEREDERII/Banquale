using Banquale.Views.Category;
namespace Banquale.Views.Balance;

public partial class BalanceView : ContentView
{
	public BalanceView()
	{
		InitializeComponent();
	}

	public async void OnButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.Navigation.PushAsync(new TransactionsPage());
    }
}
