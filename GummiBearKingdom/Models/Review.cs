using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GummiBearKingdom.Models
{
    [Table("Reviews")]
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        public string UserName { get; set; }
        public string Body { get; set; }
        public int Rating { get; set; }
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }


        public bool FitsCharacters()
        {
            if (this.Body.Length <= 255)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RatingIsValid()
        {
            if ((this.Rating >= 1) && (this.Rating <= 5))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool Equals(System.Object otherReview)
        {
            if (!(otherReview is Review))
            {
                return false;
            }
            else
            {
                Review newReview = (Review)otherReview;
                return this.ReviewId.Equals(newReview.ReviewId);
            }
        }

        public override int GetHashCode()
        {
            var hashCode = -2037718333;
            hashCode = hashCode * -1521134295 + ReviewId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(UserName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Body);
            hashCode = hashCode * -1521134295 + Rating.GetHashCode();
            hashCode = hashCode * -1521134295 + ItemId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Item>.Default.GetHashCode(Item);
            return hashCode;
        }
    }
}
