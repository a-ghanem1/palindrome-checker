using System;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Palindrome.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Palindrome.Services
{
    public class PalindromeService : IPalindromeService
    {
        private readonly IConfiguration _configuration;

        public PalindromeService()
        {
        }

        public PalindromeService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool IsPalindrome(string text)
        {
            var trimmedText = text.Replace(" ", "");
            return trimmedText.SequenceEqual(trimmedText.Reverse());
        }

        public bool IsDbPalindrome(string text)
        {
            var trimmedText = text.Replace(" ", "");

            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            SqlConnection connection = new SqlConnection(connectionString);

            var storedProcedureQuery = $@"
                DECLARE @string nvarchar(255);
                SET @string = '{trimmedText}';

                IF @string = REVERSE(@string)
                BEGIN
	                SELECT 1
                END
                ELSE
                BEGIN
	                SELECT 0
                END
            ";

            SqlCommand sqlCommand = new SqlCommand(storedProcedureQuery, connection);

            connection.Open();
            var result = (int)sqlCommand.ExecuteScalar();
            connection.Close();

            
            return Convert.ToBoolean(result);
        }
    }
}
