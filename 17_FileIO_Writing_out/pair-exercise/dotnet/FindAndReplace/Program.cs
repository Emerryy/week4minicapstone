using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAndReplace
{
    class Program
    {
        static void Main(string[] args)
        {
            //C:\Users\Student\week04-c-sharp-pairs-team02\16_FileIO_Reading_in\pair-exercise\dotnet\alice.txt
            
            //C:\Users\Student\week04-c-sharp-pairs-team02\16_FileIO_Reading_in\pair-exercise\alice.txt
            Console.WriteLine("Give me a phrase you wanna get rid of");
            string findPhrase = Console.ReadLine();
            Console.WriteLine("What should that phrase be instead?");
            string replace = Console.ReadLine();
            Console.WriteLine("Alright... now tell me the file we're looking in");
            string aliceLocation = Console.ReadLine();
            Console.WriteLine("nooooowww where do you want this file to be?");
            string output = Console.ReadLine();

            try
            {

                using (StreamReader sr = new StreamReader(aliceLocation))
                {
                    using (StreamWriter sw = new StreamWriter(output, true))
                    {
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            string replacedLine = line.Replace(findPhrase, replace);
                            sw.WriteLine(replacedLine);

                        }
                    }

                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "Whoops that file already exists there");
            }
            Console.WriteLine("we did it");

        }
    }
}
