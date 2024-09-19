using System.Net;

namespace RandomMusicPlaylist;

class Program
{
    static void Main(string[] args)
    {
        // Sebastian Main INFOTC 2040
        // This program is a redone version of RandonMusicPlaylist.
        // This one will load from a file and output a playlist file instead of hardcoding lists into the program

        // V2 Functions:
        // [loadSongs] Function loads song and artists from a scv file into a list. [x]
        // [savePlaylist] Function to save the generated playlist to a file. [x]


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

                // Call writing to playlist.txt function.
                WriteListToFile(randomSongList);
            }

            // Ask to run again
            while(true){
                Console.WriteLine("\nWould you like to make another playlist? (y/n)");
                string PlayAgain = Console.ReadLine()!;
                if(PlayAgain == "y"){
                    Playlist++;
                    break;
                }else if(PlayAgain == "n"){
                    Console.WriteLine("Exiting program...");
                    Environment.Exit(0);
                }else{
                    Console.WriteLine("ERROR: Please enter (y/n)");
                }

            }
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
    static void WriteListToFile(List<string> randomSongList){

        // Create a file handler to write the names to a file
        using(StreamWriter fileWriter = new StreamWriter("playlist.txt")){
            // Write the names to the file as [firstname], [lastname]
            foreach(string songs in randomSongList){
                string[] songParts = songs.Split(":");
                string song = songParts[0];
                string artist = songParts[1];

                // Write name to file
                fileWriter.WriteLine($"{song}:{artist}");

            }
        }
        return;
    }
}
