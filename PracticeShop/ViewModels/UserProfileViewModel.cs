using Microsoft.AspNetCore.Http;
using WebStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Models;

namespace WebStore.ViewModels
{
    public class UserProfileViewModel
    {
        public User User { get; set; }

        public IFormFile Image { get; set; }
    }
}
