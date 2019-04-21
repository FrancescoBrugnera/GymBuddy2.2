using GymBuddy.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GymBuddy.Data
{
    public class GymBuddySeeder
    {
        private readonly GymBuddyContext _ctx;
        private readonly IHostingEnvironment _hosting;
        private readonly UserManager<UserStore> _userManager;

        public GymBuddySeeder(GymBuddyContext ctx, IHostingEnvironment hosting, UserManager<UserStore> userManager)
        {
            _ctx = ctx;
            _hosting = hosting;
            _userManager = userManager;
        }

        public async Task SeedAsync()
        {
            _ctx.Database.EnsureCreated();

            UserStore user = await _userManager.FindByEmailAsync("francesco.brugnera@hotmail.com");

            if(user == null)
            {
                user = new UserStore()
                {
                    FirstName = "Francesco",
                    SecondName = "Brugnera",
                    Email = "francesco.brugnera@hotmail.com",
                    UserName = "francesco.brugnera@hotmail.com"
                };

                var result = await _userManager.CreateAsync(user, "Password@1!");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("could not create user");
                }
            }



            if (!_ctx.Lessons.Any())
            {
                //sample data creation process
                var filepath = Path.Combine(_hosting.ContentRootPath, "Data/art.json");
                var json = File.ReadAllText(filepath);
                var lessons = JsonConvert.DeserializeObject<IEnumerable<Lesson>>(json);
                _ctx.Lessons.AddRange(lessons);

                var order = _ctx.Orders.Where(o => o.Id == 1).FirstOrDefault();
                if(order != null)
                {
                    order.User = user;
                    order.Items = new List<OrderItem>()
                    {
                        new OrderItem()
                        {
                            Lesson = lessons.First(),
                            Quantity = 5,
                            UnitPrice = lessons.First().Price
                        }
                    };
                    //_ctx.Orders.Add(order);
                }
                _ctx.SaveChanges();
            }

        }

    }
}
