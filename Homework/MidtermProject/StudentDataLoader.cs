namespace MidtermProject;

// Create a class to read data from a file and return a list of objects
public class StudentDataLoader{
    
    // Create a method to read data from a file and return a list of students
    public static List<Student> LoadStudents(string filePath){
        // Create an empty list to store student objects
        List<Student> studentList = new List<Student>();

        // Open the data.csv file with a streamreader object
        using(StreamReader fileReader = new StreamReader(filePath)){

            // Read the file line by line
            while(!fileReader.EndOfStream){

                // Split the line at the comma
                string lineOfData = fileReader.ReadLine()!;

                string[] studentData = lineOfData.Split(",");

                // Get each value from the resulting array and assign to a variable, convert data type as necessary
                int studentID = int.Parse(studentData[0]);
                string firstName = studentData[1];
                string lastName = studentData[2];
                int creditHours = int.Parse(studentData[3]);
                string major = studentData[4];

                // Create student based off of classStatuc (Freshman, Sophomore, Junior, Senior)
                if(creditHours < 30){
                    studentList.Add(new Student(classStatus.Freshman, studentID, firstName, lastName, creditHours, major));
                }else if (creditHours > 30 && creditHours < 60){
                    studentList.Add(new Student(classStatus.Sophomore, studentID, firstName, lastName, creditHours, major));
                }else if (creditHours > 59 && creditHours < 90){
                    studentList.Add(new Student(classStatus.Junior, studentID, firstName, lastName, creditHours, major));
                }else if (creditHours > 90){
                    studentList.Add(new Student(classStatus.Senior, studentID, firstName, lastName, creditHours, major));
                }

            }
            return studentList;
        }
    }

    public static List<string> LoadScores(string filePath, int studentID){
        // Create an empty list to store student objects
        List<string> scoreList = new List<string>();

        // Open the scores.csv file with a streamreader object
        using(StreamReader fileReader = new StreamReader("scores.csv")){

            // Read the file line by line
            while(!fileReader.EndOfStream){

                // Split the line at the comma
                string lineOfData = fileReader.ReadLine()!;
                string[] scoreData = lineOfData.Split(",");

                if(studentID == int.Parse(scoreData[0])){
                    // Loop through the remaining values which are the scores
                    for (int i = 1; i < scoreData.Length; i++){

                        // Initialize score
                        string score = scoreData[i];

                        // Add score to list
                        scoreList.Add(score);
                    }
                }
            }
            return scoreList;
        }
    }
}
