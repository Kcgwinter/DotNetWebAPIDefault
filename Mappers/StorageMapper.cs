using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetWebAPIDefault.DTOs.Storage;
using DotNetWebAPIDefault.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace DotNetWebAPIDefault.Mappers
{
    public static class StorageMapper
    {
        public static StorageDto toStorageDto(this Storage storageModel)
        {
            return new StorageDto
            {
                Name = storageModel.Name,
                Line1 = storageModel.Line1,
                Line2 = storageModel.Line2,
                City = storageModel.City,
                Country = storageModel.Country,
                Zip = storageModel.Zip
            };
        }

        public static Storage toStorageFromCreate(this CreateStorageDto storageDto)
        {

            return new Storage
            {
                Name = storageDto.Name,
                Line1 = storageDto.Line1,
                Line2 = storageDto.Line2,
                City = storageDto.City,
                Country = storageDto.Country,
                Zip = storageDto.Zip
            };
        }

        public static Storage toStorageFromUpdate(this UpdateStorageDto storageDto)
        {

            return new Storage
            {
                Id = storageDto.Id,
                Name = storageDto.Name,
                Line1 = storageDto.Line1,
                Line2 = storageDto.Line2,
                City = storageDto.City,
                Country = storageDto.Country,
                Zip = storageDto.Zip
            };
        }

    }
}