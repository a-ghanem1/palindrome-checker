using Xunit;
using Palindrome.Services;
using Palindrome.Interfaces;

namespace Palidrome.Tests
{
    public class PalindromeServiceTests
    {
        private readonly IPalindromeService palindromeService;

        public PalindromeServiceTests()
        {
            palindromeService = new PalindromeService();
        }

        [Fact]
        public void ShouldReturnTrueWhenStringIsPalindrome()
        {
            string[] palindromeStrings = { "RACECAR", "KAYAK", "TOO HOT TO HOOT" };

            foreach (string palindromeString in palindromeStrings)
            {
                Assert.True(palindromeService.IsPalindrome(palindromeString));
            }
        }

        [Fact]
        public void ShouldReturnFalseWhenStringIsNotPalindrome()
        {
            var notPalindromeString = "RACECAA";
            Assert.False(palindromeService.IsPalindrome(notPalindromeString));
        }
    }
}
