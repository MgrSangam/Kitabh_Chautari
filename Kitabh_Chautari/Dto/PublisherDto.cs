﻿namespace KitabhChautari.Models
{
    using System.ComponentModel.DataAnnotations;

    public class PublisherDto
    {
        public int Publisher_id { get; set; }

        [Required(ErrorMessage = "Publisher name is required")]
        [StringLength(100, ErrorMessage = "Publisher name cannot be longer than 100 characters")]
        public string Publisher_Name { get; set; } = string.Empty;
    }
}