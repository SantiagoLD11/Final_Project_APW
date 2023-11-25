using Final_Project_APW.DAL;
using Final_Project_APW.DAL.Entities;
using Final_Project_APW.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace Final_Project_APW.Domain.Services
{
    public class ClientService : IClientService
    {
        private readonly DataBaseContext _context;

        public ClientService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Client>> GetClientsAsync()
        {
            var clients = await _context.Clients
                .ToListAsync();
            return clients; 
        }

        public async Task<Client> CreateClientAsync(Client client)
        {
            try
            {
                client.Id = Guid.NewGuid();
                client.CreatedDate = DateTime.Now;

                _context.Clients.Add(client); 
                await _context.SaveChangesAsync(); //Aquí ya estoy yendo a la BD para hacer el INSERT en la tabla Hotel

                return client;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message); //Coallesences Notation --> ??
            }
        }

        public async Task<Client> GetClientByIdAsync(Guid id)
        {
            return await _context.Clients
                .FirstOrDefaultAsync(c => c.Id == id); //Debe devolver un unico registro, consulta por Id
        }

        public async Task<Client> EditClientAsync(Client client)
        {
            try
            {
                client.ModifiedDate = DateTime.Now;

                _context.Clients.Update(client); //El método Update que es de EF CORE me sirve para Actualizar un objeto
                await _context.SaveChangesAsync();

                return client;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Client> DeleteClientByIdAsync(Guid id)
        {
            try
            {
                var client = await _context.Clients
                    .FirstOrDefaultAsync(c => c.Id == id);

                if (client == null) return null; //Si el país no existe, entonces me retorna un NULL

                _context.Clients.Remove(client);
                await _context.SaveChangesAsync();

                return client;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
    }
}
