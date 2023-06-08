namespace Sinav.Models
{
	public class ViewModel
	{
		public IEnumerable<Urunler> urunler { get; set; }
		public IEnumerable<Renk> renk { get; set; }
		public IEnumerable<Boyut> boyut { get; set; }
	}
}
