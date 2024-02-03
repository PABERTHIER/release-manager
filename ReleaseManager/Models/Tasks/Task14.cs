namespace ReleaseManager.Models.Tasks;

public class Task14 : ReleaseTask
{
    public Task14()
    {
        Id = Guid.NewGuid();
        Name = "Task 14";
        LinkKey = "task14";
        NbDaysBeforeRelease = 0;
        IsDone = false;
    }
}
