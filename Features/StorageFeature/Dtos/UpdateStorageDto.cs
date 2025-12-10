using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetWebAPIDefault.DTOs.Storage
{
    public class UpdateStorageDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Line1 { get; set; }
        public required string Line2 { get; set; }
        public required string City { get; set; }
        public required string Zip { get; set; }
        public required string Country { get; set; }
    }
}