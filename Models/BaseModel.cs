using System;
using System.ComponentModel.DataAnnotations;

namespace DotNetWebAPIDefault.Models;

public class BaseModel
{
    [Key]
    public int Id { get; set; }
    public DateTime Created_at { get; set; } = DateTime.Now;
    public DateTime Updated_at { get; set; } = DateTime.Now;

}
