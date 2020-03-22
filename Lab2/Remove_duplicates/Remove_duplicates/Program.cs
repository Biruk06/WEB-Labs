using System;

namespace Remove_duplicates
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length != 1)
            {
                Console.WriteLine("Incorrect number of arguments!");
                Console.WriteLine("Usage: Remove_duplicates.exe <input string>");
            }
            else
            {
                string noDuplicates = "";
                for(int i = 0; i < args[0].Length; ++i)
                {
                    if (!noDuplicates.Contains(args[0][i]))
                    {
                        noDuplicates = noDuplicates + args[0][i];
                    }
                    else
                    {
                        continue;
                    }
                }
                Console.WriteLine(noDuplicates);
            }
        }
    }
}
