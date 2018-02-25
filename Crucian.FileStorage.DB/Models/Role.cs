using Crucian.FileStorage.CORE.Interfaces;

namespace Crucian.FileStorage.DB
{
    public class Role : IRole
    {
        public virtual double Id { get; set; }

        public virtual string RoleName { get; set; }

    }
}
