using System;
namespace Banks.ConsoleInterface
{
    public class Interactions
    {
        public static string Interaction()
        {
            Console.WriteLine("Hello! Welcome to our Bank!\n");
            Console.WriteLine("Your have some options.\n");
            Console.WriteLine("Choose one of them:\n" +
                "1) Create new account\n" +
                "2) Show your balance\n" +
                "3) Put money\n" +
                "4) Get money\n" +
                "5) Transfer money to another account\n");

            return Console.ReadLine();
        }
    }
}