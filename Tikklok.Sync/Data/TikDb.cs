using System;
using System.IO.Abstractions;

namespace Tikklok.Sync.Data
{
    public class TikDb : ITikDb
    {
        readonly IFileSystem _fileSystem;
        readonly Func<DateTime> _now;

        public TikDb(IFileSystem fileSystem, Func<DateTime> now)
        {
            _fileSystem = fileSystem;
            _now = now;
        }

        public void Write(string tikFileName)
        {

        }
    }
}
