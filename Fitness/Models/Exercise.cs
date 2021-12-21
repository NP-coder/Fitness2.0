using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness.Models
{
    public class Exercise
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Назва")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Калорій на годину")]
        public double CaloriesPerMinute { get; set; }

        public List<Athletics> Athletics { get; set; } = new List<Athletics>();

    }
}
