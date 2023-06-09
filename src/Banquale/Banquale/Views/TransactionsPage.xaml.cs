using Model;
using Banquale.Views.Category;
namespace Banquale.Views;

public partial class TransactionsPage : ContentPage
{
    public Manager Mgr => (App.Current as App).MyManager;

    public TransactionsPage()
	{
		InitializeComponent();
        BindingContext = Mgr.SelectedTransaction;
        if(Mgr.IsConsultant == true && Mgr.SelectedTransaction.IsOpposition == false)
        {
            oppose.Text = "Aucune demande en cours";
        }
        else if(Mgr.IsConsultant == true && Mgr.SelectedTransaction.IsOpposition == true)
        {
            oppose.Text = "Accepter l'opposition";
            refuseOpposition.IsVisible = true;
        }
        
        if(Mgr.IsConsultant == false && Mgr.SelectedTransaction.IsOpposition == true)
        {
            oppose.Text = "Demande en cours";
        }
	}

    async void Categ_Clicked(System.Object sender, System.EventArgs e)
    {
        await Shell.Current.Navigation.PushAsync(new CategoryPage());
    }

    async void Objection_Clicked(System.Object sender, System.EventArgs e)
    {
        if(Mgr.IsConsultant == false && Mgr.SelectedTransaction.IsOpposition == false)
        {
            Mgr.SelectedTransaction.IsOpposition = true;
            DisplayAlert("Opposition", "Votre demande d'opposition à bien été pris en compte", "OK");
            await Shell.Current.Navigation.PopAsync();
        }
        else if(Mgr.IsConsultant == true && Mgr.SelectedTransaction.IsOpposition == true)
        {
            Mgr.SelectedAccount.TransactionsList.Remove(Mgr.SelectedTransaction);
            DisplayAlert("Opposition", "La demande d'opposition à été réalisé avec succé", "OK");
            await Shell.Current.Navigation.PopAsync();
        }
        else if (Mgr.IsConsultant == true && Mgr.SelectedTransaction.IsOpposition == false)
        {
            DisplayAlert("Erreur", "Aucune demande d'opposition est en cours sur cette transaction", "OK");
            await Shell.Current.Navigation.PopAsync();
        }
        else if (Mgr.IsConsultant == false && Mgr.SelectedTransaction.IsOpposition == true)
        {
            DisplayAlert("Opposition", "Votre demande est en cours. Veuillez patienter SVP.", "OK");
            await Shell.Current.Navigation.PopAsync();
        }
    }

    async void Refuse_Clicked(System.Object sender, System.EventArgs e)
    {
        Mgr.SelectedTransaction.IsOpposition = false;
        DisplayAlert("Opposition", "La demande d'opposition à bien été refusé", "OK");
        await Shell.Current.Navigation.PopAsync();
    }
}