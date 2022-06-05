﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Models
{
    public class EmailViewModel
    {
        [Required]
        public string Subject { get; set; }
        public string Phone { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Message { get; set; }

    }
}
