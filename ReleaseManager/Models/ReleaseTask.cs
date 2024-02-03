namespace ReleaseManager.Models;

public class ReleaseTask
{
    public Guid? Id { get; set; }
    public string? Name { get; set; }
    public string? LinkKey { get; set; }
    public bool? IsDone { get; set; }
    public int? NbDaysBeforeRelease { get; set; }
}
