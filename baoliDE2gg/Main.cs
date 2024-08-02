using System;
using System.IO;
using System.Reflection;
using HarmonyLib;
using UnityModManagerNet;
using UnityEngine;

namespace baoli_DE2gg
{
	[EnableReloading]
	public static class Main
	{
		private static UnityModManager.ModEntry MyModEntry;
		public static Settings MySettings { get; private set; }

		public static GameObject DE2_laliPrefab;

		private static bool Load(UnityModManager.ModEntry modEntry)
		{
			Harmony harmony = null;

			try                                                                                                                                                                                   
			{
				MyModEntry = modEntry;
				MySettings = UnityModManager.ModSettings.Load<Settings>(MyModEntry);

				MyModEntry.OnGUI = entry => MySettings.Draw(entry);
				MyModEntry.OnSaveGUI = entry => MySettings.Save(entry);

				string assetPath = Path.Combine(MyModEntry.Path, "assetbundles\\");

				var bundle = AssetBundle.LoadFromFile(Path.Combine(assetPath, "DE2922001G"));
				DE2_laliPrefab = bundle.LoadAsset<GameObject>("Assets/Prefab/De2_922_001_G.prefab");
				bundle.Unload(false);

				harmony = new Harmony(MyModEntry.Info.Id);
				harmony.PatchAll(Assembly.GetExecutingAssembly());
			}
			catch (Exception ex)
			{
				MyModEntry.Logger.LogException($"Failed to load {MyModEntry.Info.DisplayName}:", ex);
				harmony?.UnpatchAll(MyModEntry.Info.Id);
				return false;
			}

			return true;
		}

		// Logger Commands
		public static void Log(string message)
		{
			MyModEntry.Logger.Log(message);
		}

		public static void Warning(string message)
		{
			MyModEntry.Logger.Warning(message);
		}

		public static void Error(string message)
		{
			MyModEntry.Logger.Error(message);
		}
	}
}
