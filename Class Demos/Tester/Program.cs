namespace HelloWorld;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        int x = 5;
        int y = 6;
        int age = 22;
        string name = "Alice";
        float gpa = 3.74f;

        Console.WriteLine($"{name} is {age} years old and has a {gpa} gpa.");
        Console.WriteLine($"It is {x < y} that {x} is less than {y}.");
    }
}
