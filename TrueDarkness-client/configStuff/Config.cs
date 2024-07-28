using BepInEx.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine.Rendering;
using UnityEngine;

namespace Friskzips.configStuff
{
    public class Config
    {
        public ConfigEntry<float> Intensity  { get; private set; }

        
        
        public Config(ConfigFile cfg)
        {
            Intensity = cfg.Bind(
            new ConfigDefinition("Night vision", "Intensity"),
            0.0f,           
            new ConfigDescription("The lower the less you see, the higher the more you see.\nVanilla value: 366,9317")
            );
        }
    }
}
