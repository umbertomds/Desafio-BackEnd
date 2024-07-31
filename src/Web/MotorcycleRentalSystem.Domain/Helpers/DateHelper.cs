namespace MotorcycleRentalSystem.Domain.Helpers;
public static class DateUtcHelper
{
    public static DateTime Today() =>
        new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0, DateTimeKind.Utc);

    public static DateTime MinValue() => new DateTime(0, DateTimeKind.Utc);

}
