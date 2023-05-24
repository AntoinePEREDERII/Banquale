namespace Banquale.Views;

public partial class ConnectionPage : ContentPage
{
	public ConnectionPage()
	{
		InitializeComponent();
	}

    public async void Connection_Clicked(Object sender, EventArgs e)
    {
        string id = ident.Text;
        string password = pass.Text;

        if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlert("Erreur", "Tout les champs doivent être complétés", "OK");
            return;
        }

        if(id == "a")
        {
            await Navigation.PushModalAsync(new ConsultantHomePage());
            return;
        }

        await Navigation.PushModalAsync(new SwitchAccountPage());
    }

}