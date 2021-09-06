using System;
using Project1;

namespace Anagrams
{
    public class Anagrams
    {
        public static void Main(String[] args)
        {
            Console.WriteLine("Enter Word for lookp: ");
            String[] words = Console.ReadLine().Split(' ');

            EnglishDictionary ed = new EnglishDictionary("words.txt");

            Console.WriteLine(ed.Anagrams(words[0], words[1]));

            //example demonstrating that it works with mutli word phrases
            Console.WriteLine("two worded entry: " + ed.Anagrams("income tax", "toxic name"));
        }
    }
}
