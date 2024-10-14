namespace MidtermProject;

class Program
{
    static void Main(string[] args)
    {
        // Sebastian Main -- Midterm Project    
    

        // Create a list of students
        List<Student> studentList = StudentDataLoader.LoadStudents("student_data.csv");

        foreach(Student student in studentList){
            student.PrintStudentInfo();
        }

    }
}
