﻿using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Job
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public bool IsActive { get; set; }
        [Required]
        public string Assignee { get; set; }
    }
}
