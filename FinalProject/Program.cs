namespace FinalProject;

// Sebastian Main - INFOTC 2040 - FINAL PROJECT
// ONLINE BANKING APPLICATION

class Program
{
    // Global reference for customer data
    static List<Customer> customerDataList = new List<Customer>();
    // Global reference for employee data
    static List<Employee> employeeDataList = new List<Employee>();

    static void Main(string[] args){
        // Starting Line
        Console.WriteLine("\nWelcome to your Online Banking Application!\n");

        // Create a list of customers
        customerDataList = CustomerDataLoader.LoadCustomers("customer_data.csv");

        // Create a list of employees
        employeeDataList = EmployeeDataLoader.LoadEmployees("employee_data.csv");

        // Main Menu Function --> Will go into option functions
        MainMenu();
    }


    static void MainMenu(){
        // Begin Menu
        Console.WriteLine("----------------------");
        Console.WriteLine("      MAIN MENU");
        Console.WriteLine("----------------------");
        // Choices
        Console.WriteLine("1. Account Login\n2. Create Account\n3. Administrator Login\n4. Quit");
        Console.Write("\nSelect Option: ");

        // Ask for option
        while(true){
            string MenuChoice = Console.ReadLine()!;

            // Check to see if MenuChoice is one digit
            if(MenuChoice.Length != 1){
                Console.WriteLine("\nERROR: Selection must be 1 digit long and from the options!");
                Console.Write("\nSelect Option: ");
                continue;
            }

            // Verify that the MenuChoice is a digit/number
            bool isMenuChoiceValid = true;
            foreach(char character in MenuChoice){
                if(!Char.IsDigit(character)){
                    isMenuChoiceValid = false;
                    break;
                }
            }
            if(isMenuChoiceValid == false){
                Console.WriteLine("\nERROR: Selection must be a digit!");
                Console.Write("\nSelect Option: ");
                continue;
            }

            // Check to see if MenuChoice is between 1-4
            if(int.Parse(MenuChoice) < 1 || int.Parse(MenuChoice) > 4){
                Console.WriteLine("\nERROR: Selection must be 1-4 from the options!");
                Console.Write("\nSelect Option: ");
                continue;
            }

            // Now that MenuChoice is validated, find the option and call that function
            int IntMenuChoice = int.Parse(MenuChoice);
            switch(IntMenuChoice){
                case 1:
                    // Account Login
                    Console.Write("\n");
                    AccountLogin();
                    break;
                case 2:
                    // Create Account
                    CreateAccount();
                    break;
                case 3:
                    // Administrator Login
                    AdministratorLogin();
                    break;
                case 4:
                    // Quit
                    Console.WriteLine("\nThank you for using Online Banking, Goodbye!");
                    Environment.Exit(0);
                    return;
                default:
                    Console.WriteLine("ERROR: Selection out of range!");
                    break;
            }
        }
    }

