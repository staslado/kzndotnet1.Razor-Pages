using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DAL.Models;

namespace RazorPagesDemoApp.CRUD.Pages.Jobs
{
    public class CreateModel : PageModel
    {
        private readonly DAL.JobManagerContext _context;

        public CreateModel(DAL.JobManagerContext context) => _context = context;

        [BindProperty]
        public Job Job { get; set; }

        [TempData]
        public string Message { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Jobs.Add(Job);
            await _context.SaveChangesAsync();

            Message = $"Job with title '{Job.Title}' is created now";
            return RedirectToPage("./Index");
        }
    }
}