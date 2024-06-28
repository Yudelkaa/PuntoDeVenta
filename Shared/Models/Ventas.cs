using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
	public class Ventas
	{
			[Key]
			public int VentaId { get; set; }
			[ForeignKey("Configuraciones")]
			public int ConfiguracionId { get; set; }

			[ForeignKey("ApplicationUser")]
			public string? ClienteId { get; set; }

			[Required(ErrorMessage = "El Combre del cliente es obligatorio")]
			[RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "El Nombre debe contener solo letras.")]
			public string? NombreCliente { get; set; }

			[ForeignKey("Reparaciones")]
			public int ReparacionId { get; set; }

			[ForeignKey("MetodoPagos")]
			public int MetodoPagoId { get; set; }

			[Required(ErrorMessage = "Es requerido")]
			public DateTime Fecha { get; set; } = DateTime.Now;

		

			public float Recibido { get; set; }

			public float Devuelta { get; set; }

			[ForeignKey("Condiciones")]
			public int CondicionId { get; set; }

			public bool Eliminada { get; set; }

			[ForeignKey("VentaId")]
		
	
	
		public List<CartItem> Items { get; set; } = new List<CartItem>();
		public decimal SubTotal => Items.Sum(i => i.Quantity * i.Product.Price);
		public decimal ITBIS => SubTotal * 0.18m;
		public decimal Total => SubTotal + ITBIS;
	
		public ICollection<VentasDetalle> VentasDetalle { get; set; } = new List<VentasDetalle>();

	}
}
