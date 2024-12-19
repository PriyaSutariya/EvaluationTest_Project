using System;
using System.Collections.Generic;
using System.Text;

namespace EvaluationTest.db.Models
{
    public class OrderDTO
    {

        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime DateOfOrder { get; set; }
        public List<ProductDTO> Products { get; set; }
    }
}
