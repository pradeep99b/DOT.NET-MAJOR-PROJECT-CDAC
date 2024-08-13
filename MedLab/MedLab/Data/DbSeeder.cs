using Microsoft.AspNetCore.Identity;
using MedLab.Constants;
using MedLab.Models;

namespace MedLab.Data
{
    

        public class DbSeeder
        {
            public static async Task SeedDefaultData(IServiceProvider service)
            {
                var userMgr = service.GetService<UserManager<User>>();
                var roleMgr = service.GetService<RoleManager<IdentityRole>>();

                //adding some roles to db
                await roleMgr.CreateAsync(new IdentityRole(Role.ADMIN.ToString()));
                await roleMgr.CreateAsync(new IdentityRole(Role.PATIENT.ToString()));
                await roleMgr.CreateAsync(new IdentityRole(Role.LABASSISTANT.ToString()));


            //create admin user

            var admin = new User
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",
                    EmailConfirmed = true,
                    UserRole = Role.ADMIN

            };

            var userInDb = await userMgr.FindByEmailAsync(admin.Email);
            if (userInDb is null)
            {
                var result = await userMgr.CreateAsync(admin, "Admin@123");
                if (result.Succeeded)
                {
                    await userMgr.AddToRoleAsync(admin, Role.ADMIN.ToString());
                }
            }
        }
        }
    }

