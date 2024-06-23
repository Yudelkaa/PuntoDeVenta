using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Shared.Models;
[Table("SUPLIERS")]
public partial class Suplier
{
    [Key]
    public int SuplierId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? SuplierName { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? PhoneNumber { get; set; }

    [StringLength(80)]
    [Unicode(false)]
    public string? Email { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? Address { get; set; }

    [InverseProperty("Suplier")]
    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
}
