using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Shared.Models;
[Table("PAYMENTMETHODS")]
public partial class Paymentmethod
{
    [Key]
    public int PaymentMethodId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [InverseProperty("PaymentMethod")]
    public virtual ICollection<Sales> Sales { get; set; } = new List<Sales>();
}
