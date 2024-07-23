using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCrud
{

    public class CreateProductDto
    {
    
        [Required]
        [StringLength(255)]

        public string Name { get; set; }
        [StringLength(500)]

        public string Description { get; set; }
        [Required,
     Range(0.01, double.MaxValue, ErrorMessage = "The value must be a positive number.")
            ]
        public decimal Price { get; set; }
    }
}

