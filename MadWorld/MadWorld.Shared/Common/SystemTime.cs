namespace MadWorld.Shared.Common;

public static class SystemTime
{
    public static Func<DateTime> Now { get; private set; } = () => DateTime.Now;

    /// <summary> Set time to return when SystemTime.Now() is called.
    /// </summary>
    public static void SetDateTime(DateTime dateTimeNow)
    {
        Now = () => dateTimeNow;
    }

    /// <summary> Resets SystemTime.Now() to return DateTime.Now.
    /// </summary>
    public static void ResetDateTime()
    {
        Now = () => DateTime.Now;
    }
}