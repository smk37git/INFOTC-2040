namespace OOPDemo;
//create a dog class
//dog will have a name, owner, age
//dog will be able to bark

//Create the Dog Class
class Dog{
    //delcare class properties
    private string name;
    private string owner;
    private int age;

    //declare a class constructor
    public Dog(string name, string owner, int age){
        this.name = name;
        this.owner = owner;
        this.age = age;
    }

    //create a method to print dog tag information
    public void GetTagInfo(){
        Console.WriteLine($"{this.name} is {this.age} years old, and the owner is {this.owner}");
    }

    // Create getter and setter methods for class properties
    public string GetName(){
        return this.name;
    }

    public void SetName(string newName){
        this.name = newName;
    }

    public string GetOwner(){
        return this.owner;
    }

    public void SetOwner(string newOwner){
        this.owner = newOwner;
    }

    public int GetAge(){
        return this.age;
    }

    public void HasBirthday(){
        this.age ++;
    }

    // Method to have the dog bark
    // Input: (int) number of Barks
    // Output: None - print the barks to the console
    public void Bark(int numberOfBarks){
        string barkString = "";

        // for loop to produce the bark string
        for(int i = 0; i < numberOfBarks; i++){
            // concatenate a string - build the bark string
            barkString += "Bark! ";
        }

        // print the bark string to the console
        Console.WriteLine($"{this.name} >>> {barkString}");
    }


}