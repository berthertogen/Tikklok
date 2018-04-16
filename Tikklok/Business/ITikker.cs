using Tikklok.Models;

namespace Tikklok.Business
{
    public interface ITikker
    {
        void Tik(string userid, TikAction action);
    }
}
