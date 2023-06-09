using System.Diagnostics;
using Banquale.Views;
using Model;

namespace Banquale.Views;

public partial class ConsultantIdPage : ContentPage
{
    public Manager Mgr => (App.Current as App).MyManager;

    public ConsultantIdPage()
	{
		InitializeComponent();
	}

    public async void Connection_Clicked(Object sender, EventArgs e)
    {
        uint currentId = Convert.ToUInt32(ident.Text);

        if (string.IsNullOrWhiteSpace(ident.Text))
        {
            await DisplayAlert("Erreur", "Il faut rentrer un ID", "OK");
            return;
        }

        if (currentId == 0)
        {
            await DisplayAlert("Erreur", "Ce compte est innaccessible", "OK");
            return;
        }

        Customer customer = Mgr.CustomersList.FirstOrDefault(u => u.Id == currentId);
        if (customer == null)
        {
            await DisplayAlert("Erreur", "L'id entré est incorrect ou n'existe pas.", "OK");
            return;
        }

        Mgr.SelectedCustomer = customer;

        Debug.WriteLine(Mgr.IsConsultant);


        await Navigation.PushModalAsync(new SwitchAccountPage());
    }

}