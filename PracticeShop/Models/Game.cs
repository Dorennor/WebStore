namespace PracticeShop.Models
{
    public class Game
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Publisher { get; set; }
        public double Price { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Game game = obj as Game;
            return (game.ID == ID && game.Name == Name && game.Genre == Genre && game.Publisher == Publisher && game.Price == Price);
        }
    }
}