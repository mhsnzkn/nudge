using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Cart : IEntity
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public int? RamId { get; set; }
        public Configuration Ram { get; set; }
        public int? DiskId { get; set; }
        public Configuration Disk { get; set; }
        public int? ColourId { get; set; }
        public Configuration Colour { get; set; }
        public string UserId { get; set; }
    }
}
