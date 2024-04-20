using BepInEx.Logging;
using EpikAntiBan.Panels;
using HarmonyLib;
using UnityEngine;
using UniverseLib.UI;

namespace EpikAntiBan.Patches
{
    [HarmonyPatch(typeof(GorillaTagger), "Start")]
    public static class GorillaTaggerPatch
    {
        private static ManualLogSource logSource;

        public static UIBase GUIBase;
        public static RoomInfoPanel RoomInfoPanel;

        private static void Postfix(GorillaTagger __instance)
        {
            logSource = new ManualLogSource("UniverseLib");
            UniverseLib.Universe.Init(() =>
            {
                GUIBase = UniversalUI.RegisterUI("crafterbot.epikantiban", () => { });
                RoomInfoPanel = new RoomInfoPanel(GUIBase);
                new GameObject("Callbacks").AddComponent<PunCallbacks>();
            }, (message, logLevel) =>
            {
                LogLevel bepInExLevel = (logLevel) switch
                {
                    LogType.Log => LogLevel.Info,
                    LogType.Warning => LogLevel.Warning,
                    LogType.Error => LogLevel.Error,
                    LogType.Exception => LogLevel.Fatal,
                    _ => LogLevel.Debug,
                };
                logSource.Log(bepInExLevel, message);
            });
        }
    }
}
