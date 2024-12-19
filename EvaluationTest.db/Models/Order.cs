using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EvaluationTest.db.Models
{
    public class Order
    {
        [Key]
        public int order_id { get; set; }

        [ForeignKey("Customer")]

        public int customer_id { get; set; }

        public virtual Customer Customer { get; set; }

        [Required]

        public DateTime date_of_order { get; set; }

        [Required]

        public string order_payment_type { get; set; }

        public virtual ICollection<OrderProductMapping> OrderProductMappings { get; set; }
    }
}
