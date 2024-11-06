namespace OOPinheritence{
    
    // Subclass of Employee
    public class SalesPerson : Employee{

        // SalesPerson NEW properties
        private string department;
        private float sales;

        // Create a class constructor
        public SalesPerson(string firstName, string lastName, string id, string department, float sales) : base(firstName, lastName, id, EmployeeType.Sales){
            this.department = department;
            this.sales = sales;
        }

        // Methods
        // Get Sales Method
        public float getSales(){
            return this.sales;
        }

        // Add Sales Method
        public void updateSales(float newSales){
            this.sales += newSales;
        }

        // Get Sales Level Method
        public SalesLevel GetSalesLevel(){
            if(sales < 10000){
                return SalesLevel.Bronze;
            }else if(sales >= 10000 && sales < 20000){
                return SalesLevel.Silver;
            }else if(sales >= 20000 && sales < 30000){
                return SalesLevel.Gold;
            }else if(sales >= 30000 && sales < 40000){
                return SalesLevel.Diamond;
            }else{
                return SalesLevel.Platinum;
            }
        }
    }
}