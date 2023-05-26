using eq_example01_gitflow.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace eq_example01_gitflow.Models
{
    public class Calculator
    {
        [Required(ErrorMessage = "Field Number 1 is required")]
        [RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Please enter a valid number for Number 1.")]
        public decimal Number1 { get; set; }

        [Required(ErrorMessage = "Field Number 2 is required")]
        [RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Please enter a valid number for Number 2.")]

        public decimal Number2 { get; set; }
    }
}
