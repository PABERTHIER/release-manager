namespace ReleaseManager.Models.Tasks;

public class Task8 : ReleaseTask
{
    public Task8()
    {
        Id = Guid.NewGuid();
        Name = "Task 8";
        LinkKey = "task8";
        NbDaysBeforeRelease = 7;
        IsDone = false;
    }
}
