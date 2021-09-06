using System;
using System.Collections.Generic;
using Project1;

namespace WordLookup
{
    public class ScrabbleWords
    {
        public static void Main(String[] args)
        {
            Console.WriteLine("Enter a number and letters: ");
            String[] words = Console.ReadLine().Split(' ');

            EnglishDictionary ed = new EnglishDictionary("words.txt");

            //Console.WriteLine(ed.CanForm("earth".ToUpper(), "heraRTH".ToUpper()));

            ISet<string> ret = ed.ScrabbleWords(Int32.Parse(words[0]), words[1].ToUpper());
         

              foreach (string word in ret)
            {
                if(word.Length == Int32.Parse(words[0]))
                    Console.WriteLine(word);
            }
            
        }
    }
}
