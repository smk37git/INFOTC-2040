namespace FinalProject;

public abstract class Person{
    // Class Properties
    private string first_name = "";
    private string last_name = "";

    //define get and set methods
    public string First_Name{
        get{return this.first_name;}
        set{first_name = value;}
    }
    public string Last_Name{
        get{return this.last_name;}
        set{last_name = value;}
    }

    // Abstract Method
    public abstract string GetInfo();
}