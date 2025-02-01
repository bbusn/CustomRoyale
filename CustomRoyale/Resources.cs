using CustomRoyale.Core;

namespace CustomRoyale
{
    public static class Resources
    {
        public static Logger Logger { get; set; }
        public static Configuration Configuration { get; set; }
        public static LangConfiguration LangConfiguration { get; set; }
        public static Database.DatabaseManager DatabaseManager { get; set; }
        public static DateTime StartTime { get; set; }

        public static async void Initialize()
        {
            Logger = new Logger();
            Logger.Log("Starting server...", ErrorLevel.Info);

            Configuration = new Configuration();

            Configuration.Initialize();

            LangConfiguration = new LangConfiguration();

            LangConfiguration.Initialize();

            DatabaseManager = new Database.DatabaseManager();

            await Database.DatabaseManager.InitializeAsync();
        }

    }
}