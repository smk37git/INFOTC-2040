namespace LinqDemo;

    public class StudentDataLoader{
        //create a method to load students into a list
        public static List<Student> loadStudents(string filePath){
            //create an empty list to store the students in
            List<Student> studentList = new List<Student>();
            
            //open the file
            using(StreamReader fileReader = new StreamReader(filePath)){
                int lineNumber = 0;
                int piecesOfData = 5;

                //skip the first line of the file because it is a header row
                string lineOfData = fileReader.ReadLine()!;
                
                //read from the file
                while(!fileReader.EndOfStream){
                    //increment the line number
                    lineNumber ++;

                    //read the next line of data froim the file
                    lineOfData = fileReader.ReadLine()!;

                    //split the data
                    string[] studentData = lineOfData.Split(",");

                    //check that there are 5 pieces of data
                    if(studentData.Length != 5){
                        string errorMessage = $"Error in line {lineNumber}: Contains {studentData.Length} pieces of data with it should contain {piecesOfData}";
                        LogError(errorMessage);
                        continue;
                    }

                    //create student objects to load into the student list
                    try{
                        string firstName = studentData[0];
                        string lastName = studentData[1];
                        string major = studentData[2];
                        float gpa = float.Parse(studentData[3]);
                        int gradYear = int.Parse(studentData[4]);

                        //place student in the list
                        studentList.Add(new Student(firstName, lastName, major, gpa, gradYear));

                    }catch(Exception err){
                        string errorMessage = $"There was an error on line {lineNumber} in the data file: {err.Message}";
                        LogError(errorMessage);
                        continue;
                    }
                }
            }
            return studentList;
        }
    

    //create a method top log errors
    public static void LogError(string errorMessage){
        DateTime logDate = DateTime.Now;

        using(StreamWriter logger = File.AppendText("log.txt")){
            logger.WriteLine($"{logDate}: {errorMessage}");
        }
   } 

}
