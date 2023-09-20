using Microsoft.AspNetCore.Mvc;
using OrchardCore.Environment.Shell;
using OrchardCore.Environment.Shell.Configuration;
using Wolverine.Http;

namespace OrchardCore.Mvc.WebApiWithWolverine.Endpoints;

public static class GetAccountEndpoint
{
    // NOTE: This is a trivialized endpoint just for API generation
    // Added Tenant-specific services from OrchardCore to demonstrate whether tenant-specific services are available
    [WolverineGet($"api/accounts/{{id}}")]
    public static async Task<bool> GetAccount(int id, [FromServices] IShellConfiguration shell, [FromServices] IShellFeaturesManager features)
    {
        return await Task.FromResult(true);
    }
}

