﻿using Microsoft.AspNetCore.Identity;
using MedLab.Constants;

namespace MedLab.Data
{
    

        public class DbSeeder
        {
            public static async Task SeedDefaultData(IServiceProvider service)
            {
                var userMgr = service.GetService<UserManager<IdentityUser>>();
                var roleMgr = service.GetService<RoleManager<IdentityRole>>();

                //adding some roles to db
                await roleMgr.CreateAsync(new IdentityRole(Role.ADMIN.ToString()));
                await roleMgr.CreateAsync(new IdentityRole(Role.PATIENT.ToString()));
                await roleMgr.CreateAsync(new IdentityRole(Role.LABASSISTANT.ToString()));


            //create admin user

            var admin = new IdentityUser
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",
                    EmailConfirmed = true,
                };

                var userInDb = await userMgr.FindByEmailAsync(admin.Email);
                if (userInDb is null)
                {
                    await userMgr.CreateAsync(admin, "Admin@123");
                    await userMgr.AddToRoleAsync(admin, Role.ADMIN.ToString());
                }
            }
        }
    }

