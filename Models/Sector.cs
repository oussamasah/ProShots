﻿using System.ComponentModel.DataAnnotations;

namespace ProShots.Models
{
    public class Sector
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

       
        public DateTime CreatedAt { get; set; }= DateTime.Now;
    }
}


