using UndyingWorld.GameIntegration.Services;
using UndyingWorld.GameIntegration.Services.Client;

namespace UndyingWorld.Web.Services.Impl
{
    public static class IntegrationService
    {
        public static PterodactylService PteroService { get; set;}
        public static ServerService ServService { get; set;}
    }
}