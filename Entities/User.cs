using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities;

public partial class User
{
    public int Id { get; set; }
    [EmailAddress]
    [Required]
    [StringLength(50, ErrorMessage = "username more than length 50")]
    public string UserName { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    [Required]
    [StringLength(20, ErrorMessage = "password more than length 20")]

    public string Password { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
