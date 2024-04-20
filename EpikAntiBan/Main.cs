using BepInEx;
using BepInEx.Logging;

namespace EpikAntiBan
{
    [BepInPlugin("crafterbot.gorillatag.epikantiban", "EpikAntiBan", "1.0.0")]
    public class Main : BaseUnityPlugin
    {
        public static ManualLogSource Logger;

        private void Start()
        {
            Logger = base.Logger;
            HarmonyLib.Harmony.CreateAndPatchAll(typeof(Main).Assembly);
        }
    }
}