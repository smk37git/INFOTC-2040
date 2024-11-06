namespace RefTypeValType;

class Program
{
    static void Main(string[] args)
    {
        // Value Types
        int a = 5;
        int b = a;
        a = 10;

        Console.WriteLine($"a = {a}, b = {b}");

        // Reference Types
        List<string> list1 = new List<string>(){"cat", "dog"};
        List<string> list2 = list1;
        list1.Add("fish");
        list1.Add("hamster");

        // Print List Values
        Console.WriteLine("\nList1 Values\n------------------");
        foreach(string animal in list1){
            Console.WriteLine(animal);
        }

        Console.WriteLine("\nList2 Values\n------------------");
        foreach(string animal in list2){
            Console.WriteLine(animal);
        }

    }
}
