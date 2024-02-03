namespace ReleaseManager.Models.Tasks;

public class Task2 : ReleaseTask
{
    public Task2()
    {
        Id = Guid.NewGuid();
        Name = "Task 2";
        LinkKey = "task2";
        NbDaysBeforeRelease = 21;
        IsDone = false;
    }
}
