using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations;

namespace Entities;

public partial class User
{
    public int Id { get; set; }
    [EmailAddress]
    [Required]
    [StringLength(50, ErrorMessage = "name between 5-20")]

    public string UserName { get; set; } = null!;


    [StringLength(50, ErrorMessage = "name between 5-20")]

    public string? FirstName { get; set; }

    [StringLength(50, ErrorMessage = "name between 5-20")]

    public string? LastName { get; set; }
    [Required]
    [StringLength(20, ErrorMessage = "name between 5-20")]

    public string Password { get; set; } = null!;
}
