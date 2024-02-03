namespace ReleaseManager.Models.Tasks;

public class Task15 : ReleaseTask
{
    public Task15()
    {
        Id = Guid.NewGuid();
        Name = "Task 15";
        LinkKey = "task15";
        NbDaysBeforeRelease = 0;
        IsDone = false;
    }
}
