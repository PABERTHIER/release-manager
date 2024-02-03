namespace ReleaseManager.Models.Tasks;

public class Task22 : ReleaseTask
{
    public Task22()
    {
        Id = Guid.NewGuid();
        Name = "Task 22";
        LinkKey = "task22";
        NbDaysBeforeRelease = -1;
        IsDone = false;
    }
}
