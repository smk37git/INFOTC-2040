namespace FinalProject;

// Create a class to read data from a file and return a list of objects
public class CustomerDataLoader{
    
    // Create a method to read data from a file and return a list of Customers
    public static List<Customer> LoadCustomers(string filePath){
        // Create an empty list to store Customers objects
        List<Customer> customerDataList = new List<Customer>();

        try{
            using(StreamReader fileReader = new StreamReader(filePath)){
            int lineNumber = 0;
            int piecesOfData = 8;

            // Read names from the file line by line
            while(!fileReader.EndOfStream){
                lineNumber ++;
                string lineofData = fileReader.ReadLine()!;

                // Split each line at the ","
                string[] customerData = lineofData.Split(",");

                //check that there are 8 pieces of data
                if(customerData.Length != 8){
                    string errorMessage = $"Error in line {lineNumber}: Contains {customerData.Length} pieces of data with it should contain {piecesOfData}";
                    LogError(errorMessage);
                    continue;
                }

                try{
                    // Index the data into list
                    string account_number = customerData[0];
                    string CustomerPIN = customerData[1];
                    string first_name = customerData[2];
                    string last_name = customerData[3];
                    double balance = double.Parse(customerData[4]);
                    string account_type = customerData[5];
                    string loan_type = customerData[6];
                    double loanBalance = double.Parse(customerData[7]);
                
                // Add each index to the list
                customerDataList.Add(new Customer(account_number, CustomerPIN, first_name, last_name, balance, account_type, loan_type, loanBalance));

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
        return customerDataList;
    }

    //create a method top log errors
    public static void LogError(string errorMessage){
        DateTime logDate = DateTime.Now;

        using(StreamWriter logger = File.AppendText("log.txt")){
            logger.WriteLine($"{logDate}: {errorMessage}");
        }
    } 
}
