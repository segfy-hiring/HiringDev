using RTube.Context;
using RTube.Models;
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
            _context.SaveChangesAsync();
        }

        public void Update(YouTubeItem item)
        {
            _context.Items.Update(item);
            _context.SaveChangesAsync();
        }

        public bool Exists(YouTubeItem item)
        {
            return _context.Items.Any(i => i.Id == item.Id);
        }
    }
}
