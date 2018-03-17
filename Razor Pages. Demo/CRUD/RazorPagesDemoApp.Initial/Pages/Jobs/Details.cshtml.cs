using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.Models;

namespace RazorPagesDemoApp.CRUD.Pages.Jobs
{
    public class DetailsModel : PageModel
    {
        private readonly DAL.JobManagerContext _context;

        public DetailsModel(DAL.JobManagerContext context)
        {
            _context = context;
        }

        public Job Job { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Job = await _context.Jobs.SingleOrDefaultAsync(m => m.Id == id);

            if (Job == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
