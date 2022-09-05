using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheets.DTO;
using TimeSheets.Infrastructure.Models;
using TimeSheets.Interfaces;

namespace TimeSheets.Infrastructure.Repositories
{
    public class JobRepository : IJobRepository
    {
        private IList<Job> _jobs = new List<Job>();
        public IList<JobDto> JobsDtos { get; set; } = new List<JobDto>();

        public async Task<IEnumerable<Job>> CreateObjects(Job job)
        {
            await Task.Run(() => _jobs.Add(job));
            return _jobs;
        }

        public async Task<IEnumerable<Job>> GetObjects()
        {
            return await Task.Run(() => _jobs);
        }

        public Task<IEnumerable<Job>> UpdateObjects(int id, Job job)
        {
            return null;
        }

        public Task<IEnumerable<Job>> DeleteObjects(int id)
        {
            return null;
        }
    }
}
