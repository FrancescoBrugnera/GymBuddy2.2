using GymBuddy.Data.Entities;
using Microsoft.AspNetCore.Hosting;
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

        public GymBuddySeeder(GymBuddyContext ctx, IHostingEnvironment hosting)
        {
            _ctx = ctx;
            _hosting = hosting;
        }

        public void Seed()
        {
            _ctx.Database.EnsureCreated();

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
                    order.Items = new List<OrderItem>()
                    {
                        new OrderItem()
                        {
                            Lesson = lessons.First(),
                            Quantity = 5,
                            UnitPrice = lessons.First().Price
                        }
                    };
                }
                _ctx.SaveChanges();
            }

        }

    }
}
