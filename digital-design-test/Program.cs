using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;



public class MainClass
{
    public static void Main()
    {

        string text = "";

        string path = @"text.txt"; // \digital-design-test\bin\Debug\net6.0
        using (StreamReader reader = new StreamReader(path))
        {
            text = reader.ReadToEnd();
        }

        string[] words = text.ToLower().Split(new char[] { ' ', '.', ',', ';', ':', '-', '!', '?', '(', ')', '[', ']', '{', '}', '\t', '\n', '\r', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' }, StringSplitOptions.RemoveEmptyEntries);

        Dictionary<string, int> UniqueWords = new Dictionary<string, int>();
        foreach (string word in words)
        {
            if (UniqueWords.ContainsKey(word))
            {
                UniqueWords[word]++;
            }
            else
            {
                UniqueWords.Add(word, 1);
            }
        }

        var SortedDictionary = UniqueWords.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

        Console.OutputEncoding = Encoding.UTF8;
        using (StreamWriter sw = new StreamWriter(@"data1.txt"))
        {
            foreach (var item in SortedDictionary)
            {
                sw.WriteLine("{0,-60} {1,-5}", item.Key, item.Value);
            }
        }

    }
}
