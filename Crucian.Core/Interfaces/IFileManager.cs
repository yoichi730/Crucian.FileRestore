using System.Collections.Generic;

namespace Crucian.FileStorage.CORE.Interfaces
{
    public interface IFileManager
    {

        IList<_UserFile> AddNewFileToDB { get; set; }

        IList<_UserFile> GetListOfUserFilesByUser { get; set; }

        IList<_UserFile> DeleteSelectedFileById { get; set; }

    }
}
