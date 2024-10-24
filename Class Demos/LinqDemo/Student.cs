namespace LinqDemo;

public class Student{
    //create class properties
    private string firstName, lastName, major;
    private float gpa;
    private int gradYear;

    //create a constructor
    public Student(string firstName, string lastName, string major, float gpa, int gradYear){
        //assign class properties values coming in to the constructor
        this.firstName = firstName;
        this.lastName = lastName;
        this.major =major;
        this.gpa = gpa;
        this.gradYear = gradYear;
    }

    //create get/set methods for class properties
    public string getFirstName(){
        return this.firstName;
    }
    
    public string getLastName(){
        return this.lastName;
    }

    public string getMajor(){
        return this.major;
    }

    public float getGPA(){
        return this.gpa;
    }

    public int getGradYear(){
        return this.gradYear;
    }
}