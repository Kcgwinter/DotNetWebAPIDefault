using System;

namespace DotNetWebAPIDefault.DTOs.Account;

public class CreateUserDto
{
public string Username { get; set; }
public string Email { get; set; }
public string Token { get; set; }
}
