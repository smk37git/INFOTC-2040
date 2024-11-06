namespace InterfaceDemo;

public class Circle : Shape{
    private double radius;

    public double Radius{
        get{return this.radius;}
        set{this.radius = value;}
    }

    //create a circle constructor
    public Circle(double radius){
        this.radius = radius;
    }

    public override double CalculateArea()
    {
        return Math.PI * Math.Pow(this.radius, 2);
    }

    public override double CalculateVolume()
    {
        return (4/3) * Math.PI * Math.Pow(this.radius, 3);
    }

    public double CalculateCircumference(){
        return 2 * Math.PI * this.radius;
    }

    public override double CalculatePerimeter()
    {
        //show warning message telling the user to use the CalculateCircumference method next time
        Console.WriteLine("WARNING: use the CalculateCircumference() method in the future.\n");
        
        double circumference = CalculateCircumference();
        
        return circumference;
    }

    public override void LogMessage()
    {
        Console.WriteLine("Will Log messages to a file");
    }
}