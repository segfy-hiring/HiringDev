using RTube.Context;
using RTube.Models;
using System.Collections.Generic;
using System.Linq;

namespace RTube.Repositories
{
    public class YouTubeRepository : IYouTubeRepository
    {
        private readonly ApplicationContext _context;

        public YouTubeRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Save(YouTubeItem item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
        }

        public void Update(YouTubeItem item)
        {
            _context.Items.Update(item);
            _context.SaveChanges();
        }

        public bool Exists(YouTubeItem item)
        {
            return _context.Items.Any(i => i.Id == item.Id);
        }

        public IQueryable<YouTubeItem> List()
        {
            return _context.Items.OrderByDescending(i=>i.SearchedAT);
        }
    }
}
