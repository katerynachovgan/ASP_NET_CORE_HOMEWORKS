

namespace EF_HW.Models
{
    public class ProducingCountry
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Capital { get; set; }

        public int VaccineId { get; set; }
        public Vaccine Vaccine { get; set; }
    }
}
