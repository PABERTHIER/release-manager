namespace ReleaseManager.Models;

public class ReleaseTaskInfo
{
    public Guid ReleaseId { get; set; }
    public ReleaseTask? Task { get; set; }
}
