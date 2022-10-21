namespace Palindrome.Interfaces
{
    public interface IPalindromeService
    {
        bool IsPalindrome(string text);
        bool IsDbPalindrome(string text);
    }
}
