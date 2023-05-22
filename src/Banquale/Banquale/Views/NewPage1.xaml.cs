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
        Customer customer1 = new Customer("Mister", "Hello", "HelloThisIsMyPassword");
        myManager.AddCustomer(customer1);
        cpt++;
        Console.WriteLine(cpt);
        Console.WriteLine(customer1.Name);
    }

    public async void ArrowBack(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

}
