
using Crucian.FileStorage.CORE.Interfaces;

namespace Crucian.FileStorage.DB
{
    public class UserStatus : IUserStatus
    {
        public virtual double Id { get; set; }

        public virtual string Status { get; set; }
    }
}
