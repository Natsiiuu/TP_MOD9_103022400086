using System;
using System.IO;
using System.Text.Json;

namespace TP_MODUL9_103022400086
{
    public class ConfigDetail
    {
        public string satuan_suhu { get; set; }
        public int batas_hari_demam { get; set; } 
        public string pesan_ditolak { get; set; }
        public string pesan_diterima { get; set; }
    }

    public class CovidConfig
    {
        public ConfigDetail config;
        private const string filePath = "covid_config.json";

        public CovidConfig()
        {
            try
            {
                ReadConfigFile();
            }
            catch (Exception)
            {
                SetDefault();
                WriteNewConfigFile();
            }
        }

        private void ReadConfigFile()
        {
            string configJsonData = File.ReadAllText(filePath);
            config = JsonSerializer.Deserialize<ConfigDetail>(configJsonData);
        }

        private void SetDefault()
        {
            config = new ConfigDetail
            {
                satuan_suhu = "celcius",
                batas_hari_demam = 14,
                pesan_ditolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini",
                pesan_diterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini"
            };
        }

        public void WriteNewConfigFile()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(config, options);
            File.WriteAllText(filePath, jsonString);
        }

        public void UbahSatuan()
        {
            config.satuan_suhu = (config.satuan_suhu == "celcius") ? "fahrenheit" : "celcius";
            WriteNewConfigFile();
        }
    }
}