using System;
using System.ComponentModel;
using UnityEngine;
using UnityModManagerNet;

namespace baoli_DE2gg
{
	public class Settings : UnityModManager.ModSettings
	{
		public enum DE2GZlaliType
		{
			[Description("Default")]
			None,

			[Description("DE2-922-001-G")]
			Chinese,
		}

		public DE2GZlaliType DE2GZlaliAType = DE2GZlaliType.Chinese;

		public void Draw(UnityModManager.ModEntry modEntry)
		{
			// GUILayout.BeginVertical();

			GUILayout.Label("DE2-922-001-G");
			GUILayout.Label("用於DE2的SBB CFF FFS的外觀改裝");

			// GUILayout.Space(2f);

			GUILayout.Label("改裝件");
			DE2GZlaliAType = (DE2GZlaliType)GUILayout.SelectionGrid((int)DE2GZlaliAType, Enum.GetNames(typeof(DE2GZlaliType)), 1, "toggle");
			//
			// GUILayout.EndVertical();
		}

		public override void Save(UnityModManager.ModEntry modEntry)
		{
			Save(this, modEntry);
		}
	}
}
