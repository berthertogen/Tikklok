using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tikklok.Data;
using Tikklok.Models;

namespace Tikklok.Business
{
    public class Tikker: ITikker
    {
        readonly ITiklineDb _tiklineRepository;
        readonly Func<DateTime> _now;

        public Tikker(ITiklineDb tiklineRepository, Func<DateTime> now)
        {
            _tiklineRepository = tiklineRepository;
            _now = now;
        }
        public void Tik(string userid, TikAction action)
        {
            var lastTikline = _tiklineRepository.Get(userid).OrderByDescending(tl => tl.Time).FirstOrDefault();
            if (lastTikline?.Action != action)
            {
                var tikline = new Tikline
                {
                    UserId = userid,
                    Action = action,
                    Time = _now()
                };
                _tiklineRepository.Insert(tikline);
            }
        }
    }
}
