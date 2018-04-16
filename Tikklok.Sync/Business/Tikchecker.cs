using System;
using Tikklok.Sync.Data;

namespace Tikklok.Sync.Business
{
    public class Tikchecker
    {
        private readonly ITikDb _tikDb;

        public Tikchecker(ITikDb tikDb)
        {
            _tikDb = tikDb;
        }

        public void Watch(params string[] args)
        {
            var config = TikConfiguration.Create(args);

        }
    }
}
