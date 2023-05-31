using Banquale.Model;

namespace Banquale.Views;

public partial class MessageListPage : ContentPage
{
    public Manager Mgr => (App.Current as App).MyManager;

    public MessageListPage()
	{
		InitializeComponent();
        BindingContext = Mgr.Consultant;
    }
}
