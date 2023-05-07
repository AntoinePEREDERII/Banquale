using Banquale.Model;
namespace Banquale.Views;

public partial class NewPage1 : ContentPage
{

    public Manager myManager => (App.Current as App).MyManager;

	public NewPage1()
	{
        InitializeComponent();

        ListViewID.BindingContext = myManager;
    }

    int cpt = 0;

    void Button_Clicked(System.Object sender, System.EventArgs e)
    {
        Client client1 = new Client("Monsieur", "Bonjour", "HelloThisIsMyPassword");
        myManager.AjouterClient(client1);
        cpt++;
        Console.WriteLine(cpt);
        Console.WriteLine(client1.Nom);
    }

    public async void ArrowBack(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

}
