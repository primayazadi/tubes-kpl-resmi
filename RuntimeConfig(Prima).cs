using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace tubesbackuup
{
    public class RuntimeConfig
    {
        public Config config { get; set; }
        public string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        public string configFileName = "config.json";
        public RuntimeConfig()
        {
            try
            {
                ReadConfig();
            }
            catch
            {
                SetDefault();
                WriteConfig();
            }
        }
        public Config ReadConfig()
        {
            string jsonFromFile = File.ReadAllText(path + '/' + configFileName);
            config = JsonSerializer.Deserialize<Config>(jsonFromFile);
            return config;
        }

        public void WriteConfig()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            String jsonString = JsonSerializer.Serialize(config, options);
            string fullPath = path + '/' + configFileName;
            File.WriteAllText(fullPath, jsonString);
        }
        public void SetDefault()
        {
            config = new Config("Gaji", "Primer", "harian");
        }
    }
    public class Config
    {
        public string sumberPendapatan { get; set; }
        public string sumberPengeluaran { get; set; }
        public string jangkaAnalisis { get; set; }

        public Config() { }

        public Config(string sumberPendapatan, string sumberPengeluaran, string jangkaAnalisis)
        {
            this.sumberPendapatan = sumberPendapatan;
            this.sumberPengeluaran = sumberPengeluaran;
            this.jangkaAnalisis = jangkaAnalisis;
        }


    }
}


