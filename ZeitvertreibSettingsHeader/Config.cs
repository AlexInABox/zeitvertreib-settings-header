using System.ComponentModel;

namespace ZeitvertreibSettingsHeader;

public class Config
{
    public bool Debug { get; set; } = false;

    [Description("The ID of the keybind setting. This should be unique for each plugin.")]
    public int Id { get; set; } = 300;
}