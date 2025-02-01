using System;
using System.Threading.Tasks;
using CustomRoyale.Core;

namespace CustomRoyale
{
    public static class Resources
    {
        public static Logger? Logger { get; set; }
        public static Configuration Configuration { get; set; }

        public static DateTime StartTime { get; set; }

        public static async void Initialize()
        {
            Logger = new Logger();
            Logger.Log($"[{DateTime.Now.ToString("yyyy-MM-dd")}] {DateTime.Now.ToString(" HH:mm:ss")} : Starting server...", ErrorLevel.Info);

            Configuration = new Configuration();

            Configuration.Initialize();
        }

    }
}