using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

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

        private const string SystemExt = "system";

        public Reporter()
        {
            Console.WriteLine("Reporter ready...");

        }
            

        /*
         * List files in directory
         * 
         */
        public void ParseDirectory(string dir)
        {
            Dictionary<string, int> counter = new Dictionary<string, int>();
            DirectoryInfo dirInfo = new DirectoryInfo(dir);

            try
            {
                Console.WriteLine("cwd:" + dir);


                foreach(FileInfo file in dirInfo.EnumerateFiles())
                {
                    string fileName = file.Name;
                    string fileExt = file.Extension;
                    long size = file.Length;
                        

                    if (counter.ContainsKey(fileExt) == true) 
                    {
                        counter[fileExt] = (int)counter[fileExt] + 1;
                    } 
                    else 
                    {
                        counter[fileExt] =  1;
                    }



                    Console.Write("filename: " + fileName + "\t");
                    Console.Write("extension: " + fileExt + "\n");
                }

                foreach(KeyValuePair<string, int> entry in counter) 
                {
                    Console.WriteLine("{0}:{1}",entry.Key, entry.Value);
                }

            }
            catch(Exception e)
            {
                Console.WriteLine("Error" + e);


            }
        }

        public void RecordFileTypes()
        {
            


        }
    }
}

