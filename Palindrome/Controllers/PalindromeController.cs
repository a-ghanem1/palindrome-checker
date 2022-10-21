using Microsoft.AspNetCore.Mvc;
using Palindrome.Interfaces;
using Palindrome.Models;

namespace Palindrome
{
    [Route("api/palindrome")]
    [ApiController]
    public class PalindromeController : ControllerBase
    {
        private readonly IPalindromeService _palindromeService;

        public PalindromeController(IPalindromeService palindromeService)
        {
            _palindromeService = palindromeService;
        }

        [HttpGet]
        [Route("check/{text}")]
        public ActionResult<PalindromeResponse> CheckIsPalindrome(string text)
        {
            var isPalindrome = _palindromeService.IsPalindrome(text);
            var response = new PalindromeResponse(isPalindrome);

            return Ok(response);
        }
    }
}