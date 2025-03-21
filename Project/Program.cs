using Project.model;

namespace Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            DBConnection connection = new DBConnection();
            connection.CloseConnection();
        }
    }
}
