namespace Automobile;

// Automobile is to have the following private properties:
// make (of type string)
// model (of type string)
// vin (of type string)
// color (of type string)
// year (of type int)
// type (of type autoType)

//Create the Automobile Class
class Automobile{

    //delcare class properties
    private string make;
    private string model;
    private string vin;
    private string color;
    private int year;
    private AutoType type;

    //declare a class constructor
    public Automobile(string make, string model, int year, string vin, string color, AutoType type){
        this.make = make;
        this.model = model;
        this.vin = vin;
        this.color = color;
        this.year = year;
        this.type = type;

    }

    // Create getter and setter methods for AutoMobile properties
    // Get/Set Make
    public string GetMake(){
        return this.make;
    }

    // Get Model
    public string GetModel(){
        return this.model;
    }

    // Get VIN
    public string GetVin(){
        return this.vin;
    }

    // Get/Set Color
    public string GetColor(){
        return this.color;
    }
    public void SetColor(string newColor){
        this.color = newColor;
    }

    // Get Year
    public int GetYear(){
        return this.year;
    }
    // Get Type
    public AutoType GetType(){
        return this.type;
    }

    //create a method to get the age of the automobile in years. Current year minus year of cars make
    // Used https://stackoverflow.com/questions/46283314/how-do-i-get-the-current-year-in-c to get time command
    public int GetAutoAge(){
        int Age = DateTime.Now.Year - this.year;
        return Age;
    }




}