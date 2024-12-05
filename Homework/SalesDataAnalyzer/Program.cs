namespace SalesDataAnalyzer;

class Program
{
    static void Main(string[] args)
    {
        // Sebastian Main - INFOTC 2040 - Sales Data Analyzer

        // Clear Console
        Console.Clear();

        // Prompt for the .txt filepath
        Console.WriteLine("----------------SALES DATA ANALYZER----------------");
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


        // This variable will contain the data for the reports.
        // Concatentate the results from each query to this string
        string reportDocument = "";

        // Create the list for salesData.csv
        List<(string Region, string Country, string ItemType, string SalesChannel, string OrderPriority, string OrderDate, int OrderID, string ShipDate, int UnitsSold, decimal UnitPrice, decimal UnitCost)> salesDataList = new List<(string Region, string Country, string ItemType, string SalesChannel, string OrderPriority, string OrderDate, int OrderID, string ShipDate, int UnitsSold, decimal UnitPrice, decimal UnitCost)>();

        // Open the file
        try{
            using(StreamReader fileReader = new StreamReader(dataFile)){
                int lineNumber = 0;
                int piecesOfData = 11;

                // Skip the first line which is the header row
                string headerData = fileReader.ReadLine()!;

                // Read names from the file line by line
                while(!fileReader.EndOfStream){
                    lineNumber ++;
                    string lineofData = fileReader.ReadLine()!;

                    // Split each line at the ","
                    string[] salesDataData = lineofData.Split(",");

                    //check that there are 11 pieces of data
                    if(salesDataData.Length != 11){
                        string errorMessage = $"Error in line {lineNumber}: Contains {salesDataData.Length} pieces of data with it should contain {piecesOfData}";
                        LogError(errorMessage);
                        continue;
                    }

                    try{
                    // Index the data into list
                    string Region = salesDataData[0];
                    string Country = salesDataData[1];
                    string ItemType = salesDataData[2];
                    string SalesChannel = salesDataData[3];
                    string OrderPriority = salesDataData[4];
                    string OrderDate = salesDataData[5];
                    int OrderID = int.Parse(salesDataData[6]);
                    string ShipDate = salesDataData[7];
                    int UnitsSold = int.Parse(salesDataData[8]);
                    decimal UnitPrice = decimal.Parse(salesDataData[9]);
                    decimal UnitCost = decimal.Parse(salesDataData[10]);


                    // Add each index to the list
                    salesDataList.Add((Region, Country, ItemType, SalesChannel, OrderPriority, OrderDate, OrderID, ShipDate, UnitsSold, UnitPrice, UnitCost));

                    }catch(Exception err){
                        string errorMessage = $"There was an error on line {lineNumber} in the data file: {err.Message}";
                        LogError(errorMessage);
                        continue;
                    }
                }  
            }

        }catch(Exception err){
            // File not found error
            LogError($"File not found: {args[0]}. Exception: {err.Message}");
            Console.WriteLine("Error: File not found. Please check the file path.");
        }
        

        // Make the report
        reportDocument += "----------SALES DATA ANALYZER REPORT----------\n";

        // QUESTIONS

        // QUESTION 1
        // Write Question
        reportDocument += "\n1. Calculate the total profit in the data set\n";
        
        // Calculate total profit in data = (total revenue = total cost of items sold)
        // (UnitsSold * UnitPrice) - (UnitCost)
        decimal totalProfit = 0;

        foreach(var sale in salesDataList) {
            decimal profit = sale.UnitsSold * (sale.UnitPrice - sale.UnitCost);
            totalProfit += profit;
        }

        // Write Answer
        reportDocument += $"Total Profit in data: {totalProfit:C}\n";

        
        // QUESTION 2
        // Write Question
        reportDocument += "\n2. Show the unique item types in the data";

        // Get the unique item types
        var UniqueItems = from item in salesDataList
                            group item by item.ItemType into ItemTypeGroup
                            orderby ItemTypeGroup.Key ascending
                            select ItemTypeGroup;
        // Write Answer
        foreach(var item in UniqueItems){
            if (!item.Key.Contains("\"")){
                reportDocument += $"\n{item.Key}";
            }
        }


        // QUESTION 3
        // Write Question
        reportDocument += "\n\n3. Calculate the total sales for each item type\n";

        // Sort for item type
        var itemTypeSales = from sale in salesDataList
                    group sale by sale.ItemType into salesGroup
                    orderby salesGroup.Key
                    select new{
                        ItemType = salesGroup.Key,
                        TotalSales = (from sale in salesGroup
                                      select sale.UnitsSold * sale.UnitPrice).Sum()};
        // Write Answer
        foreach(var item in itemTypeSales){
            reportDocument += $"{item.ItemType}: {item.TotalSales:C}\n";
        }


        // QUESTION 4
        // Write Question
        reportDocument += "\n4. Calculate the total sales per country\n";

        // Filter by country, then add sales
        // Sort for item type
        var CountrySales = from sale in salesDataList
                    group sale by sale.Country into salesGroup
                    orderby salesGroup.Key
                    select new{
                        Country = salesGroup.Key,
                        TotalSales = (from sale in salesGroup
                                      select sale.UnitsSold * sale.UnitPrice).Sum()};
        // Write Answer
        foreach(var item in CountrySales){
            reportDocument += $"{item.Country}: {item.TotalSales:C}\n";
        }


        // QUESTION 5
        // Write Question
        reportDocument += "\n5. Which order(s) have the highest sales value\n";

        // calculate the sales data
        var orderSales = from sale in salesDataList
                select new{
                    OrderID = sale.OrderID,
                    SalesValue = sale.UnitsSold * sale.UnitPrice
                };
        // Find the maximum sales number
        decimal maxSalesValue = (from order in orderSales
                                select order.SalesValue).Max();
        // Get all orders with the maximum sales value
        var highestSalesOrders = from order in orderSales
                                where order.SalesValue == maxSalesValue
                                select order;
        // Write Answer
        foreach(var order in highestSalesOrders){
            reportDocument += $"{order.OrderID}: {order.SalesValue:C}\n";
        }


        // QUESTION 6
        // Write Question
        reportDocument += "\n6. Calculate the total sales per year";

        // Get the total sales per year in the data
        var TotalSales = from sale in salesDataList
                        let orderYear = DateTime.ParseExact(sale.OrderDate, "M/d/yy", null).Year
                        group sale by orderYear into SaleYearGroup
                        orderby SaleYearGroup.Key ascending
                        select SaleYearGroup;
        foreach(var yearGroup in TotalSales){
            decimal totalSales = 0;
            foreach(var sale in yearGroup){
                totalSales += sale.UnitsSold * sale.UnitPrice;
            }

            // Write Answer
            reportDocument += $"\n{yearGroup.Key}: {totalSales:C}";
        }


        // QUESTION 7
        // Write Question
        reportDocument += "$\n\n7. Calculate the total sales per sales channel\n";

        // Filter by sales channel, then add sales
        // Sort for item type
        var ChannelSales = from sale in salesDataList
                    group sale by sale.SalesChannel into salesGroup
                    orderby salesGroup.Key
                    select new{
                        SalesChannel = salesGroup.Key,
                        TotalSales = (from sale in salesGroup
                                      select sale.UnitsSold * sale.UnitPrice).Sum()};
        // Write Answer
        foreach(var item in ChannelSales){
            reportDocument += $"{item.SalesChannel}: {item.TotalSales:C}\n";
        }


        // QUESTION 8
        // Write Question
        reportDocument += "\n8. Calculate the number of orders per order priority type\n";

        // Sort for order priority
        var OrdersPriority = from order in salesDataList
                    group order by order.OrderPriority into orderGroup
                    orderby orderGroup.Key
                    select new{
                        OrderPriority = orderGroup.Key,
                        TotalOrders = (from order in orderGroup
                                      select order.UnitsSold).Sum()};
        // Write Answer
        foreach(var order in OrdersPriority){
            reportDocument += $"{order.OrderPriority}: {order.TotalOrders:C}\n";
        }


        // QUESTION 9
        // Write Question
        reportDocument += "\n9. Calculate the average sale per item type\n";

        // Sort for item type
        var itemTypeSale = from sale in salesDataList
                    group sale by sale.ItemType into salesGroup
                    orderby salesGroup.Key
                    select new{
                        ItemType = salesGroup.Key,
                        AverageSales = (from sale in salesGroup
                                      select sale.UnitsSold * sale.UnitPrice).Average()};
        // Write Answer
        foreach(var item in itemTypeSale){
            reportDocument += $"{item.ItemType}: {item.AverageSales:C}\n";
        }


        // QUESTION 10
        // Write Question
        reportDocument += "\n10. Calculate the total number of orders per region\n";

        // Sort for region
        var RegionOrders = from order in salesDataList
                   group order by order.Region into regionGroup
                   orderby regionGroup.Key
                   select new{
                       Region = regionGroup.Key,
                       TotalOrders = (from order in regionGroup
                                      select order).Count()};
        // Write Answer
        foreach(var region in RegionOrders){
            reportDocument += $"{region.Region}: {region.TotalOrders}\n";
        }


        // QUESTION 11
        // Write Question
        reportDocument += "\n11. Which region orders the most beverages\n";

        // Sort for beverage
        var BeverageSales = from sale in salesDataList
                    where sale.ItemType == "Beverages"
                    group sale by sale.Region into regionGroup
                    orderby regionGroup.Key
                    select new{
                        Region = regionGroup.Key,
                        TotalBeverageOrders = regionGroup.Sum(sale => sale.UnitsSold)};
        // Find the region with the most beverage orders
        int maxOrders = 0;
        string topRegion = "";

        foreach(var region in BeverageSales){
            if(region.TotalBeverageOrders > maxOrders){
                maxOrders = region.TotalBeverageOrders;
                topRegion = region.Region;
            }
        }
        // Write Answer
        reportDocument += $"{topRegion}: {maxOrders:N0}\n";

        // QUESTION 12
        // Write Question
        reportDocument += "\n12. List the total Baby Food sales for each region\n";

        // sort for baby food
        var BabyFoodSales = from sale in salesDataList
                   where sale.ItemType == "Baby Food"
                   group sale by sale.Region into regionGroup
                   select new{
                       Region = regionGroup.Key,
                       TotalSales = (from sale in regionGroup
                                     select sale.UnitsSold * sale.UnitPrice).Sum()};
        // Write Answer
        foreach(var region in BabyFoodSales){
            reportDocument += $"{region.Region}: {region.TotalSales:C}\n";
        }


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
