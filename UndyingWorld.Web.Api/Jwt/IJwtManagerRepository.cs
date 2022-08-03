namespace UndyingWorld.Web.Api.Jwt
{
    public interface IJwtManagerRepository
    {
        Models.JwtToken Authenticate(Models.User user);
    }
}
