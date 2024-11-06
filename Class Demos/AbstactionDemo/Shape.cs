namespace AbstactionDemo;

public abstract class Shape{
    //define class properties/fields
    private string shapeName = ""; 

    //define get and set methods
    public string ShapeName{
        get{return this.shapeName;}
        set{shapeName = value;}
    }

    //create aditional class methods
    //abstract methods that will need implementation details in the child/derived class
    public abstract double CalculateArea();
    public abstract double CalculateVolume();
    public abstract double CalculatePerimeter();
}