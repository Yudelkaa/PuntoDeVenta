using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Shared.Models;
[Table("INVENTORY")]
public partial class Inventory
{
    [Key]
    public int InventoryId { get; set; }

    public int ProductId { get; set; }

    public int? Quantity { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("Inventories")]
    public virtual Product Product { get; set; } = null!;
}
