using Model;
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
        int count = Mgr.SelectedAccount.TransactionsList.Count;

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
                    if(Mgr.SelectedAccount.Balance - Convert.ToDouble(Sum.Text) < 0)
                    {
                        await DisplayAlert("Erreur", "Vous ne possèdez pas assez d'argent sur ce compte pour aboutir à la transaction", "OK");
                        return;
                    }
                    Mgr.SelectedAccount.DoTransactions(acc, Convert.ToDouble(Sum.Text), true, count+1); // Type true car c'est un virement
                    await Shell.Current.Navigation.PopAsync();
                    return;
                }
            }
        }
        await DisplayAlert("Erreur", "Le compte n'existe pas", "OK");
    }

}