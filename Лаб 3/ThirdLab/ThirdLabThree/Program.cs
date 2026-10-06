using System;
using ThirdLabThree.model;

List<Song> songs = new List<Song>();
int option;
do
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("--- MUSIC DODATOK ---");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("What would you like to do: \n1.Add song\n2.Edit song\n3.Delete song\n4.Show Information about song\n5.Show Information about song(Full)\n6.Search\n7.Save a collection of songs to a file\n0.Exit:");
    Console.ForegroundColor = ConsoleColor.White;
    option = int.Parse(Console.ReadLine());
    switch (option)
    {
        case 1:
            Add();
            break;
        case 2:
            Edit();
            break;
        case 3:
            Delete();
            break;
        case 4:
            ShowSongs();
            break;
        case 5:
            FullShowSongs();
            break;
        case 6:
            Search();
            break;
        case 7:
            SaveToFile();
            break;
    }
} while (option >1 || option < 8);
Console.ReadKey();

void ShowSongs()
{
        Console.WriteLine("List Songs:");

    for (int i = 0; i < songs.Count; i++)
    {
        Console.WriteLine($"[Index: {i}]");
        Console.WriteLine(songs[i].ToShortString());
    }
}

void FullShowSongs()
{
    Console.WriteLine("List Songs:");

    for (int i = 0; i < songs.Count; i++)
    {
        Console.WriteLine($"[Index: {i}]");
        Console.WriteLine(songs[i]);
    }
}
void Add()
{
    Console.WriteLine("Title:");
    string title = Console.ReadLine();

    Console.WriteLine("Author:");
    string author = Console.ReadLine();

    Console.WriteLine("Composer:");
    string composer = Console.ReadLine();

    Console.WriteLine("Year:");
    int year;
    while (!int.TryParse(Console.ReadLine(), out year))
    {
        Console.WriteLine("Wrong year!!!");
    }

    Console.WriteLine("List the performers, separated by commas:");
    string performersInput = Console.ReadLine();
    
    var performersList = (from artist in performersInput.Split(',')
                          let trimmed = artist.Trim()
                          where trimmed != string.Empty
                          select trimmed).ToList();

    Console.WriteLine("Enter file path for lyrics: (Read from file)");
    string lyrics = "";
    if (int.Parse(Console.ReadLine()) == 1)
    {

        Console.WriteLine("File Path:");
        string filePath = Console.ReadLine();

        if (File.Exists(filePath))
        {
            lyrics = File.ReadAllText(filePath);
        }
    }
    else 
    {
        Console.WriteLine("File not found!");
    }

    Song song = new Song(title,author,composer,year,lyrics,performersList);

    songs.Add(song);
}

void Delete()
{
    ShowSongs();
    Console.Write("Enter the song ID to delete:");
    if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < songs.Count)
    songs.RemoveAt(index);
    else
    Console.WriteLine("Wrong index!");
   
}

void Edit()
{
    ShowSongs();
    Console.WriteLine("Enter the song ID to edit:");
    if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < songs.Count)
    {
        Song song = songs[index];

        Console.WriteLine($"New Title - (Old Title: {song.Title}) - (Leave this field blank if you do not wish to make any changes)");
        string title = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(title)) song.Title = title;

        Console.WriteLine($"New Author - (Old Author: {song.Author}) - (Leave this field blank if you do not wish to make any changes)");
        string author = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(author)) song.Author = author;

        Console.WriteLine($"New Composer - (Old Composer:{song.Composer}) - (Leave this field blank if you do not wish to make any changes)");
        string composer = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(composer)) song.Composer = composer;

        Console.WriteLine($"New Year - (Old Year:{song.Year}) - (Leave this field blank if you do not wish to make any changes)");
        string yearStr = Console.ReadLine();
        if (int.TryParse(yearStr, out int year)) song.Year = year;

        Console.WriteLine("New performers, separated by commas: - (Leave this field blank if you do not wish to make any changes)");
        string performersInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(performersInput))
        {
            song.Performers = (from artist in performersInput.Split(',')
                                  let trimmed = artist.Trim()
                                  where trimmed != string.Empty
                                  select trimmed).ToList();
        }
        Console.WriteLine("Will you be changing the lyrics? (0 – no, 1 – yes (Read from file)):");
        if (int.Parse(Console.ReadLine()) == 1)
        {
            LyricsFromFile(index);
        }
    }
    else
    Console.WriteLine("Wrong Index!");

}

void ShowSongsByPerformer()
{
    Console.Write("Enter full performer's name:");
    string performer = Console.ReadLine()?.ToLower();

    var songsByPerf= (from song in songs
                   from perfName in song.Performers
                   where perfName.ToLower().Contains(performer)
                   select song).ToList();
    Console.WriteLine($"Song by {performer} (Result: {songsByPerf.Count}):");
    foreach (var song in songsByPerf)
    {
        Console.WriteLine(song);
    }
}

void SaveToFile()
{
    Console.WriteLine("Enter a filename to save the file as (for example, songs.txt):");
    string file = Console.ReadLine();

        using (StreamWriter sw = new StreamWriter(file))
        {
            foreach (var song in songs)
            {
                sw.WriteLine("--- SONG ---");
                sw.WriteLine(song.Title);
                sw.WriteLine(song.Author);
                sw.WriteLine(song.Composer);
                sw.WriteLine(song.Year);
                sw.WriteLine(string.Join(";", song.Performers));
                sw.WriteLine("Lyrics:");
                sw.WriteLine(song.Lyrics);
                sw.WriteLine("------------");
            }
        }
    }

void LyricsFromFile(int index)
{
    Console.Write("Enter the path to a text file (for example, lyrics.txt):");
    string filePath = Console.ReadLine();

    if (File.Exists(filePath))
    songs[index].Lyrics = File.ReadAllText(filePath);
    else
    Console.WriteLine("File not found!"); 
}

void Search()
{
    Console.WriteLine("Search for: \n1.Title\n2.Author\n3.Composer\nSelect a criterion:");
    int option = int.Parse(Console.ReadLine());
    Console.Write("Enter what you’d like to search for songs by:");
    string word = Console.ReadLine()?.ToLower().Trim();

    var search = new List<Song>();

    switch (option)
    {
        case 1:
            search = (from song in songs
                     where song.Title.ToLower() == word.ToLower()
                     select song).ToList();
            break;
        case 2:
            search = (from song in songs
                      where song.Author.ToLower() == word.ToLower()
                      select song).ToList();
            break;
        case 3:
            search = (from song in songs
                      where song.Composer.ToLower() == word.ToLower()
                      select song).ToList();
            break;
        default:
            Console.WriteLine("Wrong!!");
            return;
    }

    Console.WriteLine($"Songs count: {search.Count}");
    foreach (var song in search)
    {
        Console.WriteLine(song.ToShortString());
    }
}