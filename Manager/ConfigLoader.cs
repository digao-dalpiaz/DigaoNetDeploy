using Newtonsoft.Json;

namespace Manager
{
    internal class ConfigLoader
    {

        private static string GetFile()
        {
            return Path.Combine(AppContext.BaseDirectory, "config.json");
        }

        public static void Load()
        {
            string file = GetFile();
            if (File.Exists(file)) 
            {
                var contents = File.ReadAllText(file);
                Vars.Config = JsonConvert.DeserializeObject<Config>(contents);
            }
            else
            {
                Vars.Config = new Config();
                Vars.Config.Servers = [];
                Vars.Config.Pipelines = [];
            }
        }

        public static void Save() 
        { 
            File.WriteAllText(GetFile(), JsonConvert.SerializeObject(Vars.Config));
        }

    }
}
