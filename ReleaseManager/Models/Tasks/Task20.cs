namespace ReleaseManager.Models.Tasks;

public class Task20 : ReleaseTask
{
    public Task20()
    {
        Id = Guid.NewGuid();
        Name = "Task 20";
        LinkKey = "task20";
        NbDaysBeforeRelease = -1;
        IsDone = false;
    }
}
