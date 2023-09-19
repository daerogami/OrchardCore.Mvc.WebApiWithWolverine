using System.Security.Principal;
using Wolverine.Http;

namespace OrchardCore.Mvc.WebApiWithWolverine.Endpoints;

public static class GetAccountEndpoint
{
    // NOTE: This is a trivialized endpoint just for API generation
    [WolverineGet($"api/accounts/{{id}}")]
    public static async Task<bool> GetAccount(int id) =>
        await Task.FromResult(true);
}

