using System;
using System.Collections.Generic;
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
        public string title { get; set; }
        public string description { get; set; }
        public string rating { get; set; }
        public int yearReleased { get; set; }
        public string posterURL { get; set; }
        public string imdbURL { get; set; }
    }
}