    static void AccountLogin(){
        // Begin Account Login Menu
        Console.WriteLine("----------------------");
        Console.WriteLine("    ACCOUNT LOGIN");
        Console.WriteLine("----------------------");

        Customer foundCustomer = null!;

        while(true){
            // Get User Account Number
            Console.WriteLine("\nEnter your account number:");
            string UserAccountNumber = Console.ReadLine()!;

            // Check whether the number is 16 characters long
            if(UserAccountNumber.Length != 16){
                Console.WriteLine("\nERROR: Account Number must be 16 digits!");
                continue;
            }

            // Verify the each character is a digit/number
            bool isAccNumValid = true;
            foreach(char character in UserAccountNumber){
                if(!Char.IsDigit(character)){
                    isAccNumValid = false;
                    break;
                }
            }

            if(isAccNumValid == false){
                Console.WriteLine("\nERROR: Account Number must be all digits!");
                continue;
            }

            // Verify that the first 6 numbers are 183977
            if(UserAccountNumber.Substring(0,6) != "183977"){
                Console.WriteLine("\nERROR: Account Number must start with [183977]!");
                continue;
            }

            // Search for the account number in the data
            foreach(var customer in customerDataList){
                if(customer.AccountNumber == UserAccountNumber){
                    foundCustomer = customer;
                    break;
                }
            }
            if(foundCustomer == null){
                Console.WriteLine("\nERROR: Account number not found!");
                continue;
            }
            
            // If Account Number is valid, break loop
            break;
        }

        // Get the User PIN
        while(true){
            Console.WriteLine("\nEnter your PIN:");
            string UserPIN = Console.ReadLine()!;

            // Check whether the number is between 0000 and 9999
            if(UserPIN.Length != 4){
                Console.WriteLine("\nERROR: PIN must be 4 digits!");
                continue;
            }

            // Verify the each character is a digit/number
            bool isPINValid = true;
            foreach(char character in UserPIN){
                if(!Char.IsDigit(character)){
                    isPINValid = false;
                    break;
                }
            }

            if(isPINValid == false){
                Console.WriteLine("\nERROR: PIN must be all digits!");
                continue;
            }

            // Search for PIN in the data
            if(foundCustomer.PIN != UserPIN){
                Console.WriteLine("\nERROR: Incorrect PIN!");
                continue;
            }

            // If the PIN is valid, break loop
            Console.WriteLine($"\nWelcome back {foundCustomer.First_Name} {foundCustomer.Last_Name}. How can we help you today?");
            break;
        }

        // Once done with both loops, call Account Services Function
        AccountServices(foundCustomer);
    }

    static void AccountServicesMenu(){
        // Begin Account Services Menu
        Console.WriteLine("----------------------");
        Console.WriteLine("   ACCOUNT SERVICES");
        Console.WriteLine("----------------------");

        // Write Services
        Console.WriteLine("\nWhat would you like to do?");
        Console.WriteLine("\n1. Make a Withdrawal\n2. Make a Deposit\n3. Transfer Funds to another User Account\n4. Make Loan Payment\n5. Customer Balance Inquiry\n6. Back to Main Menu");
        Console.Write("\nSelect Option: ");
    }

