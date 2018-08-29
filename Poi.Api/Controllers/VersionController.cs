using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Versioning;


namespace Poi.Api.Controllers
{
    [Route("[controller]")]
    public class VersionController : Controller
    {

        [HttpGet]
        public IEnumerable<KeyValuePair<string, string>> Get()
        {
            var assembly = Assembly.GetEntryAssembly();
            var fullName = assembly?.FullName;
            var packageVersion = assembly?.GetCustomAttribute<AssemblyFileVersionAttribute>()?.Version;
            var osDescription = System.Runtime.InteropServices.RuntimeInformation.OSDescription;
            var framework = assembly?.GetCustomAttribute<TargetFrameworkAttribute>()?.FrameworkName;

            var stats = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("FullName", fullName),
                new KeyValuePair<string, string>("PackageVersion", packageVersion),
                new KeyValuePair<string, string>("OSDescription", osDescription),
                new KeyValuePair<string, string>("AspDotnetVersion", framework),
            };
            return stats;
        }
    }
}
