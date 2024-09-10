using ExceptFix.Entities;
using ExceptFix.Exceptions;
using System.Globalization;
internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Enter account data: ");
            Console.Write("Number: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("Holder: ");
            string holder = Console.ReadLine();
            Console.Write("Initial balance: ");
            double iniBalance = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Withdraw limit: ");
            double withdrawLimit = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Account account = new Account(number, holder, iniBalance, withdrawLimit);
            Console.WriteLine();
            Console.Write("Enter amount of withdraw: ");
            double withdraw = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            account.Withdraw(withdraw);
            Console.WriteLine("New balance: " + account.Balance.ToString("F2", CultureInfo.InvariantCulture));
        }
        catch (DomainException excep)
        {
            Console.WriteLine("Withdraw error: " + excep.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("Unexpected error: " + e.Message);
        }
      
    }
}