    static void AccountServices(Customer customer){

        // Ask for option
        while(true){

            // Call AccountServicesMenu Function
            AccountServicesMenu();
            string AccountServicesChoice = Console.ReadLine()!;

            // Check to see if AccountServicesChoice is one digit
            if(AccountServicesChoice.Length != 1){
                Console.WriteLine("\nERROR: Selection must be 1 digit long and from the options!");
                Console.Write("\nSelect Option: ");
                continue;
            }

            // Verify that the AccountServicesChoice is a digit/number
            bool isMenuChoiceValid = true;
            foreach(char character in AccountServicesChoice){
                if(!Char.IsDigit(character)){
                    isMenuChoiceValid = false;
                    break;
                }
            }
            if(isMenuChoiceValid == false){
                Console.WriteLine("\nERROR: Selection must be a digit!");
                Console.Write("\nSelect Option: ");
                continue;
            }

            // Check to see if AccountServicesChoice is between 1-6
            if(int.Parse(AccountServicesChoice) < 1 || int.Parse(AccountServicesChoice) > 6){
                Console.WriteLine("\nERROR: Selection must be 1-6 from the options!");
                Console.Write("\nSelect Option: ");
                continue;
            }

            // Now that MenuChoice is validated, find the option and call that function
            int IntAccServicesChoice = int.Parse(AccountServicesChoice);
            switch(IntAccServicesChoice){
                case 1:
                    while(true){
                        // Make a Withdrawal
                        Console.WriteLine("\nHow much would you like to withdraw?");
                        Console.Write("Amount: ");
                        string UserWithdrawal = Console.ReadLine()!;

                        // Verify that the UserWithdrawal is a digit/number
                        bool isUserWithdrawalValid = true;
                        foreach(char character in UserWithdrawal){
                            if(Char.IsLetter(character)){
                                isUserWithdrawalValid = false;
                                break;
                            }
                        }
                        if(isUserWithdrawalValid == false){
                            Console.WriteLine("\nERROR: Amount must be a digit!");
                            continue;
                        }

                        // Check to see if UserWithdrawal is positive
                        if(double.Parse(UserWithdrawal) < 0){
                            Console.WriteLine("\nERROR: Amount must be positive!");
                            continue;
                        }

                        // Check for decimal
                        int decimalIndex = UserWithdrawal.IndexOf('.');
                        if(decimalIndex != -1){
                            // Check to see if there are > 2 decimal numbers
                            if(UserWithdrawal.Substring(decimalIndex + 1).Length > 2){
                                Console.WriteLine("\nERROR: Amount cannot have more than two decimal places!");
                                continue;
                            }
                        }

                        // Check if the customer has enough balance
                        if(double.Parse(UserWithdrawal) > customer.Balance){
                            Console.WriteLine("\nERROR: Insufficient balance!");
                            continue;
                        }

                        // Subtract the withdrawal amount from the customers balance
                        customer.Balance -= double.Parse(UserWithdrawal);

                        // Write withdrawal
                        Console.WriteLine($"\nWithdrawal Succesful! Your new balance is {customer.Balance:C}.\n");

                        // Overwrite customer_data.csv
                        OverwriteCustomerData.OverwriteData(customerDataList, "customer_data.csv");
                        break;
                    }

                    break;
                case 2:
                    // Make a Deposit
                    while(true){
                        Console.WriteLine("\nHow much would you like to deposit?");
                        Console.Write("Amount: ");
                        string UserDeposit = Console.ReadLine()!;

                        // Verify that the UserDeposit is a digit/number
                        bool isUserDepositValid = true;
                        foreach(char character in UserDeposit){
                            if(Char.IsLetter(character)){
                                isUserDepositValid = false;
                                break;
                            }
                        }
                        if(isUserDepositValid == false){
                            Console.WriteLine("\nERROR: Amount must be a digit!");
                            continue;
                        }

                        // Check to see if UserDeposit is positive
                        if(double.Parse(UserDeposit) < 0){
                            Console.WriteLine("\nERROR: Amount must be positive!");
                            continue;
                        }

                        // Check for decimal
                        int decimalIndex = UserDeposit.IndexOf('.');
                        if(decimalIndex != -1){
                            // Check to see if there are > 2 decimal numbers
                            if(UserDeposit.Substring(decimalIndex + 1).Length > 2){
                                Console.WriteLine("\nERROR: Amount cannot have more than two decimal places!");
                                continue;
                            }
                        }

                        // Add the deposit amount to the customers balance
                        customer.Balance += double.Parse(UserDeposit);

                        // Write deposit
                        Console.WriteLine($"\nDeposit Successful! Your new balance is {customer.Balance:C}.\n");

                        // Overwrite customer_data.csv
                        OverwriteCustomerData.OverwriteData(customerDataList, "customer_data.csv");
                        break;
                    }
            
                    break;
                case 3:
                    // Transfer Funds to another User Account
                    while(true){
                        Console.WriteLine("\nHow much would you like to transfer?");
                        Console.Write("Amount: ");
                        string UserTransfer = Console.ReadLine()!;

                        // Verify that the UserPayment is a digit/number
                        bool isUserTransferValid = true;
                        foreach(char character in UserTransfer){
                            if(Char.IsLetter(character)){
                                isUserTransferValid = false;
                                break;
                            }
                        }
                        if(isUserTransferValid == false){
                            Console.WriteLine("\nERROR: Amount must be a digit!");
                            continue;
                        }

                        // Check to see if UserPayment is positive
                        if(double.Parse(UserTransfer) < 0){
                            Console.WriteLine("\nERROR: Amount must be positive!");
                            continue;
                        }

                        // Check for decimal
                        int decimalIndex = UserTransfer.IndexOf('.');
                        if(decimalIndex != -1){
                            // Check to see if there are > 2 decimal numbers
                            if(UserTransfer.Substring(decimalIndex + 1).Length > 2){
                                Console.WriteLine("\nERROR: Amount cannot have more than two decimal places!");
                                continue;
                            }
                        }

                        // Check if the customer has enough balance
                        if(double.Parse(UserTransfer) > customer.Balance){
                            Console.WriteLine("\nERROR: Insufficient balance!");
                            continue;
                        }

                        // See what account number to transfer the money to
                        Console.WriteLine("\nEnter the Account Number of the person to transfer to:");
                        Console.Write("Account #: ");
                        string TransferAccNumber = Console.ReadLine()!;

                        // Checking for account
                        bool accountExists = false;
                        Customer recipient = null!;

                        // Search for the account number in the data
                        foreach(var transferCustomer in customerDataList){
                            if(transferCustomer.AccountNumber == TransferAccNumber){
                                recipient = transferCustomer;
                                accountExists = true;
                                break;
                            }
                        }
                        // If the recipient account number is not found
                        if(!accountExists){
                            Console.WriteLine("\nERROR: Account number not found!");
                            continue;
                        }

                        // Subtract amount from original customer balance
                        customer.Balance -= double.Parse(UserTransfer);

                        // Add amount from original customer balance to recipient
                        recipient.Balance += double.Parse(UserTransfer);

                        // Write Success
                        Console.WriteLine($"Transfer Successful! Your new balance is ${customer.Balance}.\n");

                        // Overwrite customer_data.csv
                        OverwriteCustomerData.OverwriteData(customerDataList, "customer_data.csv");
                        break;
                    }

                    break;
                case 4:
                    // Make Loan Payment
                    if(customer.LoanType == "None"){
                            Console.WriteLine("\nYou do not have a loan balance to pay back!\n");
                    }else{
                        while(true){
                            // Make a Payment
                            Console.WriteLine("\nHow much would you like to pay?");
                            Console.Write("Amount: ");
                            string UserPayment = Console.ReadLine()!;

                            // Verify that the UserPayment is a digit/number
                            bool isUserPaymentValid = true;
                            foreach(char character in UserPayment){
                                if(Char.IsLetter(character)){
                                    isUserPaymentValid = false;
                                    break;
                                }
                            }
                            if(isUserPaymentValid == false){
                                Console.WriteLine("\nERROR: Amount must be a digit!");
                                continue;
                            }

                            // Check to see if UserPayment is positive
                            if(double.Parse(UserPayment) < 0){
                                Console.WriteLine("\nERROR: Amount must be positive!");
                                continue;
                            }

                            // Check for decimal
                            int decimalIndex = UserPayment.IndexOf('.');
                            if(decimalIndex != -1){
                                // Check to see if there are > 2 decimal numbers
                                if(UserPayment.Substring(decimalIndex + 1).Length > 2){
                                    Console.WriteLine("\nERROR: Amount cannot have more than two decimal places!");
                                    continue;
                                }
                            }

                            // Check if the customer has enough balance
                            if(double.Parse(UserPayment) > customer.Balance){
                                Console.WriteLine("\nERROR: Insufficient balance!");
                                continue;
                            }

                            // Subtract the payment amount from the customers actual balance
                            customer.Balance -= double.Parse(UserPayment);

                            // Subtract the payment amount from the customers loan balance
                            customer.LoanBalance -= double.Parse(UserPayment);

                            // Write withdrawal
                            Console.WriteLine($"\nLoan Payment Successful! Your new loan balance is {customer.LoanBalance:C}.\n");

                            // Overwrite customer_data.csv
                            OverwriteCustomerData.OverwriteData(customerDataList, "customer_data.csv");
                            break;
                        }
                    }

                    break;
                case 5:
                    // Customer Balance Inquiry
                    Console.WriteLine("\n" + customer.GetInfo() + "\n");
                    break;
                case 6:
                    // Back to Main Menu
                    Console.Write("\n");
                    MainMenu();
                    return;
                default:
                    Console.WriteLine("ERROR: Selection out of range!");
                break;
            }
        }

    }

