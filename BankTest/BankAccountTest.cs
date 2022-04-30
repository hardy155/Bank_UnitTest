using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankCountNs;
namespace BankTest
{
    [TestClass]
    public class BankAccountTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            double beginningBanlance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("zkl", beginningBanlance);
            account.Debit(debitAmount);
            double actual = account.Banlance;
            Assert.AreEqual(expected, actual,0.01, "Account not debited correctly");
        }
        [TestMethod]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 20.0;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act
            try
            {
                account.Debit(debitAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }
    }
}