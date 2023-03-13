﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MMSApp.Models;

public partial class GuildCategory
{
    [Key]
    public long Id { get; set; }

    public int Code { get; set; }

    [StringLength(100)]
    public string Name { get; set; }

    public bool IsDeleted { get; set; }

    public bool IsActive { get; set; }

    public long CreatorUserId { get; set; }

    public DateTime CreateDate { get; set; }

    public long? UpdaterUserId { get; set; }

    public DateTime? UpdateTime { get; set; }

    [InverseProperty("GuildCategory")]
    public virtual ICollection<GuildSubCategory> GuildSubCategories { get; } = new List<GuildSubCategory>();

    [InverseProperty("GuildCategory")]
    public virtual ICollection<Shop> Shops { get; } = new List<Shop>();
}