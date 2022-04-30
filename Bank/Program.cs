// See https://aka.ms/new-console-template for more information
using System;
namespace BankCountNs
{
    public class BankAccount
    {
        private readonly string m_customerName;
        private double m_balance;
        private BankAccount() { }
        public BankAccount( string customername,double balance)
        {
            m_customerName = customername;
            m_balance = balance;
        }
        public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";
        public const string DebitAmountLessThanZeroMessage = "Debit amount is less than zero";
        public string CustomerName { get { return m_customerName; } }
        public double Banlance { get { return m_balance; } }
        public void Debit(double amount)
        {
            if(amount>m_balance)
            {
                throw new ArgumentOutOfRangeException("amount",amount,DebitAmountExceedsBalanceMessage);
            }
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount",amount,DebitAmountLessThanZeroMessage);
            }
            m_balance -= amount; 
        }
        public void Credit(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount");
            }

            m_balance += amount;
        }
        public static void Main()
        {
            BankAccount account = new BankAccount("mr", 11.34);
            account.Credit(5.77);
            account.Debit(11.22);
            Console.Write("current balance is${0}", account.Banlance);
        }
    }
}