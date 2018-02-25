using System.Collections.Generic;

namespace Crucian.FileStorage.CORE.Models
{
    class FileRepository
    {
        private FileManager FileManager = new FileManager();

        public double UserId { get; set; }

        //public IList<UserFile> UserFile { get; set; }

        public float UsedDiskStorageInMb { get; set; }

        

        
    }
}
