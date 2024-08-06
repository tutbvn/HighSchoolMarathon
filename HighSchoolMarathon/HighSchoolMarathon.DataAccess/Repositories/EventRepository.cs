using HighSchoolMarathon.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolMarathon.DataAccess.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly HighSchoolMarathonContext _context;

        public EventRepository(HighSchoolMarathonContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RunningEvent>> GetAllAsync()
        {
            return await _context.RunningEvents.ToListAsync();
        }

        public async Task<RunningEvent> GetByIdAsync(int id)
        {
            return await _context.RunningEvents.FindAsync(id);
        }

        public async Task AddAsync(RunningEvent eventEntity)
        {
            await _context.RunningEvents.AddAsync(eventEntity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(RunningEvent eventEntity)
        {
            _context.RunningEvents.Update(eventEntity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var eventEntity = await _context.RunningEvents.FindAsync(id);
            if (eventEntity != null)
            {
                _context.RunningEvents.Remove(eventEntity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<RunningEvent?> GetActiveEventAsync()
        {
            return await _context.RunningEvents.FirstOrDefaultAsync(e => e.Status == "Active");
        }
    }
}
