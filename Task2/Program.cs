using System.Net.Mime;
using System.Text;
using System.Text.RegularExpressions;

namespace Task2;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        
        Console.WriteLine("Enter path to a file:");
        string? textFilePath = Console.ReadLine();
        textFilePath = "D:/LB4/LB9/TextFiles/Task2/Text1.txt";
        if (!File.Exists(textFilePath))
        {
            Console.WriteLine("File does not exist");
            return;
        }
        string text1 = File.ReadAllText(textFilePath);
        
        Console.WriteLine("Enter path to a file:");
        string? censorWordsFilePath = Console.ReadLine();
        censorWordsFilePath = "D:/LB4/LB9/TextFiles/Task2/Text2.txt";
        if (!File.Exists(censorWordsFilePath))
        {
            Console.WriteLine("File does not exist");
            return;
        }
        string[] bannedWords = File.ReadAllLines(censorWordsFilePath);

        foreach (string word in bannedWords )
        {
            string trimmed = word.Trim();
            if (string.IsNullOrWhiteSpace(trimmed)) continue;

            // Патерн: шукаємо слово в межах слова або на межі знаків/пробілів
            string pattern = $"(?i)(?<=^|\\W)({Regex.Escape(trimmed)})(?=\\W|$)";
            string replacement = new string('*', trimmed.Length);

            text1 = Regex.Replace(text1, pattern, replacement);
        }

        File.WriteAllText("D:/LB4/LB9/TextFiles/Task2/CensorText.txt", text1);
        Console.WriteLine("Готово! Результат у 'censored_output.txt'");
        Console.ReadKey();
    }
}