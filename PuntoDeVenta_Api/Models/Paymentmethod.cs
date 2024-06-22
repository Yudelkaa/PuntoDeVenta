using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PuntoDeVenta_Api.Models;

[Table("PAYMENTMETHODS")]
public partial class Paymentmethod
{
    [Key]
    public int PaymentMethodId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [InverseProperty("PaymentMethod")]
    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
