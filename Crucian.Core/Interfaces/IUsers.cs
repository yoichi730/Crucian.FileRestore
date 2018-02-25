using System;

namespace Crucian.FileStorage.CORE.Interfaces

{
    public interface IUsers
    {
        double Id { get; set; }

        string Login { get; set; }

        string Name { get; set; }

        string Password { get; set; }

        DateTime BirthDay { get; set; }

        int Role { get; set; }

        int Status { get; set; }

    }
}
