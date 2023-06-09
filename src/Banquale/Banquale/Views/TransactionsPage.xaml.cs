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
        if(Mgr.IsConsultant == true)
        {
            oppose.Text = "Accepter l'oposition";
        }
	}

    async void Categ_Clicked(System.Object sender, System.EventArgs e)
    {
        await Shell.Current.Navigation.PushAsync(new CategoryPage());
    }

    async void Objection_Clicked(System.Object sender, System.EventArgs e)
    {
        Mgr.SelectedTransaction.IsOpposition = true;
        Mgr.Persistence.DataSave(Mgr.CustomersList, Mgr.Consultant);
        await Shell.Current.Navigation.PopAsync();
    }

    
}