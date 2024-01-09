using System.ComponentModel.DataAnnotations;

namespace pandemie.Models
{
    public class Achizitie
    {
        public int ID { get; set; }
        public int? MembruID { get; set; }
        public Membru? Membru { get; set; }
        public int? VaccinID { get; set; }
        public Vaccin? Vaccin { get; set; }

        public int Cantitate { get; set; }
        [Display(Name = "Data achizitiei")]
        [DataType(DataType.Date)]
        public DateTime Data_achizitie { get; set; }

    }
}
