﻿using System.ComponentModel.DataAnnotations;

namespace Lab12.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public int NumberOfEmployees { get; set;}
        public int FoundationYear { get; set; }
    }
}
