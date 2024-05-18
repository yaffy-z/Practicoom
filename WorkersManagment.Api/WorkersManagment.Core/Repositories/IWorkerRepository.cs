using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkersManagment.Core.Models;

namespace WorkersManagment.Core.Repositories
{
    public interface IWorkerRepository
    {
        Task<IEnumerable<Worker>> GetWorkerAsync();
        Task<Worker> GetWorkerByIdAsync(int id);
        Task<Worker> AddWorkerAsync(Worker Worker);
        Task<Worker> UpdateWorkerAsync(int id, Worker Worker);
        Task<bool> DeleteEmployeeAsync(int id);
    }
}
