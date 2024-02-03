namespace ReleaseManager.Models.Tasks;

public class Task7 : ReleaseTask
{
    public Task7()
    {
        Id = Guid.NewGuid();
        Name = "Task 7";
        LinkKey = "task7";
        NbDaysBeforeRelease = 7;
        IsDone = false;
    }
}
