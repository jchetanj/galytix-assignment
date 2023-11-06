using System.Collections.Generic;
using Galytix.WebApi.Models;


namespace Galytix.WebApi.Models
{
    public class CountryGwpRequest
    {
        public string Country { get; set; }
        public List<string> LineOfBusiness { get; set; }
    }
}
