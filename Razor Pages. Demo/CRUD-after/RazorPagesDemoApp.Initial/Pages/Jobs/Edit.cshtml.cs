using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL.Models;
using RazorPagesDemoApp.CRUD.Filters;

namespace RazorPagesDemoApp.CRUD.Pages.Jobs
{
    //[DisablePostMethodFilter]
    public class EditModel : PageModel
    {
        private readonly DAL.JobManagerContext _context;

        public EditModel(DAL.JobManagerContext context) => _context = context;

        [BindProperty]
        public Job Job { get; set; }

        [TempData]
        public string Message { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();            

            Job = await _context.Jobs.SingleOrDefaultAsync(m => m.Id == id);

            if (Job == null)            
                return NotFound();
            
            return Page();
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)            
                return Page();            

            _context.Attach(Job).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobExists(Job.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            Message = $"Job with title '{Job.Title}' is changed";

            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnPostAssigneeToAdminAsync(int id)
        {
            var job = await _context.Jobs.SingleOrDefaultAsync(m => m.Id == id);
            job.Assignee = "Administrator@manager.org";

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobExists(Job.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            Message = $"Job with title '{Job.Title}' is assignee to Administrator";

            return RedirectToPage("./Index");
        }

        private bool JobExists(int id) => _context.Jobs.Any(e => e.Id == id);
    }
}
