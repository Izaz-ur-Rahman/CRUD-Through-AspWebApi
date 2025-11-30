using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AspWebApiCRUD.Models;

public partial class Student
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string StudentName { get; set; } = null!;

    [StringLength(10)]
    public string? Gender { get; set; }

    public int Age { get; set; }

    [StringLength(50)]
    public string? Standard { get; set; }

    [StringLength(100)]
    public string? FatherName { get; set; }
}
