using System;

namespace Crucian.FileStorage.CORE.Interfaces

{
    public interface IUserFile
    {
        double Id { get; set; }

        double Autor { get; set; }

        string FileName { get; set; }

        string FilePath { get; set; }

        DateTime CreateData { get; set; }
        
    }
}
