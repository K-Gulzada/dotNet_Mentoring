namespace SqlDbIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            CommonController commonController = new CommonController(); 
            commonController.GetEmployeeInfoList();
            
            Console.ReadKey();
        }

    }
}