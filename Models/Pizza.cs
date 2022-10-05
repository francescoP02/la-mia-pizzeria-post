using System.Diagnostics.Metrics;

namespace la_mia_pizzeria_static.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public float Price { get; set; }

        public Pizza(int id, string name, string description, string photo, string price)
        {
            Id = id;
            Name = name;
            Description = description;
            Photo = photo;
            Price = float.Parse(price);
        }
    }
}
