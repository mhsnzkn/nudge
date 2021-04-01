using Entities.Abstract;
using Entities.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Configuration : IEntity
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public ConfigurationType Type { get; set; }
        public decimal Price { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
