using HighSchoolMarathon.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolMarathon.DataAccess.Repositories
{
    public interface IEventRepository
    {
        Task<IEnumerable<RunningEvent>> GetAllAsync();
        Task<RunningEvent?> GetActiveEventAsync();
        Task<RunningEvent> GetByIdAsync(int id);
        Task AddAsync(RunningEvent eventEntity);
        Task UpdateAsync(RunningEvent eventEntity);
        Task DeleteAsync(int id);
    }
}
