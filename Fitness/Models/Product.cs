using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Продукт")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Білки")]
        public double Proteines { get; set; }

        [Required]
        [Display(Name = "Жири")]
        public double Fats { get; set; }

        [Required]
        [Display(Name = "Вуглеводи")]
        public double Carbohydrates { get; set; }

        [Required]
        [Display(Name = "Калорії")]
        public double Calories { get; set; }

        public List<Food> Foods { get; set; } = new List<Food>();
    }
}
