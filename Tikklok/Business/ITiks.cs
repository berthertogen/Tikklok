using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tikklok.Models;

namespace Tikklok.Business
{
    public interface ITiks
    {
        void Insert(string userid, TikAction action);
        IEnumerable<Tikline> Get(string userid);
    }
}
