using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace pandemie.Models
{
    public class Fond
    {
        public int ID { get; set; }
        public string Ordin { get; set; }
        [Display(Name = "Data la care a fost aprobat")]
        [DataType(DataType.Date)]
        public DateTime Data_ordin { get; set; }
        [Column(TypeName = "decimal(10, 2)")]

        public decimal Masti { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Vaccinuri { get; set; }
        [Column(TypeName = "decimal(10, 2)")]

        public decimal Testare { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        [Display(Name = "Ajutor intreprinderi")]
        public decimal Ajutor_intreprinderi { get; set; }
        public int? TaraID { get; set; }
        public Tara? Tara { get; set; }
    }
}
