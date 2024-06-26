﻿using System.ComponentModel.DataAnnotations;

namespace Task_Manager.Models
{
    public class Task
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
