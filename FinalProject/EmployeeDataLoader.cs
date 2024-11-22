namespace FinalProject;

// Create a class to read data from a file and return a list of objects
public class EmployeeDataLoader{
    
    // Create a method to read data from a file and return a list of Employees
    public static List<Employee> LoadEmployees(string filePath){
        // Create an empty list to store Employee objects
        List<Employee> employeeDataList = new List<Employee>();

        try{
            using(StreamReader fileReader = new StreamReader(filePath)){
            int lineNumber = 0;
            int piecesOfData = 5;

            // Skip the first line which is the header row
            string headerData = fileReader.ReadLine()!;

            // Read names from the file line by line
            while(!fileReader.EndOfStream){
                lineNumber ++;
                string lineofData = fileReader.ReadLine()!;

                // Split each line at the ","
                string[] employeeData = lineofData.Split(",");

                //check that there are 5 pieces of data
                if(employeeData.Length != 5){
                    string errorMessage = $"Error in line {lineNumber}: Contains {employeeData.Length} pieces of data with it should contain {piecesOfData}";
                    LogError(errorMessage);
                    continue;
                }

                try{
                    // Index the data into list
                    string username = employeeData[0];
                    string password = employeeData[1];
                    string first_name = employeeData[2];
                    string last_name = employeeData[3];
                    string jobTitleString = employeeData[4].Replace(" ", "_");
                    JobTitle employeeJob = Enum.Parse<JobTitle>(jobTitleString);
                    
                // Add each index to the list
                employeeDataList.Add(new Employee(username, password, employeeJob, first_name, last_name));

                }catch(Exception err){
                    string errorMessage = $"There was an error on line {lineNumber} in the data file: {err.Message}";
                    LogError(errorMessage);
                    continue;
                    }
                }  
            }
        
        }catch(Exception err){
            // File not found error
            LogError($"File not found: {filePath}. Exception: {err.Message}");
            Console.WriteLine("Error: File not found. Please check the file path.");
        }
        return employeeDataList;
    }

    //create a method top log errors
    public static void LogError(string errorMessage){
        DateTime logDate = DateTime.Now;

        using(StreamWriter logger = File.AppendText("log.txt")){
            logger.WriteLine($"{logDate}: {errorMessage}");
        }
    } 
}
