namespace ReleaseManager.Models.Tasks;

public class Task21 : ReleaseTask
{
    public Task21()
    {
        Id = Guid.NewGuid();
        Name = "Task 21";
        LinkKey = "task21";
        NbDaysBeforeRelease = -1;
        IsDone = false;
    }
}
