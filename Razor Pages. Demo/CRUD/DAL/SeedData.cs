using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace DAL
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = serviceProvider.GetRequiredService<JobManagerContext>())
            {
                if (context.Jobs.Any())
                    return;

                context.Jobs.AddRange(
                    new Models.Job()
                    {
                        Title = "Fix 404 error on the About page",
                        Description = "-",
                        Priority = Models.Priority.Critical,
                        IsActive = true,
                        Assignee = "dev@test.ru"
                    },
                new Models.Job()
                {
                    Title = "Add authorization rule to iis site",
                    Description = "Deny access users in Operator group to Operator web app",
                    Priority = Models.Priority.Major,
                    IsActive = false,
                    Assignee = "admin@test.ru"
                });
                context.SaveChanges();
            }
        }
    }
}
