using Crucian.FileStorage.CORE;
using System.Collections.Generic;

namespace Crucian.FileStorage.CORE

{
    public interface IFileRepository
    {
        double UserId { get; set; }

        IList<_UserFile> UserFile { get; set; }

        float UsedDiskStorageInMb { get; set; }

    }
}
