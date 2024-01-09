using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace pandemie.Models
{
    public class Vaccin
    {
        public int ID { get; set; }
        [Display(Name = "Vaccin")]
        public string Nume { get; set; }

        [Display(Name = "Pretul de achizitie")]

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Pret_achizitie { get; set; }

        [Display(Name = "Data la care a fost aprobat")]
        [DataType(DataType.Date)]
        public DateTime Data_aprobare { get; set; }
        public ICollection<Producator>? Producatori { get; set; }
        [Display(Name = "Tip")]
        public ICollection<VaccinTip>? VaccinTipuri { get; set; }
        public ICollection<Achizitie>? Achizitii { get; set; }
        [Display(Name = "Link pentru mai multe informații")]
        public string Informatii { get; set; }
        
    }
}
