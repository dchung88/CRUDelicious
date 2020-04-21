using System;
using System.ComponentModel.DataAnnotations;

namespace CRUDelicious_.Models
{
    public class Dishes
    {
        [Key]

        [Required]
        public int DishID { get;set; }

        [Required]
        public string Name { get;set; }

        [Required]
        public string Chef { get;set; }

        [Required]
        public int Tastiness { get;set; }

        [Required]
        public int Calories { get;set; }

        [Required]
        public string Description { get;set; }

        [Required]
        public DateTime CreatedAt { get;set; } = DateTime.Now;

        [Required]
        public DateTime UpdatedAt { get;set; } = DateTime.Now;
    }
}