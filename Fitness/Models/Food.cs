using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness.Models
{
    public class Food
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Користувач")]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        [Required]
        [Display(Name = "Продукт")]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Required]
        [Display(Name = "Грам")]
        public double Number { get; set; }

        [Required]
        [Display(Name = "Час прийому")]
        public DateTime Timeofday { get; set; }
    }
}
