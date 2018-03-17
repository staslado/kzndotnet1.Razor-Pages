using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;

namespace RazorPagesDemoApp.CRUD.Pages.Jobs
{
    public class IndexModel : PageModel
    {
        private readonly DAL.JobManagerContext _context;

        public IndexModel(DAL.JobManagerContext context)
        {
            _context = context;
        }

        [TempData]
        public string Message { get; set; }

        public bool IsMessageExists => !string.IsNullOrEmpty(Message);

        public IList<Job> Jobs { get; set; }

        public bool IsJobsAvailable => Jobs.Count > 0;

        public async Task OnGetAsync(string priority)
        {
            Jobs = await _context.Jobs.ToListAsync();
            if (!string.IsNullOrEmpty(priority))
                Jobs = Jobs.Where(x => x.Priority == Enum.Parse<Priority>(priority)).ToList();
        }

        public async Task OnGetActiveAsync()
        {
            Jobs = await _context.Jobs.Where(x => x.IsActive).ToListAsync();
        }
    }
}
