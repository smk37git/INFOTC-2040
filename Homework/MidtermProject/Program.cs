namespace MidtermProject;

class Program
{
    static void Main(string[] args)
    {
        // Sebastian Main -- Midterm Project   
         Console.Clear();
    
        // Create a list of students
        List<Student> studentList = StudentDataLoader.LoadStudents("student_data.csv");

        // List Each student's information
        foreach(Student student in studentList){
            student.PrintStudentInfo();
        }
    }
}
