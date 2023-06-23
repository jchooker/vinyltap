using System.ComponentModel.DataAnnotations.Schema;

namespace VinylTap.Models
{
    public class AlbumOnHand : Album //need to finalize foreign key relationship in dbcontext
    {
        public int Id { get; set; }
        [ForeignKey("Album")]
        public int ParentId { get; set; }
        public Album Album { get; set; } //need instance of parent class to complete foreign key assignation
        public enum AlbumCondition { Mint, NearMint, VeryGoodPlus, VeryGood, GoodPlus, Good, Fair, Poor }
        public (double AlbumPrice, string Currency) AlbumPriceWithCurrency { get; set; }
        public int NumAlbumsAvailableForSale { get; set; }
    }
}