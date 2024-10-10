namespace InheritanceDemo;

// Cat will inherit ffrom Pet
public class Cat : Pet{

    // Create class properties specific to cats

    // Create a constructor 
    public Cat(string name, string owner, double weight, int age) : base(PetType.Cat, name, owner, weight, age){}

    // override the make sound method so that the cat can meow
    public override void MakeSound(int numSounds){
        string meowString = "";

        for(int i = 0; i < numSounds; i++){
            meowString += "Meow! ";
        }
        Console.WriteLine(meowString);
    }
}