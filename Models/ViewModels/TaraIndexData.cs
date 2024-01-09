using pandemie.Models;
namespace pandemie.Models.ViewModels
{
    public class TaraIndexData
    {
        public IEnumerable<Producator> Producatori {  get; set; }
        public IEnumerable<Tara> Tari { get; set; }
    }
}
