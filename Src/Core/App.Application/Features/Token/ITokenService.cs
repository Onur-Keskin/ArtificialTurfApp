namespace App.Application.Features.Token
{
    public interface ITokenService
    {
        public string GenerateToken(Domain.Entities.User user);
    }
}
