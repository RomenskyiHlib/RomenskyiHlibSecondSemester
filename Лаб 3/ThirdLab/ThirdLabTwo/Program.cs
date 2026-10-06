using System.IO;

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("--- Censor ---");
Console.ForegroundColor = ConsoleColor.White;

Console.WriteLine("- Enter the path to the file: (With the Text)");
string path1 = Console.ReadLine();

Console.WriteLine("- Enter the path to the file: (With the Words)");
string path2 = Console.ReadLine();

if (!File.Exists(path1) || !File.Exists(path2))
{
    Console.WriteLine("Error! File is not exist!");
    return;
}

string text = File.ReadAllText(path1);
string[] words = File.ReadAllLines(path2);

foreach (string word in words)
{

    string updateWord = word.Trim();

    if (!string.IsNullOrEmpty(updateWord))
    {
        string stars = new string('*', word.Length);
        text = text.Replace(updateWord,stars, StringComparison.OrdinalIgnoreCase);

    }
}
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("---New Text---");
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine(text);