using System.ComponentModel.DataAnnotations;

namespace pandemie.Models
{
    public class Membru
    {
        public int ID { get; set; }
        public string? Nume { get; set; }
        public string? Prenume { get; set; }
        public string? Adress { get; set; }
        public string Email { get; set; }
        public string? Telefon { get; set; }
        [Display(Name = "Nume complet")]
        public string? NumeComplet
        {
            get
            {
                return Nume + " " + Prenume;
            }
        }
        public ICollection<Achizitie>? Achizitii { get; set; }
    }
}
