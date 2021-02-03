﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETFive.Models
{
    [Table("books")]
    public class Book
    {
        [Column("id")]
        public long id { get; set; }
        [Column("author")]
        public string  Author { get; set; }
        [Column("launch_date")]
        public string LaunchDate { get; set; }
        [Column("price")]
        public float Price { get; set; }
        [Column("title")]
        public string Title { get; set; }
    }
}