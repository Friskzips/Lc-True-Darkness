
using Friskzips;
using GameNetcodeStuff;
using HarmonyLib;
using Microsoft.Cci.Pdb;

namespace Friskzips.clientPatch;


//Patch to modify the behavior of a player.

[HarmonyPatch(typeof(PlayerControllerB))]
public class NightVisionOverrideClient
{
    
    [HarmonyPatch("SetNightVisionEnabled")]
    [HarmonyPostfix]
    private static void OnNightVisionEnabled(ref PlayerControllerB __instance)
    {
        if (__instance.nightVision.enabled==true && TrueDarknessClient.nightVision==true)
        {
            if(TrueDarknessClient.Config.Intensity.Value>366.9318)
            {
                TrueDarknessClient.Log.LogError($"Your value is larger than the vanilla one\n");
                TrueDarknessClient.Log.LogError($"Sorry but i don't like cheating");
                TrueDarknessClient.Log.LogError($"If you want an higher value use the normal version of the mod");
                TrueDarknessClient.Config.Intensity.Value = 366.9317F;
            }
            if (TrueDarknessClient.Config.Intensity.Value < 0)
            {
                TrueDarknessClient.Log.LogError($"I don't think that this value would work so im setting it to 0\n");
                TrueDarknessClient.Config.Intensity.Value = 0;
            }

            __instance.nightVision.intensity = TrueDarknessClient.Config.Intensity.Value;
            //Plugin.Log.LogInfo($"NightVision enabled intensity: " + __instance.nightVision.intensity);
        }

        if (__instance.nightVision.enabled == false && TrueDarknessClient.nightVision == false)
        {
            TrueDarknessClient.nightVision = true;
        }



    }   
}
