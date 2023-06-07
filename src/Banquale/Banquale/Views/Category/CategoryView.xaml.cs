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
}