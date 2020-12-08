using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProiectDAW.Models
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        [Required]
        public virtual ICollection<Product> Products { get; set; }
    }
}