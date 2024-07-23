using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace ProductCrud.Product
{
    public class Product : BasicAggregateRoot<int>
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]

        public string Name { get; set; }
        [StringLength(500)]

        public string Description { get; set; }
        [Required,
     Range(0.01, double.MaxValue, ErrorMessage = "The value must be a positive number.")
            ]
        public decimal Price { get; set; }
        //public List<int> CategoryIds { get; set; }
        //public Book()
        //{
        //    CategoryIds= new List<int>();
        //}
    }
}
