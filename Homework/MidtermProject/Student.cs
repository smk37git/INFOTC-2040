namespace MidtermProject;

public class Student{
    // Declare class properties
    private int studentID;
    private string firstName = "", lastName = "";
    private int creditHours;
    private string major = "";
    private classStatus classStatus;

    // Create a class constructor
    public Student(classStatus classStatus, int studentID, string firstName, string lastName, int creditHours, string major){
        this.classStatus = classStatus;
        this.studentID = studentID;
        this.firstName = firstName;
        this.lastName = lastName;
        this.creditHours = creditHours;
        this.major = major;
    }

    // Create another constructor for the student class
    public Student(){}

    // Define class methods
    // Define getter and setter methods

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

    public void PrintStudentInfo(){
        Console.WriteLine($"ID: {this.studentID}: {this.firstName} {this.lastName}: {classStatus} - ({this.major})");
    }

}