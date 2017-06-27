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

        public struct FileDetail
        {
            public long totalSize; 
            public int count;

            public FileDetail(long size, int num)
            {
                totalSize = size;
                count = num;
            }
        }

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
            Dictionary<string, FileDetail> counter = new Dictionary<string, FileDetail>();
            DirectoryInfo dirInfo = new DirectoryInfo(dir);

            try
            {
                Console.WriteLine("cwd:" + dir);


                foreach(FileInfo file in dirInfo.EnumerateFiles())
                {
                    string fileName = file.Name;
                    string fileExt = file.Extension;
                    long size = file.Length;

                    FileDetail fileDetail;
                        

                    if (counter.ContainsKey(fileExt) == true) 
                    {
                        fileDetail = (FileDetail)counter[fileExt];

                        fileDetail.count++;
                        fileDetail.totalSize = fileDetail.totalSize + file.Length;
                    } 
                    else 
                    {
                        counter[fileExt] =  new FileDetail(file.Length, 1);
                    }

                    Console.Write("filename: " + fileName + "\t");
                    Console.Write("extension: " + fileExt + "\n");
                }

                foreach(KeyValuePair<string, FileDetail> entry in counter) 
                {
                    Console.WriteLine("{0} extension had {1} file(s) of {2} bytes",entry.Key, entry.Value.count, entry.Value.totalSize);
                }

            }
            catch(Exception e)
            {
                Console.WriteLine("Error" + e);
            }
        }
    }
}

