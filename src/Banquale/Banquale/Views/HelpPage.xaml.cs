using Model;
namespace Banquale.Views;

public partial class HelpPage : ContentPage
{
    public Manager Mgr => (App.Current as App).MyManager;
	public HelpPage()
	{
		InitializeComponent();
	}

    public async void Send_Clicked(Object sender, EventArgs e)
    {
        Message message = Account.AskForHelp(Subject.Text, Message.Text);
        Mgr.Consultant.MessagesList.Add(message);
        await Shell.Current.GoToAsync("//balance");
    }

}
