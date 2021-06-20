using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SegFyChallenge.Application.Interfaces.Persistence;
using SegFyChallenge.Domain.Models;
using SegFyChallenge.Persistence.Contexts;

namespace SegFyChallenge.Persistence.Repositories
{
    public class VideoRepository : IVideoRepository
    {
        private readonly ApplicationContext _context;

        public VideoRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task Delete(Video video)
        {
            _context.Videos.Remove(video);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var video = await _context.Videos.FirstOrDefaultAsync(i => i.Id == id);
            _context.Videos.Remove(video);
            await _context.SaveChangesAsync();
        }

        public async Task<Video> Get(int id)
        {
            return await _context.Videos.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<List<Video>> GetAll()
        {
            return await _context.Videos.ToListAsync();
        }

        public async Task<int> Save(Video video)
        {
            if (video.Id > 0)
            {
                _context.Videos.Update(video);
            }
            else
            {
                await _context.Videos.AddAsync(video);
            }

            await _context.SaveChangesAsync();

            return video.Id;
        }
    }
}