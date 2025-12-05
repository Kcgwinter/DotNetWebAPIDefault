using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetWebAPIDefault.Models;

namespace DotNetWebAPIDefault.Interfaces
{
    public interface IStorageRepository
    {
        Task<List<Storage>> GetAllAsync();
        Task<Storage>? GetByIdAsync(Guid id);
    }
}