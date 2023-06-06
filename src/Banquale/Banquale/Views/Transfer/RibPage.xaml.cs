using Model;

namespace Banquale.Views.Transfer;

public partial class RibPage : ContentPage
{
    public Manager Mgr => (App.Current as App).MyManager;

    public RibPage()
	{
        InitializeComponent();
        BindingContext = Mgr;
    }
}
