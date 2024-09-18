namespace DictionaryExample;

class Program
{
    static void Main(string[] args)
    {
        // Declare a dictionary of student names and scores. Name is a string and score is a float
        Dictionary<string, float> studentScores = new Dictionary<string, float>(){
            {"Brian", 94},
            {"Cyndi", 97.1f},
            {"Truman", 87.7f}
        };

        // Add an entry to the dictionary
        studentScores.Add("Jaime", 89);

        // Print values from the dictionary
        Console.WriteLine("Get Values from Dictionary\n---------------");
        Console.WriteLine(studentScores["Brian"]);
        Console.WriteLine(studentScores["Cyndi"]);
        Console.WriteLine(studentScores["Truman"]);

        // Loop through the dictionary
        Console.WriteLine("\nGet Key & Values from Dictionary\n---------------");
        foreach(KeyValuePair<string, float> student in studentScores){
            Console.WriteLine($"{student.Key}: {student.Value}");
        }

        // Loop through the dictionary with keys
        Console.WriteLine("\nGet Values from Dictionary using the Key\n---------------");
        foreach(string key in studentScores.Keys){
            Console.WriteLine($"{key}: {studentScores[key]}");
        }

        // Reference a key that is not in the dictionary
        // Console.WriteLine(studentScores["Tyler"]);

        // Check if key exists in the dictionary
        Console.WriteLine("\nSearch Dictionary for Valid Key\n------------------");
        string searchKey = "Truman";

        if(studentScores.ContainsKey(searchKey)){
            Console.WriteLine($"{searchKey}: {studentScores[searchKey]}");
        }else{
            Console.WriteLine($"{searchKey} not found in the dictionary");
        }


    }
}
