﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MMSApp.Models;

[Index("RequestId", Name = "IX_RequestIbans_RequestId")]
[Index("ShareTypeId", Name = "IX_RequestIbans_ShareTypeId")]
public partial class RequestIban
{
    [Key]
    public long Id { get; set; }

    [StringLength(30)]
    public string Iban { get; set; }

    public long? RequestId { get; set; }

    [StringLength(30)]
    public string AccountNumber { get; set; }

    public long? ShareTypeId { get; set; }

    public double? SharedAmount { get; set; }

    public long? ShareAmountMax { get; set; }

    public long? ShareAmountMin { get; set; }

    public bool? IsMain { get; set; }

    public byte? OrderNo { get; set; }

    public bool IsDeleted { get; set; }

    public bool IsActive { get; set; }

    public long CreatorUserId { get; set; }

    public DateTime CreateDate { get; set; }

    public long? UpdaterUserId { get; set; }

    public DateTime? UpdateTime { get; set; }

    [ForeignKey("RequestId")]
    [InverseProperty("RequestIbans")]
    public virtual Request Request { get; set; }

    [ForeignKey("ShareTypeId")]
    [InverseProperty("RequestIbans")]
    public virtual CommissionType ShareType { get; set; }
}