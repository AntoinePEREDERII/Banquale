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

    void Send_Clicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new BalancePage());

    }
}
