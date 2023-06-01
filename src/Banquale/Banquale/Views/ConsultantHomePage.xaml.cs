namespace Banquale.Views;

public partial class ConsultantHomePage : ContentPage
{
	public ConsultantHomePage()
	{
		InitializeComponent();
	}

    async void DisconnectionClicked(System.Object sender, System.EventArgs e)
    {
        await Shell.Current.GoToAsync("///connection");
    }

    async void Id_Clicked(System.Object sender, System.EventArgs e)
    {
        await Shell.Current.Navigation.PushAsync(new ConsultantIdPage());
        //await Shell.Current.GoToAsync("..");
    }

    async void Create_Customer_Clicked(System.Object sender, System.EventArgs e)
    {
        await Shell.Current.Navigation.PushAsync(new CreateCustomerPage());
        //await Shell.Current.GoToAsync("///createcustomer");
    }

    async void Message_Clicked(System.Object sender, System.EventArgs e)
    {
        await Shell.Current.Navigation.PushAsync(new MessageListPage());
        //await Shell.Current.GoToAsync("///createcustomer");
    }

}