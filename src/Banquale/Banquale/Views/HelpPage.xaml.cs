namespace Banquale.Views;

public partial class HelpPage : ContentPage
{
	public HelpPage()
	{
		InitializeComponent();
	}

    void ContentPage_NavigatedTo(System.Object sender, Microsoft.Maui.Controls.NavigatedToEventArgs e)
    {
    }

    public async void Send_Clicked(Object sender, EventArgs e)
    {
        await Shell.Current.Navigation.PushAsync(new BalancePage());

    }
}
