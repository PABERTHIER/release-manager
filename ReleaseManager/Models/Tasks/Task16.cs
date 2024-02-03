namespace ReleaseManager.Models.Tasks;

public class Task16 : ReleaseTask
{
    public Task16()
    {
        Id = Guid.NewGuid();
        Name = "Task 16";
        LinkKey = "task16";
        NbDaysBeforeRelease = 0;
        IsDone = false;
    }
}
