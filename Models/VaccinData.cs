namespace pandemie.Models
{
    public class VaccinData
    {
        public IEnumerable<Vaccin> Vaccinuri { get; set; }
        public IEnumerable<Tip> Tipuri { get; set; }
        public IEnumerable<VaccinTip> VaccinTipuri { get; set; }
    }
}
