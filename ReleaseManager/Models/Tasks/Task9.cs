namespace ReleaseManager.Models.Tasks;

public class Task9 : ReleaseTask
{
    public Task9(DateTime? deliveryDate = null)
    {
        Id = Guid.NewGuid();
        Name = "Task 9";
        LinkKey = "task9";
        NbDaysBeforeRelease = DeliveryDateHelper.GetNbDaysBeforeRelease(deliveryDate);
        IsDone = false;
    }
}
