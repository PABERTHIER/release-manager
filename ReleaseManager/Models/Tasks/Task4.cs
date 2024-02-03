namespace ReleaseManager.Models.Tasks;

public class Task4 : ReleaseTask
{
    public Task4()
    {
        Id = Guid.NewGuid();
        Name = "Task 4";
        LinkKey = "task4";
        NbDaysBeforeRelease = 7;
        IsDone = false;
    }
}
