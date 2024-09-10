
using ExceptFix.Exceptions;
using System.Globalization;


namespace ExceptFix.Entities
{
    internal class Account
    {
        public int Number { get; set; }
        public string Holder { get; set; }
        public double Balance { get; set; }
        public double WithdrawLimit { get; set; }

        public Account() { }

        public Account(int number, string holder, double balance, double withdrawLimit)
        {
            Number = number;
            Holder = holder;
            Balance = balance;
            WithdrawLimit = withdrawLimit;
        }

        public void Deposit(double amount)
        {
            Balance += amount;
        }

        public void Withdraw(double amount)
        {
            if (Balance == 0 || amount <= WithdrawLimit && Balance < amount)
            {
                throw new DomainException("Your balance is zero or not enough to withdraw.");
            }
            else if (amount > WithdrawLimit)
            {
                throw new DomainException("You trespass your limit for withdraw.");
            }
            else
            {
                Balance -= amount;
            }
        }
    }
}
