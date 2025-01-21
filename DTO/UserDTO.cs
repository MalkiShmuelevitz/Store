using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
  public record UserDTO(string UserName, string? FirstName,string? LastName,string Password);
    public record GetUserDTO(int Id,string UserName, string? FirstName, string? LastName);

}
