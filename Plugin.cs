using BepInEx;
using System;
using System.IO;
using UnityEngine;
using Utilla;
namespace llgtag_backend
{
    [ModdedGamemode]
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.6.10")]
    [BepInDependency("com.mrbanana.gorillatag.multigorillainteraction")]
    [ModdedGamemode("llgtag", "LEGACIES", Utilla.Models.BaseGamemode.Infection)]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        public static void customLogger(string logMessage, TextWriter w)
        {
            w.Write("\r\nLog Entry : ");
            w.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
            w.WriteLine("  |");
            w.WriteLine($"  :{logMessage}");
            w.WriteLine("__________________________________");
        }
        void Start()
        {
            using (StreamWriter w = File.AppendText("lorienlegaciesmod.log"))
            {
                customLogger("Lorien Legacies Gamemode Initalized", w);
            }
            Utilla.Events.GameInitialized += OnGameInitialized;
        }
    }
}