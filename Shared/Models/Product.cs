{
		public int ProductId { get; set; }
		public decimal Price { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal Cost { get; set; }

		public int Stock { get; set; }
}