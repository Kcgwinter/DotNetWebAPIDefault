using System;
using System.ComponentModel.DataAnnotations;

namespace DotNetWebAPIDefault.DTOs.Account;

public class CreateUserDto
{
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string Token { get; set; }
}
