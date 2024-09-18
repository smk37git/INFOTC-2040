using System.Net;

namespace RandomMusicPlaylist;

class Program
{
    static void Main(string[] args)
    {
        // Sebastian Main INFOTC 2040
        // This program will place songs in a randomly generated order based on user input.
        // 10 songs, user enters #, then the # of songs is displayed in a random order, no duplicates
        // Prompt the user to run again.

        // Needs two functiions:
        // Function to prompt user the number of songs, return integer [x]
        // Function to generate a list of random songs with none repeated, return a list of strings [x]

        // Start with program title
        Console.WriteLine("\nRandom Music Playlist\n---------------------");

        // Create the song list:
        List<string> songList = new List<string>(){
            "Need 2: Pinegrove",                            // 0
            "Cracklin' Rosie: Neil Diamond",                // 1
            "Dissolve: Joji",                               // 2
            "Vanished: Crystal Castles",                    // 3
            "Song 2: Blur",                                 // 4
            "Sofa King: Royal Otis",                        // 5
            "While My Guitar Gently Weeps: The Beatles",    // 6
            "Sleeping Powder: Gorillaz",                    // 7
            "Wish: Diplo",                                  // 8
            "Crimewave: Crystal Castles"                    // 9
        };

        // Initialize Playlists
        int Playlist = 1;

        while (true){
            // Call input function
            //int randomSongs = 0;
            int randomSongs = GetIntInput();

            // Create a random list of songs:
            // RandomSongs = userInput
            List<string> randomSongList = GenerateList(randomSongs, songList);

            // Now there is a random input and random songs:
            // Create a playlist int to change for each new playlist
            Console.WriteLine($"\nPlaylist {Playlist}\n----------");
            for(int index = 0; index < randomSongList.Count(); index++){
                Console.WriteLine($"Song {index + 1}: {randomSongList[index]}");
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

}
