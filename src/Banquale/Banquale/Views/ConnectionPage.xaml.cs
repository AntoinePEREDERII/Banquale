using Model;

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
            Mgr.IsConsultant = true;
            await Navigation.PushModalAsync(new ConsultantHomePage());
            return;
        }
        else
        {
            Mgr.IsConsultant = false;
        }


        /*foreach(var Cu in Mgr.CustomersList)
        {
            if (Cu.Id == currentId)
            {
                Mgr.SelectedCustomer = Mgr.CustomersList[currentId+1];
            }
        }*/

        //if(int.Parse(currentId) in Mgr.CustomersList) // FONCTIONNE PAS
        //{
        //    Mgr.SelectedCustomer = Mgr.CustomersList[int.Parse(currentId)];             
        //}

        Mgr.SelectedCustomer = Mgr.CustomersList[0];// 0 à changer 


        await Navigation.PushModalAsync(new SwitchAccountPage());
    }

}