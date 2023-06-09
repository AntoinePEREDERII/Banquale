using Model;
using Microsoft.Maui.Controls;

namespace Banquale.Views.Transfer;

public partial class RequestPage : ContentPage
{
    public Manager Mgr => (App.Current as App).MyManager;

    public RequestPage()
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
        if (Name.Text == Mgr.SelectedAccount.Name && IBAN.Text == Mgr.SelectedAccount.IBAN)
        {
            await DisplayAlert("Erreur", "Vous ne pouvez vous faire de demande à vous même", "OK");
            return;
        }
        foreach (var cust in Mgr.CustomersList)
        {
            foreach (var acc in cust.AccountsList)
            {
                if (acc.Name == Name.Text && acc.IBAN == IBAN.Text)
                {
                    if (acc.Balance - Convert.ToDouble(Sum.Text) < 0)
                    {
                        await DisplayAlert("Erreur", "Le compte ne possède assez d'argent sur son compte pour aboutir à la transaction", "OK");
                        return;
                    }
                    acc.DoTransactions(acc, Convert.ToDouble(Sum.Text), true); // Type true car c'est un virement que le SelectedAccount reçoit
                    Mgr.Persistence.DataSave(Mgr.CustomersList, Mgr.Consultant);
                    await Shell.Current.Navigation.PopAsync();
                    return;
                }
            }
        }
        await DisplayAlert("Erreur", "Le compte n'existe pas", "OK");
    }
}