    static void CreateAccount(){
        // Begin Create Account Menu
        Console.WriteLine("\n----------------------");
        Console.WriteLine("    CREATE ACCOUNT");
        Console.WriteLine("----------------------");

        // Create variables
        string UserFirstName = "";
        string UserLastName = "";
        string UserCreatedPIN = "";
        string UserAccountType = "";
        string newAccountNumber = "";

        // Create First Name
        while(true){
            // Enter First Name
            Console.WriteLine("\nEnter your first name:");
            UserFirstName = Console.ReadLine()!;

            // Validate First Name
            bool isUserFirstNameValid = true;
            foreach(char character in UserFirstName){
                if(!Char.IsLetter(character)){
                    isUserFirstNameValid = false;
                    break;
                }
            }
            if(isUserFirstNameValid == false){
                Console.WriteLine("\nERROR: First name must be all letters!");
                continue;
            }

            // If all information valid, break loop
            break;
        }

        // Create Last Name
        while(true){
            // Enter Last Name
            Console.WriteLine("\nEnter your last name:");
            UserLastName = Console.ReadLine()!;

            // Validate Last Name
            bool isUserLastNameValid = true;
            foreach(char character in UserLastName){
                if(!Char.IsLetter(character)){
                    isUserLastNameValid = false;
                    break;
                }
            }
            if(isUserLastNameValid == false){
                Console.WriteLine("\nERROR: Last name must be all letters!");
                continue;
            }

            // If all information valid, break loop
            break;
        }

        // Create PIN
        while(true){
            // Create a PIN
            Console.WriteLine("\nCreate your PIN [4 Digits]:");
            UserCreatedPIN = Console.ReadLine()!;

            // Check whether the number is between 0000 and 9999
            if(UserCreatedPIN.Length != 4){
                Console.WriteLine("\nERROR: PIN must be 4 digits!");
                continue;
            }

            // Verify the each character is a digit/number
            bool isPINValid = true;
            foreach(char character in UserCreatedPIN){
                if(!Char.IsDigit(character)){
                    isPINValid = false;
                    break;
                }
            }

            if(isPINValid == false){
                Console.WriteLine("\nERROR: PIN must be all digits!");
                continue;
            }

            // If all information valid, break loop
            break;
        }

        // Create Account Type
        while(true){
            // Enter Account Type
            Console.WriteLine("\nWhat type of account do you want to open:");
            Console.WriteLine("\n1. Savings\n2. Checking");
            Console.WriteLine("\nSelect Option:");
            UserAccountType = Console.ReadLine()!;

            // Check whether the number is 1 digit
            if(UserAccountType.Length != 1){
                Console.WriteLine("\nERROR: Selection must be 1 digit!");
                continue;
            }

            // Verify the each character is a digit/number
            bool isAccountValid = true;
            foreach(char character in UserAccountType){
                if(!Char.IsDigit(character)){
                    isAccountValid = false;
                    break;
                }
            }

            // Verify that UserAccountType is 1 or 2
            if(UserAccountType == "1"){
                UserAccountType = "Savings";
                break;
            }else if(UserAccountType == "2"){
                UserAccountType = "Checking";
                break;
            }else if(UserAccountType != "1" && UserAccountType != "2"){
                Console.WriteLine("\nERROR: Selection must be 1 [Savings] or 2 [Checking]!");
                continue;
            }

            if(isAccountValid == false){
                Console.WriteLine("\nERROR: Selection must be all digits!");
                continue;
            }

            // If all information valid, break loop
            break;
        }

        while(true){
            // Generate Account Number
            Random randomAccountNumber = new Random();

            // Generate a 10 digit random number
            decimal randomPart = randomAccountNumber.NextInt64(1000000000, 10000000000);

            // Add the 10 digit random number to the required 6 digit ID
            newAccountNumber = "183977" + randomPart.ToString();

            // Validate that Account Number doesn't already exist
            bool AccountNumberAlreadyExists = false;

            // Search for the account number in the data
            foreach(var existingCustomer in customerDataList){
                if(existingCustomer.AccountNumber == newAccountNumber){
                    AccountNumberAlreadyExists = true;
                    break;
                }
            }

            // If the new account number exists
            if(!AccountNumberAlreadyExists){
                break;
            }
        }

        // Create a new customer object
        Customer newCustomer = new Customer(
            newAccountNumber,
            UserCreatedPIN,
            UserFirstName,
            UserLastName,
            100,
            UserAccountType,
            "None",
            0
        );

        // Add the new customer to the customerDataList list
        customerDataList.Add(newCustomer);

        // Append to the CSV file
        OverwriteCustomerData.OverwriteData(customerDataList, "customer_data.csv");

        // Write Success Message`
        Console.WriteLine($"\nCongratulations {UserFirstName} {UserLastName}! Your account is now open with an initial deposit of $100!");
        Console.WriteLine($"Your account number is: {newAccountNumber}. You can login and access acount services now.");

        // Finally return to menu
        Console.Write("\n");
        MainMenu();

    }

