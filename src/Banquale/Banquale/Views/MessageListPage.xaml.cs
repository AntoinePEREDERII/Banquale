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
}
