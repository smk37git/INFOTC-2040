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

                // Create student object
                Student student = new Student(studentID, firstName, lastName, creditHours, major);

                // Add the student object to the list
                studentList.Add(student);

            }
            return studentList;
        }
    }
}