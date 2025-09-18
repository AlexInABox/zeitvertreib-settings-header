using LabApi.Events.Handlers;

namespace ZeitvertreibSettingsHeader;

public static class EventHandlers
{
    public static void RegisterEvents()
    {
        PlayerEvents.Joined += Utils.SendHeaderToPlayer;
        //Utils.RegisterSSSS();
    }

    public static void UnregisterEvents()
    {
    }
}