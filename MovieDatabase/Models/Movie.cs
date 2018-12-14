using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MovieDatabase.Models
{
    [Table("Movie")]
    public class Movie
    {
        [Key]
        public int movieID { get; set; }

        [DisplayName("Title")]
        public string title { get; set; }

        [DisplayName("Description")]
        public string description { get; set; }

        [DisplayName("Rating")]
        public string rating { get; set; }

        [DisplayName("Year Released")]
        public int yearReleased { get; set; }

        public string posterURL { get; set; }
        public string imdbURL { get; set; }
    }
}