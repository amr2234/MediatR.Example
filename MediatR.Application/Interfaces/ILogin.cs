using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatR.Application.Interfaces
{
    public interface ILogin
    {
       Task<String> GetUserRole(int id);
       bool ValidateUser(string username, string password);



    }
}
