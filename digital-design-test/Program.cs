using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Reflection;
using GetUniqueWords;


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

        UniqueFinder finder = new UniqueFinder();
        Type type = finder.GetType();
        MethodInfo privateMethod = type.GetMethod("GetUniqueWords", BindingFlags.NonPublic | BindingFlags.Instance);

        // Начало отсчета для функции без многопоточности
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        Dictionary<string, int> SortedDictionary = (Dictionary<string, int>)privateMethod.Invoke(finder, new object[] { text });

        stopwatch.Stop();
        TimeSpan nonThreadingTime = stopwatch.Elapsed;
        // Конец отсчета без многопоточности

        stopwatch.Reset();

        // Начало отсчета для функции с многопоточностью
        stopwatch.Start();

        SortedDictionary = finder.GetUniqueWordsMultiThread(text);

        stopwatch.Stop();
        TimeSpan withThreadingTime = stopwatch.Elapsed;
        // Конец отсчета с многопоточностью

        Console.OutputEncoding = Encoding.UTF8;
        if (SortedDictionary != null)
        {
            using (StreamWriter sw = new StreamWriter(@"data1.txt"))
            {
                foreach (var item in SortedDictionary)
                {
                    sw.WriteLine("{0,-60} {1,-5}", item.Key, item.Value);
                }
            }
        }

        Console.WriteLine("Приватный без многопоточности: " + nonThreadingTime.TotalMilliseconds + " миллисекунд");
        Console.WriteLine("Публичный с многопоточностью: " + withThreadingTime.TotalMilliseconds + " миллисекунд");

        Console.WriteLine();
        Console.WriteLine("Нажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}
