using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LAB11_MVC.Models
{
    // Used info from this location: https://stackoverflow.com/questions/26790477/read-csv-to-list-of-objects

    public class WineModel
    {
        public string ID { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public string Designation { get; set; }
        public int Points { get; set; }
        public decimal Price { get; set; }
        public string Region_1 { get; set; }
        public string Region_2 { get; set; }
        public string Variety { get; set; }
        public string Winery { get; set; }

        public static List<WineModel> WineList()
        {
            List<WineModel> list = new List<WineModel>();
            var reader = new StreamReader(File.OpenRead("../wine.csv"));
            while (!reader.EndOfStream)
            {
                var value = reader.ReadLine();
                WineModel newWine = FromCSV(Convert.ToString(value));
                list.Add(newWine);
            }
            return list;
        }

        public static WineModel FromCSV(string csvData)
        {
            string[] values = Regex.Split(csvData, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
            WineModel model = new WineModel
            {
                ID = values[0],
                Country = values[1],
                Description = values[2],
                Designation = values[3],
                Points = Convert.ToInt32(values[4]),
                Price = Convert.ToDecimal(values[5]),
                Region_1 = values[6],
                Region_2 = values[7],
                Variety = values[8],
                Winery = values[9]
            };
            return model;

        }
    }
}
