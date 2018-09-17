using Microsoft.AspNetCore.Mvc;
using Poi.Middleware.Models;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Versioning;


namespace Poi.Api.Controllers
{
    [Route("[controller]")]
    public class VersionController : Controller
    {
        public VersionController(PackageInfo packageInfo)
        {
            PackageInfo = packageInfo;
        }

        public PackageInfo PackageInfo { get; }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, string>> Get()
        {
            var osDescription = System.Runtime.InteropServices.RuntimeInformation.OSDescription;
            var framework = PackageInfo.Assembly?.GetCustomAttribute<TargetFrameworkAttribute>()?.FrameworkName;

            var stats = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("Id", PackageInfo.Id),
                new KeyValuePair<string, string>("Version", PackageInfo.Version),
                new KeyValuePair<string, string>("Company", PackageInfo.Company),
                new KeyValuePair<string, string>("Product", PackageInfo.Product),
                new KeyValuePair<string, string>("Description", PackageInfo.Description),
                new KeyValuePair<string, string>("Copyright", PackageInfo.Copyright),
                new KeyValuePair<string, string>("OSDescription", osDescription),
                new KeyValuePair<string, string>("AspDotnetVersion", framework),
            };
            return stats;
        }
    }
}
