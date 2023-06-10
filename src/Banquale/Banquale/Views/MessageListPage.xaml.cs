using System.Diagnostics;
using System.Runtime.Serialization.DataContracts;
using Model;

namespace Banquale.Views;

public partial class MessageListPage : ContentPage
{
    public Manager Mgr => (App.Current as App).MyManager;

    public MessageListPage()
	{
        Debug.WriteLine(Mgr.Consultant.MessagesList[0].Subject);
        BindingContext = Mgr;
        InitializeComponent();
    }

    public async void MessageDelete(Object sender, EventArgs e)
    {
        var selectedItem = (sender as Grid)?.BindingContext as Message;

        if (selectedItem != null)
        {
            bool rep = await DisplayAlert("Suppression", "Voulez vous supprimer ce message ?", "Oui", "Non");
            Debug.WriteLine("Rep : " + rep);
            if(rep)
            {
                Mgr.Consultant.MessagesList.Remove(selectedItem);
                await Shell.Current.Navigation.PopAsync();
            }
        }
    }
}
