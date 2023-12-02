using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using hackathon.Models;
using hackathon.Data;

namespace Week2_IdentitySystem.Data
{
    public static class DbInitializer
    {
        public static async Task<int> SeedUsersAndRoles(IServiceProvider serviceProvider)
        {
            // create the database if it doesn't exist
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();

            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();



            // Check if users already exist and exit if there are
            if (userManager.Users.Count() > 0)
                return 3;  // should log an error message here

            // Seed users
            int result = await SeedUsers(userManager);
            if (result != 0)
                return 4;  // should log an error message here

            return 0;
        }

        private static async Task<int> SeedUsers(UserManager<ApplicationUser> userManager)
        {
            // Create Admin User
            var adminUser = new ApplicationUser
            {
                UserName = "student1@mohawkcollege.ca",
                Email = "student1@mohawkcollege.ca",
                EmailConfirmed = true,
                Description = "Hi! I am a student taking the Mohawk 559 course in semester 3. I am looking for other people in the same " +
                "semester as me to study alongside."
            };
            var result = await userManager.CreateAsync(adminUser, "Password!1");
            if (!result.Succeeded)
                return 1;  // should log an error message here

            // Create Member User
            var memberUser = new ApplicationUser
            {
                UserName = "student2@mohawkcollege.ca",
                Email = "student2@mohawkcollege.ca",
                EmailConfirmed = true,
                Description = "Hi! I am a student2 taking the Mohawk 559 course in semester 3. I am looking for other people in the same " +
                "semester as me to study alongside."
            };
            result = await userManager.CreateAsync(memberUser, "Password!1");
            if (!result.Succeeded)
                return 3;  // should log an error message here


            return 0;
        }
    }
}
