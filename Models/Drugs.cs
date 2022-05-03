using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MaxDoseCheckerMVC.Models
{
    public class Drugs

    {
        public int Id { get; set; }
        public string Route { get; set; }
        public string Name { get; set; }
         public decimal MaxDose { get; set; }
         public string DoseType { get; set; }
        public static List<Drugs> GetDrugInfoFromCsv()
        {


            string path = System.IO.Directory.GetCurrentDirectory()
            + @"\data\drugs.csv";

            List<Drugs> values = File.ReadAllLines(path)
                                           .Skip(1)
                                           .Select(v => Drugs.FromCsv(v))
                                           .ToList();

            return values;

        }

        public static Drugs FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            Drugs Drugs = new Drugs();
            Drugs.Id = Convert.ToInt32(values[0]);
            Drugs.Route = Convert.ToString(values[1]);
            Drugs.Name = Convert.ToString(values[2]);
            Drugs.MaxDose = Convert.ToDecimal(values[3]);
            Drugs.DoseType = Convert.ToString(values[4]);

            return Drugs;
        }
    }
}