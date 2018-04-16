//using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using Tikklok.Models;

namespace Tikklok.Data
{
    public class TiklineDb : ITiklineDb
    {
        const string DBFILENAME = @"tiklines.db";

        public IEnumerable<Tikline> Get(string userid)
        {
            return new List<Tikline>();
            //using (var db = new LiteDatabase(DBFILENAME))
            //{
            //    // Get a collection (or create, if doesn't exist)
            //    var tiklines = db.GetCollection<TiklineDTO>("tiklines");
            //    return tiklines
            //        .Find(tl => tl.UserId == userid)
            //        .Select(tl => new Tikline
            //        {
            //            UserId = tl.UserId,
            //            Time = tl.Time,
            //            Action = tl.Action
            //        });
            //}
        }

        public void Insert(Tikline tikline)
        {
            //using (var db = new LiteDatabase(DBFILENAME))
            //{
            //    var tiklines = db.GetCollection<TiklineDTO>("tiklines");
            //    tiklines.Insert(new TiklineDTO
            //    {
            //        Id = Guid.NewGuid(),
            //        UserId = tikline.UserId,
            //        Time = tikline.Time,
            //        Action = tikline.Action,
            //    });
            //}
        }
    }
}
