using System;
using System.ComponentModel.DataAnnotations;

namespace Poi.Domain
{
    public class PointOfInterest
    {
        [Key]
        public Guid Id { get; private set; }
        [Required, MaxLength(256)]
        public string Name { get; private set; }
        [Required, MaxLength(512)]
        public string Description { get; private set; }
    }
}
