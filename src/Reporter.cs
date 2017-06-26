using System;
using System.IO;

namespace mainProgram
{
    /*
     * File System reporter 
     * 
     * Report format:
     * - How many files of each type were encountered.
     * - How much space each type takes up on disk.
     * - Which file of each type took up the most space.
     * 
    */
    public class Reporter
    {

        public Reporter()
        {
            Console.WriteLine("starting another one...");
            try
            {
                string cwd = Directory.GetCurrentDirectory();

                Console.WriteLine("cwd:" + cwd);


                foreach(string path in Directory.EnumerateFiles(cwd))
                {
                    string[] file = path.Split('.');
                    string fileExt = file[1];
                    string [] tree = file[0].Split('/');
                    string fileName = tree[tree.Length - 1];

                    Console.Write("filename: " + fileName + "\t");
                    Console.Write("extension: " + fileExt + "\n");
                }
                ;

            }
            catch(Exception e)
            {
                Console.WriteLine("OOPSY" + e);

              
            }
        }

        public void ShowFiles()
        {
            return;
        }
    }
}

