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
        if(Subject.Text.Length >= 50 || Description.Text.Length >= 200)
        {
            await DisplayAlert("Erreur", "Trop de caracteres", "OK");
        }
        else
        {
            Message message = Account.AskForHelp(Subject.Text, Description.Text);
            Mgr.Consultant.MessagesList.Add(message);
            await Shell.Current.GoToAsync("//balance");
        }
        
    }

}
