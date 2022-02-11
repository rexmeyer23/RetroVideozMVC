using RetroVideoz.Data;
using RetroVideoz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroVideoz.Services
{
    public class VideoService
    {
        private readonly Guid _userID;

        public VideoService(Guid userId)
        {
            _userID = userId;
        }

        public bool CreateVideo(VideoCreate model)
        {
            var entity =
                new Video()
                {
                    OwnerID = _userID,
                    Title = model.Title,
                    Description = model.Description,
                    Year = model.Year,
                    Rating = model.Rating,
                    Genre = model.Genre,
                    Format = model.Format,
                    Price = model.Price,
                    Quantity = model.Quantity,
                    //Image = model.Image
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Videos.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<VideoListItem> GetVideos()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Videos
                    .Where(e => e.OwnerID == _userID)
                    .OrderBy(v => v.Title)
                    .Select(
                        e =>
                        new VideoListItem
                        {
                            VideoID = e.VideoID,
                            Title = e.Title,
                            Year = e.Year,
                            Format = e.Format,
                            Price = e.Price,
                            Quantity = e.Quantity,
                        }
                        );
                return query.ToArray();
            }
        }
        public VideoDetail GetVideoByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Videos
                    .Single(e => e.VideoID == id && e.OwnerID == _userID);
                return
                    new VideoDetail
                    {
                        VideoID = entity.VideoID,
                        Title = entity.Title,
                        Description = entity.Description,
                        Year = entity.Year,
                        Rating = entity.Rating,
                        Genre = entity.Genre,
                        Format = entity.Format,
                        Price = entity.Price,
                        Quantity = entity.Quantity,
                    };
            }
        }
        public bool UpdateVideo(VideoEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Videos
                    .Single(e => e.VideoID == model.VideoID && e.OwnerID == _userID);
                entity.Title = model.Title;
                entity.Description = model.Description;
                entity.Year = model.Year;
                entity.Rating = model.Rating;
                entity.Genre = model.Genre;
                entity.Format = model.Format;
                entity.Price = model.Price;
                entity.Quantity = model.Quantity;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteVideo(int videoID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Videos
                    .Single(e => e.VideoID.Equals(videoID) && e.OwnerID.Equals(_userID));

                ctx.Videos.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

