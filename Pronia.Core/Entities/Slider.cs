using Pronia.Core.Interface;

namespace Pronia.Core.Entities;

public class Slider : IEntity
{
    public int Id { get; set; }
    public string Offer { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string ImagePath { get; set; } = null!;
}
