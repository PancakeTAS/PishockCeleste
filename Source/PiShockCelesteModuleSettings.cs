using System;
using System.Collections.Generic;
using IL.Celeste;
using IL.Celeste.Mod.UI;
using IL.Monocle;

namespace Celeste.Mod.PiShockCeleste;


public class PiShockCelesteModuleSettings : EverestModuleSettings {

    // enable

    public bool EnableIntegration { get; set; } = false;

    // intensity

    [SettingRange(0, 100)]
    public int ShockIntensity { get; set; } = 20;

    // duration

    public float ShockDuration { get; set; } = 0.3f;

    private static readonly float[] ShockDurationValues = { 0.1f, 0.3f, 1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f };

    public void CreateShockDurationEntry(TextMenu menu, bool inGame) {
        var slider = new TextMenu.Option<float>("Shock Duration");
        foreach (var duration in ShockDurationValues)
            slider.Add(duration.ToString(), duration, duration == ShockDuration);
        menu.Add(slider);
    }

    // api

    [SettingMaxLength(96)]
    public string User { get; set; } = "";

    [SettingMaxLength(36)]
    public string ApiKey { get; set; } = "";

    [SettingMaxLength(16)]
    public string Code { get; set; } = "";

}