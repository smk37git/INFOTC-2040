using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;

namespace CsharpBasics;

class Program
{
    static void Main(string[] args)
    {
        // Sebastian Main

        const byte sample1 = 0x3A;
        byte sample2 = 58;
        int heartRate = 85;
        double deposits = 135002796;
        const float acceleration = 9.800f;
        float mass = 14.6f;
        double distance = 129.763001f;
        bool lost = true;
        bool expensive = true;
        int choice = 2;
        const char integral = '\u222B';
        const string greeting = "Hello";
        string name = "Karen";


        // Sample's display
        if (sample1 == sample2){
            Console.WriteLine("Sample 1 and Sample 2 are equal."); 
            }else if (sample1 != sample2){
                Console.WriteLine("Sample 1 and Sample 2 are not equal.");
        }

        // HeartRate display
        if ((heartRate >= 40) && (heartRate <= 80)){
            Console.WriteLine("Heart rate is normal.");
            }else if (heartRate < 40){
                Console.WriteLine("Heart rate is not normal (< 40).");
            }else if (heartRate > 80){
                Console.WriteLine("Heart rate is not normal (> 80).");
        }

        // Deposits display
        if (deposits >= 100000000){
            Console.WriteLine("You are exceedingly wealthy");
        }else if (deposits <= 100000000){
            Console.WriteLine("Sorry you are so poor.");
        }

        // Force Mass Acceleration Display
        float force = (mass * acceleration);
        Console.WriteLine($"Force = {force}.");

        // Distance display
        Console.WriteLine($"{distance} is the distance.");

        // Lost and Expensive display
        if ((lost == true) && (expensive == true)){
            Console.WriteLine("I am really sorry! I will get the manager.");
        }else if ((lost == true) && (expensive == false)){
            Console.WriteLine("Here is a coupon for 10% off.");
        }

        // Switch/Case display
        switch (choice)
        {
            case 1:
            Console.WriteLine("You chose1.");
            break;

            case 2:
            Console.WriteLine("You chose 2.");
            break;

            case 3:
            Console.WriteLine("You chose 3.");
            break;

            default:
            Console.WriteLine("You made an unknown choice");
            break;
        }

        // Char Constant display
            Console.WriteLine($"{integral} is an integral.");

        // For Loop
        for (int i = 5; i <= 10; i++){
            Console.WriteLine($"i = {i}");
        }

        // Age display
        int age = 0;
        while(age < 6){
            age++;
            Console.WriteLine($"Age = {age}.");
        }

        // Greeting display
        Console.WriteLine($"{greeting} {name}.");
    }
}