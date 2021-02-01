using System;
using System.IO;
using System.Text;

namespace file_io_part1_exercises_pair
{
    class Program
    {
        static void Main(string[] args)
        {
            //number of words 
            //number of sentences 
            //word count ~30355
            //sentence 1116- 1839

            // C:\Users\Student\week04-c-sharp-pairs-team02\16_FileIO_Reading_in\pair-exercise\dotnet\alice.txt

            Console.WriteLine("Please give me the file location that we're reading");

            string aliceLocation = Console.ReadLine();

            using (StreamReader sr = new StreamReader(aliceLocation))
            {
                int numWords = 0;
                int numSentence = 0;
                // while (!sr.EndOfStream)
                // {
                string thisString = File.ReadAllText(aliceLocation);
                string[] wordArray = thisString.Split(" ");
                foreach (string spaces in wordArray) 
                { if (spaces.Contains("1"))
                    {
                        numWords--; 
                    }
                    if(spaces.Contains("2"))
                    {
                        numWords--;
                    }
                    if(spaces.Contains("3"))
                    {
                        numWords--;
                    }
                    if(spaces.Contains("4"))
                    {
                        numWords--;
                    }
                    if (spaces.Contains("5"))
                    {
                        numWords--;
                    }
                    if (spaces.Contains("6"))
                    {
                        numWords--;
                    }
                    if (spaces.Contains("7"))
                    {
                        numWords--;
                    }
                    if (spaces.Contains("8"))
                    {
                        numWords--;
                    }
                    if (spaces.Contains("9"))
                    {
                        numWords--;
                    }
                    if (spaces.Contains("0"))
                    {
                        numWords--;
                    }
                    if (spaces.Contains("-"))
                    {
                        numWords--;
                    }


                }
                numWords += wordArray.Length;

                string[] periodArray = thisString.Split('.', '?', '!');
                numSentence += periodArray.Length;
                // }
                Console.WriteLine("Has " + numWords + " words.");
                Console.WriteLine("Has " + numSentence + " sentences.");

            }
        }
    }
}
