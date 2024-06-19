using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string text1 = "Hello, how are you? I am fine.";
        string text2 = "Hi there! How are you doing? I am good.";

        int n = 2; // Размер N-грамм

        var nGrams1 = GetNGrams(text1, n);
        var nGrams2 = GetNGrams(text2, n);

        double jaccardCoefficient = CalculateJaccardCoefficient(nGrams1, nGrams2);

        Console.WriteLine($"Количество N-грамм в первом тексте: {nGrams1.Count}");
        Console.WriteLine($"Количество N-грамм во втором тексте: {nGrams2.Count}");
        Console.WriteLine($"Коэффициент Жаккара для текстов: {jaccardCoefficient}");
    }

    static List<string> GetNGrams(string text, int n)
    {
        //TODO: напишите функцию для поиска N-grams
        throw new NotImplementedException(); // заглушка, надо убрать
    }

    static double CalculateJaccardCoefficient(List<string> nGrams1, List<string> nGrams2)
    {
        //TODO: напишите функцию подсчета коэффициента Жаккара
        throw new NotImplementedException(); // заглушка, надо убрать
    }
}