using TMPro;
using UserSettings.ServerSpecific;

namespace ZeitvertreibSettingsHeader;

public static class Utils
{
    /// <summary>
    ///     Registers the SSSS for the plugin based on values in the config and translation files, by combining the existing
    ///     settings with the new ones.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public static void RegisterSSSS()
    {
        ServerSpecificSettingBase[] extra =
        [
            new SSTextArea(Plugin.Instance.Config!.Id,
                "Das ist Zeitvertreib! Hier ist dein Login link für unsere Website:",
                SSTextArea.FoldoutMode.NotCollapsable, null, TextAlignmentOptions.Center)
        ];

        var existing = ServerSpecificSettingsSync.DefinedSettings ?? [];

        var combined = new ServerSpecificSettingBase[existing.Length + extra.Length];
        existing.CopyTo(combined, 0);
        extra.CopyTo(combined, existing.Length);

        ServerSpecificSettingsSync.DefinedSettings = combined;
        ServerSpecificSettingsSync.UpdateDefinedSettings();
    }
}