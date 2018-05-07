using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GummiBearKingdom.Models
{
    [Table("Items")]
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }


    

    //Method for Rating will go here
    public double AvgRating()
    {

        List<int> ratings = new List<int>();
        if (ratings.Count > 0)
        {
            foreach (var review in Reviews)
            {
                ratings.Add(review.Rating);
            }
            return Math.Round(ratings.Average());
        }
        else
        {
            return 0;
        }

    }

    public override bool Equals(System.Object otherProduct)
    {
        if (!(otherProduct is Item))
        {
            return false;
        }
        else
        {
            Item newProduct = (Item)otherProduct;
            return this.ItemId.Equals(newProduct.ItemId);
        }
    }

        public override int GetHashCode()
        {
            var hashCode = -217289168;
            hashCode = hashCode * -1521134295 + ItemId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + Cost.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Description);
            hashCode = hashCode * -1521134295 + EqualityComparer<ICollection<Review>>.Default.GetHashCode(Reviews);
            return hashCode;
        }
    }
}
