using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieDatabase.Models
{
    public class UserLibrary
    {
        [Key]
        public int movieID { get; set; }
        public string userID { get; set; }
        public int locationID { get; set; }
    }
}