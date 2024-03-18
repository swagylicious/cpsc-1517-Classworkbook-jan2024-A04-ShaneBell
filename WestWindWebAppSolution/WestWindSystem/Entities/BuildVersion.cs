﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WestWindSystem.Entities;

[Table("BuildVersion")]
public partial class BuildVersion
{
    [Key]
    public int Id { get; set; }

    public int Major { get; set; }

    public int Minor { get; set; }

    public int Build { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ReleaseDate { get; set; }
}