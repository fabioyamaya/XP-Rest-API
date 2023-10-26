using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace XP_Rest_API.Models;
public class Email
{
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int Id { get; set; }
  public required string EmailAddress { get; set; }
  public required bool IsPrimary { get; set; }

  [ForeignKey("ClientId")]
  public int ClientId { get; set; }

  [JsonIgnore]
  public virtual Client Client { get; set; }
}
