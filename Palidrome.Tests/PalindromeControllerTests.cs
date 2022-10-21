using Xunit;
using Palindrome;
using Palindrome.Interfaces;
using Palindrome.Services;
using Microsoft.AspNetCore.Mvc;
using Palindrome.Models;

namespace Palidrome.Tests
{
    public class PalindromeControllerTests
    {
        private readonly IPalindromeService palindromeService;
        private readonly PalindromeController palindromeController;

        public PalindromeControllerTests()
        {
            palindromeService = new PalindromeService();
            palindromeController = new PalindromeController(palindromeService);
        }

        [Fact]
        public void ShouldReturnResponseWithTrueWhenStringIsPalindrome()
        {
            var palindromeText = "RACECAR";
            var actionResult = palindromeController.CheckIsPalindrome(palindromeText);

            Assert.IsType<ActionResult<PalindromeResponse>>(actionResult);
            var resultObject = GetObjectResultContent<PalindromeResponse>(actionResult);


            Assert.True(resultObject.IsPalindrome);
        }

        [Fact]
        public void ShouldReturnResponseWithFalseWhenStringIsNotPalindrome()
        {
            var palindromeText = "RACECAA";
            var actionResult = palindromeController.CheckIsPalindrome(palindromeText);

            Assert.IsType<ActionResult<PalindromeResponse>>(actionResult);
            var resultObject = GetObjectResultContent<PalindromeResponse>(actionResult);


            Assert.False(resultObject.IsPalindrome);
        }

        private static T GetObjectResultContent<T>(ActionResult<T> result)
        {
            return (T)((ObjectResult)result.Result).Value;
        }
    }
}
