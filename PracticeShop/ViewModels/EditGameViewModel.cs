using System.ComponentModel.DataAnnotations;

namespace WebStore.ViewModels
{
    public class EditGameViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Название игры")]
        public string Name { get; set; }

        [Display(Name = "Жанр")]
        public string Genre { get; set; }

        [Display(Name = "Издатель")]
        public string Publisher { get; set; }

        [Display(Name = "Цена")]
        public double Price { get; set; }
    }
}