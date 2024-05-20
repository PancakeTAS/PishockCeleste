using System;
using IL.Celeste.Mod;

namespace Celeste.Mod.PiShockCeleste;

public class PiShockCelesteModule : EverestModule {

    public static PiShockCelesteModule Instance { get; private set; }

    public override Type SettingsType => typeof(PiShockCelesteModuleSettings);
    public static PiShockCelesteModuleSettings Settings => (PiShockCelesteModuleSettings) Instance._Settings;
    public static PiShockCelesteModuleApi Api => new PiShockCelesteModuleApi();

    public PiShockCelesteModule() {
        Instance = this;
        Logger.SetLogLevel(nameof(PiShockCelesteModule), LogLevel.Info);
    }

    // load and unload the module

    public override void Load() {
        Everest.Events.Player.OnDie += OnDie;
        Everest.Events.Level.OnPause += OnPause;
        Everest.Events.Level.OnUnpause += OnUnpause;
        Everest.Events.Level.OnEnter += OnEnter;
    }

    public override void Unload() {

    }

    // check if the shock is active

    public static bool IsActive { get; private set; }

    private void OnPause(Level level, int startIndex, bool minimal, bool quickReset) {
        if (quickReset)
            return;

        Logger.Log(LogLevel.Info, "PiShockCelesteModule", "PiShock paused");
        IsActive = false;
    }

    private void OnUnpause(Level level) {
        Logger.Log(LogLevel.Info, "PiShockCelesteModule", "PiShock unpaused");
        IsActive = true;
    }

    private void OnEnter(Session session, bool fromSaveData) {
        Logger.Log(LogLevel.Info, "PiShockCelesteModule", "PiShock unpaused");
        IsActive = true;
    }

    // do the shock

    private void OnDie(Player player) {
        if (!IsActive)
            return;

        if (!Settings.EnableIntegration)
            return;

        if (Settings.ShockIntensity <= 0 || Settings.ShockIntensity > 100) {
            Logger.Log(LogLevel.Warn, "PiShockCelesteModule", "Invalid shock intensity: " + Settings.ShockIntensity);
            return;
        }

        if ((Settings.ShockDuration < 1 && Settings.ShockDuration != 0.1f && Settings.ShockDuration != 0.3f)
            || (Settings.ShockDuration > 15)) {
            Logger.Log(LogLevel.Warn, "PiShockCelesteModule", "Invalid shock duration: " + Settings.ShockDuration);
            return;
        }

        try {
            Logger.Log(LogLevel.Info, "PiShockCelesteModule", "Executing shock with intensity " + Settings.ShockIntensity + " and duration " + Settings.ShockDuration);
            Api.Execute(Settings.User, Settings.ApiKey, Settings.Code, Settings.ShockIntensity, Settings.ShockDuration);
        } catch (Exception e) {
            Logger.Log(LogLevel.Error, "PiShockCelesteModule", "Failed to execute shock: " + e);
        }
    }

}