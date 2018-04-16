using System.Collections.Generic;
using Tikklok.Models;

namespace Tikklok.Data
{
    public interface ITiklineDb
    {
        IEnumerable<Tikline> Get(string userid);
        void Insert(Tikline tikline);
    }
}
