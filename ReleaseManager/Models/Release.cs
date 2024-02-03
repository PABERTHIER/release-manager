namespace ReleaseManager.Models;

public class Release
{
    public Guid? Id { get; set; }
    public string? Name { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public IEnumerable<ReleaseTask>? Tasks { get; set; }
}

public class ReleaseName
{
    public Guid? Id { get; set; }
    public string? Name { get; set; }
}
