using System.Collections.Generic;
using GymBuddy.Data.Entities;

namespace GymBuddy.Data
{
    public interface IGymBuddyRepository
    {
        IEnumerable<Lesson> GetAllLessons();
        IEnumerable<Lesson> GetLessonsByCategory(string category);

        bool SaveAll();

        IEnumerable<Order> GetAllOrders();
        Order GetOrderById(string username, int id);
        void AddOrder(object model);
        void AddOrderItem(object model);
        IEnumerable<Order> GetAllOrdersByUser(string username);
    }
}