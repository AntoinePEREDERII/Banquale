namespace Banquale.Views;

public partial class SwitchAccountPage : ContentPage
{
	public SwitchAccountPage()
	{
		InitializeComponent();
	}

    async void DisconnectionClicked(System.Object sender, System.EventArgs e)
    {
        await Shell.Current.GoToAsync("///connection");
    }

}