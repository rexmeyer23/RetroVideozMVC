﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroVideoz.Models.Review
{
    public class ReviewDetail
    {
        public int ReviewID { get; set; }
        [Display(Name = "Header")]
        public string ReviewHeader { get; set; }
        [Display(Name = "Text")]
        public string ReviewText { get; set; }
        [Display(Name = "Star Rating")]
        public decimal StarRating { get; set; }
        [Display(Name = "Would Recommend?")]
        public bool WouldRecommend { get; set; }
        [Display(Name = "Date Review was Added")]
        public DateTimeOffset? DateAdded { get; set; }
        [Display(Name = "User")]
        public string UserID { get; set; }
        public string Username { get; set; }
        [Display(Name = "Video")]
        public int VideoID { get; set; }
        public string Title { get; set; }
    }
}
