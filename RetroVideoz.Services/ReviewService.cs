using RetroVideoz.Data;
using RetroVideoz.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroVideoz.Services
{
    public class ReviewService
    {
        private readonly Guid _userID;
        public ReviewService(Guid userID)
        {
            _userID = userID;
        }

        public bool CreateReview(ReviewCreate model)
        {
            var entity = new Review()
            {
                OwnerID = _userID,
                ReviewID = model.ReviewID,
                ReviewHeader = model.ReviewHeader,
                ReviewText = model.ReviewText,
                StarRating = model.StarRating,
                WouldRecommend = model.WouldRecommend,
                DateAdded = DateTime.Now,
                VideoID = model.VideoID,
                //UserID = model.UserID,
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
                    .Where(e => e.OwnerID == _userID)
                    .OrderBy(x => x.DateAdded)
                    .Select(review => new ReviewListItem
                    {

                        ReviewHeader = review.ReviewHeader,
                        VideoTitle = review.Video.Title,
                        //ReviewText = review.ReviewText,
                        StarRating = review.StarRating,
                        DateAdded = review.DateAdded,
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
                        //ReviewID = e.ReviewID,
                        ReviewHeader = e.ReviewHeader,
                       VideoTitle = e.Video.Title,
                        StarRating = e.StarRating,
                        DateAdded = e.DateAdded
                    });
                return query.ToArray();
            }
        }
        public IEnumerable<ReviewListItem> GetReviewsByVideoID(int videoID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Reviews
                    .Where(e => e.Video.VideoID == videoID)
                    .OrderBy(r => r.DateAdded)
                    .Select(e => new ReviewListItem
                    {
                        ReviewHeader = e.ReviewHeader,
                        VideoTitle = e.Video.Title,
                        StarRating = e.StarRating,
                        DateAdded = e.DateAdded
                    });
                return query.ToArray();
            }
        }
        public ReviewDetail GetReviewByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Reviews
                    .Single(e => e.ReviewID == id && e.OwnerID == _userID);
                return
                    new ReviewDetail
                    {
                        ReviewHeader = entity.ReviewHeader,
                        VideoTitle = entity.Video.Title,
                        ReviewText = entity.ReviewText,
                        StarRating = entity.StarRating,
                        WouldRecommend = entity.WouldRecommend,
                        DateAdded = entity.DateAdded,
                        //UserID = entity.UserID,
                        //Username = entity.ApplicationUser.Username

                    };
            }
        }

        //get reviews by video id

        public bool UpdateReview(ReviewEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Reviews
                    .Single(e => e.ReviewID == model.ReviewID && e.OwnerID == _userID);
                entity.ReviewHeader = model.ReviewHeader;
                entity.ReviewText = model.ReviewText;
                entity.StarRating = model.StarRating;
                entity.WouldRecommend = model.WouldRecommend;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteReview(int reviewID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Reviews
                    .Single(e => e.ReviewID == reviewID && e.OwnerID == _userID);
                ctx.Reviews.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}

