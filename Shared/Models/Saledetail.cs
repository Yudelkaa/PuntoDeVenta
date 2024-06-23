using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Shared.Models;
[Table("SALEDETAILS")]
public partial class Saledetail
{
    [Key]
    public int DetailId { get; set; }

    public int SaleId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal UnitaryPrice { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal SubTotal { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("Saledetails")]
    public virtual Product Product { get; set; } = null!;

    [ForeignKey("SaleId")]
    [InverseProperty("Saledetails")]
    public virtual Sales Sale { get; set; } = null!;
}
