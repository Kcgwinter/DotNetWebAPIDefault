using System;
using DotNetWebAPIDefault.Models;

namespace DotNetWebAPIDefault.Interfaces;

public interface ITokenService
{
    string CreateToken(AppUser user);
}
