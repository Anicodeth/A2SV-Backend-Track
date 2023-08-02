using System;

namespace PalindromeCheck
{
    class Program
    {
        static void Main(string[] args)
        
        {
            Console.WriteLine("Enter a Word or sentence: ");
            string input = Console.ReadLine();
            bool isPalindrome = IsPalindrome(input);

            Console.WriteLine($"Is the input a palindrome? {isPalindrome}");
        }

        static bool IsPalindrome(string input)
        {
            // Remove spaces, punctuation, and convert to lowercase
            string cleanedInput = RemoveNonAlphanumeric(input).ToLower();

            // Compare the cleaned string with its reverse
            return cleanedInput == ReverseString(cleanedInput);
        }

        static string RemoveNonAlphanumeric(string input)
        {
            return System.Text.RegularExpressions.Regex.Replace(input, "[^a-zA-Z0-9]", "");
        }

        static string ReverseString(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
