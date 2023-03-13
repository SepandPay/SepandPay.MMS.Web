﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MMSApp.Models;

[Index("GuildCategoryId", Name = "IX_GuildSubCategories_GuildCategoryId")]
public partial class GuildSubCategory
{
    [Key]
    public long Id { get; set; }

    public long? GuildCategoryId { get; set; }

    [StringLength(150)]
    public string Title { get; set; }

    [StringLength(10)]
    public string Code { get; set; }

    public bool IsDeleted { get; set; }

    public bool IsActive { get; set; }

    public long CreatorUserId { get; set; }

    public DateTime CreateDate { get; set; }

    public long? UpdaterUserId { get; set; }

    public DateTime? UpdateTime { get; set; }

    [ForeignKey("GuildCategoryId")]
    [InverseProperty("GuildSubCategories")]
    public virtual GuildCategory GuildCategory { get; set; }
}