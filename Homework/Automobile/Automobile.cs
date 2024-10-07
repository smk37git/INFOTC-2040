using System.Runtime.InteropServices;

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
    private string autoType;

    //declare a class constructor
    public Automobile(string make, string model, string vin, string color, int year, string autoType){
        this.make = make;
        this.model = model;
        this.vin = vin;
        this.color = color;
        this.year = year;
        this.autoType = autoType;
    }


}