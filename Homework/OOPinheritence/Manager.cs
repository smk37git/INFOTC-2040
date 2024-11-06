namespace OOPinheritence{
    
    // Subclass of Employee
    public class Manager : Employee{

        // Manager NEW properties
        private string department;
        private string region;

        // Create a class constructor
        public Manager(string firstName, string lastName, string id, string department, string region) : base(firstName, lastName, id, EmployeeType.Manager){
            this.department = department;
            this.region = region;
        }

        // METHODS
        // Get Manager Department
        public string getDepartment(){
                return this.department;
        }
        // Set Manager Department
        public void setDepartment(string newDepartment){
        this.department = newDepartment;
        }

        // Get Manager Region
        public string getRegion(){
                return this.region;
        }
        // Set Manager Region
        public void setRegion(string newRegion){
        this.region = newRegion;
        }
    }
}