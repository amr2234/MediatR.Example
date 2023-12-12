using MediatR.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediatR.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using MediatR.Domain.Entities;

namespace MediatR.Infrastructure.Data
{
    public class Login : ILogin
    {
        protected DBContext_App _context;

        public Login(DBContext_App context)
        {
            _context = context;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            if (email == null) {
                return null;
                    }
            return await _context.Users.Where(a => a.UserEmail == email).FirstOrDefaultAsync();
        }

        public async Task<User> GetUserRole(User user)
        {

            var RoleID = await _context.UserRoles.Where(a => a.UserId == user.id).Select(a => a.RoleId).FirstOrDefaultAsync();
            var RoleName = await _context.Roles.Where(a => a.id == RoleID).Select(a => a.RoleName).FirstOrDefaultAsync();
            
            return user;
        }

        public bool ValidateUser(string Email, string password)
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(password))
            {
                return false;
            }
            
          
            //var user = (from us in _context.Users
            //            where string.Compare(username, us.UserEmail, StringComparison.OrdinalIgnoreCase) == 0
            //            && string.Compare(password, us.Password, StringComparison.OrdinalIgnoreCase) == 0
            //            select us).FirstOrDefault();

            var user = _context.Users.FirstOrDefault(u => u.UserEmail == Email && u.Password == password);
            if (user == null) { 
                return false;
            }
           // var RoleName = GetUserRole(user);
            
            return true;

        }

   
    }
}
