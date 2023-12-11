using MediatR.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediatR.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MediatR.Infrastructure.Data
{
    public class Login : ILogin
    {
        protected DBContext_App _context;

        public Login(DBContext_App context)
        {
            _context = context;
        }

        public async Task<string> GetUserRole(int id)
        {
            var RoleID = await _context.UserRoles.Where(a => a.UserId == id).Select(a => a.RoleId).FirstOrDefaultAsync();
            var RoleName = await _context.Roles.Where(a => a.id == RoleID).Select(a => a.RoleName).FirstOrDefaultAsync();
            return RoleName;
        }

        public bool ValidateUser(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return false;
            }


            var user = (from us in _context.Users
                        where string.Compare(username, us.UserName, StringComparison.OrdinalIgnoreCase) == 0
                        && string.Compare(password, us.Password, StringComparison.OrdinalIgnoreCase) == 0
                        select us).FirstOrDefault();

            return (user != null) ? true : false;

        }
    }
}
