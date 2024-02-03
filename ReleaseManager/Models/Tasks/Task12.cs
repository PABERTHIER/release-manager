namespace ReleaseManager.Models.Tasks;

public class Task12 : ReleaseTask
{
    public Task12()
    {
        Id = Guid.NewGuid();
        Name = "Task 12";
        LinkKey = "task12";
        NbDaysBeforeRelease = 0;
        IsDone = false;
    }
}
