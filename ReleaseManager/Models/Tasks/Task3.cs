namespace ReleaseManager.Models.Tasks;

public class Task3 : ReleaseTask
{
    public Task3()
    {
        Id = Guid.NewGuid();
        Name = "Task 3";
        LinkKey = "task3";
        NbDaysBeforeRelease = 21;
        IsDone = false;
    }
}
