using System;
namespace Opakovani.OOP
{
	public interface IBankAccount
	{
		IBankAccount Deposit(double value);
		IBankAccount Withdraw(double value);
	}

	public class BankAccount: IBankAccount
	{
		public int AccountNumber { get; }
		public string FirstName { get; }
		public string LastName { get; }
		public double Balance { get; private set; }

		// staticka promenna, pristupujeme k ni skrze tridu
		public static int AccountCounter { get; private set; }

		public BankAccount(int accountNumber, string firstName, string lastName)
		{
			AccountNumber = accountNumber;
			FirstName = firstName;
			LastName = lastName;
			Balance = 0.0;
			AccountCounter++;
		}

		public static void PrintAccountCounter()
		{
			Console.WriteLine($"Počet založených účtů: {AccountCounter}");
        }

        public IBankAccount Deposit(double value)
        {
			Balance += value;

			return this;
        }

		public IBankAccount Withdraw(double value)
		{
			double temp = Balance - value;

			if (temp < 0.0)
			{
				throw new Exception("Zůstatek na účtě nemůže být menší než 0.");
			}

			Balance -= value;

			return this;
		}
    }
}

