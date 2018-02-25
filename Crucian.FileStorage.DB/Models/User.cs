using System;
using Crucian.FileStorage.CORE.Interfaces;

namespace Crucian.FileStorage.DB
{
    public class User : IUsers
    {
        public virtual double Id { get; set; }

        public virtual string Login { get; set; }

        public virtual string Password { get; set; }

        public virtual string Name { get; set; }
        
        public virtual int Role { get; set; }

        public virtual int Status { get; set; }

        public virtual DateTime BirthDay { get; set; }  

    }
}
