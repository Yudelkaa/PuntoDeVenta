using PuntoDeVenta_Api.Models;
namespace Shared.Models
{
	public class CartItem
	{
		public Product? Product { get; set; }
		public int Quantity { get; set; }
		public decimal SubTotal { get; set; }

	}
}