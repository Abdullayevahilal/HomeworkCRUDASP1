using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeworkASPCRUD.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter title.")]
        [MaxLength(50,ErrorMessage = "Title can be max 50 characters long.")]
        [MinLength(2,ErrorMessage = "Title must be at least 2 characters long.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "'Field name' is not a number")]
        public double Price { get; set; }
        [Required(ErrorMessage ="Please enter Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
