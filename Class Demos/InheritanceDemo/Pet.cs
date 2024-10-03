using System.Security.Cryptography;

namespace InheritanceDemo;

public class Pet{
    // Declare class properties
    private string name, owner, petType;
    private int age;
    private double weight;

    // Create a class constructor
    public Pet(string petType, string name, string owner, double weight, int age){
        this.petType = petType;
        this.name = name;
        this.owner = owner;
        this.weight = weight;
        this.age = age;
    }

    // Define class methods
    // Define getter and setter methods
    public string GetPetType(){
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
        Console.WriteLine($"{this.name} is a {this.petType} and is {this.age} years old, and the owner is {this.owner}");

    }

    public override string ToString()
    {
        return $"{this.name} is a {this.petType} and is {this.age} years old, and the owner is {this.owner}";
    }

}