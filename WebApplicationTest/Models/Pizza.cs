using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationTest.Models
{
    public class Pizza
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string? Name { get; set; }

        [Column(TypeName = "text")]
        public string? Description { get; set; }

        [Column(TypeName = "varchar(500)")]
        public string? Image { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string? Price { get; set; }

        public Pizza()
        {

        }

        public Pizza(int id, string name, string description, string image, string price)
        { 
            Id = id;
            Name = name;
            Description = description;
            Image = image;
            Price = price;
        }
    }
}
