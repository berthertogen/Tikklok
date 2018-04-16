using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tikklok.Data;
using Tikklok.Models;

namespace Tikklok.Business
{
    public class Tikked : ITikked
    {
        private readonly ITiklineDb _tiklineRepository;

        public Tikked(ITiklineDb tiklineRepository)
        {
            _tiklineRepository = tiklineRepository;
        }

        public IEnumerable<Tikline> Tiks(string userid)
        {
            return _tiklineRepository.Get(userid);
        }
    }
}
