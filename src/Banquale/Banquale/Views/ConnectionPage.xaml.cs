namespace Banquale.Views;

public partial class ConnectionPage : ContentPage
{
	public ConnectionPage()
	{
		InitializeComponent();
	}

    public async void Connection_Clicked(Object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///balance");
    }

}