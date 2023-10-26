using System.ComponentModel.DataAnnotations;

namespace XP_Rest_API.Models.DTO;
public class CreateClientDTO
{
  [Required(ErrorMessage = "Name is required")]
  public required string Name { get; set; }

  [Required(ErrorMessage = "Phone is required")]
  [RegularExpression(@"^\(\d{2}\)\d{5}-\d{4}$", ErrorMessage = "Invalid phone number format")]
  public required string Phone { get; set; }

  [Required(ErrorMessage = "At least one email must be provided")]
  [EmailList(ErrorMessage = "Invalid email address format")]
  public required List<string> Emails { get; set; }
  public required List<NewAddressDTO> Addresses { get; set; }
}

public class NewAddressDTO
{
  public required string Street { get; set; }
  public required string City { get; set; }
  public required string State { get; set; }
}

public class EmailListAttribute : ValidationAttribute
{
  public override bool IsValid(object value)
  {
    if (value is List<string> emailList)
    {
      foreach (var email in emailList)
      {
        if (!IsValidEmail(email))
        {
          return false;
        }
      }
      return true;
    }
    return false;
  }

  private bool IsValidEmail(string email)
  {
    try
    {
      var addr = new System.Net.Mail.MailAddress(email);
      return addr.Address == email;
    }
    catch
    {
      return false;
    }
  }
}