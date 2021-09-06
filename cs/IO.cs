using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Threading;

/*
 Answers to Questions:
 1) There was significant difference in computing time between the three different methods.

RunTime List: 00:00:00.0119501
RunTime SortedSet: 00:00:00.4789798
RunTime HashSet: 00:00:00.0448746

As we can see, a normal list had the fasted computing time, followed by HashSet, and finally, SortedSet
which was much, much slower.

2) Yes there was substantive time difference between the data structures. Both the List and HashSet had a much faster time than the SortedSet.
For looking up a word in a dictionary, as we are, it would be suggested to use either a List or HashSet over a SortedSet for best computation time.

3) There are 972 three letter words found in the words.txt

 */

namespace cs {
    public class IO {
        public static void IOMain(string[] args) {
            using (StreamWriter output = new StreamWriter("sorted.txt"))
            using (StreamReader input = new StreamReader("items.csv")) {
                while (!input.EndOfStream) {
                    string line = input.ReadLine();
                    string[] toks = line.Split(',');
                    int[] values = new int[toks.Length];
                    for (int i = 0; i < toks.Length; i++)
                        values[i] = Int32.Parse(toks[i]);
                    Array.Sort(values);
                    foreach (int value in values) {
                        output.Write(value + " ");
                    }
                    output.WriteLine();
                }
            }

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            ReadWordsList("words.txt");
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            Console.WriteLine("RunTime List: " + ts);
            stopWatch.Restart();
            ReadWordsSortedSet("words.txt");
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            Console.WriteLine("RunTime SortedSet: " + ts);
            stopWatch.Restart();
            ReadWordsHashSet("words.txt");
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            Console.WriteLine("RunTime HashSet: " + ts);

            int count = 0;
            string[] words = { "COMPUTERS", "ZYMOTIC", "AARDVARK", "WORD", "DATABASIC" };
            stopWatch.Restart();
            for (int i = 0; i < words.Length; i++)
                if (ReadWordsList("words.txt").Contains(words[i]))
                    count++;
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            Console.WriteLine("List Words Found: " + count + " Time: " + ts);

            count = 0;
            stopWatch.Restart();
            for (int i = 0; i < words.Length; i++)
                if (ReadWordsSortedSet("words.txt").Contains(words[i]))
                    count++;
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            Console.WriteLine("SortedSet Words Found: " + count + " Time: " + ts);

            count = 0;
            stopWatch.Restart();
            for (int i = 0; i < words.Length; i++)
                if (ReadWordsHashSet("words.txt").Contains(words[i]))
                    count++;
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            Console.WriteLine("HashSet Words Found: " + count + " Time: " + ts);

            int three = 0;
            List<string> L = ReadWordsList("words.txt");
            foreach (string word in L)
            {
                if (word.Length == 3)
                    three++;
            }
            Console.WriteLine("3 letter words found: " + three);

        }

        //this method is complete and correct
        public static List<string> ReadWordsList(string filename) {
            List<string> result = new List<string>();
            using(StreamReader input = new StreamReader(filename))
                while (!input.EndOfStream)
                {
                    string line = input.ReadLine();
                    result.Add(line);
                }
            return result;
        }

        //this method is complete and correct
        public static SortedSet<string> ReadWordsSortedSet(string fileName)
        {
            SortedSet<string> result = new SortedSet<string>();
            using(StreamReader input = new StreamReader(fileName))
                while (!input.EndOfStream)
            {
                string line = input.ReadLine();
                result.Add(line);
            }
            return result;
        }

        //this method is complete and correct
        public static HashSet<string> ReadWordsHashSet(string fileName)
        {
            HashSet<string> result = new HashSet<string>();
            using (StreamReader input = new StreamReader(fileName))
                while (!input.EndOfStream)
                {
                    string line = input.ReadLine();
                    result.Add(line);
                }
            return result;
        }

        //this method is complete and correct
        public static void DisplayStuff<T>(IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
