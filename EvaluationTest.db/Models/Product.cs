using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EvaluationTest.db.Models
{
    public class Product
    {
        [Key]
        public int product_id { get; set; }

        [Required]
        public string product_name { get; set; }

        [Required]
        public decimal product_price { get; set; }

        public string product_code { get; set; }

        public ICollection<OrderProductMapping> OrderProductMappings { get; set; }

    }
}
