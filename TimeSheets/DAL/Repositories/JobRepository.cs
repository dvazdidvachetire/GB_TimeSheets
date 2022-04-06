using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.DAL.Interfaces;
using TimeSheets.DAL.Models;
using TimeSheets.DTO;

namespace TimeSheets.DAL.Repositories
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
