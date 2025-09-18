﻿using System;
using LabApi.Features;
using LabApi.Features.Console;
using LabApi.Loader;
using LabApi.Loader.Features.Plugins;
using LabApi.Loader.Features.Plugins.Enums;

namespace ZeitvertreibSettingsHeader;

// ReSharper disable once ClassNeverInstantiated.Global
public class Plugin : Plugin<Config>
{
    public override string Name { get; } = "ZeitvertreibSettingsHeader";

    public override string Description { get; } =
        "ZeitvertreibSettingsHeader";

    public override string Author { get; } = "AlexInABox";
    public override Version Version { get; } = new(1, 0, 0);
    public override Version RequiredApiVersion { get; } = new(LabApiProperties.CompiledVersion);

    public override LoadPriority Priority { get; } =
        LoadPriority.Highest; //just to ensure that out ssss is on top at all times

    public Translation Translation { get; private set; }

    public static Plugin Instance { get; private set; }

    public override void Enable()
    {
        Instance = this;
        if (Config == null)
        {
            Logger.Error("There is an error while loading the config. Reverting to the default one.");
            Config = new Config();
        }

        if (!this.TryLoadConfig("translation.yml", out Translation translation))
        {
            Logger.Error("There is an error while loading translation. Using default one.");
            translation = new Translation();
        }

        Translation = translation;
        EventHandlers.RegisterEvents();
    }

    public override void Disable()
    {
        EventHandlers.UnregisterEvents();
    }
}