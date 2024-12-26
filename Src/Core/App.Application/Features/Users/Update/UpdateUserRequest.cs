namespace App.Application.Features.Users.Update;
public record UpdateUserRequest
    (int UserId,string Name,string Email,string MobilePhoneNumber,string Role);

