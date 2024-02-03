namespace ReleaseManager.Models.Tasks;

public class Task6 : ReleaseTask
{
    public Task6()
    {
        Id = Guid.NewGuid();
        Name = "Task 6";
        LinkKey = "task6";
        NbDaysBeforeRelease = 7;
        IsDone = false;
    }
}
