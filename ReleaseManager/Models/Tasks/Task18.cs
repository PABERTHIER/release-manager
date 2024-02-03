namespace ReleaseManager.Models.Tasks;

public class Task18 : ReleaseTask
{
    public Task18()
    {
        Id = Guid.NewGuid();
        Name = "Task 18";
        LinkKey = "task18";
        NbDaysBeforeRelease = 0;
        IsDone = false;
    }
}
