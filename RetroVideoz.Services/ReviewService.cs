using RetroVideoz.Data;
using RetroVideoz.Models.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroVideoz.Services
{
    public class ReviewService
    {
        public bool CreateReview(ReviewCreate model)
        {
            var entity = new Review()
            {
                ReviewHeader = model.ReviewHeader,
                ReviewText = model.ReviewText,
                StarRating = model.StarRating,
                WouldRecommend = model.WouldRecommend,
                DateAdded = model.DateAdded,
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Reviews.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ReviewListItem> GetReviews()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Reviews
                    .OrderBy(x => x.DateAdded)
                    .Select(review => new ReviewListItem
                    {
                        ReviewHeader = review.ReviewHeader,
                        ReviewText = review.ReviewText,
                        StarRating = review.StarRating,
                        WouldRecommend = review.WouldRecommend,
                        DateAdded = DateTime.Now,
                    });
                  
                return query.ToArray();
            }
        }
        public IEnumerable<ReviewListItem> GetReviewsByVideoTitle(string title)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Reviews
                    .Where(e => e.Video.Title == title)
                    .OrderBy(r => r.DateAdded)
                    .Select(e => new ReviewListItem
                    {
                        ReviewID = e.ReviewID,
                        ReviewText = e.ReviewText,
                        StarRating = e.StarRating,
                        WouldRecommend = e.WouldRecommend,
                        DateAdded = e.DateAdded
                    });
                return query.ToArray();
                    //new ReviewListItem
                    //{
                    //    ReviewHeader = entity.ReviewHeader,
                    //    ReviewText = entity.ReviewText,
                    //    StarRating = entity.StarRating,
                    //    WouldRecommend = entity.WouldRecommend,
                    //    DateAdded = entity.DateAdded,
                    //};
            }
        }
        //get reviews by id
        //get reviews by video id
    }
}

