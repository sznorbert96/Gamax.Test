using Gamax.Domain.Common;

namespace Gamax.Domain.Entities
{
    public class User : AuditableEntity
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
