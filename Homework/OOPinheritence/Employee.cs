namespace  OOPinheritence;

public class Employee{

    // Declare Class Properities
    private string firstName;
    private string lastName;
    private string id;
    private EmployeeType empType;


    // Create a class constructor
    public Employee(string firstName, string lastName, string id, EmployeeType empType){
        this.firstName = firstName;
        this.lastName = lastName;
        this.id = id;
        this.empType = SetEmployeeType(id);
    }

    // Create another constructor for the Employee class
    public Employee(){}

    // DEFINE GETTER AND SETTER METHODS

    // First Name
    public string getFirstName(){
        return this.firstName;
    }
    public void setFirstName(string newFirstName){
        this.firstName = newFirstName;
    }

    // Last Name
    public string getlastName(){
        return this.lastName;
    }

    public void setLastName(string newLastName){
        this.lastName = newLastName;
    }

    // Set empType
    private static EmployeeType SetEmployeeType(string id){
        int newid = int.Parse(id);
        if(newid == 12345){
            return EmployeeType.Sales;
        }else if(newid == 23456){
            return EmployeeType.Sales;
        }else if(newid == 56789){
            return EmployeeType.Manager;
        }else{
            return EmployeeType.Production;
        }
    }

    // Get empType
    public EmployeeType SetEmployeeType(){
        return this.empType;
    }

    // ID
    public string GetID(){
        return this.id;
    }

    public void getEmployeeInfo(){
        Console.WriteLine($"Name: {firstName} {lastName}\nID: {id}\nType: {empType}");
    }


}