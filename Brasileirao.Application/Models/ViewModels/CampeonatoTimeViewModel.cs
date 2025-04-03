namespace Brasileirao.Application.Models.ViewModels;

public class CampeonatoTimeViewModel
{
    public Guid Id { get; set; }
    public Guid CampeonatoId { get; set; }
    public Guid TimeId { get; set; }

    public CampeonatoTimeViewModel(Guid id, Guid campeonatoId, Guid timeId)
    {
        Id = id;
        CampeonatoId = campeonatoId;
        TimeId = timeId;
    }
}