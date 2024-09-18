namespace ListLoops;

class Program
{
    static void Main(string[] args)
    {
        // Create a list of 5 meals
        List<string> mealList = new List<string>(){
            "Hamburger and Fries",
            "Pepperoni Pizza",
            "Cracked Conch",
            "Spagetthi & Meatballs",
            "Ice Cream"
        };
        // Add 2 items to the list using the .Add method
        mealList.Add("PB & J Sandwich");
        mealList.Add("Apple Pie");

        // Get the second item from the list
        string secondMeal = mealList[1];
        Console.WriteLine(secondMeal);

        // Print all items in the meal list
        Console.WriteLine("\nPrint Meals using Foreach\n-------------------------");
        foreach(string meal in mealList){
            Console.WriteLine(meal);
        }

        Console.WriteLine("\nPrint Meals with meal number\n-------------------------");
        // Print all meals with their meal number
        for(int index = 0; index < mealList.Count(); index++){
            Console.WriteLine($"Meal {index + 1}: {mealList[index]}");
        }

        int randomMeals = 3;
        // Create a random listing of meals
        List<string> randomMealsList = GenerateList(randomMeals, mealList);


    }

    // Function to create a random list of meals
    // Input: List of strings, number of meals to generate
    // Output: list of random meals

    /*static List<string> GenerateList(int numberOfMeals, List<string> listOfMeals){
        List<string> randomMeals = new List<string>();
        Random randomGenerator = new Random();

        while(randomMeals.Count() < numberOfMeals){
            // Generate a random number between 0 and list.count()
            int randomIndex = randomGenerator.Next(0, randomMeals.Count());
            
            // Place meal at random index in list if meal is not already in the list
            if(!randomMeals.Contains(listOfMeals[randomIndex])){
                randomMeals.Add(listOfMeals[randomIndex]);
            }

            


        }
        return randomMeals;
    }
    */

    static List<string> GenerateList(int numberOfMeals, List<string> listOfMeals){
    List<string> randomMeals = new List<string>();
    Random randomGenerator = new Random();

    while(randomMeals.Count < numberOfMeals){
        // Generate a random number between 0 and the number of meals available in listOfMeals
        int randomIndex = randomGenerator.Next(0, listOfMeals.Count);
        
        // Place meal at random index in list if meal is not already in the list
        if(!randomMeals.Contains(listOfMeals[randomIndex])){
            randomMeals.Add(listOfMeals[randomIndex]);
        }
    }
    return randomMeals;
    }

}
