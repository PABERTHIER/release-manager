namespace ReleaseManager.Models.Tasks;

public class Task13 : ReleaseTask
{
    public Task13()
    {
        Id = Guid.NewGuid();
        Name = "Task 13";
        LinkKey = "task13";
        NbDaysBeforeRelease = 0;
        IsDone = false;
    }
}
