namespace InheritanceDemo;
// Dog will inherit from Pet

public class Dog : Pet{
    // Declare class properties

    // Create constructor
    public Dog(string name, string owner, double weight, int age) : base(PetType.Dog, name, owner, weight, age){}

    // Override the MakeSound method so that the dog can bark
    public override void MakeSound(int numSounds){
        string barkString = "";

        for(int i = 0; i < numSounds; i++){
            barkString += "Bark! ";
        }
        Console.WriteLine(barkString);
    }


}