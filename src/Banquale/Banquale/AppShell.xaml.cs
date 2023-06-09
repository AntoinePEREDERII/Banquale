using Banquale.Views;
using Banquale.Views.Category;
using Banquale.Views.Transfer;
using Model;

namespace Banquale;

public partial class AppShell : Shell
{

    public Manager Mgr => (App.Current as App).MyManager;

    public AppShell()
	{
        InitializeComponent();
    }
}