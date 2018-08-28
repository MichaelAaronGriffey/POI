using System;
using System.ComponentModel.DataAnnotations;

namespace Poi.Data.Entities
{
    public class PointOfInterest
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(256)]
        public string Name { get; set; }
        [MaxLength(512)]
        public string Description { get; set; }
    }
}
