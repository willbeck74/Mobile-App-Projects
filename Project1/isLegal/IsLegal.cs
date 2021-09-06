using System;
using Project1;

namespace isLegal
{
    public class IsLegal
    {
        public static void Main(String[] args)
        {
            Console.WriteLine("Enter Word for lookp: ");
            String[] words = Console.ReadLine().Split(' ');

            EnglishDictionary ed = new EnglishDictionary("words.txt");

            foreach (string word in words)
            {
                bool ret = ed.IsLegal(word.ToUpper());
                if (ret)
                    Console.WriteLine("{0} (legal)", word);
                else
                {
                    Console.WriteLine("{0} (illegal)", word);
                }
            }
            
        }
    }
}
