using System.ComponentModel.DataAnnotations;

namespace WebStore.Models
{
    public class Orders
    {
        [Key]
        public int ID { get; set; }

        public string UserID { get; set; }
        public string GamesID { get; set; }

        public Orders(string userID)
        {
            UserID = userID;
        }

        public Orders(string userName, string gamesID) : this(userName)
        {
            GamesID = gamesID;
        }
    }
}