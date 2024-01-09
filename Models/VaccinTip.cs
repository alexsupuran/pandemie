namespace pandemie.Models
{
    public class VaccinTip
    {
        public int ID { get; set; }
        public int VaccinID { get; set; }
        public Vaccin Vaccin { get; set; }
        public int TipID { get; set; }
        public Tip Tip { get; set; }
    }
}
