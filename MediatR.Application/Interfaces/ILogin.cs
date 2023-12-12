using MediatR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatR.Application.Interfaces
{
    public interface ILogin
    {
       Task<User> GetUserRole(User user);
       bool ValidateUser(string username, string password);
       Task<User> GetUserByEmail(string email);

      


    }
}
