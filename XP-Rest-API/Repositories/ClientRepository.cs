using Microsoft.EntityFrameworkCore;
using XP_Rest_API.Data;
using XP_Rest_API.Models;

namespace XP_Rest_API.Repositories;
public class ClientRepository : IClientRepository
{
  private readonly ClientContext _db;

  public ClientRepository(ClientContext db)
  {
    _db = db;
  }

  public async Task<ICollection<Client>> GetAllClientsAsync()
  {
    return await _db.Clients.Include(c => c.Emails)
                            .Include(c => c.Addresses)
                            .ToListAsync();
  }

  public async Task<Client?> GetClientAsync(int id)
  {
    return await _db.Clients.Include(c => c.Emails)
                            .Include(c => c.Addresses)
                            .FirstOrDefaultAsync(c => c.Id == id);
  }

  public async Task RegisterClient(Client client)
  {
    _db.Clients.Add(client);
    await _db.SaveChangesAsync();
    return;
  }
}
