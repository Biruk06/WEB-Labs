using System;
using System.IO;

namespace RemoveExtraBlanks
{
    public struct Arguments
    {
        public string inputFile;
        public string outputFile;
    }
    public class Program
    {
        public static Arguments ParseArgs(string[] args)
        {
            Arguments arguments = new Arguments();
            if (args.Length != 2)
            {
                Console.WriteLine("Invalid argument count.\nUsage RemoveExtraBlanks.exe <inputFile.txt> <outputFile.txt>");
                Environment.Exit(1);
            }
            else
            {
                arguments.inputFile = args[0];
                arguments.outputFile = args[1];
            }
            return arguments;
        }

        public static string RemoveExtraBlanks(string str)
        {
            string withoutExtraBlanks = "";
            bool blankFlag = false;
            str = str.Trim();
            for(int i = 0;i < str.Length; ++i)
            {
                if(str[i] != ' ' && str[i] != '\t')
                {
                    withoutExtraBlanks += str[i];
                    blankFlag = false;
                }
                else
                {
                    if (!blankFlag)
                    {
                        withoutExtraBlanks += str[i];
                        blankFlag = true;
                    }
                }
            }
            //Console.WriteLine("ss " + withoutExtraBlanks);
            return withoutExtraBlanks;
        }

        static void Main(string[] args)
        {
            Arguments arguments = ParseArgs(args);
            //Console.WriteLine(args_1.inputFile + "\n" + args_1.outputFile);
            StreamReader inputFile = new StreamReader(arguments.inputFile);
            StreamWriter outputFile = new StreamWriter(arguments.outputFile);
            string inString;
            while((inString = inputFile.ReadLine()) != null)
            {
                string withoutExtraBlanks = RemoveExtraBlanks(inString);
                //Console.WriteLine(inString);
                //Console.WriteLine(withoutExtraBlanks);
                outputFile.WriteLine(withoutExtraBlanks); 
            }
            inputFile.Close();
            outputFile.Close();
        }
    }
}
