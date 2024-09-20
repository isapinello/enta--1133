namespace Lesson2_IsabelaAmorim
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Isabela Pinello Amorim");
            Console.WriteLine("2024-09-19");

            GameManager manager = new GameManager(); //Created the instance of a Game Manager

            manager.PlayGame(); //With the .PlayGame, it is connecting to the GameManager class
            
            Console.WriteLine("Thank you for playing!");
        }
    }
}
