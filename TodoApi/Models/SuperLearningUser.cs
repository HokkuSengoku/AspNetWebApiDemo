using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models;

public class SuperLearningUser
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Role { get; set; }
}