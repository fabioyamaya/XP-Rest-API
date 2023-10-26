using XP_Rest_API.Models;

namespace XP_Rest_API.Repositories
{
    public interface IClientRepository
    {
        Task<ICollection<Client>> GetAllClientsAsync();
        Task<Client?> GetClientAsync(int id);
        Task RegisterClient(Client client);
    }
}