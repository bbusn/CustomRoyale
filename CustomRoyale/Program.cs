namespace CustomRoyale
{
    public static class Program
    {
        private static void Main()
        {
            Console.Clear();
            Console.Title = "CustomRoyale";
            Console.ForegroundColor = ConsoleColor.Black;
            
            Resources.Initialize();

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
            Console.ForegroundColor = ConsoleColor.Black;

            Logger.Log("Press ENTER to shutdown the server....", ErrorLevel.Info);
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