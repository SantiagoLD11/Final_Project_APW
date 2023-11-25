using Final_Project_APW.DAL.Entities;
using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;

namespace Final_Project_APW.Domain.Interfaces
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> GetClientsAsync();
        Task<Client> CreateClientAsync(Client client);
        Task<Client> GetClientByIdAsync(Guid id);
        Task<Client> EditClientAsync(Client client);
        Task<Client> DeleteClientByIdAsync(Guid id);
    }
}
