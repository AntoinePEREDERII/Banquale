using Model;

namespace Banquale.Views.Category;

public partial class CategoryView : ContentView
{

    public Manager Mgr => (App.Current as App).MyManager;
    public CategoryView()
	{
		InitializeComponent();
		BindingContext = Mgr;
	}

    public async void Category_Clicked(object sender, EventArgs e)
	{
        var selectedItem = (sender as Grid)?.BindingContext as string;
        if (selectedItem != null)
        {
            Mgr.SelectedTransaction.ChangeCategory(selectedItem);
            Mgr.Persistence.DataSave(Mgr.CustomersList, Mgr.Consultant);
            await Shell.Current.Navigation.PopAsync();
        }
        
    }
}