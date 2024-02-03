namespace ReleaseManager.Models.Tasks;

public class Task11 : ReleaseTask
{
    public Task11(DateTime? deliveryDate = null)
    {
        Id = Guid.NewGuid();
        Name = "Task 11";
        LinkKey = "task11";
        NbDaysBeforeRelease = DeliveryDateHelper.GetNbDaysBeforeRelease(deliveryDate);
        IsDone = false;
    }
}
