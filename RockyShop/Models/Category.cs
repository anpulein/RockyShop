using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RockyShop.Models;

public class Category
{
    [Key]
    public int Id { get; set; }
    [Required] // Обязательно заполнения поля
    public string Name { get; set; }
    [DisplayName("Display Order")]
    [Required] // Обязательно заполнения поля
    [Range(1, Int32.MaxValue, ErrorMessage = "Display order for category must be greater than 0")]
    public int DisplayOrder { get; set; }
}