using System;

namespace POT_DU1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //if (!System.IO.Directory.Exists(@"C:\Users\radof\Source\Repos\POT_CV1"))
            //{
            //    System.IO.Directory.CreateDirectory(@"C:\Users\Public\TestFolder\");
            //}
            
            System.IO.Directory.SetCurrentDirectory(@"C:\Users\radof\Source\Repos\POT_CV1");

            string currentDirName = System.IO.Directory.GetCurrentDirectory();
            Console.WriteLine(currentDirName);

            string[] files = System.IO.Directory.GetFiles(currentDirName);
            

            foreach (string s in files)
            {
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
                Console.WriteLine("{0} : {1}", fi.Name, fi.Directory);
            }
        }
    }
}
