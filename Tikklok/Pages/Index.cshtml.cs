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
        readonly ITiks _tiks;

        public IEnumerable<Tikline> Tiklines { get; set; }

        [BindProperty]
        public string UserId { get; set; }

        public IndexModel(ITiks tiks)
        {
            _tiks = tiks;
        }
        
        public void OnGet()
        {
            if (string.IsNullOrWhiteSpace(UserId))
            {
                Tiklines = new List<Tikline>();
            }
            else
            {
                Tiklines = _tiks.Get(UserId).OrderByDescending(t => t.Time);
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
                Tiklines = _tiks.Get(UserId).OrderByDescending(t => t.Time);
            }
        }

        public void OnPostStart()
        {
            if (string.IsNullOrWhiteSpace(UserId))
            {
                Tiklines = new List<Tikline>();
                return;
            }
            _tiks.Insert(UserId, TikAction.Start);
            Tiklines = _tiks.Get(UserId).OrderByDescending(t => t.Time);
        }

        public void OnPostStop()
        {
            if (string.IsNullOrWhiteSpace(UserId))
            {
                Tiklines = new List<Tikline>();
                return;
            }
            _tiks.Insert(UserId, TikAction.Stop);
            Tiklines = _tiks.Get(UserId).OrderByDescending(t => t.Time);
        }

    }
}