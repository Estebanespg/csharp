namespace CRUD.Shared.Models;
public class UserModel
{
    public int Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;

    // 0 UNDEFINED
    // 1 ACTIVE
    // 2 DISABLED
    public int State { get; set; }
}
