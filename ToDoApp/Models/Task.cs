using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToDoApp.Models
{
    public class Task
    {
        public int Id { get; set; }

        [Required]
        public string TaskText { get; set; }

        [Required]
        public int OrderScore { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}