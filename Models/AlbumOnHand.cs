using System.ComponentModel.DataAnnotations.Schema;

namespace VinylTap.Models
{
    public class AlbumOnHand : Album //need to finalize foreign key relationship in dbcontext
    {
        public int Id { get; set; }
        [ForeignKey("Album")]
        public int AlbumId { get; set; }
        public Album Album { get; set; } //need instance of parent class to complete foreign key assignation
        public enum AlbumCondition { Mint, NearMint, VeryGoodPlus, VeryGood, GoodPlus, Good, Fair, Poor }
        //consider what data types to use for albums where each condition has its own price
        public double AlbumPrice { get; set; }
        public string CurrencyType { get; set; }
    }
}