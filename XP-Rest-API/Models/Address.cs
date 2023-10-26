using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace XP_Rest_API.Models;
public class Address
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int Id { get; set; }
  public required string Street { get; set; }
  public required string City { get; set; }
  public required string State { get; set; }
  public required bool IsPrimary { get; set; }

  [ForeignKey("ClientId")]
  public int ClientId { get; set; }

  [JsonIgnore]
  public virtual Client Client { get; set; }

  public string GetFullAddress()
  {
    return State + ", " + City + ", " + Street;
  }
}
