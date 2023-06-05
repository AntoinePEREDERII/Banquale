using System.Diagnostics;
using Model;
namespace UnitTest;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        Account Remi = new Account(900, "Remi", "FR00299209");
        Debug.WriteLine(Remi.Balance);

    }
}
