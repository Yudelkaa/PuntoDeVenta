using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using PuntoDeVenta_Api.Models;

namespace Shared.Models;

[Table("CATEGORIES")]
public partial class Category
{
    [Key]
    public int CategoryId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string CategoryName { get; set; } = null!;

    [InverseProperty("Category")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
