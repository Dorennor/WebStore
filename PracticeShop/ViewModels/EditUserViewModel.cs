using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace WebStore.ViewModels
{
    public class EditUserViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Имя пользователя")]
        public string UserName { get; set; }

        public IFormFile UploadedFile { get; set; }
    }
}