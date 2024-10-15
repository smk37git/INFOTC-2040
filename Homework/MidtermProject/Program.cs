namespace MidtermProject;

class Program
{
    static void Main(string[] args)
    {
        // Sebastian Main -- Midterm Project   
         Console.Clear();
    
        // Create a list of students
        List<Student> studentList = StudentDataLoader.LoadStudents("student_data.csv");

        // List each student's information
        foreach(Student student in studentList){
            student.PrintStudentInfo();

            // Get the studentID using the GetID method
            int studentID = student.GetID();

            // Create a list of student's score
            List<string> studentScores = StudentDataLoader.LoadScores("scores.csv", studentID);

            // Initalize variables
            int testNumber = 1;
            double averageScore = 0;
            
            // Print scores
            if (studentScores.Count > 0){
                foreach (string score in studentScores){
                    Console.WriteLine($"Test {testNumber}: {score}");
                    testNumber++;
                    averageScore += double.Parse(score);
                }
            }
            averageScore /= (testNumber - 1);
            Console.WriteLine($"\nAverage Score: {averageScore:F2}");

        }
    }
}
