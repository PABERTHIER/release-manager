namespace ReleaseManager.Models.Tasks;

public class Task1 : ReleaseTask
{
    public Task1()
    {
        Id = Guid.NewGuid();
        Name = "Task 1";
        LinkKey = "task1";
        NbDaysBeforeRelease = 21;
        IsDone = false;
    }
}
