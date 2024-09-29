namespace TestProject1
{
    public class InheritanceTests
    {
        [Fact]
        public void CalculateInterest_AppliesHigherRate()
        {
            // Arrange
            BankAccount account = new SavingsAccount(12345, 1000, 0.05);

            // Act
            account.CalculateInterest();

            // Assert
            Assert.Equal(1075, account.GetBalance()); // Expected value based on 1000 + (1000 * 0.075)
        }
    }
}
