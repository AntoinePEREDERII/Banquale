using Banquale.Model;
namespace Banquale.Views;


public partial class BalancePage : ContentPage
{
	public BalancePage()
	{
		InitializeComponent();
	}

	public async void OnButtonClicked(object sender, EventArgs e)
	{
		await Shell.Current.Navigation.PushAsync(new NewPage1());
	}

}
