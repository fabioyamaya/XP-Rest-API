using Microsoft.EntityFrameworkCore;
using XP_Rest_API.Models;

namespace XP_Rest_API.Data;
public class ClientContext : DbContext
{
  public ClientContext(DbContextOptions<ClientContext> options) : base(options) { }

  public DbSet<Client> Clients { get; set; }
}
