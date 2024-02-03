namespace ReleaseManager.Services;

public interface IReleaseService
{
    Release GetReleaseById(Guid id);
    List<ReleaseName> GetReleasesName();
    Release CreateRelease(Release release);
    ReleaseTaskInfo UpdateTask(ReleaseTaskInfo taskInfo);
}
