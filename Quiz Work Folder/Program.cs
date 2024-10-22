namespace Quiz_Work_Folder;

class Program
{
    static void Main(string[] args)
    {
        int quantity = 20;
        var cost = quantity < 10 ? 19.95 : quantity * 1.79;

        Console.WriteLine(cost);


    }
}
