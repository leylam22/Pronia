using System.ComponentModel.DataAnnotations;

namespace Pronia.UI.Areas.ProniaAdmin.ViewModels.SliderViewModel;

public class SliderPostVM
{
    [Required,StringLength(50)]
    public string Offer { get; set; } = null!;
    [Required, StringLength(100)]
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    [Required, StringLength(250)]
    public string ImagePath { get; set; } = null!;
}
