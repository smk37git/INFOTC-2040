namespace CrimeAnalyzer;

class Program
{
    static void Main(string[] args)
    {
        // Crime Analyzer -- Sebastian Main -- INFOTC 2040

        // Clear Console
        Console.Clear();

        // Prompt for the csv filepath
        Console.WriteLine("----------------CRIME ANALYZER----------------");
        // Require the the program is run using command line arguments for the data file and the report file
        // If both command line arguments are not provided, then end the program
        if(args.Length != 2){
            Console.WriteLine("Error: Program requires 2 command line arguments as shown below.\n");
            Console.WriteLine("dotnet run <data file name> <report file name>");
            Environment.Exit(0);
        }

        // Get the command line arguments from args[]
        string dataFile = args[0];
        string reportFile = args[1];

        //This variable will contain the data for the reports.
        //We will concatentate the results from each query to this string
        string reportDocument = "";

        // Create list from CrimeData.csv
        List<(int Year, int Population, int ViolentCrime, int Murder, int Rape, int Robbery, int AggravatedAssault, int PropertyCrime, int Burglary, int Theft, int MotorVehicleTheft)> crimesList = new List<(int Year, int Population, int ViolentCrime, int Murder, int Rape, int Robbery, int AggravatedAssault, int PropertyCrime, int Burglary, int Theft, int MotorVehicleTheft)>();

        // Open the file
        using(StreamReader fileReader = new StreamReader(dataFile)){
            int lineNumber = 0;
            int piecesOfData = 11;

            // Skip the first line which is the header row
            string headerData = fileReader.ReadLine()!;

            // Read names from the file line by line
            while(!fileReader.EndOfStream){
                lineNumber ++;
                string lineofData = fileReader.ReadLine()!;

                // Split each line at the ", "
                string[] crimeData = lineofData.Split(",");

                //check that there are 11 pieces of data
                if(crimeData.Length != 11){
                    string errorMessage = $"Error in line {lineNumber}: Contains {crimeData.Length} pieces of data with it should contain {piecesOfData}";
                    LogError(errorMessage);
                    continue;
                }

                try{
                // Index the data into list
                int Year = int.Parse(crimeData[0]);
                int Population = int.Parse(crimeData[1]);
                int ViolentCrime = int.Parse(crimeData[2]);
                int Murder = int.Parse(crimeData[3]);
                int Rape = int.Parse(crimeData[4]);
                int Robbery = int.Parse(crimeData[5]);
                int AggravatedAssault = int.Parse(crimeData[6]);
                int PropertyCrime = int.Parse(crimeData[7]);
                int Burglary = int.Parse(crimeData[8]);
                int Theft = int.Parse(crimeData[9]);
                int MotorVehicleTheft = int.Parse(crimeData[10]);

                // Add each index to the list
                crimesList.Add((Year, Population, ViolentCrime, Murder, Rape, Robbery, AggravatedAssault, PropertyCrime, Burglary, Theft, MotorVehicleTheft));

                }catch(Exception err){
                    string errorMessage = $"There was an error on line {lineNumber} in the data file: {err.Message}";
                    LogError(errorMessage);
                    continue;
                }
            }

        }

        

        // Make the report
        reportDocument += "----------Crime Analyzer Report----------";

        // QUESTIONS

        // QUESTION 1
        // Get the years
        var years = from crime in crimesList
                select crime.Year;

        // Write Answer
        reportDocument += "\n1. What is the range of years included in the data?";
        reportDocument += $"\nPeriod: {years.First()}-{years.Last()}\n";


        // QUESTION 2
        // How many years of data are included?
        int Range = years.Last() - years.First();
        
        // Write Answer
        reportDocument += "\n2. How many years of data are included?";
        reportDocument += $"\nThere are {Range} years of data\n";
    

        // QUESTION 3
        // Years murders per year < 15000:
        var murderYears = from crime in crimesList
            where crime.Murder < 15000
            select crime.Year;

        // Write Answer
        reportDocument += "\n3. What years is the number of murders per year less than 15000?";
        foreach(var year in murderYears){
            reportDocument+= $"\n{year} ";
        }


        // QUESTION 4
        // Robberies per year > 500000:
        var robberyYears = from crime in crimesList
            where crime.Robbery > 500000
            select(crime.Year, crime.Robbery);

        // Write Answer
        reportDocument += "\n\n4. What are the years and associated robberies per year for years where the number of robberies is greater than 500000?";
        foreach(var robbery in robberyYears){
            reportDocument += $"\n{robbery.Year} = {robbery.Robbery}";
        }


        // QUESTION 5
        // What is the violent crime per capita rate for 2010:
        // Per capita rate = # of violent crimes a year / population of year
        foreach (var crime in crimesList){

            // Loop to find 2010 data
            if (crime.Year == 2010){
                var crimeData = crime;

                // Calculate Per Capita Rate
                double perCapita = (double)crimeData.ViolentCrime / crimeData.Population;

                // Write Answer
                reportDocument += "\n\n5. What is the violent crime per capita rate for 2010? Per capita rate is the number of violent crimes in a year divided by the size of the population that year.";
                reportDocument += $"\nPer Capita violent crime rate: {perCapita}\n";

                break; 
            }
        }


        // QUESTION 6
        // What is the average number of murders per year across all years?
        // Need to index all years for murder integer, then divide by Range.
        float NumberOfMurders = 0;
        float Total = 0;

        foreach(var crime in crimesList){

            // Add Murders
            NumberOfMurders += crime.Murder;

            // Average Murders
            Total = NumberOfMurders / Range;

        }

        // Write Answer
        reportDocument += "\n6. What is the average number of murders per year across all years?";
        reportDocument += $"\nThe average mumber of murders from all years: {Total}\n";


        // QUESTION 7
        // What is the average number of murders per year for 1994-1997?
        NumberOfMurders = 0; Total = 0;

        foreach(var crime in crimesList){
            if(crime.Year >= 1994 && crime.Year <= 1997){

            // Add Murders
            NumberOfMurders += crime.Murder;

            }
        }

        // Average Murders
        Total = NumberOfMurders / 4;

        // Write Answer
        reportDocument += "\n7. What is the average number of murders per year for 1994 to 1997?";
        reportDocument += $"\nThe average mumber of murders from 1994 to 1997: {Total:F2}\n";


        // QUESTION 8
        // What is the average number of murders per year for 2010-2013?
        NumberOfMurders = 0; Total = 0;

        foreach(var crime in crimesList){
            if(crime.Year >= 2010 && crime.Year <= 2013){

            // Add Murders
            NumberOfMurders += crime.Murder;

            }
        }

        // Average Murders
        Total = NumberOfMurders / 4;

        // Write Answer
        reportDocument += "\n8. What is the average number of murders per year for 2010 to 2013?";
        reportDocument += $"\nThe average mumber of murders from 2010 to 2013: {Total:F2}\n";


        // QUESTION 9
        // What is the minimum number of thefts per year for 1999 to 2004?
        int minimumTheft = 0;

        foreach(var crime in crimesList){
            if(crime.Year >= 1999 && crime.Year <= 2004){

                if(minimumTheft == 0 || crime.Theft < minimumTheft){
                    minimumTheft = crime.Theft;
                }
            }
        }

        // Write Answer
        reportDocument += "\n9. What is the minimum number of thefts per year for 1999 to 2004?";
        reportDocument += $"\nThe minimum numer of thefts from 1999 to 2004: {minimumTheft}\n";

        
        // QUESTION 10
        // What is the maximum number of thefts per year for 1999 to 2004?
        int maximumTheft = 0;

        foreach(var crime in crimesList){
            if(crime.Year >= 1999 && crime.Year <= 2004){

                if(maximumTheft == 0 || crime.Theft > minimumTheft){
                    maximumTheft = crime.Theft;
                }
            }
        }

        // Write Answer
        reportDocument += "\n10. What is the maximum number of thefts per year for 1999 to 2004?";
        reportDocument += $"\nThe maximum number of thefts from 1999 to 2004: {maximumTheft}\n";

        // QUESTION 11
        // What year had the highest number of motor vehicle thefts?
        int maximumVehicleTheft = 0;
        int MaxVehicleTheftYear = 0;

        foreach(var crime in crimesList){

            if(crime.MotorVehicleTheft > maximumVehicleTheft){

                maximumVehicleTheft = crime.MotorVehicleTheft;
                MaxVehicleTheftYear = crime.Year;

            }
        }

        // Write Answer
        reportDocument += "\n11. What year had the highest number of motor vehicle thefts?";
        reportDocument += $"\nThe year that had the highest number of motor vehicle thefts: {MaxVehicleTheftYear}\n";


        // Call the WriteReport function to write the report
        WriteReport(reportDocument, reportFile);
    
    }

    //create a method top log errors
    public static void LogError(string errorMessage){
        DateTime logDate = DateTime.Now;

        using(StreamWriter logger = File.AppendText("log.txt")){
            logger.WriteLine($"{logDate}: {errorMessage}");
        }
    } 

    // Function to write the report document
    // Input: report document string
    // Output: None
    static void WriteReport(string reportDocument, string reportFile){
        //write the report
        using(StreamWriter reportWriter = new StreamWriter(reportFile)){
            reportWriter.Write(reportDocument);
        }
    }

}
