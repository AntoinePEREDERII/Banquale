using Banquale.Model;
using System.Linq;

namespace Banquale.Views.Transfer;

public partial class TransferPage : ContentPage
{
    public Manager Mgr => (App.Current as App).MyManager;
    public TransferPage()
	{
		InitializeComponent();
	}

    public async void Send_Clicked(Object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Name.Text) || string.IsNullOrEmpty(IBAN.Text) || string.IsNullOrEmpty(Sum.Text))
        {
            await DisplayAlert("Erreur", "Tout les champs doivent être complétés", "OK");
            return;
        }
        foreach (var cust in Mgr.CustomersList)
        {
            foreach (var acc in cust.AccountsList)
            {
                if(acc.Name == Name.Text && acc.IBAN == IBAN.Text)
                {
                    acc.DoTransactions(acc, Convert.ToDouble(Sum.Text), true); // Type true car c'est un virement
                    //await Shell.Current.GoToAsync("//balance");
                    await Shell.Current.Navigation.PopAsync();
                    return;
                }
            }
        }
        await DisplayAlert("Erreur", "Le compte n'existe pas", "OK");
    }

}