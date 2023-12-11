
using MediatR.Domain.Commen;


namespace MediatR.Domain.Entities
{
    public class Role:BaseClass
    {
        public string RoleName { get; set; }
        public IList<UserRoles> UserRoles { get; set; }
        
    }
}
