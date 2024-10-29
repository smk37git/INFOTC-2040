using System.Configuration.Assemblies;
using Microsoft.VisualBasic;

namespace AnalyzeMusicPlaylist;

class Program
{
    static void Main(string[] args)
    {
        // Sebastian Main - INFOTC 2040 - Analyze Music Playlist

        // Clear Console
        Console.Clear();

        // Prompt for the .txt filepath
        Console.WriteLine("----------------MUSIC PLAYLIST ANALYZER----------------");
        // Require the the program is run using command line arguments for the data file and the report file
        // If both command line arguments are not provided, then end the program
        if(args.Length != 2){
            Console.WriteLine("Error: Program requires 2 command line arguments as shown below.\n");
            Console.WriteLine("dotnet run <data file name> <report file name>");
            Environment.Exit(0);
        }

        // Get the command line arguments from args[]
        string dataFile = args[0];
        string reportFile = args[1];


        // This variable will contain the data for the reports.
        // Concatentate the results from each query to this string
        string reportDocument = "";

        // Create the list for SampleMusicPlaylist.txt
        List<(string Name, string Artist, string Album, string Genre, int Size, int Time, int Year, int Plays)> musicList = new List<(string Name, string Artist, string Album, string Genre, int Size, int Time, int Year, int Plays)>();

        // Open the file
        try{
           using(StreamReader fileReader = new StreamReader(dataFile)){
            int lineNumber = 0;
            int piecesOfData = 8;

            // Skip the first line which is the header row
            string headerData = fileReader.ReadLine()!;

            // Read names from the file line by line
            while(!fileReader.EndOfStream){
                lineNumber ++;
                string lineofData = fileReader.ReadLine()!;

                // Split each line at the "\t" (tabs in .txt files)
                string[] musicData = lineofData.Split("\t");

                //check that there are 8 pieces of data
                if(musicData.Length != 8){
                    string errorMessage = $"Error in line {lineNumber}: Contains {musicData.Length} pieces of data with it should contain {piecesOfData}";
                    LogError(errorMessage);
                    continue;
                }

                try{
                // Index the data into list
                string Name = musicData[0];
                string Artist = musicData[1];
                string Album = musicData[2];
                string Genre = musicData[3];
                int Size = int.Parse(musicData[4]);
                int Time = int.Parse(musicData[5]);
                int Year = int.Parse(musicData[6]);
                int Plays = int.Parse(musicData[7]);


                // Add each index to the list
                musicList.Add((Name, Artist, Album, Genre, Size, Time, Year, Plays));

                }catch(Exception err){
                    string errorMessage = $"There was an error on line {lineNumber} in the data file: {err.Message}";
                    LogError(errorMessage);
                    continue;
                    }
                }  
            }

        }catch(Exception err){
            // File not found error
            LogError($"File not found: {args[0]}. Exception: {err.Message}");
            Console.WriteLine("Error: File not found. Please check the file path.");
        }
        

        // Make the report
        reportDocument += "----------MUSIC PLAYLIST ANALYZER REPORT----------\n";

        // QUESTIONS

        // QUESTION 1
        // Write Question
        reportDocument += "\n1. How many songs received 200 or more plays?\n";
        
        // Get the songs that have >= 200 plays
        var twoHundredPlays = from song in musicList
                            where song.Plays >= 200
                            select(song.Name, song.Artist, song.Album, song.Genre, song.Size, song.Time, song.Year, song.Plays);
        // Write Answer
        foreach(var song in twoHundredPlays){
            reportDocument+= $"Name: {song.Name}, Artist: {song.Artist}, Album: {song.Album}, Genre: {song.Genre}, Size: {song.Size}, Time: {song.Time}, Year: {song.Year}, Plays: {song.Plays}\n";
        }

        
        // QUESTION 2
        // Write Question
        reportDocument += "\n2. How many songs are in the playlist with the Genre of 'Alternative'?\n";

        // Get the songs with the "Alternative" Genre
        int altSongs = 0;
        foreach(var song in musicList){
            if(song.Genre == "Alternative"){
                altSongs ++;
            }
        }
        // Write Answer
        reportDocument += $"{altSongs}\n";

        
        // QUESTION 3
        // Write Question
        reportDocument += "\n3. How many songs are in the playlist with the Genre of 'Hip-Hop/Rap'?\n";

        // Get the songs with the "Hip-Hop/Rap" Genre
        int hipAndrapSongs = 0;
        foreach(var song in musicList){
            if(song.Genre == "Hip-Hop/Rap"){
                hipAndrapSongs ++;
            }
        }
        // Write Answer
        reportDocument += $"{hipAndrapSongs}\n";

        // QUESTION 4
        // Write Question
        reportDocument += "\n4. What songs are in the playlist from the album 'Welcome to the Fishbowl'?\n";

        // Get the songs in the album "Welcome to the Fishbowl"
        var FishBowlSongs = from song in musicList
                        where song.Album == "Welcome to the Fishbowl"
                        select(song.Name, song.Artist, song.Album, song.Genre, song.Size, song.Time, song.Year, song.Plays);
        // Write Answer
        foreach(var song in FishBowlSongs){
            reportDocument+= $"Name: {song.Name}, Artist: {song.Artist}, Album: {song.Album}, Genre: {song.Genre}, Size: {song.Size}, Time: {song.Time}, Year: {song.Year}, Plays: {song.Plays}\n";
        }

        
        // QUESTION 5
        // Write Question
        reportDocument += "\n5. What are the songs in the playlist from before 1970?\n";

        // Get songs from < 1970
        var Pre1970 = from song in musicList
                        where song.Year < 1970
                        select(song.Name, song.Artist, song.Album, song.Genre, song.Size, song.Time, song.Year, song.Plays);
        // Write Answer
        foreach(var song in Pre1970){
            reportDocument+= $"Name: {song.Name}, Artist: {song.Artist}, Album: {song.Album}, Genre: {song.Genre}, Size: {song.Size}, Time: {song.Time}, Year: {song.Year}, Plays: {song.Plays}\n";
        }           


        // QUESTION 6
        // Write Question
        reportDocument += "\n6. What are the song names that are more than 85 characters long?\n";

        // Get song names > 85 characters long
        var LongSongNames = from song in musicList
                        where song.Name.Count() > 85
                        select song.Name;
        // Write Answer
        foreach(var song in LongSongNames){
            reportDocument+= $"Name: {song}\n";
        }


        // QUESTION 7
        // Write Question
        reportDocument += "\n7. What is the longest song? (longest in Time)\n";

        // Get the song with the maximum time
        var maxTime = (from song in musicList
                            orderby song.Time descending
                            select song).FirstOrDefault();
        // Write Answer
        reportDocument += $"Name: {maxTime.Name}, Artist: {maxTime.Artist}, Album: {maxTime.Album}, Genre: {maxTime.Genre}, Size: {maxTime.Size}, Time: {maxTime.Time}, Year: {maxTime.Year}, Plays: {maxTime.Plays}\n";


        // QUESTION 8
        // Write Question
        reportDocument += "\n8. What are the unique Genres in the playlist?\n----------------------------------------------\n";

        // Get the unique genres
        var unqiueGenres = (from song in musicList select song.Genre).Distinct();

        // Write Answer
        foreach(var genre in unqiueGenres){
            reportDocument += $"{genre}\n";
        }


        // QUESTION 9
        // Write Question
        reportDocument += "\n9. How many songs were produced each year in the playlist?\n----------------------------------------------------------";

        // Get the # of songs produced each year
        var SongsEachYear = from song in musicList
                        group song by song.Year into SongYearGroup
                        orderby SongYearGroup.Key descending
                        select SongYearGroup;
        // Write Answer
        foreach(var yearGroup in SongsEachYear){
            reportDocument += $"\n{yearGroup.Key}: {yearGroup.Count()}";
        }


        // QUESTION 10
        // Write Question
        reportDocument += "\n\n10. What are the total plays per year in the playlist?\n------------------------------------------------------";

        // Get the total plays in the data
        var TotalPlays = from song in musicList
                        group song by song.Year into SongYearGroup
                        orderby SongYearGroup.Key descending
                        select SongYearGroup;
        foreach(var yearGroup in TotalPlays){
            int totalPlays = 0;
            foreach(var song in yearGroup){
                totalPlays += song.Plays;
            }

            // Write Answer
            reportDocument += $"\n{yearGroup.Key}: {totalPlays}";
        }


        // QUESTION 11
        // Write Question
        reportDocument += "\n\n11. Print a list of the unique artists in the playlist.\n--------------------------------------------------";
        
        // Get the unique Artists
        var UniqueArtists = from song in musicList
                            group song by song.Artist into artistGroup
                            orderby artistGroup.Key ascending
                            select artistGroup;
        // Write Answer
        foreach(var artist in UniqueArtists){
            if (!artist.Key.Contains("\"")){
                reportDocument += $"\n{artist.Key}";
            }
        }


        // Call the WriteReport function to write the report
        WriteReport(reportDocument, reportFile);

    }

    //create a method top log errors
    public static void LogError(string errorMessage){
        DateTime logDate = DateTime.Now;

        using(StreamWriter logger = File.AppendText("log.txt")){
            logger.WriteLine($"{logDate}: {errorMessage}");
        }
    } 

    // Function to write the report document
    // Input: report document string
    // Output: None
    static void WriteReport(string reportDocument, string reportFile){
        //write the report
        using(StreamWriter reportWriter = new StreamWriter(reportFile)){
            reportWriter.Write(reportDocument);
        }
    }
}
