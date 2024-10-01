namespace OOPDemo;

class Program
{
    static void Main(string[] args)
    {
        //create instances of the Dog class. Create 3 Dog objects
        Dog buster = new Dog("Buster", "Mary", 5);
        Dog lucky = new Dog("Lucky", "Ricky", 15);
        Dog winston = new Dog("Winston", "Jordan", 7);

        //print dog information
        buster.GetTagInfo();
        lucky.GetTagInfo();
        winston.GetTagInfo();

        // make dogs bark
        buster.Bark(3);
        winston.Bark(7);

        // Birthday party
        lucky.HasBirthday();
        winston.HasBirthday();
        Console.WriteLine($"{winston.GetName()}'s owner is {winston.GetOwner()}");
        winston.GetTagInfo();
        lucky.GetTagInfo();

    }
}
