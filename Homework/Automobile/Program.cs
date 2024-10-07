namespace Automobile;

class Program
{
    static void Main(string[] args)
    {
        // Sebastian Main
        // Creating classes + constructors + enumerators

        // Automobile is to have the following private properties:
        // make (of type string)
        // model (of type string)
        // vin (of type string)
        // color (of type string)
        // year (of type int)
        // type (of type autoType)

        Console.WriteLine("\nCreating the first Automobile\n---------------");
        Automobile auto1 = new Automobile("Tesla", "Model X", 2020, "12345", "blue", AutoType.Sedan);
        Console.WriteLine($"Make: {auto1.GetMake()} \nModel: {auto1.GetModel()}\nYear: {auto1.GetYear()}\nType: {auto1.GetType()} \nVIN: {auto1.GetVin()}");
        Console.WriteLine($"Color: {auto1.GetColor()}");
        Console.WriteLine("\nChanging the Colour\n---------------");
        auto1.SetColor("black");
        Console.WriteLine($"Color: {auto1.GetColor()}");

        Console.WriteLine("\nCreating the second Automobile\n---------------");
        Automobile auto2 = new Automobile("Mercedes", "G-Wagon", 2017, "24578", "silver", AutoType.SUV);
        Console.WriteLine($"Make: {auto2.GetMake()}\nModel: {auto2.GetModel()}\nYear: {auto2.GetYear()}\nType: {auto2.GetType()}\nVIN: {auto2.GetVin()}");

        Console.WriteLine("\nPrinting Automobile Ages\n---------------");
        Console.WriteLine($"Auto1 Age: {auto1.GetAutoAge()} years");
        Console.WriteLine($"Auto2 Age: {auto2.GetAutoAge()} years");
    }
}
