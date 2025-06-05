using System.Text;


namespace LB9;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("Enter path to a file:");
        string? path = Console.ReadLine();
        path = "D:/LB4/LB9/TextFiles/Task2/Text1.txt";
        if (!File.Exists(path))
        {
            Console.WriteLine("File does not exist");
            return;
        }
        string text = File.ReadAllText(path);
        Console.WriteLine(text);

        int countLowercase = 0;
        int countUppercase = 0;
        int countNumbers = 0;
        int countVowels = 0;
        int countConsonants = 0;
        int countSentences = 0;
        
        char[] vowels = 
        {
            'А', 'Е', 'Є', 'И', 'І', 'Ї', 'О', 'У', 'Ю', 'Я'
        };
        foreach (var c in text)
        {
            if (vowels.Contains(char.ToUpper(c)))
            {
                countVowels++;
            }
            else
            {
                countConsonants++;
            }
        }
        foreach (var c in text)
        {
            if (char.IsUpper(c))
            {
                countUppercase++;
            }
            else
            {
                countLowercase++;
            }
        }
        foreach (var c in text)
        {
            if (c == '.' || c == '!' || c == '?')
            {
                countSentences++;
            }
        }
        foreach (var c in text)
        {
            if (char.IsNumber(c))
                countNumbers++;
        }
        Console.WriteLine($"Кількість речень: {countSentences}");
        Console.WriteLine($"Кількість великих літер: {countUppercase}");
        Console.WriteLine($"Кількість маленьких літер: {countLowercase}");
        Console.WriteLine($"Кількість голосних літер: {countVowels}");
        Console.WriteLine($"Кількість приголосних літер: {countConsonants}");
        Console.WriteLine($"Кількість цифр: {countNumbers}");
        Console.ReadKey();
    }
}