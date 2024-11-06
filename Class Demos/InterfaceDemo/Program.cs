namespace InterfaceDemo;

class Program
{
    static void Main(string[] args)
    {
        //The code below returns an error because we cannot create an object from an abstract class
        //Shape myShape = new Shape();

        Square square1 = new Square(4.2);
        square1.ShapeName = "My Square";

        Circle circle1 = new Circle(3.2);
        circle1.ShapeName = "My Circle";

        Console.WriteLine("\nSquare Measurements\n-------------------------");
        Console.WriteLine($"Name: {square1.ShapeName}");
        Console.WriteLine($"{square1.ShapeName} Area: {square1.CalculateArea():N2}");
        Console.WriteLine($"{square1.ShapeName} Volume: {square1.CalculateVolume():N2}");
        Console.WriteLine($"{square1.ShapeName} Perimeter: {square1.CalculatePerimeter():N2}");
        square1.LogMessage();

        Console.WriteLine("\nCircle Measurements\n-------------------------");
        Console.WriteLine($"Name: {circle1.ShapeName}");
        Console.WriteLine($"{circle1.ShapeName} Area: {circle1.CalculateArea():N2}");
        Console.WriteLine($"{circle1.ShapeName} Volume: {circle1.CalculateVolume():N2}");
        Console.WriteLine($"{circle1.ShapeName} Circumference: {circle1.CalculateCircumference():N2}");
        circle1.LogMessage();

        Console.WriteLine("\nPool Measurements\n---------------------------");
        Pool pool1 = new Pool(10, 8, 8);
        pool1.PoolName = "My Pool";
        Console.WriteLine($"Name: {pool1.PoolName}");
        Console.WriteLine($"{pool1.PoolName} Area: {pool1.CalculateArea():N2}");
        Console.WriteLine($"{pool1.PoolName} Volume: {pool1.CalculateVolume():N2}");
        Console.WriteLine($"{pool1.PoolName} Perimeter: {pool1.CalculatePerimeter():N2}");

    }
}
