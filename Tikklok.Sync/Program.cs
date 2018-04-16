using System;
using System.IO.Abstractions;
using Tikklok.Sync.Business;
using Tikklok.Sync.Data;

namespace Tikklok.Sync
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Listening ...");
            var checker = new Tikchecker(new TikDb(new FileSystem(), () => DateTime.Now));
            checker.Watch(args);
        }
    }
}
