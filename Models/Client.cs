using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XP_Rest_API.Models;
public class Client
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int Id { get; set; }
  public required string Name { get; set; }
  public required string Phone { get; set; }

  [InverseProperty("Client")]
  public virtual required ICollection<Email> Emails { get; set; }

  [InverseProperty("Client")]
  public virtual required ICollection<Address> Addresses { get; set; }

}