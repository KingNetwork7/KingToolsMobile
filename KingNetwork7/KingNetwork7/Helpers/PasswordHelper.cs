using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingNetwork7.Helpers
{
    public static class PasswordHelper
    {
        public static string GeneratePassword(int genlen = 8, bool usenumbers = true, bool usehighalphabets = true, bool usesymbols = true)
        {
            //string password = Guid.NewGuid().ToString();
            //while (password.Length < digits)
            //{
            //    password += Guid.NewGuid().ToString();
            //}
            //return password.Substring(0, digits);
            var upperCase = new char[]
            {
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U',
                'V', 'W', 'X', 'Y', 'Z'
            };

            var numerals = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            var symbols = new char[]
                {
                '~', '`', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '{', '[', '}', ']', '-', '_', '=', '+', ':',
                ';', '|', '/', '?', ',', '<', '.', '>'
                };

            char[] total = (new char[0])
                            .Concat(usehighalphabets ? upperCase : new char[0])
                            .Concat(usenumbers ? numerals : new char[0])
                            .Concat(usesymbols ? symbols : new char[0])
                            .ToArray();

            var rnd = new Random();

            var chars = Enumerable
                .Repeat<int>(0, genlen)
                .Select(i => total[rnd.Next(total.Length)])
                .ToArray();

            return new string(chars);
        }
    }
}
