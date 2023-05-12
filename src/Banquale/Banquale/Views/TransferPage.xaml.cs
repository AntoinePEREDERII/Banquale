namespace Banquale.Views;

public partial class TransferPage : ContentPage
{
	public TransferPage()
	{
		InitializeComponent();
	}

    public async void Send_Clicked(Object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//balance");
    }

}