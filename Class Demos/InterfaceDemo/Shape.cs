using System.ComponentModel;

namespace InterfaceDemo;

public abstract class Shape : IShape, ILog{
    // Define class properties and fields
    private string shapeName = "";

    // Define get and set methods
    public string ShapeName{
        get{return this.shapeName;}
        set{shapeName = value;}
    }

    // Create additional class methods
    // Abstract methods that will need implementation details in the child/derived class
    public abstract double CalculateArea();
    public abstract double CalculateVolume();
    public abstract double CalculatePerimeter();
    public abstract void LogMessage();
}