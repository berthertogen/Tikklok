using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tikklok.Models;

namespace Tikklok.Business
{
    public interface ITikked
    {
        IEnumerable<Tikline> Tiks(string userid);
    }
}
