namespace Opakovani;

using Opakovani.OOP;
using Opakovani.Variables;

class Program
{
    static void Main(string[] args)
    {
        Variables.Variables tridaSPromennymi = new Variables.Variables();
        tridaSPromennymi.WorkWithVariables();
        int x = 100;

        tridaSPromennymi.ReferenceAddNumber(ref x);

        Console.WriteLine(x); // 110, predali jsme jako referenci a hodnotu modifikovali v metode

        IBankAccount bankAccount = new BankAccount(250727069, "Adam", "Cuba");
        bankAccount.Deposit(10000);

        try
        {
            bankAccount.Withdraw(20000);
        } catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }

        // ke statickym promennym nebo metodam pristuujeme skrze nazev tridy, stejna jako Console.WriteLine()
        Console.WriteLine(BankAccount.AccountCounter);
        BankAccount.PrintAccountCounter();
    }
}
