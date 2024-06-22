using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PuntoDeVenta_Api.Models;

[Table("PURCHASEDETAILS")]
public partial class Purchasedetail
{
    [Key]
    public int DetailId { get; set; }

    public int PurchaseId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal UnitPrice { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal SubTotal { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("Purchasedetails")]
    public virtual Product Product { get; set; } = null!;

    [ForeignKey("PurchaseId")]
    [InverseProperty("Purchasedetails")]
    public virtual Purchase Purchase { get; set; } = null!;
}
