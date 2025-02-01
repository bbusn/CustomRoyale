using System;
using System.IO;
using DotNetEnv;

namespace CustomRoyale.Core
{
    public class Configuration
    {
        public string ClusterKey { get; private set; }
        public string ClusterNonce { get; private set; }
        public int ClusterServerPort { get; private set; }
        public string EncryptionKey { get; private set; }
        public string MySqlDatabase { get; private set; }
        public string MySqlPassword { get; private set; }
        public string MySqlServer { get; private set; }
        public string MySqlUserId { get; private set; }
        public int ServerPort { get; private set; }
        public int MinTroph { get; private set; }
        public int MaxTroph { get; private set; }
        public int DefGold { get; private set; }
        public int DefGems { get; private set; }
        public int DefLevel { get; private set; }
        public bool UseUdp { get; private set; }
        public int Admin1 { get; private set; }
        public int Admin2 { get; private set; }
        public int Admin3 { get; private set; }
        public int GemsReward { get; private set; }
        public int GoldReward { get; private set; }
        public void Initialize()
        {
            Env.Load();

            ClusterKey = GetEnv("CLUSTER_ENCRYPTION_KEY", "f7dU0qCKSOYV4oxX0Fr8yYCVE6paoUYI7BMk1ccZaJeyhnuAKSRz7oAG9bTv3gHc");
            ClusterNonce = GetEnv("CLUSTER_ENCRYPTION_NONCE", "mvSmefyDIZfHcBB4bHidMmZhlTQUJcJsDY2XVU5RYvFbO2XAeGr0Ooyr3gb1H7fM96ql9g1xy50CiDgztTQN9ACITbnj6P9T");
            ClusterServerPort = GetEnvInt("CLUSTER_SERVER_PORT", 9876);
            EncryptionKey = GetEnv("ENCRYPTION_KEY", "fhsd6f86f67rt8fw78fw789we78r9789wer6re");
            
            MySqlDatabase = GetEnv("MYSQL_DATABASE", "customroyaledb");
            MySqlPassword = GetEnv("MYSQL_PASSWORD", "");
            MySqlServer = GetEnv("MYSQL_SERVER", "127.0.0.1");
            MySqlUserId = GetEnv("MYSQL_USER", "root");
            
            ServerPort = GetEnvInt("SERVER_PORT", 9339);
            
            MinTroph = GetEnvInt("MIN_TROPHIES", 0);
            MaxTroph = GetEnvInt("MAX_TROPHIES", 10000);
            DefGold = GetEnvInt("DEFAULT_GOLD", 1000);
            DefGems = GetEnvInt("DEFAULT_GEMS", 100);
            DefLevel = GetEnvInt("DEFAULT_LEVEL", 1);
            
            UseUdp = GetEnvBool("USE_UDP", false);
            
            Admin1 = GetEnvInt("ADMIN_ID_1", 0);
            Admin2 = GetEnvInt("ADMIN_ID_2", 0);
            Admin3 = GetEnvInt("ADMIN_ID_3", 0);
            
            GemsReward = GetEnvInt("GEMS_REWARD_AFTER_MATCH", 0);
            GoldReward = GetEnvInt("GOLD_REWARD_AFTER_MATCH", 500);
        }

        private string GetEnv(string key, string defaultValue)
        {
            return Environment.GetEnvironmentVariable(key) ?? defaultValue;
        }

        private int GetEnvInt(string key, int defaultValue)
        {
            return int.TryParse(Environment.GetEnvironmentVariable(key), out int result) ? result : defaultValue;
        }

        private bool GetEnvBool(string key, bool defaultValue)
        {
            return bool.TryParse(Environment.GetEnvironmentVariable(key), out bool result) ? result : defaultValue;
        }
    }
}