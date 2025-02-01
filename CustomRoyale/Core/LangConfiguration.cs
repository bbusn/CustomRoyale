using System;
using System.IO;
using System.Text.Json;
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


        [JsonProperty("PlayerJoined")] public string PlrJoined = "Player %PlayerName joined the server";
        [JsonProperty("PlayerDisconnected")] public string PlrConnLost = "Player %PlayerName disconnected";
        [JsonProperty("StartingServer")] public string SrvStarting = "Server is starting, please wait";
        [JsonProperty("ShuttingDownServer")] public string SrvClosing = "Server is shutting down, sorry for inconvenience";
        [JsonProperty("BattleStarted")] public string BattleStarted = "Battle with id %id started";
        [JsonProperty("BattleEnded")] public string BattleEnded = "Battle with id %id ended";
        [JsonProperty("PlayerJoinedBattle")] public string PlayerJoined = "Player %username joined battle with id %id";
        

        public void Initialize();
        {
            if (File.Exists("lang.json")) 
            {

            }
        }
    }
}