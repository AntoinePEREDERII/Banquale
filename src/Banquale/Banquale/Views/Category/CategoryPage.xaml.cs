using Model;

namespace Banquale.Views.Category;

public partial class CategoryPage : ContentPage
{

    public Manager Mgr => (App.Current as App).MyManager;
    public CategoryPage()
	{
		InitializeComponent();
	}
}