namespace MidtermProject;

class Program
{
    static void Main(string[] args)
    {
        // Sebastian Main -- Midterm Project   
        Console.Clear();
    
        // Create a list of students
        List<Student> studentList = StudentDataLoader.LoadStudents("student_data.csv");


        using(StreamWriter fileWriter = new StreamWriter("report.txt", true)){
            // Start file
            fileWriter.WriteLine("-------------Student Grade Report-------------");
            fileWriter.WriteLine("----------------------------------------------");

        }

        // List each student's information
        foreach(Student student in studentList){
            
            // Add credit hours if needed
            student.AddCreditHours(0);

            // Print Student Info
            student.PrintStudentInfo();
        }
    }

}
