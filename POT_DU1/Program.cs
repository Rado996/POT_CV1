using System;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace POT_DU1
{
    class Program
    {
        
        static void Main(string[] args)
        {

            string directoryPath = "";
            int layer = 1;
            bool color = false;
            const int whitespaces = 2;
            int newNumWhitespaces = 0;

            if (args.Length > 0)
            {
                foreach (string VARIABLE in args)
                {
                    if (!VARIABLE.Substring(0, 1).Equals("/"))
                    {
                        directoryPath = VARIABLE;
                    }
                    else if (VARIABLE.Substring(1, 1).Equals("r"))
                    {
                        layer = Int32.Parse(VARIABLE.Substring(2));
                    }
                    else if (VARIABLE.Substring(1, 1).Equals("t"))
                    {
                        newNumWhitespaces = Int32.Parse(VARIABLE.Substring(2));
                    }
                    else if (VARIABLE.Substring(1, 1).Equals("c"))
                    {
                        color = true;
                    }
                }

                System.IO.Directory.SetCurrentDirectory(directoryPath);

                string currentDirName = System.IO.Directory.GetCurrentDirectory();
                Console.WriteLine(currentDirName);

                string[] files = System.IO.Directory.GetFiles(currentDirName);
                string[] directories = System.IO.Directory.GetDirectories(currentDirName);
                if (newNumWhitespaces == 0)
                {
                    printData(directories, layer, 1, whitespaces, color);
                    printData(files, layer, 1, whitespaces, color);
                }
                else
                {
                    printData(directories, layer, 1, newNumWhitespaces, color);
                    printData(files, layer, 1, newNumWhitespaces, color);
                }
            }
            else
                Console.WriteLine("Wrong input.");
        }

        private static void printData(string[] data, int pTargetLayer,int pCurrentLayer, int pWhiteSpaces, bool pColor)
        {
            int curentLayer = 1;
            int targetLayer = 1;
            foreach (string s in data)
            {
                targetLayer = pTargetLayer;
                curentLayer = pCurrentLayer;
                System.IO.FileInfo fi = null;
                try
                {
                    fi = new System.IO.FileInfo(s);
                }
                catch (System.IO.FileNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                string fileName = fi.Name;
                string spacer = "";

                try
                {
                    int pads = 15;
                    string fileSize = fi.Length.ToString();
                    Console.WriteLine($"{fi.LastWriteTime} {fileSize.PadLeft(pads)} {spacer.PadLeft(pWhiteSpaces * curentLayer)}{fileName}");
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"{fi.LastWriteTime} {spacer.PadLeft(16+(pWhiteSpaces * curentLayer))}{fileName}{"\\"}");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    if (targetLayer>curentLayer)
                    {
                            System.IO.Directory.SetCurrentDirectory(fi.FullName);
                            string[] files = System.IO.Directory.GetFiles(fi.FullName);
                            string[] directories = System.IO.Directory.GetDirectories(fi.FullName);
                            printData(files, targetLayer, curentLayer+1, pWhiteSpaces, pColor);
                            printData(directories, targetLayer, curentLayer+1, pWhiteSpaces, pColor);
                    }
                    continue;
                }

            }
        }
    }
}
