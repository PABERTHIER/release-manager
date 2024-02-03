namespace ReleaseManager.Models.Tasks;

public class Task19 : ReleaseTask
{
    public Task19()
    {
        Id = Guid.NewGuid();
        Name = "Task 19";
        LinkKey = "task19";
        NbDaysBeforeRelease = -1;
        IsDone = false;
    }
}
