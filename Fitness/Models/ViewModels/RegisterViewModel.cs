using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Пароль має містити не менше {2} символів", MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        public int Height { get; set; }

        [Required]
        public int Weight { get; set; }

        [Required]
        public DateTime Birth { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public int GenderId { get; set; }

    }
}
