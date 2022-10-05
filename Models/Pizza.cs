using la_mia_pizzeria_static.Models;
using la_mia_pizzeria_static;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;

namespace la_mia_pizzeria_static.Models
{
    [Table("pizzas")]
    public class Pizza
    {
        [Key]
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public float Price { get; set; }

        public Pizza(string name, string description, string photo, float price)
        {
            Name = name;
            Description = description;
            Photo = photo;
            Price = price;
        }
    }
}
