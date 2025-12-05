using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetWebAPIDefault.Data;
using DotNetWebAPIDefault.Interfaces;
using DotNetWebAPIDefault.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetWebAPIDefault.Repository
{
    public class StorageRepository(AppDBContext context) : IStorageRepository
    {
        private readonly AppDBContext _context = context;

        public async Task<List<Storage>> GetAllAsync()
        {
            return await _context.Storages.ToListAsync();
        }

        public async Task<Storage>? GetByIdAsync(Guid id)
        {
            return await _context.Storages.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}