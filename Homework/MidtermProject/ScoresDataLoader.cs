namespace MidtermProject;

// Create a class to read data from a file and return a list of objects
public class ScoresDataLoader{
    
    // Create a method to read data from a file and return a list of students
    public static List<Score> LoadStudents(string filePath, int studentID){
        // Create an empty list to store student objects
        List<Score> scoreList = new List<Score>();

        // Open the data.csv file with a streamreader object
        using(StreamReader fileReader = new StreamReader(filePath)){

            // Read the file line by line
            while(!fileReader.EndOfStream){

            // Split the line at the comma
            string lineOfData = fileReader.ReadLine()!;
            string[] scoreData = lineOfData.Split(",");

            while(studentID == int.Parse(scoreData[0])){
                // Loop through the remaining values which are the scores
                for (int i = 1; i < scoreData.Length; i++){
                    double scores = double.Parse(scoreData[i]);

                    // Create a new Score object and add it to the list
                    scoreList.Add(new Score(studentID, scores));
                }
                
            }
        }
        return scoreList;
    }
}
}