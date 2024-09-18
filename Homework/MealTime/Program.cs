namespace MealTime;

class Program
{
    static void Main(string[] args)
    {
        // Sebastian Main

        // Prompt the user to enter a time (24 Hr format)
        // Valid: xx:yy, x,yy
        Console.WriteLine("What time is it? (24 HR FORMAT)");
        string time = Console.ReadLine()!;

        // Call to Function (convertTime)
        float newTime = convertTime(time);


        // Calculations done:
        // Declare time period
        // If time is between 7:00 and 8:00 = breakfast
        if (newTime >= 7 && newTime <= 8){
            Console.WriteLine("Breakfast Time!");
        }
        // If time is between 12:00 and 13:00 = lunch
        else if (newTime >= 12 && newTime <= 13){
            Console.WriteLine("Lunch Time!");
        }
        // If time is between 18:00 and 19:00 = dinner
        else if (newTime >= 18 && newTime <= 19){
            Console.WriteLine("Dinner Time!");
        }
        else{
            Console.WriteLine("Not time to eat!");
        }
    }
    public static float convertTime(string time){

        // Declare Variables
        int hours = 0, minutes = 0;
    
        // Seperate string
        string[] timeParts = time.Split(":");

        // Make sure time is in the correct format and timeParts has 2 items.
        if(timeParts.Length != 2){
            Console.WriteLine("ERROR: Incorrect format.\nExiting Program...");
            Environment.Exit(0);
        }

        // Validate input: make sure hours and minutes are numbers
        try{
            hours = int.Parse(timeParts[0]);
            minutes = int.Parse(timeParts[1]);
        }catch(Exception){
            Console.WriteLine("ERROR: Must enter numbers.\nExiting the program...");
            Environment.Exit(0);
        }

        // Check to make sure time is within 0:00 and 23:59.
        if(hours > 0 && hours > 23){
            Console.WriteLine("ERROR: Must enter numbers between 0:00 and 23:59.\nExiting the program...");
            Environment.Exit(0);
        }
            
        // Convert to 24 Hours
        // Example 7:30 = 7.5hrs
        // 60f for float 60.
        float newTime = hours + minutes / 60f;

        // Return the output
        return newTime;
    }
}
