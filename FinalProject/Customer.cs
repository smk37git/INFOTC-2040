namespace FinalProject;

public class Customer : Person{
    // Declare class properties
    private string account_number = "";
    private string CustomerPIN = "";
    private double balance;
    private string account_type = "";
    private string loan_type = "";
    private double loanBalance;

    // Create a class constructor
    public Customer(string account_number, string CustomerPIN, string first_name, string last_name, double balance, string account_type, string loan_type, double loanBalance){
        this.account_number = account_number;
        this.CustomerPIN = CustomerPIN;
        this.balance = balance;
        this.account_type = account_type;
        this.loan_type = loan_type;
        this.loanBalance = loanBalance;

        // Inherited Properties
        this.First_Name = first_name;
        this.Last_Name = last_name;
    }

    // Get and Set methods
    public string AccountNumber{
        get{return this.account_number;}
        set{account_number = value;}
    }

    public string PIN{
        get{return this.CustomerPIN;}
        set{CustomerPIN = value;}
    }

    public double Balance{
        get{return this.balance;}
        set{balance = value;}
    }

    public string AccountType{
        get{return this.account_type;}
        set{account_type = value;}
    }

    public string LoanType{
        get{return this.loan_type;}
        set{loan_type = value;}
    }

    public double LoanBalance{
        get{return this.loanBalance;}
        set{loanBalance = value;}
    }

    // Override the GetInfo() method
    public override string GetInfo()
    {
        return $"---------- ACCOUNT #:{AccountNumber} --------------\nName: {First_Name} {Last_Name}\n{AccountType} Account Balance: ${Balance:F2}\n{LoanType} Loan Balance: ${LoanBalance:F2}";
    }
}