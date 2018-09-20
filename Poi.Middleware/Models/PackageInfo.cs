using System.Reflection;

namespace Poi.Middleware.Models
{
    public class PackageInfo
    {
        public Assembly Assembly { get; set; }
        public string Id { get; set; }
        public string Version { get; set; }
        public string Company { get; set; }
        public string Product { get; set; }
        public string Description { get; set; }
        public string Copyright { get; set; }
        public string XMLComents { get; set; }
    }
}
