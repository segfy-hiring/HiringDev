using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SegFyChallenge.Application.Interfaces.Persistence;
using SegFyChallenge.Domain.Models;
using SegFyChallenge.Persistence.Contexts;

namespace SegFyChallenge.Persistence.Repositories
{
    public class ChannelRepository : IChannelRepository
    {
        private readonly ApplicationContext _context;

        public ChannelRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task Delete(Channel channel)
        {
            _context.Channels.Remove(channel);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var channel = await _context.Channels.FirstOrDefaultAsync(d => d.Id == id);
            _context.Channels.Remove(channel);
            await _context.SaveChangesAsync();
        }

        public async Task<Channel> Get(int id)
        {
            return await _context.Channels.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<List<Channel>> GetAll()
        {
            return await _context.Channels.ToListAsync();
        }

        public async Task<int> Save(Channel channel)
        {
            if (channel.Id > 0)
            {
                _context.Channels.Update(channel);
            }
            else
            {
                await _context.Channels.AddAsync(channel);
            }

            await _context.SaveChangesAsync();

            return channel.Id;
        }
    }
}