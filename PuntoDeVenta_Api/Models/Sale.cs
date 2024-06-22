using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PuntoDeVenta_Api.Models;

[Table("SALES")]
public partial class Sale
{
    [Key]
    public int SaleId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime SaleDate { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal SaleTotal { get; set; }

    public int PaymentMethodId { get; set; }

    [ForeignKey("PaymentMethodId")]
    [InverseProperty("Sales")]
    public virtual Paymentmethod PaymentMethod { get; set; } = null!;

    [InverseProperty("Sale")]
    public virtual ICollection<Saledetail> Saledetails { get; set; } = new List<Saledetail>();
}
