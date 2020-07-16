using PasswordGenerator.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PasswordGenerator.Models
{
    public class Password : AppSettings
    {        
        public Password()
        {
            Excluded = new List<int>();
        }
        
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [NotMapped]
        public List<int> Excluded { get; set; }
        [Display(Name = "Generated Password")]
        public string Value { get; set; }
    }
}
