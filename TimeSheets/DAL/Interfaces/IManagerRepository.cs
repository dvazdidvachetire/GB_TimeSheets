using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.DAL.Models;
using TimeSheets.DTO;

namespace TimeSheets.DAL.Interfaces
{
    public interface IManagerRepository
    {
        Task<IEnumerable<ContractDto>> CreateContract(Contract contract);
        Task<ContractDto> GetByIdContract(int id, int idC);
        Task<IEnumerable<ContractDto>> GetByIdContracts(int id);
        Task<IEnumerable<ContractDto>> GetAllContracts();
        Task<IEnumerable<Models.Job>> CreateTask(Models.Job task);
    }
}
