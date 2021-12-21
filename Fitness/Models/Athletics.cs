using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness.Models
{
    public class Athletics
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Користувач")]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        [Required]
        [Display(Name = "Вправа")]
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }

        [Required]
        [Display(Name = "Тривалість")]
        public double Duration { get; set; }

        [Required]
        [Display(Name = "Час занять")]
        public DateTime Timeofday { get; set; }
    }
}
