using System.Diagnostics;
using System.Globalization;
using System.Linq.Expressions;
using System.Net;
using System.Runtime.InteropServices;

namespace RandomMusicPlaylist;

class Program
{
    static void Main(string[] args)
    {
        // Sebastian Main INFOTC 2040
        // This program is a redone version of RandonMusicPlaylist.
        // This one will give the user options and create a folder where users can save playlists.

        // V3 Functions:
        // getPlaylistName -- prompt user to enter name and save playlist, if no name, reprompt, verify ".txt" at end
        // getSaveQuitOption -- prompt user with 4 choices: save+, save-, -save+, -save-

        // Start with program title
        Console.WriteLine("\nRandom Music Playlist\n---------------------");

        // Import songs from csv file
        List<string> ListOfSongs = loadDataFromFile();

        // Initialize Playlists
        int Playlist = 1;

        while (true){
            // Call input function
            //int randomSongs = 0;
            int randomSongs = GetIntInput();

            // Create a random list of songs:
            // RandomSongs = userInput
            List<string> randomSongList = GenerateList(randomSongs, ListOfSongs);

            // Now there is a random input and random songs:
            // Create a playlist int to change for each new playlist
            Console.WriteLine($"\nPlaylist {Playlist}\n----------");
            for(int index = 0; index < randomSongList.Count(); index++){
                Console.WriteLine($"Song {index + 1}: {randomSongList[index]}");
            }

            // Ask to run again
            getSaveQuitOption(randomSongList);
            Playlist++;

        }
    }

    // Function to get user input:
    // Input: User
    // Output: Number of songs
    static int GetIntInput(){

        // Initialize variable
        int number;

        // while loop to get input
        while (true){
            Console.WriteLine("\nEnter the number of songs to play: ");
            string UserInput = Console.ReadLine()!;

            // Check for positive, integer numbers
            try{
                number = int.Parse(UserInput);
                if (number <= 0 || number > 10){
                    Console.WriteLine("ERROR: please enter a number between 1 and 10.");
                    continue;
                }
            }catch(Exception){
                Console.WriteLine("ERROR: Only whole numbers allowed.");
                continue;
            }
        return number;
        }
    }

    // Function to create a random list of songs
    // Input: List of strings, number of songs to generate
    // Output: list of random songs
    static List<string> GenerateList(int numberOfSongs, List<string> listOfSongs){
    List<string> randomSongs = new List<string>();
    Random randomGenerator = new Random();

    while(randomSongs.Count < numberOfSongs){
        // Generate a random number between 0 and the number of meals available in listOfMeals
        int randomIndex = randomGenerator.Next(0, listOfSongs.Count);
        
        // Place meal at random index in list if meal is not already in the list
        if(!randomSongs.Contains(listOfSongs[randomIndex])){
            randomSongs.Add(listOfSongs[randomIndex]);
        }
    }
    return randomSongs;
    }

    // Function to load songs from csv file
    // Seperate line by line, then split
    // Index each element into artist/song
    // Return to songsList
    static List<string> loadDataFromFile(){
        // create an empty list to stre the names in
        List<string> songsList = new List<string>();

        string fullPath = Path.Join("songs.csv");
        // Open the file
        using(StreamReader fileReader = new StreamReader(fullPath)){
            // Skip the first line which is the header row
            string headerData = fileReader.ReadLine()!;

            // Read names from the file line by line
            while(!fileReader.EndOfStream){
                string lineofData = fileReader.ReadLine()!;

                // Split each line at the ", "
                string[] songData = lineofData.Split(",");

                // Get first and last name
                string artist = songData[1];
                string song = songData[0];

                // Store name in list: [firstname] [lastname]
                songsList.Add($"{song}: {artist}");
            } 
        }
        return songsList;
    }

    // Function to write to playlist.txt file.
    // Get list of randomSongList
    // Seperate songs and art
    // Print line by line.
    static void WriteListToFile(List<string> randomSongList, string fullName){

        // Create playlists directory
        string playlistsDirectory = "playlists";
        Directory.CreateDirectory(playlistsDirectory);

        // Make sure fullName includes the playlists directory
        string filePath = Path.Combine(playlistsDirectory, fullName);

        // Create a file handler to write the names to a file
        using(StreamWriter fileWriter = new StreamWriter(filePath)){
            // Write the names to the file as [firstname], [lastname]
            foreach(string songs in randomSongList){
                string[] songParts = songs.Split(":");
                string song = songParts[0];
                string artist = songParts[1];

                // Write name to file
                fileWriter.WriteLine($"{song}:{artist}");

            }
        }
    }

    // Function to get (1-4) options
    static int getSaveQuitOption(List<string> randomSongsList){
        
        // Start
        Console.WriteLine("\nChoose one of the following options\n-----------------");
        Console.WriteLine("1. Save Playlist & Continue\n2. Save Playlist & Quit\n3. DON'T Save Playlist & Continue\n4. DON'T Save Playlist & Quit");
        Console.WriteLine("\nEnter save option: ");

        // Collect option
        string input = Console.ReadLine()!;
        int optionPick;

        // Parse option
        if (!int.TryParse(input, out optionPick)){
            Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
            return getSaveQuitOption(randomSongsList);
        }

        // Switch Case for options
        string fullName;
        
        switch (optionPick){
            case 1:
                // Get playlist name
                fullName = getPlaylistName();
                // Call writing to playlist.txt function.
                WriteListToFile(randomSongsList, fullName);
                break;
            case 2:
                // Get playlist name
                fullName = getPlaylistName();
                // Call writing to playlist.txt function.
                WriteListToFile(randomSongsList, fullName);
                Environment.Exit(0);
                break;
            case 3:
                break;
            case 4:
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Number out of range. Please enter a number between 1 and 4.");
                return getSaveQuitOption(randomSongsList);
        }

        return optionPick;

    }

    static string getPlaylistName(){

        // Start
        Console.WriteLine("Enter a name for your Playlist file: ");
        string newName = Console.ReadLine()!;

        // Check if newName has ".txt"
        bool endsInDotTXT = newName.EndsWith(".txt");

        // if to add or continue
        if(endsInDotTXT == true){
            Console.WriteLine("YES");
            string fullName;
            fullName = newName;
            return fullName;

        }else{
            // Concatenate strings
            string filetype = ".txt";
            string fullName = String.Concat(newName, filetype);
            return fullName;
            
        }

    }
}
