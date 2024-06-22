using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PuntoDeVenta_Api.Models;

[Table("PURCHASES")]
public partial class Purchase
{
    [Key]
    public int PurchaseId { get; set; }

    public int SuplierId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime PurchaseDate { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal TotalPurchase { get; set; }

    [InverseProperty("Purchase")]
    public virtual ICollection<Purchasedetail> Purchasedetails { get; set; } = new List<Purchasedetail>();

    [ForeignKey("SuplierId")]
    [InverseProperty("Purchases")]
    public virtual Suplier Suplier { get; set; } = null!;
}