    static void AdministratorLogin(){
        // Begin Admin Login Menu
        Console.WriteLine("----------------------");
        Console.WriteLine("    ADMIN LOGIN");
        Console.WriteLine("----------------------");

        Employee foundEmployee = null!;

        while(true){
            // Get Employee Username
            Console.WriteLine("\nEnter Employee username:");
            string UserUsername = Console.ReadLine()!;

            // Search for the account number in the data
            foreach(var employee in employeeDataList){
                if(employee.Username == UserUsername){
                    foundEmployee = employee;
                    break;
                }
            }
            if(foundEmployee == null){
                Console.WriteLine("\nERROR: Employee not found!");
                continue;
            }
            
            // If Employee Username is valid, break loop
            break;
        }

        // Get the Employee Password
        while(true){
            Console.WriteLine("\nEnter Employee password:");
            string UserPassword = Console.ReadLine()!;

            // Check whether the number is between 00000 and 99999
            if(UserPassword.Length != 5){
                Console.WriteLine("\nERROR: Password must be 5 digits");
                continue;
            }

            // Verify the each character is a digit/number
            bool isPasswordValid = true;
            foreach(char character in UserPassword){
                if(!Char.IsDigit(character)){
                    isPasswordValid = false;
                    break;
                }
            }

            if(isPasswordValid == false){
                Console.WriteLine("\nERROR: Password must be all digits!");
                continue;
            }

            // Search for PIN in the data
            if(foundEmployee.Password != UserPassword){
                Console.WriteLine("\nERROR: Incorrect Password!");
                continue;
            }

            // If the PIN is valid, break loop
            Console.WriteLine($"\nWelcome to the Admin Portal {foundEmployee.First_Name}!");
            break;
        }

        // Once done with both loops, call Account Services Function
        AdministratorServices(foundEmployee);
    }

