namespace LinqDemo;

class Program
{
    static void Main(string[] args)
    {
        // Require the the program is run using command line arguments for the data file and the report file
        // If both command line arguments are not provided, then end the program
        if(args.Length != 2){
            Console.WriteLine("Error: Program requires 2 command line arguments as shown below.\n");
            Console.WriteLine("dotnet run <data file name> <report file name>");
            Environment.Exit(0);
        }

        // Get the command line arguments from args[]
        string dataFile = args[0];
        string reportFile = args[1];

        //This variable will contain the data for the reports.
        //We will concatentate the results from each query to this string
        string reportDocument = "";

        //get a list of students
        List<Student> studentList = StudentDataLoader.loadStudents(dataFile);

        Console.WriteLine($"Student list contains {studentList.Count} students");

        //Process the student Data using LINQ
        //Get Deans List students: gpa >= 3.5
        var deansListStudents = from student in studentList
                                where student.getGPA() >= 3.5
                                select student;

        reportDocument += "Dean's List Students\n--------------------------\n";
        //loop through the query results
        foreach(Student student in deansListStudents){
            reportDocument += $"Name: {student.getFirstName()} {student.getLastName()} - {student.getGPA():N2}\n";
        }

        //Get students whose name begin with the letter M
        var studentsWithMNames = from student in studentList
                                where student.getFirstName().StartsWith("M")
                                select student;

        reportDocument += "\nStudents Names that Beginn with M\n-------------------------------\n";
        //iterate through the query results
        foreach(var student in studentsWithMNames){
            reportDocument += $"{student.getFirstName()} {student.getLastName()}\n";
        }

        //find the lowest GPA between 2016 and 2020
        var minGPA2016_2020 = (from student in studentList
                                where student.getGradYear() >= 2016 && student.getGradYear() <= 2020
                                select student.getGPA()).Min();
        
        reportDocument += $"\nMin GPA 2016 - 2020: {minGPA2016_2020:N2}\n";

        //find the highest GPA between 2016 and 2020
        var maxGPA2016_2020 = (from student in studentList
                                where student.getGradYear() >= 2016 && student.getGradYear() <= 2020
                                select student.getGPA()).Max();
        
        reportDocument += $"\nMax GPA 2016 - 2020: {maxGPA2016_2020:N2}\n";

        //find the average GPA between 2016 and 2020
        var averageGPA2016_2020 = (from student in studentList
                                where student.getGradYear() >= 2016 && student.getGradYear() <= 2020
                                select student.getGPA()).Average();
        
        reportDocument += $"\nAverage GPA 2016 - 2020: {averageGPA2016_2020:N2}\n";

        // Get the names and graduation year of the students with the lowest GPA in the dataset
        var lowestGPA = from student in studentList
                        where student.getGPA() == (from otherStudent in studentList select otherStudent.getGPA()).Min()
                        select student;
        reportDocument += "\nStudents with the Lowest GPA\n-------------------------------\n";
        foreach(var student in lowestGPA){
            reportDocument += $"Name: {student.getFirstName()} {student.getLastName()}\nGPA: {student.getGPA():N2} -- GradYear: {student.getGradYear()}\n\n";
        }

        // List students by graduation year using LINQ
        var studentByGradYear = from student in studentList
                                group student by student.getGradYear() into gradYearGroup
                                orderby gradYearGroup.Key ascending
                                select gradYearGroup;

        reportDocument += "\nStudents by Graduation Year\n---------------------------\n";
        // Loop through the grad year groups
        foreach(var yearGroup in studentByGradYear){
            reportDocument += $"\nGraduation Year: {yearGroup.Key}\n---------------------\n";
            // Loop through the students in each grad year group
            foreach(var student in yearGroup){
                reportDocument += $"Name: {student.getFirstName()} {student.getLastName()}\n";
            }

        }
            

        // Call the WriteReport function to write the report
        WriteReport(reportDocument, reportFile);

    }

    // Function to write the report document
    // Input: report document string
    // Output: None
    static void WriteReport(string reportDocument, string reportFile){
        //write the report
        using(StreamWriter reportWriter = new StreamWriter(reportFile)){
            reportWriter.Write(reportDocument);
        }
    }

}
