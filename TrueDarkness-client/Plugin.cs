using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using Friskzips.clientPatch;
using Friskzips.service;
using Friskzips.configStuff;

namespace Friskzips;

[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
[BepInDependency("ainavt.lc.lethalconfig", BepInDependency.DependencyFlags.SoftDependency)]
public class TrueDarknessClient : BaseUnityPlugin
{
    public static TrueDarknessClient Instance { get; set; }

    public static ManualLogSource Log => Instance.Logger;

    private readonly Harmony _harmony = new(PluginInfo.PLUGIN_GUID);

    public FriskzipsService Service;

    internal static bool nightVision = true;

    public TrueDarknessClient()
    {
        Instance = this;
    }

    internal static new Config Config;
    private void Awake()
    {
        Config = new Config(base.Config);
        Service = new FriskzipsService();

        Log.LogInfo($"Applying patches...");
        ApplyPluginPatch();
        Log.LogInfo($"Patches applied");
    }

    /// <summary>
    /// Applies the patch to the game.
    /// </summary>
    private void ApplyPluginPatch()
    {
        _harmony.PatchAll(typeof(NightVisionOverrideClient));

        if (LethalConfigCompatibility.enabled)
        {
            Log.LogInfo($"LethalConfig found!");
            LethalConfigCompatibility.initLethalConfig();

        }
    }
}
