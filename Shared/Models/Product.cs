﻿using Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PuntoDeVenta_Api.Models;

[Table("PRODUCTS")]
public partial class Product
{
    [Key]

    public int ProductId { get; set; }

    [StringLength(30)]

    public string Name { get; set; } = null!;

    [Column(TypeName = "decimal(18, 0)")]
    public decimal Price { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal Cost { get; set; }

    public int Stock { get; set; }

    [StringLength(500)]
    public string? Description { get; set; }

    public int? CategoryId { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("Products")]
    public virtual Category? Category { get; set; }


    [InverseProperty("Product")]
    public virtual ICollection<Purchasedetail> Purchasedetails { get; set; } = new List<Purchasedetail>();

    [InverseProperty("Product")]
    public virtual ICollection<Saledetail> Saledetails { get; set; } = new List<Saledetail>();
}