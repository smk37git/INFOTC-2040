namespace AbstactionDemo;

public class Square : Shape{
    private double sideLength;

    public double SideLength{
        get{return this.sideLength;}
        set{this.sideLength = value;}
    }

    //create a square constructor
    public Square(double sideLength){
        this.sideLength = sideLength;
    }

    //implement abstract methods from the parent class Shape
    public override double CalculateArea()
    {
        return this.sideLength * this.sideLength;
    }

    public override double CalculatePerimeter()
    {  
        return this.sideLength * 4;
    }

    public override double CalculateVolume()
    {
        return Math.Pow(this.sideLength, 3);
    }
}