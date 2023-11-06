using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Galytix.WebApi.Models;

namespace Galytix.WebApi.Services
{
    public class GwpService : IGwpService
    {
        private readonly string dataPath = "Data/gwpByCountry.csv";

        public async Task<Dictionary<string, double>> CalculateAverageGwp(string country, List<string> lineOfBusiness)
        {
            try
            {
   
                var data = File.ReadLines(dataPath)
                    .Skip(1) // Skip the header line
                    .Select(line => line.Split('\t'))
                    .Where(fields => fields[0] == country && lineOfBusiness.Contains(fields[3]))
                    .GroupBy(fields => fields[3])
                    .ToDictionary(
                        group => group.Key,
                        group => group.Skip(4).Select(double.Parse).Average()
                    );

                return data;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while calculating average GWP.", ex);
            }
        }
    }
}
