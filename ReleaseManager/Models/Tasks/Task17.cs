namespace ReleaseManager.Models.Tasks;

public class Task17 : ReleaseTask
{
    public Task17()
    {
        Id = Guid.NewGuid();
        Name = "Task 17";
        LinkKey = "task17";
        NbDaysBeforeRelease = 0;
        IsDone = false;
    }
}   
