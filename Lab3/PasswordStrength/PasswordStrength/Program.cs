using System;
using System.Collections.Generic;

namespace PasswordStrength
{
    public class Program
    {
        public static int CalcPasswordStrength(string password)
        {
            int strength = 0;
            int lettersCount = 0, upperLettersCount = 0, lowerLettersCount = 0, numsCount = 0;
            Dictionary<char, int> symbols = new Dictionary<char, int>();
            /*if(password.Length == 0)
            {
                Console.WriteLine("Password can not be empty string.");
                Environment.Exit(1);
            }*/
            for(int i = 0; i < password.Length; ++i)
            {
                if (symbols.ContainsKey(password[i]))
                {
                    symbols[password[i]] += 1;
                    //Console.WriteLine(symbols[password[i]]);
                }
                else
                {
                    symbols.Add(password[i], 1);
                }

                if(password[i] >= 'A' && password[i] <= 'Z')
                {
                    ++lettersCount;
                    ++upperLettersCount;
                }
                else if (password[i] >= 'a' && password[i] <= 'z')
                {
                    ++lettersCount;
                    ++lowerLettersCount;
                }
                else if(password[i] >= '0' && password[i] <= '9')
                {
                    ++numsCount;
                }
                else
                {
                    Console.WriteLine("Invalid symbols in password.");
                    Environment.Exit(1);
                }
            }

            int duplicatesCount = 0;

            foreach(var i in symbols)
            {
                if(i.Value > 1)
                {
                    duplicatesCount += i.Value;
                }
            }

            strength = 4 * password.Length;
            strength += 4 * numsCount;
            if (upperLettersCount != 0) {
                strength += (password.Length - upperLettersCount) * 2;
            }
            if (lowerLettersCount != 0)
            {
                strength += (password.Length - lowerLettersCount) * 2;
            }
            if(numsCount == 0)
            {
                strength -= password.Length;
            }
            if (lettersCount == 0)
            {
                strength -= password.Length;
            }
            if(duplicatesCount != 0)
            {
                strength -= duplicatesCount;
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
                int passwordStrength = CalcPasswordStrength(args[0]);
                Console.WriteLine(passwordStrength);
            }
        }
    }
}
