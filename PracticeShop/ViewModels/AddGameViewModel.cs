using System.ComponentModel.DataAnnotations;

namespace PracticeShop.ViewModels
{
    public class AddGameViewModel
    {
        [Required]
        [Display(Name = "Издатель")]
        public string Name { get; set; }

        [Display(Name = "Жанр")]
        public string Genre { get; set; }

        [Required]
        [Display(Name = "Издатель")]
        public string Publisher { get; set; }

        [Required]
        [Display(Name = "Цена в $")]
        public double Price { get; set; }
    }
}