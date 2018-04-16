using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tikklok.Business;
using Tikklok.Models;

namespace Tikklok
{
    public class IndexModel : PageModel
    {
        readonly ITikked _tikked;
        readonly ITikker _tikker;

        public IEnumerable<Tikline> Tiklines { get; set; }

        [BindProperty]
        public string UserId { get; set; }

        public IndexModel(ITikked tikked, ITikker tikker)
        {
            _tikked = tikked;
            _tikker = tikker;
        }
        
        public void OnGet()
        {
            if (string.IsNullOrWhiteSpace(UserId))
            {
                Tiklines = new List<Tikline>();
            }
            else
            {
                Tiklines = _tikked.Tiks(UserId).OrderByDescending(t => t.Time);
            }
        }

        public void OnPostRefresh()
        {
            if (string.IsNullOrWhiteSpace(UserId))
            {
                Tiklines = new List<Tikline>();
            }
            else
            {
                Tiklines = _tikked.Tiks(UserId).OrderByDescending(t => t.Time);
            }
        }

        public void OnPostStart()
        {
            if (string.IsNullOrWhiteSpace(UserId))
            {
                Tiklines = new List<Tikline>();
                return;
            }
            _tikker.Tik(UserId, TikAction.Start);
            Tiklines = _tikked.Tiks(UserId).OrderByDescending(t => t.Time);
        }

        public void OnPostStop()
        {
            if (string.IsNullOrWhiteSpace(UserId))
            {
                Tiklines = new List<Tikline>();
                return;
            }
            _tikker.Tik(UserId, TikAction.Stop);
            Tiklines = _tikked.Tiks(UserId).OrderByDescending(t => t.Time);
        }

    }
}