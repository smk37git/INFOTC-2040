namespace MidtermProject;

public class Student{
    // Declare class properties
    private int studentID;
    private string firstName = "", lastName = "";
    private int creditHours;
    private string major = "";
    private classStatus classStatus;
    private List<string> testScores = new List<string>();

    // Create a class constructor
    public Student(int studentID, string firstName, string lastName, int creditHours, string major){
        this.studentID = studentID;
        this.firstName = firstName;
        this.lastName = lastName;
        this.creditHours = creditHours;
        this.major = major;
        this.classStatus = SetClassStatus(creditHours);
    }

    // Create another constructor for the student class
    public Student(){}

    // DEFINE GETTER AND SETTER METHODS

    // Class
    public classStatus GetClassStatus(){
        return this.classStatus;
    }

    // ID
    public int GetID(){
        return this.studentID;
    }

    // First Name
    public string GetFirstName(){
        return this.firstName;
    }

    public void SetFirstName(string newFirstName){
        this.firstName = newFirstName;
    }

    // Last Name
    public string GetLastName(){
        return this.lastName;
    }

    public void SetLastName(string newLastName){
        this.lastName = newLastName;
    }

    // Major
    public string GetMajor(){
        return this.major;
    }

    public void SetMajor(string newMajor){
        this.major = newMajor;
    }

    // Credit Hours
    public int GetCreditHours(){
        return this.creditHours;
    }

    // DEFINE CLASS METHODS

    // Define fullName Method
    public string MakeFullName(){
        return this.firstName + " " + this.lastName;
    }

    // Define classStatus Method
    // Create student based off of classStatus (Freshman, Sophomore, Junior, Senior)
    private static classStatus SetClassStatus(int creditHours){
        if(creditHours < 30){
            return classStatus.Freshman;
        }else if (creditHours >= 30 && creditHours < 60){
            return classStatus.Sophomore;
        }else if (creditHours >= 60 && creditHours < 90){
            return classStatus.Junior;
        }else{
            return classStatus.Senior;
        }
    }

    // Add Credit Hours Method
    public void AddCreditHours(int creditAmount){
        this.creditHours += creditAmount;
        this.classStatus = SetClassStatus(this.creditHours);
    }

    // Get testScores in list Method
    public void LoadScores(string filePath){
        // Create an empty list to store student objects
        List<string> studentScores = new List<string>();

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
                        studentScores.Add(score);
                    }
                }
            }
        }
        this.testScores = studentScores;
    }

    // Method to return scores in string format
    public string StringScores(){

        // Initalize Variable
        int testNumber = 1;
        double totalScore = 0;
        string Scores = "";

        foreach (string score in testScores){
            Scores += $"Test {testNumber}: {score}\n";
            totalScore += double.Parse(score);
            testNumber++;
        }

        // Call Average Score Method and append it to the scores
        Scores += CalculateAverage(totalScore, testNumber);
        return Scores;
    }

    // Method to calculate average score
    public string CalculateAverage(double totalScore, int testNumber){
        double averageScore = totalScore / (testNumber - 1);

        string AverageString = $"\nAverage Score: {averageScore:F2}%";

        // Call Assign Letter Grade Method and append it to average scores
        AverageString += AssignLetterGrade(averageScore);


        return AverageString;

    }

    // Method that assigns letter score (A, B, C, D, F)
    // Call average score in this method.
    public string AssignLetterGrade(double averageScore){

        // Initalize Letter Grade
        string LetterGrade;

        if(averageScore >= 90){
            LetterGrade = "A";
        }else if(averageScore >= 80.00 && averageScore <= 89.99){
            LetterGrade = "B";
        }else if(averageScore >= 70.00 && averageScore <= 79.99){
            LetterGrade = "C";
        }else if(averageScore >= 60.00 && averageScore <= 69.99){
            LetterGrade = "D";
        }else{
            LetterGrade = "F";
        }

        return $" -- Grade: {LetterGrade}";
    }


    // Print Student Info Method
    public void PrintStudentInfo(){
        // Load Scores
        LoadScores("scores.csv");
        
        // Print Student Info
        Console.WriteLine($"\nID: {this.studentID}: {this.MakeFullName()}: {classStatus} - ({this.major})");

        // Print scores
        Console.WriteLine("----------Scores----------");
        Console.WriteLine(StringScores());

        // Create a file handler to write the Student Info to a file
        using(StreamWriter fileWriter = new StreamWriter("report.txt", true)){

            // Write the students to file
            fileWriter.WriteLine($"\nID: {this.studentID}: {this.MakeFullName()}: {classStatus} - ({this.major})");
            fileWriter.WriteLine("----------Scores---------");
            fileWriter.WriteLine(StringScores());
            
            
        }




    }
}