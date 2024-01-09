using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pandemie.Models
{
    public class Tara
    {
        public int ID { get; set; }
        [Display(Name = "Tara")]
        public string Name { get; set; }
        [Display(Name = "Cazuri lunare de infectati")]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Cazuri { get; set; }
        [Display(Name = "Cazuri lunare de morti")]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Morti { get; set; }
        public ICollection<Producator>? Producatori { get; set; }

        public ICollection<Fond>? Fonduri { get; set; }

    }
}
