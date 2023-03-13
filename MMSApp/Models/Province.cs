﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MMSApp.Models;

public partial class Province
{
    [Key]
    public long Id { get; set; }

    public int Code { get; set; }

    [StringLength(50)]
    public string Name { get; set; }

    [StringLength(3)]
    [Unicode(false)]
    public string Abbreviation { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string TelCode { get; set; }

    public long? CountryId { get; set; }

    public bool IsDeleted { get; set; }

    public bool IsActive { get; set; }

    public long CreatorUserId { get; set; }

    public DateTime CreateDate { get; set; }

    public long? UpdaterUserId { get; set; }

    public DateTime? UpdateTime { get; set; }
}