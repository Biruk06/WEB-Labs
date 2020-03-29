using System;

namespace CheckIdentifer
{
    public class Program
    {
        public static bool CheckIdentifer(string identifer)
        {
            bool endNumsFlag = false;
            if (identifer == "")
            {
                Console.WriteLine("Identifer can not be empty string.");
                return false;
            }
            else
            {
                for (int i = identifer.Length - 1; i >= 0; --i)
                {
                    if (char.IsDigit(identifer[i]) && !endNumsFlag)
                    {
                        if (i == 0)
                        {
                            Console.WriteLine("Identifier contains only digits.");
                            return false;
                        }
                        continue;
                    }
                    else if (char.IsDigit(identifer[i]) && endNumsFlag)
                    {
                        Console.WriteLine("Identifier can contain numbers only at the end.");
                        return false;
                    }
                    else if (char.IsLetter(identifer[i]) && !endNumsFlag)
                    {
                        endNumsFlag = true;
                        continue;
                    }
                    else if (!char.IsLetter(identifer[i]))
                    {
                        Console.WriteLine("The identifier contains neither a letter nor a number.");
                        return false;
                    }
                }
                return true;
            }
        }

        public static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Invalid arguments count. \nUsage CheckIdentifer.exe <identifer>.");
            }
            else
            {
                string identifer = args[0];
                bool isIdentifer = CheckIdentifer(identifer);
                if (isIdentifer)
                {
                    Console.WriteLine("Yes.");
                }
                else
                {
                    Console.WriteLine("No.");
                }

            }
        }
    }
}
