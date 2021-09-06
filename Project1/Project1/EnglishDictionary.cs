using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;


namespace Project1
{
    public class EnglishDictionary
    {
        private Task loadTask;
        public HashSet<String> dictionary = new HashSet<string>();

        public EnglishDictionary(string fileName)
        {
            loadTask = PreFileReading(fileName);
            loadTask.Wait();
        }

        public async Task PreFileReading(string fileName)
        {
            using (StreamReader input = new StreamReader(fileName))
            {
                while (!input.EndOfStream)
                {
                    string line = await input.ReadLineAsync();
                    dictionary.Add(line);
                }
            }
        }

        public bool IsLegal(string word)
        {
            word = word.ToUpper();

            foreach (string w in dictionary)
                if (word.Equals(w))
                    return true;
            return false;
        }

        public ISet<string> ScrabbleWords(int minLength, string tile)
        {
            ISet<string> words = new HashSet<string>();

            char[] letters = tile.ToCharArray();

            foreach(string word in dictionary)
            {
                int counter = 0;
                if (word.Length >= minLength) {
                    for (int i = 0; i < letters.Length; i++)
                        if (word.Contains(letters[i]))
                            counter++;
                    if (counter >= word.Length)
                        words.Add(word);
                }
            }
            return words;
        }

      public bool Anagrams(string a, string b)
        {
            if(a.Length != b.Length) { return false; }

            var aList = a.ToUpper().ToCharArray();
            var bList = b.ToUpper().ToCharArray();

            Array.Sort(aList);
            Array.Sort(bList);

            string retA = new string(aList);
            string retB = new string(bList);

            return retA == retB;
        }
      
    }
}
