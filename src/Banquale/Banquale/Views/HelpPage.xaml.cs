namespace Banquale.Views;

public partial class HelpPage : ContentPage
{
	public HelpPage()
	{
		InitializeComponent();
	}

    public async void Send_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.Navigation.PushAsync(new BalancePage());

    }

}
