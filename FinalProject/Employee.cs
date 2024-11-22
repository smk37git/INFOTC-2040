namespace FinalProject;

public class Employee : Person{
    // Declare class properties
    private string username = "";
    private string password = "";
    private JobTitle employeejob;

    // Create a class constructor
    public Employee(string username, string password, JobTitle employeejob, string first_name, string last_name){
        this.username = username;
        this.password = password;
        this.employeejob = employeejob;

        // Inherited Properties
        this.First_Name = first_name;
        this.Last_Name = last_name;
    }

    // Get and Set methods
    public string Username{
        get{return this.username;}
        set{username = value;}
    }

    public string Password{
        get{return this.password;}
        set{password = value;}
    }

    public JobTitle EmployeeJob{
        get{return this.employeejob;}
        set{employeejob = value;}
    }


    // Override the GetInfo() method
    public override string GetInfo()
    {
        return $"Name: {First_Name} {Last_Name} - Title: {EmployeeJob}";
    }
}