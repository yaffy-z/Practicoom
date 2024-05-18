using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkersManagment.Core.Models;

namespace WorkersManagment.Core.Services
{
    public interface IWorkerService
    {
        Task<IEnumerable<Worker>> GetWorkerAsync();
        Task<Worker> GetWorkerByIdAsync(int id);
        Task<Worker> AddWorkerAsync(Worker worker);
        Task<Worker> UpdateWorkerAsync(int id, Worker worker);
        Task<bool> DeleteWorkerAsync(int id);
    }
}
