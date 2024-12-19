using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace EvaluationTest.db.Models
{
    public class Customer
    {
        [Key]
        public int customer_id { get; set; }

        [Required]
        [MaxLength(30)]
        public string customer_firstname {  get; set; }

        [Required]
        [MaxLength(30)]
        public string customer_lastname { get;set; }

        public string customer_email {  get; set; }

        public string customer_DOB {  get; set; }

        public virtual ICollection<Order> orders { get; set; }
    }
}
