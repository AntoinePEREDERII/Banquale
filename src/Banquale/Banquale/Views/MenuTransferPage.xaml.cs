namespace Banquale.Views;

public partial class MenuTransferPage : ContentPage
{
	public MenuTransferPage()
	{
        InitializeComponent();
	}

    public async void RIB_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.Navigation.PushAsync(new RibPage());
    }

    public async void Request_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.Navigation.PushAsync(new RequestPage());
    }

    public async void Transfer_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.Navigation.PushAsync(new TransferPage());
    }

}
