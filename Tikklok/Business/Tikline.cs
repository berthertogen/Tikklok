using System;
using System.Collections.Generic;

namespace Tikklok.Models
{
    public class Tikline
    {
        public string UserId { get; set; }
        public DateTime Time { get; set; }
        public TikAction Action { get; set; }

        public override bool Equals(object obj)
        {
            var tikline = obj as Tikline;
            if (obj == null)
            {
                return false;
            }
            return string.Equals(UserId, tikline.UserId) &&
                Time.Equals(tikline.Time);
        }

        public override int GetHashCode()
        {
            var hashCode = 1712660928;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(UserId);
            hashCode = hashCode * -1521134295 + Time.GetHashCode();
            return hashCode;
        }
    }
}
