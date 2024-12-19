using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EvaluationTest.db.Models
{
    public class OrderProductMapping
    {
       
            [Key]
            public int order_product_id { get; set; }
            [ForeignKey("order")]
            public int order_id { get; set; }
            [ForeignKey("product")]
            public int product_id { get; set; }

            public Order order { get; set; }
            public Product product { get; set; }
            public int product_quantity { get; set; }

    }
}
