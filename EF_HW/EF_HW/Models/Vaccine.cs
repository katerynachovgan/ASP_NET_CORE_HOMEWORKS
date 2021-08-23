
using System.Collections.Generic;

namespace EF_HW.Models
{
    public class Vaccine
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ProducingCountry Country { get; set; }

        public int DiseaseId { get; set; }
        public Disease Disease { get; set; }

        public List<CountriesWithAllowed> AllCountries { get; set; } = new List<CountriesWithAllowed>();
    }
}
