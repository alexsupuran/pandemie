using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace pandemie.Models
{
    public class Producator
    {
        public int ID { get; set; }
        [Display(Name = "Producator")]
        public string Nume { get; set; }
        public int? VaccinID { get; set; }
        public Vaccin? Vaccin { get; set; }
        public int? TaraID { get; set; }
        public Tara? Tara { get; set; }
    }
}
