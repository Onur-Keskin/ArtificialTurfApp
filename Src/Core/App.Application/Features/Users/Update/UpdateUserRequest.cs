namespace App.Application.Features.Users.Update;
public record UpdateUserRequest
    (int Id,string Name,string Email,string MobilePhoneNumber,string Role);

