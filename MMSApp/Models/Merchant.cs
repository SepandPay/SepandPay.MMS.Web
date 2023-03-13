﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MMSApp.Models;

[Index("CustomerId", Name = "IX_Merchants_CustomerId")]
[Index("MerchantStateId", Name = "IX_Merchants_MerchantStateId")]
[Index("PspId", Name = "IX_Merchants_PspId")]
[Index("TerminalTypeId", Name = "IX_Merchants_TerminalTypeId")]
public partial class Merchant
{
    [Key]
    public long Id { get; set; }

    public long? PspId { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string AcceptorCode { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string TerminalNo { get; set; }

    public long? CustomerId { get; set; }

    public long? MerchantStateId { get; set; }

    public long? TerminalTypeId { get; set; }

    [Unicode(false)]
    public string merchantKey { get; set; }

    public string Title { get; set; }

    public string PSPUser { get; set; }

    public string PSPPassword { get; set; }

    public bool IsDeleted { get; set; }

    public bool IsActive { get; set; }

    public long CreatorUserId { get; set; }

    public DateTime CreateDate { get; set; }

    public long? UpdaterUserId { get; set; }

    public DateTime? UpdateTime { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("Merchants")]
    public virtual Shop Customer { get; set; }

    [ForeignKey("MerchantStateId")]
    [InverseProperty("Merchants")]
    public virtual MerchantState MerchantState { get; set; }

    [ForeignKey("PspId")]
    [InverseProperty("Merchants")]
    public virtual PSP Psp { get; set; }

    [InverseProperty("Merchant")]
    public virtual ICollection<Request> Requests { get; } = new List<Request>();

    [ForeignKey("TerminalTypeId")]
    [InverseProperty("Merchants")]
    public virtual SettelementType TerminalType { get; set; }
}