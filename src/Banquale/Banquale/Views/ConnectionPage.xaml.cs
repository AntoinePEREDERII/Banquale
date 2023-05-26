using Banquale.Model;

namespace Banquale.Views;

public partial class ConnectionPage : ContentPage
{
    public Manager Mgr => (App.Current as App).MyManager;

    public ConnectionPage()
	{
		InitializeComponent();
	}

    public async void Connection_Clicked(Object sender, EventArgs e)
    {
        string currentId = ident.Text;
        string password = pass.Text;

        if (string.IsNullOrWhiteSpace(currentId) || string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlert("Erreur", "Tout les champs doivent être complétés", "OK");
            return;
        }

        if(currentId == "1")
        {
            await Navigation.PushModalAsync(new ConsultantHomePage());
            return;
        }

        await Navigation.PushModalAsync(new SwitchAccountPage());
    }

}