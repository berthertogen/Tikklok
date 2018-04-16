//using System;
//using System.Collections.Generic;
//using System.Globalization;
//using System.IO;
//using System.IO.Abstractions;
//using System.Linq;
//using Tikklok.Models;

//namespace Tikklok.Repositories
//{
//    public class TikRepository : ITikRepository
//    {
//        readonly TikConfiguration _config;
//        readonly IFileSystem _fileSystem;
//        readonly Func<DateTime> _now;

//        private const int USERID_START = 14;
//        private const int USERID_LENGTH = 19;
//        private const int TYPE_START = USERID_START + USERID_LENGTH;
//        private const string EXTENSIE = ".txt";
//        private const string DATEFORMAT = "yyyyMMddHHmmss";

//        public TikRepository(IFileSystem fileSystem, Func<DateTime> now, TikConfiguration config)
//        {
//            _fileSystem = fileSystem;
//            _now = now;
//            _config = config;
//        }

//        public IEnumerable<Tikline> Get(string userid)
//        {
//            CreateDirectoriesIfNotExist();
//            var files = _fileSystem.Directory.GetFiles(_config.PersistentPath);
//            var result = ToTiklines(files);
//            return result.Where(tikline => tikline.UserId.ToUpper() == userid.ToUpper());
//        }
//        IEnumerable<Tikline> ToTiklines(string[] files)
//        {
//            return files.Select(fullPath =>
//            {
//                var filename = Path.GetFileNameWithoutExtension(fullPath);
//                var type = GetTiklineType(filename);
//                return new Tikline
//                {
//                    Time = Time(filename),
//                    UserId = UserId(filename),
//                    Type = type,
//                    MachineName = MachineName(filename, type)
//                };
//            });
//        }
//        string MachineName(string filename, TikType type)
//        {
//            var startIndex = TYPE_START + type.ToString().Length;
//            var length = filename.Length - startIndex;
//            return filename
//                .Substring(startIndex, length)
//                .Replace(_config.Padder.ToString(), string.Empty)
//                .Replace(EXTENSIE, string.Empty);
//        }
//        string UserId(string filename)
//        {
//            return filename
//                .Substring(USERID_START, USERID_LENGTH)
//                .Replace(_config.Padder.ToString(), string.Empty);
//        }
//        static DateTime Time(string filename)
//        {
//            return DateTime.ParseExact(filename.Substring(0, 14), DATEFORMAT, CultureInfo.InvariantCulture);
//        }
//        static TikType GetTiklineType(string filename)
//        {
//            var length = filename.Substring(TYPE_START, 2).ToLower() == "in" ? 2 : 3;
//            return (TikType)Enum.Parse(typeof(TikType), filename.Substring(TYPE_START, length), true);
//        }

//        public void Tik(string userid, TikType type)
//        {
//            CreateDirectoriesIfNotExist();
//            if (IsNotOfType(userid, type))
//            {
//                WriteToFileSystem(userid, type);
//            }
//        }
//        void WriteToFileSystem(string userid, TikType type)
//        {
//            var useridMetPadding = userid.ToUpper().PadRight(19, _config.Padder);
//            var machineNameMetPadding = _config.MachineName.ToUpper().PadRight(16, _config.Padder);
//            var time = _now().ToString(DATEFORMAT);
//            var stream = _fileSystem.File.Create(Path.Combine(_config.Path, $"{time}{useridMetPadding}{type.ToString().ToUpper()}{machineNameMetPadding}.txt"));
//            var streamPersistent = _fileSystem.File.Create(Path.Combine(_config.PersistentPath, $"{time}{useridMetPadding}{type.ToString().ToUpper()}{machineNameMetPadding}.txt"));
//            stream.Close();
//            streamPersistent.Close();
//        }
//        bool IsNotOfType(string userid, TikType type)
//        {
//            var lastTikline = Get(userid)?.OrderByDescending(t => t.Time)?.FirstOrDefault();
//            return lastTikline == null || lastTikline.Type != type;
//        }

//        void CreateDirectoriesIfNotExist()
//        {
//            CreateDirectoryIfNotExist(_config.Path);
//            CreateDirectoryIfNotExist(_config.PersistentPath);
//        }
//        void CreateDirectoryIfNotExist(string path)
//        {
//            if (!_fileSystem.Directory.Exists(path))
//            {
//                _fileSystem.Directory.CreateDirectory(path);
//            }
//        }
//    }
//}
