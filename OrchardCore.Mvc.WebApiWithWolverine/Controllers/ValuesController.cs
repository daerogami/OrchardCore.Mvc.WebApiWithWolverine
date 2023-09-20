using Microsoft.AspNetCore.Mvc;
using OrchardCore.Environment.Shell;
using OrchardCore.Environment.Shell.Configuration;

namespace OrchardCore.Mvc.WebApiWithWolverine.Controllers;

// NOTE: This is a controller directly from the templates just for API generation
[Route("api/[controller]")]
[ApiController]
public class ValuesController : ControllerBase
{
    // NOTE: Added Tenant-specific service from OrchardCore to deomnstrate whether tenant-specific services are available
    private readonly IShellConfiguration _shell;
    private readonly IShellFeaturesManager _shellFeatures;

    public ValuesController(IShellConfiguration shell, IShellFeaturesManager shellFeatures)
    {
        _shell = shell;
        _shellFeatures = shellFeatures;
    }

    // GET: api/<ValuesController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    // GET api/<ValuesController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<ValuesController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<ValuesController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<ValuesController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}

