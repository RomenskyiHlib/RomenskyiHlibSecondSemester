using System;

Console.WriteLine("- Enter the path to the file:");
string path = Console.ReadLine();

if (!File.Exists(path))
{
    Console.WriteLine("Error! File is not exist!");
    return;
}

string text = File.ReadAllText(path);

string vowels = "aeiouAEIOU";

int capitalLetCount = 0;
int lowercaseLetCount = 0;
int digitCount = 0;
int vowelsCount = 0;
int consonantsCount = 0;
int sentenceCount = 0;

foreach (char character in text)
{
    if (char.IsUpper(character)) { capitalLetCount++; }

    if (char.IsLower(character)) { lowercaseLetCount++; }

    if (char.IsDigit(character)) { digitCount++; }

    if (char.IsLetter(character))
    { 
        if (vowels.Contains(character))
        {
            vowelsCount++;

        }
        else
        {
            consonantsCount++;

        }

    }

    sentenceCount = text.Split(new[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries).Count();
}

Console.WriteLine($"Sentence Count: {sentenceCount}");
Console.WriteLine($"Capital letters Count: {capitalLetCount}");
Console.WriteLine($"Lowercade letters Count: {lowercaseLetCount}");
Console.WriteLine($"Vowels Count: {vowelsCount}");
Console.WriteLine($"Consonants COunt: {consonantsCount}");
Console.WriteLine($"Digits Count: {digitCount}");