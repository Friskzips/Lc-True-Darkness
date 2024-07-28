using GameNetcodeStuff;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;
using Friskzips.clientPatch;
using BepInEx.Configuration;
using LethalConfig.ConfigItems.Options;
using LethalConfig.ConfigItems;
using LethalConfig;

namespace Friskzips
{
    public class LethalConfigCompatibility
    {
        private static bool? _enabled;

        public static bool enabled
        {
            get
            {
                if (_enabled == null)
                {
                    _enabled = BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey("ainavt.lc.lethalconfig");
                }
                return (bool)_enabled;
            }
        }


        internal static void initLethalConfig()
        {
            var IntensitySlider = new FloatSliderConfigItem(TrueDarknessClient.Config.Intensity, new FloatSliderOptions
            {
                RequiresRestart = false,
                Min = 0,
                Max = 366.9317F
            });

            LethalConfigManager.AddConfigItem(IntensitySlider);
            LethalConfigManager.SetModDescription("Do you want to be on the dark but diversity is too much for your modpack? then this is for you!");
        }

    }
}