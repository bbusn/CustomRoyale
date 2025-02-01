using System;
using System.IO;
using Newtonsoft.Json;

namespace CustomRoyale.Core {
    public class LangConfiguration
    {
        [JsonIgnore]
        public static JsonSerializerSettings JsonSettings = new JsonSerializerSettings
        {
            ObjectCreationHandling = ObjectCreationHandling.Reuse,
            MissingMemberHandling = MissingMemberHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore,
            TypeNameHandling = TypeNameHandling.Auto,
            Formatting = Formatting.None
        };

        [JsonProperty("PlayerJoined")] public string PlayerJoined { get; set; } = "Player %PlayerName joined the server";
        [JsonProperty("PlayerDisconnected")] public string PlayerConnLost { get; set; } = "Player %PlayerName disconnected";
        [JsonProperty("StartingServer")] public string ServerStarting { get; set; } = "Server is starting, please wait";
        [JsonProperty("ShuttingDownServer")] public string ServerClosing { get; set; } = "Server is shutting down, sorry for inconvenience";
        [JsonProperty("BattleStarted")] public string BattleStarted { get; set; } = "Battle with id %id started";
        [JsonProperty("BattleEnded")] public string BattleEnded { get; set; } = "Battle with id %id ended";
        [JsonProperty("PlayerJoinedBattle")] public string PlayerJoinedBattle { get; set; } = "Player %username joined battle with id %id";

        public void Initialize()
        {
            if (File.Exists("lang.json"))
            {
                try
                {
                    var lang = JsonConvert.DeserializeObject<LangConfiguration>(File.ReadAllText("lang.json"));
                    
                    if (lang != null)
                    {
                        PlayerJoined = lang.PlayerJoined;
                        PlayerConnLost = lang.PlayerConnLost;
                        ServerStarting = lang.ServerStarting;
                        ServerClosing = lang.ServerClosing;
                        BattleStarted = lang.BattleStarted;
                        BattleEnded = lang.BattleEnded;
                        PlayerJoinedBattle = lang.PlayerJoinedBattle;
                    }
                }
                catch (Exception ex)
                {
                    Logger.Log($"Error loading language file: {ex.Message}", ErrorLevel.Error);
                }
            }  
            else 
            {
                try
                {
                    Save();

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Logger.Log($"Created Lang.json file, restarting...", ErrorLevel.Info);
                    System.Diagnostics.Process.Start(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
                    Environment.Exit(0);
                }
                catch (Exception)
                {
                    Logger.Log($"Couldn't create Lang.json file, press any key to shutdown...", ErrorLevel.Error);
                    Console.ReadKey();
                    Environment.Exit(0);
                }
            }
        }

        public void Save()
        {
            File.WriteAllText("lang.json", JsonConvert.SerializeObject(this, Formatting.Indented));
        }
    }
}
