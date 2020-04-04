using System;
using System.Collections.Generic;

namespace PasswordStrength
{
    public struct PasswordParts
    {
        public int passwordLength;
        public int lettersCount;
        public int upperLettersCount;
        public int lowerLettersCount;
        public int numsCount;
        public int duplicatesCount;
    }
    public class Program
    {
        public static PasswordParts CalcPasswordParts(string password)
        {
            PasswordParts parts = new PasswordParts();
            parts.passwordLength = password.Length;
            Dictionary<char, int> symbols = new Dictionary<char, int>();
            for (int i = 0; i < password.Length; ++i)
            {
                if (symbols.ContainsKey(password[i]))
                {
                    symbols[password[i]] += 1;
                }
                else
                {
                    symbols.Add(password[i], 1);
                }

                if (password[i] >= 'A' && password[i] <= 'Z')
                {
                    ++parts.lettersCount;
                    ++parts.upperLettersCount;
                }
                else if (password[i] >= 'a' && password[i] <= 'z')
                {
                    ++parts.lettersCount;
                    ++parts.lowerLettersCount;
                }
                else if (password[i] >= '0' && password[i] <= '9')
                {
                    ++parts.numsCount;
                }
                else
                {
                    Console.WriteLine("Invalid symbols in password.");
                    Environment.Exit(1);
                }
            }

            foreach (var i in symbols)
            {
                if (i.Value > 1)
                {
                    parts.duplicatesCount += i.Value;
                }
            }

            return parts;
        }

        public static int CalcPasswordStrength(PasswordParts parts)
        {
            int strength = 0;
            
            strength = 4 * parts.passwordLength;
            strength += 4 * parts.numsCount;
            if (parts.upperLettersCount != 0) {
                strength += (parts.passwordLength - parts.upperLettersCount) * 2;
            }
            if (parts.lowerLettersCount != 0)
            {
                strength += (parts.passwordLength - parts.lowerLettersCount) * 2;
            }
            if(parts.numsCount == 0)
            {
                strength -= parts.passwordLength;
            }
            if (parts.lettersCount == 0)
            {
                strength -= parts.passwordLength;
            }
            if(parts.duplicatesCount != 0)
            {
                strength -= parts.duplicatesCount;
            }

            return strength;
        }

        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Invalid argument count.\nUsage PasswordStrength.exe <password>.");
            }
            else
            {
                PasswordParts parts = CalcPasswordParts(args[0]);
                int passwordStrength = CalcPasswordStrength(parts);
                Console.WriteLine(passwordStrength);
            }
        }
    }
}
