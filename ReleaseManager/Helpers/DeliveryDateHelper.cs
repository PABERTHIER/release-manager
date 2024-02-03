namespace ReleaseManager.Helpers
{
    public static class DeliveryDateHelper
    {
        public static int GetNbDaysBeforeRelease(DateTime? deliveryDate = null)
        {
            if (deliveryDate != null)
            {
                DateTime deadLineDate = GetDeadLineDate(deliveryDate.Value, DayOfWeek.Thursday);
                return GetNewNbDaysBeforeRelease(deliveryDate.Value, deadLineDate);
            }

            return 5;
        }

        private static DateTime GetDeadLineDate(DateTime deliveryDate, DayOfWeek demandDay)
        {
            int diff = deliveryDate.DayOfWeek - demandDay;

            if (diff < 0)
            {
                diff += 7;
            }

            return deliveryDate.AddDays(-1 * diff).Date;
        }

        private static int GetNewNbDaysBeforeRelease(DateTime deliveryDate, DateTime deadline)
        {
            return (deliveryDate - deadline).Days;
        }
    }
}
