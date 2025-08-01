﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Project_ERP.Models;

public partial class JVDetail
{
    public int JVID { get; set; }

    public int AccountID { get; set; }

    public int? SubAccountID { get; set; }

    [Column(TypeName = "numeric(22, 8)")]
    public decimal? Debit { get; set; }

    [Column(TypeName = "numeric(22, 8)")]
    public decimal? Credit { get; set; }

    public bool IsDocumented { get; set; }

    [StringLength(1000)]
    public string Notes { get; set; }

    public int? BranchID { get; set; }

    [Key]
    public int JVDetailID { get; set; }

    [ForeignKey("AccountID")]
    [InverseProperty("JVDetails")]
    public virtual Account Account { get; set; }

    [ForeignKey("BranchID")]
    [InverseProperty("JVDetails")]
    public virtual Branch Branch { get; set; }

    [ForeignKey("JVID")]
    [InverseProperty("JVDetails")]
    public virtual JV JV { get; set; }

    [ForeignKey("SubAccountID")]
    [InverseProperty("JVDetails")]
    public virtual SubAccount SubAccount { get; set; }
}