using System.Collections.Generic;

namespace EF_HW.Models
{
    public class CountriesWithAllowed
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Vaccine> Vaccines { get; set; } = new List<Vaccine>();
    }
}
