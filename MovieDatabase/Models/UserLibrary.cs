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
        [Column(Order =1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int movieID { get; set; }
        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string userID { get; set; }
        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int locationID { get; set; }
    }
}