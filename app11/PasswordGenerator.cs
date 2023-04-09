using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app11
{
    internal static class PasswordGenerator
    {
        public static string GetPassword()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()";
            Random rnd = new Random();

            return new string(Enumerable.Repeat(chars, 12)
            .Select(s => s[rnd.Next(s.Length)]).ToArray());
        }

    }
}
