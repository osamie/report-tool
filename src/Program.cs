using System;
using System.IO;

namespace mainProgram
{
    class MainClass
    {
        public static void Main(string [] args)
        {
            
            Reporter r = new Reporter();
            String input = "";

            while(input != "#Q")
            {
                Console.WriteLine("Enter an absolute Directory path below. For example, /User/oomigie");
                input = Console.ReadLine();
                r.ParseDirectory(input);
            }
             
        }
    }
}
