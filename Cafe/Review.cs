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
        public int rate { get; set; }

        public Review(User user, Cafes cafe, int rate)
        {
            this.user = user;
            this.cafe = cafe;
            this.rate = rate;
        }

        List<Review> reviews = new List<Review>();
        public void AddReview()
        {
            reviews.Add()
        }
    }
}
