using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    class Review
    {
        public User user { get; set; }
        public Cafes cafe { get; set; }
        public String rate { get; set; }
        public String comment { get; set; }

        public Review(User user, Cafes cafe, String rate, String comment)
        {
            this.user = user;
            this.cafe = cafe;
            this.rate = rate;
            this.comment = comment;
        }

        List<Review> reviews = new List<Review>();
        public void AddReview(Review review)
        {
            reviews.Add(review);
        }
    }
}
