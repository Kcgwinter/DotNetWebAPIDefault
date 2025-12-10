using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetWebAPIDefault.Interfaces;
using DotNetWebAPIDefault.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace DotNetWebAPIDefault.Controllers
{
    public class StorageController(IStorageRepository storageRepository) : BaseApiController
    {
        private readonly IStorageRepository _storageRepository = storageRepository;

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var storages = await _storageRepository.GetAllAsync();
            return Ok(storages);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult> GetById([FromRoute] Guid id)
        {
            var storage = await _storageRepository.GetByIdAsync(id);
            if (storage == null) return NotFound();

            return Ok(storage.toStorageDto());

        }

    }
}