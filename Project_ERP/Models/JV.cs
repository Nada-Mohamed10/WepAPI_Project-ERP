﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Project_ERP.Models;

[Table("JV")]
public partial class JV
{
    [Required]
    [StringLength(50)]
    public string JVNo { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime JVDate { get; set; }

    public int? JVTypeID { get; set; }

    [Column(TypeName = "numeric(22, 8)")]
    public decimal TotalDebit { get; set; }

    [Column(TypeName = "numeric(22, 8)")]
    public decimal TotalCredit { get; set; }

    [StringLength(50)]
    public string ReceiptNo { get; set; }

    [StringLength(1000)]
    public string Notes { get; set; }

    public int? BranchID { get; set; }

    [Key]
    public int JVID { get; set; }

    [ForeignKey("BranchID")]
    [InverseProperty("JVs")]
    public virtual Branch Branch { get; set; }

    [InverseProperty("JV")]
    public virtual ICollection<JVDetail> JVDetails { get; set; } = new List<JVDetail>();

    [ForeignKey("JVTypeID")]
    [InverseProperty("JVs")]
    public virtual JVType JVType { get; set; }
}