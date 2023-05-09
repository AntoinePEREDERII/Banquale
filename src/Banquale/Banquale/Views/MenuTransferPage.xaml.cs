namespace Banquale.Views;

public partial class MenuTransferPage : ContentPage
{
	public MenuTransferPage()
	{
        InitializeComponent();
	}

    void ContentPage_NavigatedTo(System.Object sender, Microsoft.Maui.Controls.NavigatedToEventArgs e)
    {
    }

    public async void RIB_Clicked(Object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RibPage());
    }

    public async void Request_Clicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new RequestPage());
    }

    public async void Transfer_Clicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new TransferPage());
    }

}
