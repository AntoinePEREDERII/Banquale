using Banquale.Model;
using Banquale.Stub;
using Banquale.DataContractPersistance;
namespace Banquale;

public partial class App : Application
{

	public Manager MyManager { get; private set; } = new Manager(new Stub.Stub() /*DataContractPersistance.DataContractPers()*/);

	

	public App()
	{

		MyManager.DataLoad();
		MyManager.Persistence = new DataContractPersistance.DataContractPers();
		MyManager.DataSave();

		InitializeComponent();

		MainPage = new AppShell();

	}
}

