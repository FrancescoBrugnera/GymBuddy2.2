using GymBuddy.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymBuddy.Data
{
    public class GymBuddyRepository : IGymBuddyRepository
    {
        private GymBuddyContext _ctx;

        public GymBuddyRepository(GymBuddyContext ctx)
        {
            _ctx = ctx;
        }

        public void AddOrder(object model)
        {
            _ctx.Add(model);
        }

        public void AddOrderItem(object model)
        {
            _ctx.Add(model);
        }

        public IEnumerable<Lesson> GetAllLessons()
        {
            return _ctx.Lessons
                        .OrderBy(l => l.Title)
                        .ToList();
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _ctx.Orders.
                Include(o => o.Items).
                ThenInclude(l => l.Lesson).
                ToList();
        }

        public IEnumerable<Order> GetAllOrdersByUser(string username)
        {
            return _ctx.Orders
                .Where(o => o.User.UserName == username)
                .Include(o => o.Items)
                .ThenInclude(l => l.Lesson)
                .ToList();
        }

        public IEnumerable<Lesson> GetLessonsByCategory(string category)
        {
            return _ctx.Lessons
                        .Where(l => l.Category == category)
                        .ToList();
        }

        public Order GetOrderById(string username, int id)
        {
            return _ctx.Orders.
                Include(o => o.Items).
                ThenInclude(l => l.Lesson).
                Where(o => o.Id == id && o.User.UserName == username).
                FirstOrDefault();
        }

        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }

    }
}
