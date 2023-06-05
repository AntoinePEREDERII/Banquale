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
        uint currentId = Convert.ToUInt32(ident.Text);
        string password = pass.Text;

        if (string.IsNullOrWhiteSpace(ident.Text) || string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlert("Erreur", "Tout les champs doivent être complétés", "OK");
            return;
        }

        if(currentId == 0)
        {
            Mgr.IsConsultant = true;
            await Navigation.PushModalAsync(new ConsultantHomePage());
            return;
        }
        else
        {
            Mgr.IsConsultant = false;
        }

        Customer customer = Mgr.CustomersList.FirstOrDefault(u => u.Id == currentId && u.Password == password);
        if (customer == null)
        {
            await DisplayAlert("Erreur", "Le mot de passe ou l'id entré est incorrect.", "OK");
            return;
        }

        Mgr.SelectedCustomer = customer;


        await Navigation.PushModalAsync(new SwitchAccountPage());
    }

}