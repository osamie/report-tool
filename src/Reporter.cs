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
            public string extension;

            public FileDetail(long size, int num, string ext)
            {
                totalSize = size;
                count = num;
                extension = ext;
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

            FileInfo currentMaxFile = null;

            try
            {
                Console.WriteLine("cwd:" + dir);


                foreach(FileInfo file in dirInfo.EnumerateFiles())
                {
                    string fileName = file.Name;
                    string fileExt = file.Extension;
                    long size = file.Length;

                    FileDetail fileDetail;

                    if (currentMaxFile == null)
                    {
                        currentMaxFile = file;
                    }

                    if (counter.ContainsKey(fileExt) == true) 
                    {
                        fileDetail = (FileDetail)counter[fileExt];

                        fileDetail.count++;
                        fileDetail.totalSize = fileDetail.totalSize + file.Length;
                    } 
                    else 
                    {
                        fileDetail = new FileDetail(file.Length, 1, file.Extension);
                        counter[fileExt] = fileDetail; 
                    }

                    if (file.Length > currentMaxFile.Length) 
                    {
                        currentMaxFile = file;
                    }

                    Console.Write("filename: " + fileName + "\t");
                    Console.Write("extension: " + fileExt + "\n");
                }

                foreach(KeyValuePair<string, FileDetail> entry in counter) 
                {
                    Console.WriteLine("{0} extension had {1} file(s) of {2} bytes",entry.Key, entry.Value.count, entry.Value.totalSize);
                }

                if (currentMaxFile != null)
                {
                    Console.WriteLine("filename {0} was the largest file - {1} bytes.", currentMaxFile.Name, currentMaxFile.Length);
                }


            }
            catch(Exception e)
            {
                Console.WriteLine("Error" + e);
            }
        }
    }
}

