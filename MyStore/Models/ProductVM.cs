using Microsoft.AspNetCore.Mvc.Rendering;
using MyStore.Entities;
using System.ComponentModel.DataAnnotations;

namespace MyStore.Models;

public class ProductVM
{
    public int ProductId { get; set; }

    public CategoryVM Category { get; set; }

    public List<SelectListItem> Categories { get; set; }

    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public decimal Price { get; set; }
    [Required]
    public int Stock { get; set; }

    public String? ImagenName { get; set; } = null;

    public IFormFile? ImageFile { get; set; }
}
