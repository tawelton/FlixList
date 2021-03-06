﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MovieDatabase.Models
{
    [Table("Location")]
    public class Location
    {
        [Key]
        public int locationID { get; set; }
        public string description { get; set; }
        public string logoURL { get; set; }

        [NotMapped]
        public bool selected { get; set; }
    }
}