using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MaxDoseCheckerMVC.Models
{
    public class Drug

    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Route { get; set; }
        public decimal MaxDose { get; set; }
        public string Frequency { get; set; }

        public static List<Drug> GetDrugInfoFromCsv()
        {


            try
            {
                //Debug
                #if DEBUG
                 string path = System.IO.Directory.GetCurrentDirectory()
                          + @"\wwwroot\data\drugs.csv";
                //Live
                #else
                    string path = Environment.GetEnvironmentVariable("HOME") +
                                    "\\site\\wwwroot\\wwwroot\\data\\drugs.csv";
                #endif
                List<Drug> values = File.ReadAllLines(path)
                                               .Skip(1)
                                               .Select(v => Drug.FromCsv(v))
                                               .ToList();

                return values;
            }
            catch (Exception e)
            {

                throw e;
            }



        }

        public static Drug FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            Drug Drugs = new Drug();
            Drugs.Id = Convert.ToInt32(values[0]);
            Drugs.Name = Convert.ToString(values[1]);
            Drugs.Route = Convert.ToString(values[2]);
            Drugs.MaxDose = Convert.ToDecimal(values[3]);
            Drugs.Frequency = Convert.ToString(values[4]);

            return Drugs;
        }

        public static int CalculateMaxDoseUtilisation(decimal? dose, decimal? maxDose)
        {
            int maxDoseUtilisation = (int)(dose / maxDose * 100);

            return maxDoseUtilisation;
        }
    }
}