using System.Collections.Generic;
using GymBuddy.Data.Entities;

namespace GymBuddy.Data
{
    public interface IGymBuddyRepository
    {
        IEnumerable<Lesson> GetAllLessons();
        IEnumerable<Lesson> GetLessonsByCategory(string category);
        bool SaveAll();
    }
}