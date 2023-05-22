using Banquale.Model;
namespace Banquale.Views;

public partial class HelpPage : ContentPage
{
	public HelpPage()
	{
		InitializeComponent();
	}

    public async void Send_Clicked(Object sender, EventArgs e)
    {
        Account.AskForHelp(Request, Subject, Message);
        await Shell.Current.GoToAsync("//balance");
    }

}
