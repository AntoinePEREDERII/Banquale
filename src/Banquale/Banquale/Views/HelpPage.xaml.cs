namespace Banquale.Views;

public partial class HelpPage : ContentPage
{
	public HelpPage()
	{
		InitializeComponent();
	}

    public async void Send_Clicked(Object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//balance");
    }
}
