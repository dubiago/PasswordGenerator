using PasswordGenerator.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PasswordGenerator.Classes
{
    public class AppSettings
    {
        [Display(Name = "Minimum Characters")]
        [Required(ErrorMessage = "Required")]
        public int MinChar { get; set; }
        [Display(Name = "Maximum Characters")]
        public int? MaxChar { get; set; }
        [Display(Name = "Minimum Lowercase")]
        [Required(ErrorMessage = "Required")]
        public int MinUC { get; set; }
        [Display(Name = "Minimum Uppercase")]
        [Required(ErrorMessage = "Required")]
        public int MinLC { get; set; }
        [Display(Name = "Minimum Symbols")]
        [Required(ErrorMessage = "Required")]
        public int MinSp { get; set; }
        [Display(Name = "Minimum Numerics")]
        [Required(ErrorMessage = "Required")]
        public int MinNum { get; set; }
        [Display(Name = "Excluded Characters (comma-delimited)")]
        public string ExcludedCharacters { get; set; }
    }
}
