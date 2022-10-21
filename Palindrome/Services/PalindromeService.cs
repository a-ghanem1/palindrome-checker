using System;
using System.Linq;
using Palindrome.Interfaces;

namespace Palindrome.Services
{
    public class PalindromeService: IPalindromeService
    {
        public bool IsPalindrome(string text)
        {
            var trimmedText = text.Replace(" ", "");
            return trimmedText.SequenceEqual(trimmedText.Reverse());
        }
    }
}
