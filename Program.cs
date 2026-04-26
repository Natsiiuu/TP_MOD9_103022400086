using System;

namespace TP_MODUL9_103022400086
{
    class Program
    {
        static void Main(string[] args)
        {
            CovidConfig covidConfig = new CovidConfig();

            Console.Write($"Berapa suhu badan anda saat ini? Dalam nilai {covidConfig.config.satuan_suhu}: ");
            double suhu = Convert.ToDouble(Console.ReadLine());

            Console.Write("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam? ");
            int hari = Convert.ToInt32(Console.ReadLine());

            bool isSuhuValid = false;
            if (covidConfig.config.satuan_suhu == "celcius")
            {
                isSuhuValid = (suhu >= 36.5 && suhu <= 37.5);
            }
            else
            {
                isSuhuValid = (suhu >= 97.7 && suhu <= 99.5);
            }

            bool isHariValid = (hari < covidConfig.config.batas_hari_demam);

            if (isSuhuValid && isHariValid)
            {
                Console.WriteLine("\n" + covidConfig.config.pesan_diterima);
            }
            else
            {
                Console.WriteLine("\n" + covidConfig.config.pesan_ditolak);
            }

            covidConfig.UbahSatuan();
            Console.WriteLine($"\n[Sistem] Satuan telah diubah otomatis menjadi: {covidConfig.config.satuan_suhu}");
        }
    }
}