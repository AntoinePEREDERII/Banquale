using Banquale.Model;
namespace Banquale.Views;

public partial class NewPage1 : ContentPage
{

    public Manager myManager => (App.Current as App).MyManager;
	public NewPage1()
	{
		InitializeComponent();
	}

    int cpt = 0;

    void Button_Clicked(System.Object sender, System.EventArgs e)
    {
        myManager.AjouterClient(new Client("Monsieur", "Bonjour", "HelloThisIsMyPassword"));
        cpt++;
        Console.WriteLine(cpt);
    }
}
