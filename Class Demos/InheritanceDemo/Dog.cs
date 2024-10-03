namespace InheritanceDemo;
// Dog will inherit from Pet

public class Dog : Pet{
    // Declare class properties
    private string breed;

    // Create constructor
    public Dog(string name, string owner, double weight, int age, string breed) : base("Dog", name, owner, weight, age){
        this.breed = breed;
    }

    // Declare get and set methods for the dog
    public string GetBreed(){
        return this.breed;
    }


}