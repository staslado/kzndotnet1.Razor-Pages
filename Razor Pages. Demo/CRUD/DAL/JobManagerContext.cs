using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class JobManagerContext : DbContext
    {
        public JobManagerContext(DbContextOptions<JobManagerContext> options) : base(options)
        {
        }

        public DbSet<Job> Jobs { get; set; }
    }
}
