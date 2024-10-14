namespace InheritanceDemo;

public class Pet{
    // Declare class properties
    private string name = "", owner = "";
    private int age;
    private double weight;
    private PetType petType;

    // Create a class constructor
    public Pet(PetType petType, string name, string owner, double weight, int age){
        this.petType = petType;
        this.name = name;
        this.owner = owner;
        this.weight = weight;
        this.age = age;
    }

    // Create another constructor for the pet class
    public Pet(){}

    // Define class methods
    // Define getter and setter methods
    public PetType GetPetType(){
        return this.petType;
    }

    public string GetOwner(){
        return this.owner;
    }

    public void SetOwner(string newOwner){
        this.owner = newOwner;
    }

    public string GetName(){
        return this.name;
    }

    public int GetAge(){
        return this.age;
    }

    public void HasBirthday(){
        this.age ++;
    }

    public double GetWeight(){
        return this.weight;
    }

    public void SetWeight(double newWeight){
        this.weight = newWeight;
    }

    public void PrintPetInfo(){
        Console.WriteLine($"{this.name} is a {this.petType}, weighs {this.weight}lbs, is {this.age} years old, and the owner is {this.owner}");
    }

    public override string ToString()
    {
        return $"{this.name} is a {this.petType} and is {this.age} years old, and the owner is {this.owner}";
    }

    // Create a method for the pet to make a sound
    public virtual void MakeSound(int numSounds){
        Console.WriteLine("This pet does not make a sound.");
    }

}