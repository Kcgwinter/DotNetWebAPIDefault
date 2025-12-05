using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetWebAPIDefault.Models
{
    public class Storage
    {
        [Key]
        public Guid Id { get; set; } = new Guid();
        public required string Name { get; set; }
        public required string Line1 { get; set; }
        public string? Line2 { get; set; }
        public required string City { get; set; }
        public required string Zip { get; set; }
        public required string Country { get; set; }

    }

}