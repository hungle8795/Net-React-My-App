﻿namespace Net_React.Server.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int CategoryId { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}