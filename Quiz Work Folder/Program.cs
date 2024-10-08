namespace Quiz_Work_Folder;

class Program
{
    static void Main(string[] args)
    {
        string s1 = "quick";
        string s2 = "Quick";

        if(s1.ToUpper() == s2){
            Console.WriteLine("The strings are equal");
        }else{
            Console.WriteLine("The strings are not equal");
        }
    }
}
