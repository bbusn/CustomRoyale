using System;
using System.Threading;

namespace CustomRoyale
{
    public static class Program
    {
        private static void Main()
        {
            Console.Clear();
            Console.Title = "CustomRoyale";
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("___________________________________________________________________________\n\n");
            Console.WriteLine(
                "                  __                                            __       \n" +
                ".----.--.--.-----|  |_.-----.--------.  .----.-----.--.--.---.-|  .-----.\n" +
                "|  __|  |  |__ --|   _|  _  |        |  |   _|  _  |  |  |  _  |  |  -__|\n" +
                "|____|_____|_____|____|_____|__|__|__|  |__| |_____|___  |___._|__|_____| \n" +
                "                                                   |_____|\n"
            );

            Console.WriteLine("Thanks to Incredible for orginal version of CR server.\nThanks to Zordon1337 for ZrdRoyale, a RetroRoyale Fork");
            Console.WriteLine("Fork of ZrdRoyale by bbusn");
            Console.WriteLine("___________________________________________________________________________\n\n");
            Console.WriteLine("Press any key to shutdown the server....");
                
            Console.Read();
            Shutdown();
        }

        public static void Shutdown()
        {
            Console.WriteLine("Shutting down server...");
        }

        public static void Exit()
        {
            Console.WriteLine("Shutting down server...");
            Environment.Exit(0);
        }
    }
}