namespace XP_Rest_API.Models;
public class Client
{
  public int Id { get; set; }
  public required string Name { get; set; }
  public required string Phone { get; set; }
  public required string Email { get; set; }
  public string? SecondaryEmail { get; set; }
}
