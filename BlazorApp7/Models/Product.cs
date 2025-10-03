using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp7.Client.Models
{
    public class Product
    {
        public int Id { get; set; }

        // Validering som i guiden
        [Required]
        [StringLength(50, ErrorMessage = "Name must be less than 50 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }

        public string Description { get; set; } = string.Empty;

        public bool IsPublished { get; set; }

        // Note 2: fornuftig startdato
        public DateTime PublishedDate { get; set; } = DateTime.Now;

        // Opgave 3: dropdown for materiale
        public string Materiale { get; set; } = string.Empty;

        // Bruges i Opgave 2 (simpel tekstvisning, hvis du vil teste hurtigt)
        public override string ToString()
            => $"{Name} ({Materiale}) – {Price:C} – {(IsPublished ? "Published" : "Draft")} – {PublishedDate:d}";
    }
}
