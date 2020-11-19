using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ProiectDAW.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public string Image { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int Rating { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public IEnumerable<SelectListItem> AllCategories { get; internal set; }
        public int Status { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}