using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MovieDatabase.Models
{
    [Table("UserLibrary")]
    public class UserLibrary
    {
        [Key]
        public int movieID { get; set; }
        public string userID { get; set; }
        public int locationID { get; set; }
    }
}