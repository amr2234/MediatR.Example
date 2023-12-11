using MediatR.Domain.Commen;
using System.Data;

namespace MediatR.Domain.Entities
{
    public class User:BaseClass
    {
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Password { get; set; }

        public IList<UserRoles> UserRoles { get; set; }


    }
}
