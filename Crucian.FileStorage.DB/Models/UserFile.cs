using Crucian.FileStorage.CORE.Interfaces;
using System;

namespace Crucian.FileStorage.DB
{
    public class UserFile : IUserFile
    {
        public virtual double Id { get; set; }

        public virtual double Autor { get; set; }
        
        public virtual DateTime CreateData { get; set; }
        
        public virtual string FileName { get; set; }
        
        public virtual string FilePath { get; set; }
        
               
    }
}
