using System.Collections.Generic;
using System.Threading.Tasks;

namespace Galytix.WebApi.Services
{
    public interface IGwpService
    {
        Task<Dictionary<string, double>> CalculateAverageGwp(string country, List<string> lineOfBusiness);
    }
}
