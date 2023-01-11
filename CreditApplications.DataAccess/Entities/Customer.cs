﻿using System.ComponentModel.DataAnnotations;

namespace CreditApplications.DataAccess.Entities;

public class Customer : EntityBase
{
    [Required]
    [MaxLength(500)]
    public string? CustomerFirstName { get; set; }

    [Required]
    [MaxLength(500)]
    public string? CustomerLastName { get; set; }

    public List<CreditApplication>? CreditApplications { get; set; }
}