namespace ReleaseManager.Models.Tasks;

public class Task5 : ReleaseTask
{
    public Task5()
    {
        Id = Guid.NewGuid();
        Name = "Task 5";
        LinkKey = "task5";
        NbDaysBeforeRelease = 7;
        IsDone = false;
    }
}
