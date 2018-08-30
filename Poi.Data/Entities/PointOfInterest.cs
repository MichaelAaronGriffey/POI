using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Poi.Data.Entities
{
    public class PointOfInterest
    {
        [Required, Key]
        public Guid Id { get; set; }
        [Required, MaxLength(256)]
        public string Name { get; set; }
        [Required, MaxLength(256)]
        public string Description { get; set; }
        public virtual City City { get; set; }

    }
}
