namespace Palindrome.Models
{
    public class PalindromeResponse
    {
        public PalindromeResponse(bool isPalindrome)
        {
            IsPalindrome = isPalindrome;
        }

        public bool IsPalindrome { set; get; }
    }
}
