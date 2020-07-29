using System.ComponentModel.DataAnnotations;

namespace PracticeShop.Models
{
    public class Library
    {
        [Key]
        public int ID { get; set; }

        public string UserID { get; set; }
        public string GamesID { get; set; }

        public Library(string userID)
        {
            UserID = userID;
        }

        public Library(string userName, string gamesID) : this(userName)
        {
            GamesID = gamesID;
        }
    }
}