    static void AdministratorServicesMenu(){
        // Begin Account Services Menu
        Console.WriteLine("\n----------------------");
        Console.WriteLine("    ADMIN PORTAL");
        Console.WriteLine("----------------------");

        // Write Services
        Console.WriteLine("\nSelect a report to review?");
        Console.WriteLine("\n1. Show average Savings Account balance\n2. Show total Savings Account balance\n3. Show average Checking Account balance\n4. Show total Checking Account balance\n5. Show the number of accounts for each account type");
        Console.WriteLine("6. Show the number of each type of loan\n7. Show total outstanding balance for each type of loan\n8. Show the average outstanding balance for each type of loan\n9. Show All Employee Information\n10. Back to Main Menu");
        Console.Write("\nSelect Option: ");
    }

    static void AdministratorServices(Employee employee){
        // Ask for option
        while(true){

            // Call AdminstratorServicesMenu Function
            AdministratorServicesMenu();
            string AdministatorServicesChoice = Console.ReadLine()!;

            // Check to see if AdministatorServicesChoice is one or two digit
            if(AdministatorServicesChoice.Length !> 3){
                Console.WriteLine("\nERROR: Selection must be from the options!");
                Console.Write("\nSelect Option: ");
                continue;
            }

            // Verify that the AdministatorServicesChoice is a digit/number
            bool isMenuChoiceValid = true;
            foreach(char character in AdministatorServicesChoice){
                if(!Char.IsDigit(character)){
                    isMenuChoiceValid = false;
                    break;
                }
            }
            if(isMenuChoiceValid == false){
                Console.WriteLine("\nERROR: Selection must be a digit!");
                Console.Write("\nSelect Option: ");
                continue;
            }

            // Check to see if AccountServicesChoice is between 1-10
            if(int.Parse(AdministatorServicesChoice) < 1 || int.Parse(AdministatorServicesChoice) > 10){
                Console.WriteLine("\nERROR: Selection must be 1-10 from the options!");
                Console.Write("\nSelect Option: ");
                continue;
            }

            // Now that AdministatorServicesChoice is validated, find the option and call that function
            int IntAdminServicesChoice = int.Parse(AdministatorServicesChoice);
            switch(IntAdminServicesChoice){
                case 1:
                    // Average Savings Account Balance
                    Console.WriteLine("\n-----Average Savings Account Balance Report-----");

                    var SavingsAvgTotal = (from balance in customerDataList
                    where balance.AccountType == "Savings"
                    select balance.Balance).Average();

                    // Write Average Savings Account Balance
                    Console.WriteLine($"Total Average balance from ALL Savings Accounts: {SavingsAvgTotal:C}");
                    
                    break;
                case 2:
                    // Total Savings Account Balance
                    Console.WriteLine("\n-----Total Savings Account Balance Report-----");

                    var SavingsTotal = from balance in customerDataList
                    where balance.AccountType == "Savings"
                    group balance by balance.AccountType into accountGroup
                    orderby accountGroup.Key
                    select new{
                        AccountType = accountGroup.Key,
                        TotalBalance = (from balance in accountGroup
                                      select balance.Balance).Sum()};
                        // Write Savings Total Account Balance
                        foreach(var item in SavingsTotal){
                            Console.WriteLine($"Total balance from ALL Savings Accounts: {item.TotalBalance:C}");
                        }
                    
                    break;
                case 3:
                    // Average Savings Account Balance
                    Console.WriteLine("\n-----Average Checking Account Balance Report-----");

                    var CheckingAvgTotal = (from balance in customerDataList
                    where balance.AccountType == "Checking"
                    select balance.Balance).Average();

                    // Write Average Savings Account Balance
                    Console.WriteLine($"Total Average balance from ALL Savings Accounts: {CheckingAvgTotal:C}");
                    
                    break;
                case 4:
                    // Total Checking Account Balance
                    Console.WriteLine("\n-----Total Checking Account Balance Report-----");

                    var CheckingTotal = from balance in customerDataList
                    where balance.AccountType == "Checking"
                    group balance by balance.AccountType into accountGroup
                    orderby accountGroup.Key
                    select new{
                        AccountType = accountGroup.Key,
                        TotalBalance = (from balance in accountGroup
                                      select balance.Balance).Sum()};
                        // Write Total Checking Account Balance
                        foreach(var item in CheckingTotal){
                            Console.WriteLine($"Total balance from ALL Checking Accounts: {item.TotalBalance:C}");
                        }
                    
                    break;
                case 5:
                    // Total Accounts for each AccountType
                    Console.WriteLine("\n-----Total Savings/Checking Accounts Report-----");
                    var TotalAccounts = from accounts in customerDataList
                    group accounts by accounts.AccountType into accountGroup
                    orderby accountGroup.Key
                    select new{
                        Account = accountGroup.Key,
                        TotalAccounts = (from account in accountGroup
                                            select account).Count()};
                    // Write Amount of Accounts
                    foreach(var account in TotalAccounts){
                        Console.WriteLine($"{account.Account}: {account.TotalAccounts}");
                    }
                    
                    break;
                case 6:
                    // Total Loans for each LoanType
                    Console.WriteLine("\n-----Total Loans Report-----");
                    var TotalLoans = from loans in customerDataList
                    group loans by loans.LoanType into loanGroup
                    orderby loanGroup.Key
                    select new{
                        Loan = loanGroup.Key,
                        TotalLoans = (from loan in loanGroup
                                            select loan).Count()};
                    // Write Amount of Loans in LoansType
                    foreach(var loan in TotalLoans){
                        Console.WriteLine($"{loan.Loan}: {loan.TotalLoans}");
                    }
                    
                    break;
                case 7:
                    // Total Loans Balance for each LoanType
                    Console.WriteLine("\n-----Total Loans Outstanding Balance Report-----");
                    var TotalLoansBalance = from loans in customerDataList
                    group loans by loans.LoanType into loanGroup
                    orderby loanGroup.Key
                    select new{
                        Loan = loanGroup.Key,
                        TotalLoansBalance = (from loan in loanGroup
                                            select loan.LoanBalance).Sum()};
                    // Write LoansType Balance
                    foreach(var loan in TotalLoansBalance){
                        Console.WriteLine($"{loan.Loan}: {loan.TotalLoansBalance:C}");
                    }
                    
                    break;
                case 8:
                    // Average Loans Balance for each LoanType
                    Console.WriteLine("\n-----Average Loans Outstanding Balance Report-----");
                    var AverageLoansBalance = from loans in customerDataList
                    group loans by loans.LoanType into loanGroup
                    orderby loanGroup.Key
                    select new{
                        Loan = loanGroup.Key,
                        AverageLoansBalance = (from loan in loanGroup
                                            select loan.LoanBalance).Average()};
                    // Write Average LoansType Balance
                    foreach(var loan in AverageLoansBalance){
                        Console.WriteLine($"{loan.Loan}: {loan.AverageLoansBalance:C}");
                    }
                    
                    break;
                case 9:
                    // Employee Information Inquiry
                    Console.Write("\n-----Employee Data------");
                    foreach(var Employee in employeeDataList){
                        Console.WriteLine("\n" + Employee.GetInfo());
                    }
                    Console.Write("\n");
                    break;
                case 10:
                    // Back to Main Menu
                    Console.Write("\n");
                    MainMenu();
                    return;
                default:
                    Console.WriteLine("ERROR: Selection out of range!");
                break;
            }
        }

    }

    // Overwrite customer_data.csv
    public class OverwriteCustomerData{
        public static void OverwriteData(List<Customer> customerDataList, string filePath){
            try{
                using (StreamWriter writer = new StreamWriter(filePath, false)){
                    foreach (var customer in customerDataList){

                        // Write customer details as CSV format
                        writer.WriteLine($"{customer.AccountNumber},{customer.PIN},{customer.First_Name},{customer.Last_Name},{customer.Balance:F2},{customer.AccountType},{customer.LoanType},{customer.LoanBalance:F2}");
                    }
                }
                
            }catch(Exception error){
                Console.WriteLine($"Error writing to file: {error.Message}");
            }
        }
    }
}