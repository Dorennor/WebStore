using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeShop.Models
{
    public class Library
    {
        [Key]
        public int ID { get; set; }
        public string UserName { get; set; }
        public string GamesID { get; set; }

        public Library(string userName)
        {
            UserName = userName;
        }

        public Library(string userName, string gamesID) : this(userName)
        {
            GamesID = gamesID;
        }
    }
}
