﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MMSApp.Models;

public partial class Alphabet
{
    [Key]
    public long Id { get; set; }

    [Required]
    [StringLength(50)]
    public string AlphabiticChar { get; set; }

    public bool IsDeleted { get; set; }

    public bool IsActive { get; set; }

    public long CreatorUserId { get; set; }

    public DateTime CreateDate { get; set; }

    public long? UpdaterUserId { get; set; }

    public DateTime? UpdateTime { get; set; }

    [InverseProperty("BirthCertificateAlphabiticNo")]
    public virtual ICollection<Person> People { get; } = new List<Person>();
}