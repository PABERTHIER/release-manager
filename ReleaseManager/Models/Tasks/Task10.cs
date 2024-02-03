namespace ReleaseManager.Models.Tasks;

public class Task10 : ReleaseTask
{
    public Task10(DateTime? deliveryDate = null)
    {
        Id = Guid.NewGuid();
        Name = "Task 10";
        LinkKey = "task10";
        NbDaysBeforeRelease = DeliveryDateHelper.GetNbDaysBeforeRelease(deliveryDate);
        IsDone = false;
    }
}
