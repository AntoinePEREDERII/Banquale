using Model;
using Banquale.Stub;
using Banquale.DataContractPersistance;

namespace Banquale;

public partial class App : Application
{

	public Manager MyManager { get; private set; } = new Manager(new Stub.Stub() /*DataContractPersistance.DataContractPersXML()*/);



	public App()
	{

		MyManager.DataLoad();
		MyManager.Persistence = new DataContractPersistance.DataContractPersXML();
		MyManager.DataSave();

		InitializeComponent();

		MainPage = new AppShell();

    }
}
