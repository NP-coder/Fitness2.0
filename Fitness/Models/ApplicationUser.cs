using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness.Models
{
    public class ApplicationUser : IdentityUser
    {
        //[Key]
        //public new int Id { get; set; }

        public override string UserName { get; set; }

        public string Password { get; set; }

        public int Height { get; set; }

        public int Weight { get; set; }

        public DateTime Birth { get; set; }

        public DateTime Registration { get; set; }

        public DateTime Removal { get; set; }

        public byte[] Avatar { get; set; }

        public int GenderId { get; set; }
        public Gender Gender { get; set; }

        public List<Food> Foods { get; set; } = new List<Food>();

        public List<Athletics> Athletics { get; set; } = new List<Athletics>();
    }
}
