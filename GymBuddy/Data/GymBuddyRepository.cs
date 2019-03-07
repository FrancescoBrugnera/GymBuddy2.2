using GymBuddy.Data.Entities;
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

        public IEnumerable<Lesson> GetAllLessons()
        {
            return _ctx.Lessons
                        .OrderBy(l => l.Title)
                        .ToList();
        }

        public IEnumerable<Lesson> GetLessonsByCategory(string category)
        {
            return _ctx.Lessons
                        .Where(l => l.Category == category)
                        .ToList();
        }

        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }

    }
}
